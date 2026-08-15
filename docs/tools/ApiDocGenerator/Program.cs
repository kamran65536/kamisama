using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

var repoRoot = FindRepoRoot(AppContext.BaseDirectory);
var srcRoot = Path.Combine(repoRoot, "src");
var docsRoot = Path.Combine(repoRoot, "docs");
var contentRoot = Path.Combine(docsRoot, "content");
var solutionPath = Path.Combine(srcRoot, "kamisama.slnx");
var dryRun = args.Any(x => x.Equals("--dry-run", StringComparison.OrdinalIgnoreCase));
var rootVersion = RootVersion(Path.Combine(srcRoot, "props.xml"));
var docsVersion = DocsVersion(rootVersion);

if (!File.Exists(solutionPath))
{
    throw new FileNotFoundException("Cannot find solution file.", solutionPath);
}

var exampleProvider = new ExampleProvider(srcRoot);
var allProjects = LoadProjects(solutionPath, srcRoot);
var projects = allProjects
    .Where(p => !IsExcludedProject(p))
    .OrderBy(p => p.Group)
    .ThenBy(p => p.Name)
    .ToList();

var api = projects
    .Select(project => BuildLibraryDocs(project, repoRoot, exampleProvider))
    .Where(library => library.Types.Count > 0)
    .ToList();

if (dryRun)
{
    Console.WriteLine("Included projects:");
    foreach (var library in api)
    {
        Console.WriteLine($"- {library.Name} ({library.Types.Count} types, {library.Types.Sum(t => t.Members.Count)} member pages)");
    }

    Console.WriteLine();
    Console.WriteLine("Excluded projects:");
    foreach (var project in allProjects.Where(IsExcludedProject))
    {
        Console.WriteLine($"- {project.Name}");
    }

    return;
}

var snapshots = Directory.Exists(contentRoot)
    ? Directory.EnumerateFiles(contentRoot, "doc-snapshot.md", SearchOption.AllDirectories)
        .ToDictionary(path => Path.GetRelativePath(contentRoot, path), File.ReadAllText)
    : [];

if (Directory.Exists(contentRoot))
{
    Directory.Delete(contentRoot, recursive: true);
}

Directory.CreateDirectory(contentRoot);
Directory.CreateDirectory(Path.Combine(contentRoot, "api"));
Directory.CreateDirectory(Path.Combine(contentRoot, "topics"));
foreach (var snapshot in snapshots)
{
    var target = Path.Combine(contentRoot, snapshot.Key);
    Directory.CreateDirectory(Path.GetDirectoryName(target)!);
    File.WriteAllText(target, snapshot.Value, Encoding.UTF8);
}

WriteOverview(contentRoot, api, docsVersion);
CopyTopicDocs(docsRoot, contentRoot);
WriteApiDocs(contentRoot, api, docsVersion);
WriteMkDocs(docsRoot, api, docsVersion);

Console.WriteLine($"Generated {api.Sum(l => l.Types.Count)} type pages and {api.Sum(l => l.Types.Sum(t => t.Members.Count))} member pages for {api.Count} libraries.");

static string FindRepoRoot(string start)
{
    var directory = new DirectoryInfo(start);
    while (directory is not null)
    {
        if (Directory.Exists(Path.Combine(directory.FullName, ".git")))
        {
            return directory.FullName;
        }

        directory = directory.Parent;
    }

    throw new InvalidOperationException("Could not find repository root.");
}

static string RootVersion(string propsPath)
{
    var xml = XDocument.Load(propsPath);
    var version = xml.Descendants("Version").FirstOrDefault()?.Value.Trim();
    return string.IsNullOrWhiteSpace(version)
        ? throw new InvalidOperationException($"Cannot find Version in {propsPath}.")
        : version;
}

static string DocsVersion(string rootVersion)
{
    var version = Environment.GetEnvironmentVariable("KAMISAMA_DOCS_VERSION");
    return string.IsNullOrWhiteSpace(version) ? rootVersion : version.Trim();
}

static List<ProjectDoc> LoadProjects(string solutionPath, string srcRoot)
{
    var projects = new List<ProjectDoc>();
    var currentGroup = "";
    var folderRegex = new Regex("<Folder\\s+Name=\"(?<name>[^\"]+)\"", RegexOptions.Compiled);
    var projectRegex = new Regex("<Project\\s+Path=\"(?<path>[^\"]+)\"", RegexOptions.Compiled);

    foreach (var line in File.ReadLines(solutionPath))
    {
        var folder = folderRegex.Match(line);
        if (folder.Success)
        {
            currentGroup = folder.Groups["name"].Value.Trim('/').Replace('/', ' ');
        }

        var project = projectRegex.Match(line);
        if (!project.Success)
        {
            continue;
        }

        var relativePath = project.Groups["path"].Value.Replace('/', Path.DirectorySeparatorChar);
        var fullPath = Path.GetFullPath(Path.Combine(srcRoot, relativePath));
        if (!File.Exists(fullPath))
        {
            continue;
        }

        var name = Path.GetFileNameWithoutExtension(fullPath);
        var xml = XDocument.Load(fullPath);
        var outputType = ElementValue(xml, "OutputType");
        var packageType = ElementValue(xml, "PackageType");
        var isPackable = ElementValue(xml, "IsPackable");
        var packageId = ElementValue(xml, "PackageId");
        var description = ElementValue(xml, "Description");
        projects.Add(new ProjectDoc(
            name,
            fullPath,
            currentGroup,
            outputType,
            packageType,
            isPackable,
            string.IsNullOrWhiteSpace(packageId) ? name : packageId,
            NormalizeText(description)));
    }

    return projects;
}

static string ElementValue(XDocument xml, string name) =>
    xml.Descendants(name).FirstOrDefault()?.Value.Trim() ?? "";

static bool IsExcludedProject(ProjectDoc project)
{
    var path = project.Path.Replace('\\', '/');
    if (project.Name.Contains(".Tests", StringComparison.OrdinalIgnoreCase) ||
        project.Name.Equals("Testing.Tests", StringComparison.OrdinalIgnoreCase) ||
        project.Name.Equals("ChassisTestProject", StringComparison.OrdinalIgnoreCase))
    {
        return true;
    }

    if (project.OutputType?.Equals("Exe", StringComparison.OrdinalIgnoreCase) == true)
    {
        return true;
    }

    if (project.PackageType?.Equals("Template", StringComparison.OrdinalIgnoreCase) == true)
    {
        return true;
    }

    return path.Contains("/Templates/content/", StringComparison.OrdinalIgnoreCase);
}

static LibraryDoc BuildLibraryDocs(ProjectDoc project, string repoRoot, ExampleProvider exampleProvider)
{
    var projectDirectory = Path.GetDirectoryName(project.Path)!;
    var files = Directory.EnumerateFiles(projectDirectory, "*.cs", SearchOption.AllDirectories)
        .Where(path => !IsExcludedSource(path))
        .OrderBy(path => path)
        .ToList();

    var types = new List<TypeDoc>();
    foreach (var file in files)
    {
        var text = File.ReadAllText(file);
        var tree = CSharpSyntaxTree.ParseText(text, new CSharpParseOptions(LanguageVersion.Preview), path: file);
        var root = tree.GetCompilationUnitRoot();
        foreach (var typeNode in root.DescendantNodes().Where(IsTypeNode))
        {
            if (!IsVisibleType(typeNode))
            {
                continue;
            }

            var line = tree.GetLineSpan(typeNode.Span).StartLinePosition.Line + 1;
            var namespaceName = GetNamespace(typeNode);
            var typeName = GetTypeName(typeNode);
            var containingTypes = GetContainingTypeNames(typeNode);
            var fullName = string.Join(".", new[] { namespaceName }.Where(x => !string.IsNullOrWhiteSpace(x))
                .Concat(containingTypes)
                .Concat([typeName]));
            var relativeSource = Path.GetRelativePath(repoRoot, file).Replace('\\', '/');
            var docs = GetXmlDocs(typeNode);
            var kind = GetTypeKind(typeNode);
            var typeDescription = CuratedTypeDescription(fullName, typeName);
            if (string.IsNullOrWhiteSpace(typeDescription))
            {
                typeDescription = DeveloperDescription(docs.Summary, TypeFallbackDescription(typeName, kind));
            }

            var type = new TypeDoc(
                project,
                namespaceName.Length == 0 ? "(global namespace)" : namespaceName,
                typeName,
                fullName,
                kind,
                GetSignature(typeNode),
                relativeSource,
                line,
                SourceUrl(relativeSource, line),
                typeDescription,
                docs.Remarks,
                CuratedTypeExample(fullName, typeName));

            type.Constructors.AddRange(GetConstructors(typeNode, tree, relativeSource));
            type.Members.AddRange(GetMembers(typeNode, tree, relativeSource, fullName, typeName, exampleProvider));
            types.Add(type);
        }
    }

    var description = PackageDescription(project);
    return new LibraryDoc(project.Name, project.Group, ProjectSlug(project.Name), project.PackageId, description, types.OrderBy(t => t.Namespace).ThenBy(t => t.FullName).ToList());
}

static bool IsExcludedSource(string path)
{
    var normalized = path.Replace('\\', '/');
    return normalized.Contains("/bin/", StringComparison.OrdinalIgnoreCase) ||
           normalized.Contains("/obj/", StringComparison.OrdinalIgnoreCase) ||
           normalized.Contains("/.vs/", StringComparison.OrdinalIgnoreCase) ||
           normalized.Contains("/TestResults/", StringComparison.OrdinalIgnoreCase) ||
           normalized.Contains("/Migrations/", StringComparison.OrdinalIgnoreCase) ||
           normalized.Contains("/Templates/content/", StringComparison.OrdinalIgnoreCase) ||
           normalized.EndsWith(".g.cs", StringComparison.OrdinalIgnoreCase) ||
           normalized.EndsWith(".Designer.cs", StringComparison.OrdinalIgnoreCase);
}

static bool IsTypeNode(SyntaxNode node) =>
    node is BaseTypeDeclarationSyntax or DelegateDeclarationSyntax;

static bool IsVisibleType(SyntaxNode node)
{
    if (IsExplicitPrivateOnly(node))
    {
        return false;
    }

    var parentType = node.Parent?.AncestorsAndSelf().OfType<BaseTypeDeclarationSyntax>().FirstOrDefault();
    if (parentType is null)
    {
        return HasModifier(node, SyntaxKind.PublicKeyword);
    }

    return HasApiVisibilityModifier(node) || parentType is InterfaceDeclarationSyntax;
}

static bool IsVisibleMember(MemberDeclarationSyntax member, SyntaxNode typeNode)
{
    if (IsExplicitPrivateOnly(member))
    {
        return false;
    }

    if (typeNode is InterfaceDeclarationSyntax)
    {
        return true;
    }

    return HasApiVisibilityModifier(member);
}

static bool HasApiVisibilityModifier(SyntaxNode node) =>
    HasModifier(node, SyntaxKind.PublicKeyword) ||
    HasModifier(node, SyntaxKind.ProtectedKeyword);

static bool IsExplicitPrivateOnly(SyntaxNode node) =>
    HasModifier(node, SyntaxKind.PrivateKeyword) && !HasModifier(node, SyntaxKind.ProtectedKeyword);

static bool HasModifier(SyntaxNode node, SyntaxKind kind) =>
    node switch
    {
        MemberDeclarationSyntax member => member.Modifiers.Any(kind),
        _ => false
    };

static List<ConstructorDoc> GetConstructors(SyntaxNode typeNode, SyntaxTree tree, string relativeSource)
{
    var constructors = new List<ConstructorDoc>();

    if (TryGetPrimaryConstructor(typeNode, out var primaryParameters))
    {
        var docs = GetXmlDocs(typeNode);
        var line = tree.GetLineSpan(typeNode.Span).StartLinePosition.Line + 1;
        constructors.Add(new ConstructorDoc(
            "Primary constructor",
            "Constructor",
            GetSignature(typeNode),
            line,
            SourceUrl(relativeSource, line),
            BuildParameters(primaryParameters!.Parameters, docs),
            DeveloperDescription(docs.Summary, "Initializes the type with the values required by its declaration.")));
    }

    if (typeNode is TypeDeclarationSyntax typeDeclaration)
    {
        foreach (var ctor in typeDeclaration.Members.OfType<ConstructorDeclarationSyntax>())
        {
            if (!IsVisibleMember(ctor, typeNode))
            {
                continue;
            }

            var docs = GetXmlDocs(ctor);
            var line = tree.GetLineSpan(ctor.Span).StartLinePosition.Line + 1;
            constructors.Add(new ConstructorDoc(
                ctor.Identifier.Text,
                "Constructor",
                GetSignature(ctor),
                line,
                SourceUrl(relativeSource, line),
                BuildParameters(ctor.ParameterList.Parameters, docs),
                DeveloperDescription(docs.Summary, $"Initializes a new `{ctor.Identifier.Text}` instance.")));
        }
    }

    return constructors;
}

static bool TryGetPrimaryConstructor(SyntaxNode typeNode, out ParameterListSyntax? parameterList)
{
    parameterList = typeNode switch
    {
        RecordDeclarationSyntax record => record.ParameterList,
        ClassDeclarationSyntax cls => cls.ParameterList,
        StructDeclarationSyntax str => str.ParameterList,
        _ => null
    };

    return parameterList is not null;
}

static List<MemberDoc> GetMembers(SyntaxNode typeNode, SyntaxTree tree, string relativeSource, string typeFullName, string typeName, ExampleProvider exampleProvider)
{
    var members = new List<MemberDoc>();

    if (typeNode is EnumDeclarationSyntax enumType)
    {
        foreach (var enumMember in enumType.Members)
        {
            var docs = GetXmlDocs(enumMember);
            var line = tree.GetLineSpan(enumMember.Span).StartLinePosition.Line + 1;
            var member = new MemberDoc(
                enumMember.Identifier.Text,
                "Enum member",
                "public",
                enumMember.ToString().TrimEnd(','),
                relativeSource,
                line,
                SourceUrl(relativeSource, line),
                DeveloperDescription(docs.Summary, $"Represents the `{enumMember.Identifier.Text}` value of `{typeName}`."),
                docs.Remarks,
                [],
                [],
                "",
                "",
                $"The enum value is used wherever `{typeName}` is accepted.",
                Anchor("enum-member-" + enumMember.Identifier.Text),
                typeFullName,
                MemberFileName("Enum member", enumMember.Identifier.Text, line));
            member.Example = exampleProvider.FindExample(typeFullName, member) ?? "";
            members.Add(member);
        }

        return members;
    }

    var typeMembers = typeNode is TypeDeclarationSyntax type ? type.Members : [];
    foreach (var memberNode in typeMembers)
    {
        if (memberNode is BaseTypeDeclarationSyntax or DelegateDeclarationSyntax or ConstructorDeclarationSyntax)
        {
            continue;
        }

        if (!IsVisibleMember(memberNode, typeNode))
        {
            continue;
        }

        var line = tree.GetLineSpan(memberNode.Span).StartLinePosition.Line + 1;
        var name = GetMemberName(memberNode);
        if (string.IsNullOrWhiteSpace(name))
        {
            continue;
        }

        var docs = GetXmlDocs(memberNode);
        var kind = GetMemberKind(memberNode);
        var description = CuratedMemberDescription(typeFullName, typeName, name, kind);
        if (string.IsNullOrWhiteSpace(description))
        {
            description = DeveloperDescription(docs.Summary, MemberFallbackDescription(typeName, name, kind));
        }

        var member = new MemberDoc(
            name,
            kind,
            GetModifiers(memberNode),
            GetSignature(memberNode),
            relativeSource,
            line,
            SourceUrl(relativeSource, line),
            description,
            docs.Remarks,
            BuildParameters(GetParameters(memberNode), docs),
            BuildTypeParameters(GetTypeParameterList(memberNode), docs),
            GetReturnType(memberNode),
            docs.Returns,
            ValueDescription(memberNode, docs),
            Anchor(kind + "-" + name + "-" + line),
            typeFullName,
            MemberFileName(kind, name, line));
        member.Example = docs.Example;
        if (string.IsNullOrWhiteSpace(member.Example))
        {
            member.Example = BuildFallbackExample(typeFullName, member);
        }

        if (string.IsNullOrWhiteSpace(member.Example))
        {
            member.Example = exampleProvider.FindExample(typeFullName, member) ?? "";
        }

        members.Add(member);
    }

    return members.OrderBy(m => m.Kind).ThenBy(m => m.Name).ThenBy(m => m.Line).ToList();
}

static SeparatedSyntaxList<ParameterSyntax> GetParameters(MemberDeclarationSyntax member) =>
    member switch
    {
        MethodDeclarationSyntax method => method.ParameterList.Parameters,
        IndexerDeclarationSyntax indexer => indexer.ParameterList.Parameters,
        OperatorDeclarationSyntax op => op.ParameterList.Parameters,
        ConversionOperatorDeclarationSyntax op => op.ParameterList.Parameters,
        _ => SyntaxFactory.SeparatedList<ParameterSyntax>()
    };

static TypeParameterListSyntax? GetTypeParameterList(MemberDeclarationSyntax member) =>
    member switch
    {
        MethodDeclarationSyntax method => method.TypeParameterList,
        _ => null
    };

static List<ParameterDoc> BuildParameters(SeparatedSyntaxList<ParameterSyntax> parameters, XmlDoc docs)
{
    var result = new List<ParameterDoc>();
    foreach (var parameter in parameters)
    {
        var name = parameter.Identifier.Text;
        result.Add(new ParameterDoc(
            name,
            parameter.Type?.ToString() ?? "var",
            parameter.Default is null ? "" : parameter.Default.Value.ToString(),
            parameter.Modifiers.Any(SyntaxKind.ThisKeyword),
            parameter.Modifiers.Any(SyntaxKind.OutKeyword),
            parameter.Modifiers.Any(SyntaxKind.RefKeyword),
            docs.Parameters.TryGetValue(name, out var description) && !string.IsNullOrWhiteSpace(description)
                ? description
                : $"The `{name}` value passed to this member."));
    }

    return result;
}

static List<TypeParameterDoc> BuildTypeParameters(TypeParameterListSyntax? typeParameters, XmlDoc docs)
{
    if (typeParameters is null)
    {
        return [];
    }

    return typeParameters.Parameters
        .Select(p => new TypeParameterDoc(
            p.Identifier.Text,
            docs.TypeParameters.TryGetValue(p.Identifier.Text, out var description)
                ? description
                : $"The `{p.Identifier.Text}` generic type argument."))
        .ToList();
}

static string GetReturnType(MemberDeclarationSyntax member) =>
    member switch
    {
        MethodDeclarationSyntax method => method.ReturnType.ToString(),
        OperatorDeclarationSyntax op => op.ReturnType.ToString(),
        ConversionOperatorDeclarationSyntax op => op.Type.ToString(),
        _ => ""
    };

static string ValueDescription(MemberDeclarationSyntax member, XmlDoc docs)
{
    if (!string.IsNullOrWhiteSpace(docs.Value))
    {
        return docs.Value;
    }

    return member switch
    {
        PropertyDeclarationSyntax property => property.AccessorList?.Accessors.Any(a => a.IsKind(SyntaxKind.SetAccessorDeclaration) || a.IsKind(SyntaxKind.InitAccessorDeclaration)) == true
            ? $"Gets or sets a `{property.Type}` value."
            : $"Gets a `{property.Type}` value.",
        IndexerDeclarationSyntax indexer => $"Gets or sets a `{indexer.Type}` value by index.",
        FieldDeclarationSyntax field => $"Stores a `{field.Declaration.Type}` value.",
        EventFieldDeclarationSyntax evt => $"Event handlers use `{evt.Declaration.Type}`.",
        EventDeclarationSyntax evt => $"Event handlers use `{evt.Type}`.",
        _ => ""
    };
}

static string GetNamespace(SyntaxNode node)
{
    var namespaceNode = node.AncestorsAndSelf().OfType<BaseNamespaceDeclarationSyntax>().FirstOrDefault();
    return namespaceNode?.Name.ToString() ?? "";
}

static List<string> GetContainingTypeNames(SyntaxNode node) =>
    node.Ancestors()
        .OfType<BaseTypeDeclarationSyntax>()
        .Reverse()
        .Select(GetTypeName)
        .ToList();

static string GetTypeName(SyntaxNode node) =>
    node switch
    {
        TypeDeclarationSyntax type => type.Identifier.Text + TypeParameterSuffix(type.TypeParameterList),
        DelegateDeclarationSyntax del => del.Identifier.Text + TypeParameterSuffix(del.TypeParameterList),
        EnumDeclarationSyntax en => en.Identifier.Text,
        _ => node.ToString()
    };

static string TypeParameterSuffix(TypeParameterListSyntax? parameters) =>
    parameters is null ? "" : "<" + string.Join(", ", parameters.Parameters.Select(p => p.Identifier.Text)) + ">";

static string GetTypeKind(SyntaxNode node) =>
    node switch
    {
        ClassDeclarationSyntax => "Class",
        InterfaceDeclarationSyntax => "Interface",
        RecordDeclarationSyntax => "Record",
        StructDeclarationSyntax => "Struct",
        EnumDeclarationSyntax => "Enum",
        DelegateDeclarationSyntax => "Delegate",
        _ => "Type"
    };

static string GetMemberName(MemberDeclarationSyntax member) =>
    member switch
    {
        DestructorDeclarationSyntax dtor => "~" + dtor.Identifier.Text,
        MethodDeclarationSyntax method => method.Identifier.Text + TypeParameterSuffix(method.TypeParameterList),
        PropertyDeclarationSyntax property => property.Identifier.Text,
        IndexerDeclarationSyntax => "this[]",
        FieldDeclarationSyntax field => string.Join(", ", field.Declaration.Variables.Select(v => v.Identifier.Text)),
        EventFieldDeclarationSyntax evt => string.Join(", ", evt.Declaration.Variables.Select(v => v.Identifier.Text)),
        EventDeclarationSyntax evt => evt.Identifier.Text,
        OperatorDeclarationSyntax op => "operator " + op.OperatorToken.Text,
        ConversionOperatorDeclarationSyntax op => "operator " + op.Type,
        _ => ""
    };

static string GetMemberKind(MemberDeclarationSyntax member) =>
    member switch
    {
        DestructorDeclarationSyntax => "Destructor",
        MethodDeclarationSyntax => "Method",
        PropertyDeclarationSyntax => "Property",
        IndexerDeclarationSyntax => "Indexer",
        FieldDeclarationSyntax => "Field",
        EventFieldDeclarationSyntax => "Event",
        EventDeclarationSyntax => "Event",
        OperatorDeclarationSyntax => "Operator",
        ConversionOperatorDeclarationSyntax => "Operator",
        _ => "Member"
    };

static string GetModifiers(MemberDeclarationSyntax member) =>
    string.Join(" ", member.Modifiers.Select(m => m.Text));

static string GetSignature(SyntaxNode node)
{
    var text = node switch
    {
        MethodDeclarationSyntax method => method.WithBody(null).WithExpressionBody(null).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)).NormalizeWhitespace().ToFullString(),
        ConstructorDeclarationSyntax ctor => ctor.WithBody(null).WithExpressionBody(null).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)).NormalizeWhitespace().ToFullString(),
        DestructorDeclarationSyntax dtor => dtor.WithBody(null).WithExpressionBody(null).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)).NormalizeWhitespace().ToFullString(),
        OperatorDeclarationSyntax op => op.WithBody(null).WithExpressionBody(null).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)).NormalizeWhitespace().ToFullString(),
        ConversionOperatorDeclarationSyntax op => op.WithBody(null).WithExpressionBody(null).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)).NormalizeWhitespace().ToFullString(),
        BaseTypeDeclarationSyntax type => TrimDeclaration(type.ToString()),
        DelegateDeclarationSyntax del => del.NormalizeWhitespace().ToFullString(),
        _ => node.NormalizeWhitespace().ToFullString()
    };

    return StripAttributes(text).Trim();
}

static string TrimDeclaration(string text)
{
    var brace = text.IndexOf('{');
    return brace >= 0 ? text[..brace].Trim() : text.Trim();
}

static string StripAttributes(string text)
{
    var lines = text.Replace("\r\n", "\n").Split('\n');
    return string.Join(Environment.NewLine, lines.Where(line =>
    {
        var trimmed = line.TrimStart();
        return !trimmed.StartsWith("[", StringComparison.Ordinal) &&
               !trimmed.StartsWith("///", StringComparison.Ordinal);
    }));
}

static string Plural(string value) =>
    value.EndsWith('y') ? value[..^1] + "ies" : value + "s";

static XmlDoc GetXmlDocs(SyntaxNode node)
{
    var result = new XmlDoc();
    foreach (var trivia in node.GetLeadingTrivia())
    {
        var structure = trivia.GetStructure();
        if (structure is not DocumentationCommentTriviaSyntax doc)
        {
            continue;
        }

        foreach (var element in doc.Content.OfType<XmlElementSyntax>())
        {
            var name = element.StartTag.Name.LocalName.Text;
            var text = XmlContent(element.Content);
            switch (name)
            {
                case "summary":
                    result.Summary = text;
                    break;
                case "remarks":
                    result.Remarks = text;
                    break;
                case "returns":
                    result.Returns = text;
                    break;
                case "value":
                    result.Value = text;
                    break;
                case "example":
                    result.Example = text;
                    break;
                case "param":
                    var paramName = XmlName(element.StartTag.Attributes);
                    if (!string.IsNullOrWhiteSpace(paramName))
                    {
                        result.Parameters[paramName] = text;
                    }
                    break;
                case "typeparam":
                    var typeParamName = XmlName(element.StartTag.Attributes);
                    if (!string.IsNullOrWhiteSpace(typeParamName))
                    {
                        result.TypeParameters[typeParamName] = text;
                    }
                    break;
            }
        }
    }

    return result;
}

static string XmlContent(SyntaxList<XmlNodeSyntax> content)
{
    var builder = new StringBuilder();
    foreach (var child in content)
    {
        var value = child switch
        {
            XmlTextSyntax text => string.Concat(text.TextTokens.Select(t => t.Text)),
            XmlEmptyElementSyntax empty when empty.Name.LocalName.Text == "see" => CodeReference(empty.Attributes),
            XmlElementSyntax element when element.StartTag.Name.LocalName.Text == "c" => "`" + XmlContent(element.Content).Trim() + "`",
            XmlElementSyntax element => XmlContent(element.Content),
            _ => child.ToFullString()
        };

        builder.Append(value);
    }

    return NormalizeText(SecurityElement.Escape(builder.ToString().Trim()) ?? "");
}

static string XmlName(SyntaxList<XmlAttributeSyntax> attributes)
{
    var text = attributes.FirstOrDefault(a => a.ToString().StartsWith("name=", StringComparison.Ordinal))?.ToString() ?? "";
    var match = Regex.Match(text, "name\\s*=\\s*\"(?<name>[^\"]+)\"");
    return match.Success ? match.Groups["name"].Value : "";
}

static string CodeReference(SyntaxList<XmlAttributeSyntax> attributes)
{
    var cref = attributes.OfType<XmlCrefAttributeSyntax>().FirstOrDefault()?.Cref.ToString();
    return string.IsNullOrWhiteSpace(cref) ? "" : $"`{cref}`";
}

static string SourceUrl(string relativeSource, int line) =>
    $"https://gitlab.com/kamran65536/KamiSama/-/blob/master/{relativeSource}#L{line}";

static void WriteOverview(string contentRoot, List<LibraryDoc> libraries, string docsVersion)
{
    var builder = new StringBuilder();
    builder.AppendLine("# KamiSama.Extensions");
    builder.AppendLine();
    builder.AppendLine("KamiSama.Extensions is a reusable .NET and ASP.NET Core package family for building modular applications. It includes core extension methods, dependency-injection helpers, JSON/XML serialization utilities, repository implementations, HTTP exception handling, ProblemDetails integration, web modules, external service integrations, and ready-made bounded-context modules such as Identity, Localization, Locations, ServicePlans, and Ticketing.");
    builder.AppendLine();
    builder.AppendLine("Use these packages when you want shared infrastructure, feature-layer building blocks, and module wiring patterns across multiple services without copying the same plumbing into every project.");
    builder.AppendLine();
    builder.AppendLine($"Version: `{Markdown(docsVersion)}`");
    builder.AppendLine();
    builder.AppendLine("## Package areas");
    builder.AppendLine();
    builder.AppendLine("| Area | What it provides |");
    builder.AppendLine("| --- | --- |");
    builder.AppendLine("| Core extensions | Byte, string, date, hash, stream, collection, conversion, and paging helpers. |");
    builder.AppendLine("| Dependency injection | Attribute-based service registration and assembly scanning. |");
    builder.AppendLine("| Serialization | JSON and XML helpers for strings, streams, bytes, files, and repositories. |");
    builder.AppendLine("| Repositories | In-memory, JSON, XML, EF, and EF Core repository patterns and paging support. |");
    builder.AppendLine("| Chassis | Base classes and contracts for CRUD-style feature services and HTTP-aware errors. |");
    builder.AppendLine("| Web modules | Modular ASP.NET Core service and middleware registration. |");
    builder.AppendLine("| External services | Email and SMS abstractions plus SMTP, Kavenegar, and NeoZarin integrations. |");
    builder.AppendLine("| Application modules | Identity, Localization, Locations, ServicePlans, and Ticketing bounded contexts. |");
    builder.AppendLine();
    builder.AppendLine("## API documentation");
    builder.AppendLine();
    builder.AppendLine("- [Package index](api/index.md)");
    builder.AppendLine("- [Symbol index](api/symbols.md)");
    builder.AppendLine();
    builder.AppendLine("## Packages");
    builder.AppendLine();
    foreach (var library in libraries)
    {
        builder.AppendLine($"- [{Markdown(library.Name)}](api/{library.Slug}/index.md) - {Markdown(library.Description)}");
    }

    File.WriteAllText(Path.Combine(contentRoot, "index.md"), builder.ToString(), Encoding.UTF8);
}

static void CopyTopicDocs(string docsRoot, string contentRoot)
{
    var oldRoot = Path.Combine(docsRoot, "old");
    if (!Directory.Exists(oldRoot))
    {
        return;
    }

    foreach (var oldDoc in Directory.EnumerateFiles(oldRoot, "*.md").OrderBy(path => path))
    {
        var target = Path.Combine(contentRoot, "topics", Path.GetFileName(oldDoc));
        var content = File.ReadAllText(oldDoc);
        content = Regex.Replace(content, @"\[([^\]]+)\]\(#[^)]+\)", "$1");
        File.WriteAllText(target, content, Encoding.UTF8);
    }
}

static void WriteApiDocs(string contentRoot, List<LibraryDoc> libraries, string docsVersion)
{
    WriteApiIndex(contentRoot, libraries, docsVersion);
    WriteSymbolIndex(contentRoot, libraries);

    foreach (var library in libraries)
    {
        var libraryRoot = Path.Combine(contentRoot, "api", library.Slug);
        Directory.CreateDirectory(libraryRoot);
        WriteLibraryIndex(libraryRoot, library, docsVersion);

        foreach (var namespaceGroup in library.Types.GroupBy(t => t.Namespace).OrderBy(g => g.Key))
        {
            var namespaceRoot = Path.Combine(libraryRoot, Slug(namespaceGroup.Key));
            Directory.CreateDirectory(namespaceRoot);
            WriteNamespaceIndex(namespaceRoot, library, namespaceGroup.Key, namespaceGroup.ToList());

            foreach (var type in namespaceGroup)
            {
                WriteTypePage(namespaceRoot, library, type);
            }
        }
    }
}

static void WriteApiIndex(string contentRoot, List<LibraryDoc> libraries, string docsVersion)
{
    var builder = new StringBuilder();
    builder.AppendLine("# Package Index");
    builder.AppendLine();
    builder.AppendLine("[Back to documentation home](../index.md)");
    builder.AppendLine();
    builder.AppendLine($"Version: `{Markdown(docsVersion)}`");
    builder.AppendLine();
    builder.AppendLine("| Package | Description | Install | Types |");
    builder.AppendLine("| --- | --- | --- | ---: |");
    foreach (var library in libraries)
    {
        builder.AppendLine($"| [{Markdown(library.Name)}]({library.Slug}/index.md) | {Markdown(library.Description)} | `{Markdown(InstallCommand(library.PackageId, docsVersion))}` | {library.Types.Count} |");
    }

    File.WriteAllText(Path.Combine(contentRoot, "api", "index.md"), builder.ToString(), Encoding.UTF8);
}

static void WriteSymbolIndex(string contentRoot, List<LibraryDoc> libraries)
{
    var symbols = libraries
        .SelectMany(l => l.Types.Select(t => (Library: l, Type: t)))
        .OrderBy(x => x.Type.Name)
        .ThenBy(x => x.Type.Namespace)
        .ToList();
    var builder = new StringBuilder();
    builder.AppendLine("# Symbol Index");
    builder.AppendLine();
    builder.AppendLine("[Back to package index](index.md)");
    builder.AppendLine();
    builder.AppendLine("| Symbol | Kind | Namespace | Package |");
    builder.AppendLine("| --- | --- | --- | --- |");
    foreach (var symbol in symbols)
    {
        builder.AppendLine($"| [{Markdown(symbol.Type.Name)}]({TypeRelativePath(symbol.Library, symbol.Type)}) | {symbol.Type.Kind} | `{Markdown(symbol.Type.Namespace)}` | [{Markdown(symbol.Library.Name)}]({symbol.Library.Slug}/index.md) |");
    }

    File.WriteAllText(Path.Combine(contentRoot, "api", "symbols.md"), builder.ToString(), Encoding.UTF8);
}

static void WriteLibraryIndex(string libraryRoot, LibraryDoc library, string docsVersion)
{
    var builder = new StringBuilder();
    builder.AppendLine($"# {library.Name}");
    builder.AppendLine();
    builder.AppendLine("[Back to package index](../index.md)");
    builder.AppendLine();
    builder.AppendLine($"Version: `{Markdown(docsVersion)}`");
    builder.AppendLine();
    builder.AppendLine("## Description");
    builder.AppendLine();
    builder.AppendLine(DeveloperDescription(library.Description, $"{library.Name} contains reusable KamiSama APIs for the {library.Group} area."));
    builder.AppendLine();
    builder.AppendLine("## How to use");
    builder.AppendLine();
    builder.AppendLine("```shell");
    builder.AppendLine(InstallCommand(library.PackageId, docsVersion));
    builder.AppendLine("```");
    builder.AppendLine();
    if (library.Name.Equals("KamiSama.Modules.PolicyEngine.Abstractions", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` is the current workspace/root documentation version and remains the required repository install command. NuGet returned no published package or version for this package ID when reviewed.");
        builder.AppendLine();
        builder.AppendLine("Reference these provider-neutral contracts from callers or alternative implementations that need CRUD requests, DTOs, search models, or evaluation-shaped data without depending on EF Core. The package defines `PolicyContext`, diagnostics, a three-valued condition result, and resolved-action data, but it defines no evaluator, condition parser, action-handler contract, middleware, authorization policy, controller, or endpoint. An application must implement those concerns separately.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.PolicyEngine.Core", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` is the current workspace/root documentation version and remains the required repository install command. NuGet returned no published package or version for this package ID when reviewed.");
        builder.AppendLine();
        builder.AppendLine("Call `AddPolicyEngineModule(moduleSection, databaseSection, providerCallback)` on an `ExtendedWebApplicationBuilder`, select `postgresql` with `AddPostgresqlPolicyEngineDbContext` or `sqlite` with `AddSqlitePolicyEngineDbContext`, and then call `BuildAsync`. The callback is nullable but required in normal setup unless the host separately registers the exact configured keyed `PolicyEngineDbContext`. Service registration binds the empty `PolicyEngineOptions`, named initialization options, attributed repositories and features, and `__EFMigrationsHistory_PolicyEngine`; post-build setup resolves a custom initializer or the migration-only default.");
        builder.AppendLine();
        builder.AppendLine("This package manages policy-action, policy-rule, rule/action-assignment, policy-list, and polymorphic exact/range item entities. Public CRUD contracts cover only action, rule, and list definitions; there is no list-item or rule/action-assignment feature API, and returned list DTOs omit those relationships. There is no policy evaluator, condition parser, action execution, controller, endpoint, authentication, or authorization integration.");
        builder.AppendLine();
        builder.AppendLine("**Runtime defects:** the attributed `ListPolicyActions`, `DeletePolicyAction`, `ListPolicyLists`, `DeletePolicyList`, `ListPolicyRules`, and `DeletePolicyRule` classes do not implement their declared service interfaces. Service-provider validation can fail during `BuildAsync`; without validation, resolving those six contracts fails. Name uniqueness uses a case-insensitive read-before-write check with no model-level unique index, and mutations save immediately without a feature-level transaction. Provider packages contain no migrations, so the default migration stage cannot provision PolicyEngine tables; provision a compatible schema separately or supply migrations/custom initialization before using the repositories. Protect every exposed operation with host authentication and authorization.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.PolicyEngine.Postgresql", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` is the current workspace/root documentation version and remains the required repository install command. NuGet returned no published package or version for this package ID when reviewed.");
        builder.AppendLine();
        builder.AppendLine("Install this package with PolicyEngine Core and call `database => database.AddPostgresqlPolicyEngineDbContext()` from `AddPolicyEngineModule` while the database provider value is `postgresql` (case-insensitive before keyed lookup). Registration adds a scoped Npgsql context, lazy-loading proxies, `__EFMigrationsHistory_PolicyEngine`, and process-wide legacy timestamp and disabled infinity-conversion switches. This package contains no PolicyEngine migrations, so startup migration does not create the module schema; provision a compatible schema or provide migrations separately.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.PolicyEngine.Sqlite", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` is the current workspace/root documentation version and remains the required repository install command. NuGet returned no published package or version for this package ID when reviewed.");
        builder.AppendLine();
        builder.AppendLine("Install this package with PolicyEngine Core and call `database => database.AddSqlitePolicyEngineDbContext()` from `AddPolicyEngineModule` while the database provider value is `sqlite` (case-insensitive before keyed lookup). Registration adds a scoped SQLite context, lazy-loading proxies, and `__EFMigrationsHistory_PolicyEngine`. This package contains no PolicyEngine migrations, so startup migration does not create the module schema; provision a compatible schema or provide migrations separately.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.ServicePlans.Abstractions", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet returned no published package or version for this package ID when reviewed.");
        builder.AppendLine();
        builder.AppendLine("Inject the plan, subscriber, and subscription feature contracts after a concrete implementation has registered them. This package contains contracts and data shapes only: it registers no services, persistence, offer-management API, controllers, endpoints, validation pipeline, authentication, or authorization. Alternative implementations define query, mutation, transaction, validation, and cancellation semantics.");
        builder.AppendLine();
        builder.AppendLine("Current Core treats request subscriber identifiers, subscription statuses, dates, allowances, and usage counters as trusted input. Protect mutation operations at the host boundary and validate ownership, status transitions, date ranges, non-negative counters, plan availability, and subscriber eligibility before invoking them.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.ServicePlans.Core", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet returned no published package or version for this package ID when reviewed.");
        builder.AppendLine();
        builder.AppendLine("Install Core plus the selected provider package. Configure a database section with `provider` and `connection-string`, pass a callback that registers `postgresql` through `AddPostgresqlServicePlansDbContext` or `sqlite` through `AddSqliteServicePlansDbContext`, and finish setup through `BuildAsync`:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Modules;");
        builder.AppendLine("using KamiSama.Modules.ServicePlans;");
        builder.AppendLine();
        builder.AppendLine("IConfigurationSection servicePlans = webBuilder.Configuration.GetSection(\"ServicePlans\");");
        builder.AppendLine("ExtendedWebApplicationBuilder builder = webBuilder.Extend()");
        builder.AppendLine("    .AddServicePlansModule(");
        builder.AppendLine("        servicePlans,");
        builder.AppendLine("        servicePlans.GetSection(\"database\"),");
        builder.AppendLine("        database => database.AddPostgresqlServicePlansDbContext());");
        builder.AppendLine("WebApplication app = await builder.BuildAsync(cancellationToken);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("The nullable provider callback is required in normal setup unless the host separately registers the exact configured keyed `ServicePlansDbContext`. During `BuildAsync`, Core binds the empty `ServicePlansOptions`, named connection and initialization options, scans Core for attributed scoped repositories and features, and selects `__EFMigrationsHistory_ServicePlans`. After build it resolves a custom `IDatabaseInitializer<ServicePlansDbContext>` or a migration-only default and executes the enabled `migrate`, `initialize`, and `test-data` stages. The default seed stages are no-ops.");
        builder.AppendLine();
        builder.AppendLine("**Schema limitation:** neither current provider package contains ServicePlans migrations. Enabling `migrate` therefore cannot create these tables from this checkout; provision a compatible schema or supply migrations/custom initialization before using the repositories. Core exposes tracked plan, offer, offer-country, offer-payment-method, subscriber, and subscription entities, but public feature services cover only plans, subscribers, and subscriptions. No public offer CRUD exists.");
        builder.AppendLine();
        builder.AppendLine("All current attributed ServicePlans features and repositories are assignable to their declared service contracts. Plan names and subscriber external-user identifiers use case-sensitive or case-normalized read-before-write duplicate checks without model-level unique indexes, so concurrent writes can create duplicates. Mutations save immediately without a feature-level transaction. Searches use translated lowercase equality for plan names, recognize only documented source tokens, and return tracked entities before DTO conversion.");
        builder.AppendLine();
        builder.AppendLine("**Security and correctness limitations:** Core maps no controllers, endpoints, middleware, authentication, or authorization. It does not validate positive rates or allowances, date ordering, duration consistency, enum validity, status transitions, subscriber enabled state, plan enabled state, or ownership of supplied subscriber identifiers. Subscription add/update accepts caller-selected usage balances and can reassign both subscriber and plan. Add endpoint authorization and domain validation before exposing these features.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.ServicePlans.Postgresql", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet returned no published package or version for this package ID when reviewed.");
        builder.AppendLine();
        builder.AppendLine("Install this package with ServicePlans Core, configure provider `postgresql`, and pass `database => database.AddPostgresqlServicePlansDbContext()` to `AddServicePlansModule`. Registration adds a scoped Npgsql context and exact keyed base-context alias, enables lazy-loading proxies, uses `__EFMigrationsHistory_ServicePlans`, and applies the shared PostgreSQL provider's process-wide legacy timestamp and disabled infinity-conversion switches. This package contains no ServicePlans migrations, so provision a compatible schema or supply migrations separately.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.ServicePlans.Sqlite", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet returned no published package or version for this package ID when reviewed.");
        builder.AppendLine();
        builder.AppendLine("Install this package with ServicePlans Core, configure provider `sqlite`, and pass `database => database.AddSqliteServicePlansDbContext()` to `AddServicePlansModule`. Registration adds a scoped SQLite context and exact keyed base-context alias, enables lazy-loading proxies, and uses `__EFMigrationsHistory_ServicePlans`. This package contains no ServicePlans migrations, so provision a compatible schema or supply migrations separately.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.ServicePlans.PolicyAction", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet returned no published package or version for this exact package ID when reviewed.");
        builder.AppendLine();
        builder.AppendLine("Add the package module to an `ExtendedWebApplicationBuilder`, finish the two-phase module lifecycle with `BuildAsync`, and resolve the package-specific handler from a scope:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Modules;");
        builder.AppendLine("using KamiSama.ServicePlans.PolicyAction;");
        builder.AppendLine("using Microsoft.Extensions.DependencyInjection;");
        builder.AppendLine();
        builder.AppendLine("ExtendedWebApplicationBuilder builder = webBuilder.Extend()");
        builder.AppendLine("    .AddServicePlansPolicyActionModule();");
        builder.AppendLine("WebApplication app = await builder.BuildAsync(cancellationToken);");
        builder.AppendLine();
        builder.AppendLine("using IServiceScope scope = app.Services.CreateScope();");
        builder.AppendLine("IServicePlansPolicyActionHandler handler = scope.ServiceProvider");
        builder.AppendLine("    .GetRequiredService<IServicePlansPolicyActionHandler>();");
        builder.AppendLine("string handlerName = handler.HandlerName; // service-plans");
        builder.AppendLine("// Do not call ExecuteAsync in 10.0.0: the registered implementation always throws.");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("`ConfigureServices` scans this assembly and registers its internal implementation as scoped. `ApplyConfigurationToAsync` returns a completed task and adds no middleware, endpoints, or dispatcher. The module does not add PolicyEngine Core or ServicePlans Core; register those independently if the host needs their CRUD or persistence features. Although the project carries both abstractions as package dependencies, current source uses only PolicyEngine's `PolicyContext` and calls no ServicePlans contract.");
        builder.AppendLine();
        builder.AppendLine("This is not an end-to-end PolicyEngine integration. PolicyEngine Abstractions stores `ResolvedPolicyAction.HandlerName` and configuration as opaque values and defines no action-handler or dispatcher contract. A host would have to match `ServicePlansPolicyActionHandlerNames.ServicePlans`, select this package-specific interface, and invoke it manually. The current `ExecuteAsync` throws `NotImplementedException` synchronously before reading the context, configuration, or cancellation token. `CostExpression` has no defined serialization format, grammar, validation, fact-key convention, or evaluator, and no computation units are applied to ServicePlans plans, subscribers, or subscriptions. Supply a separate working implementation and dispatcher before relying on this boundary.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Extensions.Json", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Use `KamiSama.Extensions` for serialization helpers and `KamiSama.Extensions.Json` for converter types. Register converters on the `JsonSerializerOptions` instance used by your application:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Extensions;");
        builder.AppendLine("using KamiSama.Extensions.Json;");
        builder.AppendLine();
        builder.AppendLine("var options = new JsonSerializerOptions()");
        builder.AppendLine("    .AddHexByteConverter()");
        builder.AppendLine("    .AddTimeSpanJsonConverter();");
        builder.AppendLine();
        builder.AppendLine("options.Converters.Add(new BigIntegerJsonConverter());");
        builder.AppendLine("options.Converters.Add(new DynamicObjectConverter());");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("For polymorphic deserialization, mark one base-type property with `JsonHirerarchyDiscriminatorAttribute`, register each derived type with `HierarchicalJsonConverter<T>.Register`, and then call `AddHierarchicalConverter<T>()` on the same options instance.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Extensions.Xml", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Use `KamiSama.Extensions` for both string serialization and polymorphic override helpers. Decorate polymorphic members, discover their concrete types, and pass the resulting serializer to the string helpers:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using System.Xml.Serialization;");
        builder.AppendLine("using KamiSama.Extensions;");
        builder.AppendLine();
        builder.AppendLine("var overrides = new XmlAttributeOverrides();");
        builder.AppendLine("overrides.AddAutoXmlAttributes(typeof(Document), [typeof(TextContent)]);");
        builder.AppendLine("var serializer = new XmlSerializer(typeof(Document), overrides);");
        builder.AppendLine();
        builder.AppendLine("string xml = document.SerializeToXml(serializer: serializer);");
        builder.AppendLine("Document? copy = xml.DeserializeFromXml<Document>(serializer);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("`SerializeToXml` and `DeserializeFromXml<T>` operate on strings. Models must still satisfy the normal `XmlSerializer` requirements; `AutoXmlArrayItemAttribute` supports array members, and candidate discovery finds non-abstract subclasses rather than interface implementations.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Repositories.Core", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Use the contracts to keep callers independent of persistence, or use `InMemoryRepository<TEntity>` for transient data and tests. Its update methods are no-ops, duplicate handling follows `HashSet<TEntity>` equality, and live queries must not be enumerated concurrently with mutations:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Repositories;");
        builder.AppendLine();
        builder.AppendLine("using var repository = new InMemoryRepository<User>(users, UserIdComparer.Instance);");
        builder.AppendLine("User? admin = repository.FirstOrDefault(user => user.IsAdmin);");
        builder.AppendLine("List<User> allUsers = repository.GetAll().ToList();");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("The repository interfaces do not define durability, transactions, duplicate behavior, cancellation guarantees, or whether returned queries are snapshots. `IAsyncQueryableRepository<TEntity>.Where` is synchronous despite the interface name. `ConnectionStringOption` and `DataInitializationOptions` are configuration data only; an initializer or provider implementation decides how their values are applied.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Repositories.Json", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Point `JsonRepository<TEntity>` at an existing file containing a JSON array, subscribe to failure events, and prefer asynchronous reads:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Repositories.Json;");
        builder.AppendLine();
        builder.AppendLine("using var repository = new JsonRepository<User>(\"data/users.json\", UserIdComparer.Instance);");
        builder.AppendLine("repository.LoadFailed += (_, error) => logger.LogError(error, \"Could not load users\");");
        builder.AppendLine("repository.SaveFailed += (_, error) => logger.LogError(error, \"Could not save users\");");
        builder.AppendLine();
        builder.AppendLine("User? user = await repository.FindAsync(x => x.Id == userId, cancellationToken);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("The repository loads lazily and cannot initialize a missing or invalid file. Mutations rewrite the complete JSON array non-atomically; `Update` only rewrites objects already changed in memory. Save failures are suppressed after raising `SaveFailed`, do not roll back the cache, and can leave partial file content. Locking is per instance, queries are live, and separate instances or processes can overwrite each other. Duplicate behavior follows the configured `HashSet<TEntity>` comparer.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Repositories.Xml", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Treat both XML repository classes as read-only in version 10.0.0. Store one entity per `*.xml` file, pass a serializer for one entity because the default array serializer cannot read those files, and make the mapping return each exact file name:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using System.Xml.Serialization;");
        builder.AppendLine("using KamiSama.Repositories.Xml;");
        builder.AppendLine();
        builder.AppendLine("var serializer = new XmlSerializer(typeof(User));");
        builder.AppendLine("using var repository = new XmlDirectoryRepository<User>(");
        builder.AppendLine("    \"data/users\", user => $\"{user.Id}.xml\", serializer, UserIdComparer.Instance);");
        builder.AppendLine();
        builder.AppendLine("User? user = await repository.FindAsync(x => x.Id == userId, cancellationToken);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("Do not call add, update, or delete expecting persistence. Both implementations write to the directory path instead of mapped entity files, ignore the supplied serializer while saving, and never delete stale files; failures are raised through `SaveFailed` after in-memory changes and otherwise suppressed. A single invalid or misnamed file fails the whole load, equal entities from separate files are silently collapsed, queries are live, and locking does not coordinate multiple instances or processes.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Repositories.EntityFramework", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Construct a repository with an application-owned EF6 context. Mutations save immediately, while queries remain tracked and deferred:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Extensions.Paging;");
        builder.AppendLine("using KamiSama.Repositories.EntityFramework;");
        builder.AppendLine();
        builder.AppendLine("var repository = new DbRepository<User, AppDbContext>(dbContext);");
        builder.AppendLine("await repository.AddAsync(new User { Name = \"Ada\" }, cancellationToken);");
        builder.AppendLine("PagedResult<User> page = await repository.AsQueryable()");
        builder.AppendLine("    .OrderBy(user => user.Id)");
        builder.AppendLine("    .MakePagedAsync(SearchModel.FromPage(1, 20), cancellationToken);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("The repository does not own or dispose the context. Each add, update, or delete calls `SaveChanges` immediately rather than participating in a repository-level unit of work. Queries track entities by default. Paging requires an ordered query, performs a synchronous uncancellable count before cancellable asynchronous materialization, and uses separate count and data queries.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Repositories.EntityFrameworkCore", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Register the base context from configuration, set one shared migration-history table, and add each installed concrete provider context through its generic extension:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Repositories.EntityFrameworkCore;");
        builder.AppendLine("using KamiSama.Repositories.EntityFrameworkCore.Postgresql;");
        builder.AppendLine("using KamiSama.Repositories.EntityFrameworkCore.Sqlite;");
        builder.AppendLine();
        builder.AppendLine("services.AddMultiProviderDbContext<AppDbContext>(configuration.GetSection(\"Database\"))");
        builder.AppendLine("    .WithMigrationHistoryTable(\"__AppMigrationsHistory\")");
        builder.AppendLine("    .AddPostgresql<PostgresqlAppDbContext>()");
        builder.AppendLine("    .AddSqlite<SqliteAppDbContext>();");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("Configuration uses the `provider` and `connection-string` keys. Provider lookup lowercases the configured value, and installed providers register exact `postgresql` or `sqlite` keys. Contexts and the keyed base-context alias are scoped. Provider packages enable lazy-loading proxies and apply the configured migration-history table.");
        builder.AppendLine();
        builder.AppendLine("`DbRepository<TEntity>` borrows its context, does not dispose it, tracks queries by default, and saves every mutation immediately. `MakePagedAsync<T>` requires caller-supplied deterministic ordering, counts synchronously without cancellation, then materializes asynchronously in a separate query. Initializer stages run sequentially without a transaction supplied by the base class.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Repositories.EntityFrameworkCore.Postgresql", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Warning:** the workspace root version is `10.0.0`, but a matching provider package may not be published. The required workspace-version command above is intentionally retained.");
        builder.AppendLine();
        builder.AppendLine("Register a concrete context derived from the base context after `AddMultiProviderDbContext<TBaseContext>`: `builder.AddPostgresql<PostgresqlAppDbContext>()`. This adds scoped services under the exact `postgresql` key, enables lazy-loading proxies, and applies the builder migration-history table. It also sets `Npgsql.EnableLegacyTimestampBehavior` and `Npgsql.DisableDateTimeInfinityConversions` process-wide, affecting all Npgsql use in the process.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Repositories.EntityFrameworkCore.Sqlite", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Warning:** the workspace root version is `10.0.0`, but a matching provider package may not be published. The required workspace-version command above is intentionally retained.");
        builder.AppendLine();
        builder.AppendLine("Register a concrete context derived from the base context after `AddMultiProviderDbContext<TBaseContext>`: `builder.AddSqlite<SqliteAppDbContext>()`. This adds scoped services under the exact `sqlite` key, enables lazy-loading proxies, and applies the builder migration-history table.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Extensions.DependencyInjection", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Decorate each implementation with the appropriate registration attribute, then scan its assembly during service configuration:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Extensions.DependencyInjection;");
        builder.AppendLine();
        builder.AppendLine("[AutoInjectScoped<IProductService>]");
        builder.AppendLine("public sealed class ProductService : IProductService;");
        builder.AppendLine();
        builder.AppendLine("services.AutoAddDependenciesFrom<Program>();");
        builder.AppendLine("```");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Chassis.HttpExceptions", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Throw an HTTP exception from application or feature code, then let an API-boundary adapter translate its status and localization metadata into a response:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Chassis.HttpExceptions;");
        builder.AppendLine();
        builder.AppendLine("Product product = await repository.FindByIdAsync(id, cancellationToken)");
        builder.AppendLine("    ?? throw new NotFoundException<Product>(id, nameof(id));");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("These exceptions only carry metadata; they do not write HTTP responses. `ExceptionLocalizationKey` and `ExceptionLocalizationArguments` are intended for a localizing adapter. `ExtendedProperties` is available to adapters, but the current `KamiSamaProblemDetailsProvider` does not copy it. `GoneException` currently reports 401 rather than 410.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Chassis.ProblemDetails", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Register the MVC filter after adding controllers. The default provider converts `HttpExceptionBase` metadata and uses the package resource localizer:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Chassis.ProblemDetails;");
        builder.AppendLine();
        builder.AppendLine("services.AddControllers()");
        builder.AppendLine("    .AddExceptionFilterForProblemDetails(options => options");
        builder.AppendLine("        .UseDefaultProblemDetailsProvider()");
        builder.AppendLine("        .UseResourceLocalizer<ErrorMessages>());");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("The filter handles every MVC exception. Non-HTTP exceptions become status 500 payloads whose title uses the original exception message. The current filter does not explicitly assign `ObjectResult.StatusCode`, and the default provider does not copy `ExtendedProperties`; account for those runtime limitations or supply a custom `IProblemDetailsDataProvider`. Custom provider factories must configure their own localization behavior.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Chassis.Commons.Abstractions", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Reference this package from contracts, callers, and implementations that need shared CRUD feature or repository shapes without taking a dependency on the concrete chassis workflows:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Chassis.Commons.Features;");
        builder.AppendLine();
        builder.AppendLine("public sealed class ProductController(IFindByIdFeature<ProductDto, Guid> findProduct)");
        builder.AppendLine("{");
        builder.AppendLine("    public Task<ProductDto> Get(Guid id, CancellationToken cancellationToken)");
        builder.AppendLine("        => findProduct.FindByIdAsync(id, cancellationToken);");
        builder.AppendLine("}");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("This package contains contracts only: it does not register services, implement persistence, define transaction boundaries, or decide missing-entity behavior. The shorter `IListFeature<TEntityDto, TSearchModel>`, `IListingRepository<TEntity, TSearchModel>`, and `IGenericRepository<TEntity, TSearchModel>` interfaces are aliases for the standard `PagedResult<T>` shapes.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Chassis.Commons", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Derive a focused feature from a generic workflow, implement its validation or mapping hooks, and register the concrete feature and repository with your application:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Chassis.Commons.Features;");
        builder.AppendLine();
        builder.AppendLine("public sealed class FindProduct(IProductRepository repository)");
        builder.AppendLine("    : GenericFindByIdFeature<Product, ProductDto, IProductRepository, Guid>(repository)");
        builder.AppendLine("{");
        builder.AppendLine("    protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)");
        builder.AppendLine("        => Task.FromResult(new ProductDto(entity.Id, entity.Name));");
        builder.AppendLine("}");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("Create and update hooks run around repository mutation; find and delete workflows throw HTTP not-found exceptions for missing entities; exists workflows delegate directly. `GenericRepository` is EF Core based, applies the same search hook to list and count queries, and relies on the injected `DbContext` lifetime and save behavior inherited from `DbRepository`. The delete guard returns without deleting when it yields false and does not report why.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Wrap a standard builder, add modules in the required middleware and endpoint order, and finish with `BuildAsync`. All module service phases run first in insertion order, the application is built once, and then all application phases run in the same order:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Modules;");
        builder.AppendLine();
        builder.AppendLine("var webBuilder = WebApplication.CreateBuilder(args);");
        builder.AppendLine("webBuilder.Services.AddAntiforgery(); // Required before AddAntiForgery.");
        builder.AppendLine();
        builder.AppendLine("var builder = webBuilder.Extend()");
        builder.AppendLine("    .AddForwardedHeaders()");
        builder.AppendLine("    .AddHttpsRedirection()");
        builder.AppendLine("    .AddStaticFiles()");
        builder.AppendLine("    .AddRouting(options => options.LowercaseUrls = true)");
        builder.AppendLine("    .AddAuthorization()");
        builder.AppendLine("    .AddAntiForgery()");
        builder.AppendLine("    .AddControllers()");
        builder.AppendLine("    .AddSwagger();");
        builder.AppendLine();
        builder.AppendLine("var app = await builder.BuildAsync(CancellationToken.None);");
        builder.AppendLine("await app.RunAsync();");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("Module order is middleware and endpoint order during the post-build phase. A failure stops later modules, and a cancellation token is only passed to modules; most built-in modules ignore it. `Build` blocks on `BuildAsync(CancellationToken.None).Result`. `AntiForgeryModule` only calls `UseAntiforgery`, so register antiforgery services separately. **Do not add `ResponseCachingModule` in a runnable build:** its application phase always throws `NotImplementedException`, causing both build methods to fail after the underlying application has already been built.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Testing.NSubstitute", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Derive a scenario-specific builder, expose configured substitutes, build the target once, and resolve generated dependencies from the resulting scope:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Testing.NSubstitute;");
        builder.AppendLine("using NSubstitute;");
        builder.AppendLine();
        builder.AppendLine("public sealed class ProductServiceTestsBuilder : TesterBuilderBase");
        builder.AppendLine("{");
        builder.AppendLine("    public IProductRepository Repository { get; };");
        builder.AppendLine();
        builder.AppendLine("    public ProductServiceTestsBuilder()");
        builder.AppendLine("    {");
        builder.AppendLine("        Repository = AddScoped<IProductRepository>();");
        builder.AppendLine("        AddOption<ProductOptions>(options => options.PageSize = 20);");
        builder.AppendLine("    }");
        builder.AppendLine();
        builder.AppendLine("    public ProductService Build() => BuildService<ProductService>();");
        builder.AppendLine("}");
        builder.AppendLine();
        builder.AppendLine("var builder = new ProductServiceTestsBuilder();");
        builder.AppendLine("builder.Repository.Find(42).Returns(new Product(42, \"Keyboard\"));");
        builder.AppendLine("ProductService service = builder.Build();");
        builder.AppendLine("ILogger<ProductService> logger = builder.For<ILogger<ProductService>>();");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("`BuildService<TService>` inspects only the first public constructor returned by reflection and substitutes only unresolved parameters from that constructor. NSubstitute still requires proxyable interfaces or classes with overridable members. `AddScoped` and `AddTransient` capture one substitute, so their registrations do not create fresh doubles per scope or resolution. Registrations accumulate across builds. The builder does not dispose its temporary providers or scopes, its final provider, replaced scopes, or scoped/transient disposables; keep builders short-lived and do not use this helper when disposal verification matters. Call `For<T>` only after a successful build.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.Localization.Abstractions", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Depend on these interfaces from application code or implement them in a localization provider without referencing the ASP.NET Core core package:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Modules.Localization.Features;");
        builder.AppendLine();
        builder.AppendLine("public sealed class CultureMenu(");
        builder.AppendLine("    IListAvailableCultures cultures,");
        builder.AppendLine("    IGetCurrentCulture currentCulture,");
        builder.AppendLine("    ISetCulture setCulture)");
        builder.AppendLine("{");
        builder.AppendLine("    public Task<CultureInfoDto[]> ListAsync(CancellationToken token) => cultures.ListAsync(token);");
        builder.AppendLine("    public Task<CultureInfoDto> CurrentAsync(CancellationToken token) => currentCulture.GetCurrentCultureAsync(token);");
        builder.AppendLine("    public Task<CultureInfoDto> SelectAsync(string name, CancellationToken token) => setCulture.SetAsync(name, token);");
        builder.AppendLine("}");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("These contracts do not prescribe storage, request integration, cancellation guarantees, culture validation, or whether returned arrays are snapshots. Implementations own those semantics.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.Localization.Core", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Version `10.0.0` in the install command is the current workspace/root documentation version. This package version was not published at the time of review; when installing from NuGet, replace it with a version that is actually available.");
        builder.AppendLine();
        builder.AppendLine("Register `IHttpContextAccessor` before adding the localization module, bind the module section, and build through the extended builder:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Modules;");
        builder.AppendLine("using KamiSama.Modules.Localization;");
        builder.AppendLine();
        builder.AppendLine("var webBuilder = WebApplication.CreateBuilder(args);");
        builder.AppendLine("webBuilder.Services.AddHttpContextAccessor();");
        builder.AppendLine();
        builder.AppendLine("var builder = webBuilder.Extend()");
        builder.AppendLine("    .AddLocalizationModule(webBuilder.Configuration.GetSection(\"Localization\"));");
        builder.AppendLine();
        builder.AppendLine("var app = await builder.BuildAsync(CancellationToken.None);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("The effective request provider precedence is Accept-Language header, then query string, then cookie because each provider is inserted at the front. `SetCulture.SetAsync` validates configured metadata and appends a one-year response cookie; it does not change the current request, so the cookie participates on a later request and still loses to header or query values. The three feature methods complete synchronously and ignore cancellation. `ListAvailableCultures.ListAsync` exposes the mutable configured array directly, and options also accept mutable replacement arrays. `GetCurrentCulture` falls back only when the current UI culture is neutral and synthesizes metadata when no configured entry matches.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.Identity.Abstractions", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Inject only the feature interfaces needed by an application service. The Core package discovers its implementations during module registration, while another provider can implement the same contracts without depending on ASP.NET Core Identity:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Modules.Identity.Services.AccountSecurity;");
		builder.AppendLine("using KamiSama.Modules.Identity.Services.Authentication;");
        builder.AppendLine("using KamiSama.Modules.Identity.Services.Roles;");
        builder.AppendLine("using KamiSama.Modules.Identity.Services.Users;");
        builder.AppendLine();
        builder.AppendLine("public sealed class AccountFacade(");
		builder.AppendLine("    ILogin login,");
		builder.AppendLine("    IRefreshToken refreshToken,");
		builder.AppendLine("    ILogout logout,");
        builder.AppendLine("    IFindCurrentUser currentUser,");
        builder.AppendLine("    IListRoles listRoles,");
        builder.AppendLine("    IListActiveSessions sessions,");
        builder.AppendLine("    IChangePassword changePassword)");
        builder.AppendLine("{");
		builder.AppendLine("    public Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken token) => login.LoginAsync(request, token);");
		builder.AppendLine("    public Task<TokenPairDto> RefreshAsync(RefreshTokenRequest request, CancellationToken token) => refreshToken.RefreshAsync(request, token);");
		builder.AppendLine("    public Task LogoutAsync(CancellationToken token) => logout.LogoutAsync(token);");
        builder.AppendLine("    public Task<UserDto> CurrentAsync(CancellationToken token) => currentUser.GetCurrentUserAsync(token);");
        builder.AppendLine("    public Task<IReadOnlyList<ActiveSessionDto>> SessionsAsync(Guid userId, CancellationToken token) => sessions.ListAsync(userId, token);");
        builder.AppendLine("    public Task ChangePasswordAsync(ChangePasswordRequest request, CancellationToken token) => changePassword.ChangeAsync(request, token);");
        builder.AppendLine("}");
        builder.AppendLine("```");
        builder.AppendLine();
		builder.AppendLine("These are operation shapes, not an authorization boundary. `ILogin` accepts one user name or email value and returns both the authenticated user and a new session's tokens; `IRefreshToken` replaces tokens for the session represented by the supplied pair. `ILogout` and `ILogoutAll` rely on an implementation-defined current authenticated context. Implementations must authorize target user and role identifiers, avoid account-enumeration differences, define cancellation and transaction behavior, and protect token and password workflows. DTO arrays are mutable, and the contracts do not promise that search or update fields are honored by every implementation.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.Identity.Core", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** version `10.0.0` in the install command is the current workspace/root documentation version, but this package version was not published at the time of review. Keep the root-version command in repository documentation; use an actually published version when installing from NuGet.");
        builder.AppendLine();
        builder.AppendLine("Install exactly one provider package, pass its callback, and add authentication before authorization in the application pipeline:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Modules;");
        builder.AppendLine("using KamiSama.Modules.Identity;");
        builder.AppendLine();
        builder.AppendLine("var webBuilder = WebApplication.CreateBuilder(args);");
        builder.AppendLine("var builder = webBuilder.Extend()");
        builder.AppendLine("    .AddKamiSamaIdentityModule(");
        builder.AppendLine("        webBuilder.Configuration.GetSection(\"Identity\"),");
        builder.AppendLine("        webBuilder.Configuration.GetSection(\"Identity:Database\"),");
        builder.AppendLine("        registerIdentity: true,");
        builder.AppendLine("        useJwtAuth: true,");
        builder.AppendLine("        configureDbContext: database => database.AddPostgresqlIdentityDbContext());");
        builder.AppendLine();
        builder.AppendLine("var app = await builder.BuildAsync(CancellationToken.None);");
        builder.AppendLine("app.UseAuthentication();");
        builder.AppendLine("app.UseAuthorization();");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("The provider callback is nullable in the signature but mandatory in practice unless another registration adds the keyed concrete context. `BuildAsync` runs configured migration and seed work before returning the application, so startup needs database access and can fail or block while migration runs. The module configures authentication services but does not call `UseAuthentication`; place it before `UseAuthorization` and protected endpoints.");
        builder.AppendLine();
        builder.AppendLine("`registerIdentity: true, useJwtAuth: true` is the self-contained JWT configuration. `true, false` uses Identity application/external scheme defaults and requires the host's intended cookie setup. `false, true` configures JWT only but Core features still require externally registered Identity managers, stores, and token providers. `false, false` configures Identity scheme names without registering their handlers or Core dependencies, so it is usable only when the host supplies the complete Identity setup.");
        builder.AppendLine();
        builder.AppendLine("**Security limitations:** feature interfaces and implementations do not authorize the caller or verify that caller-controlled user IDs, role IDs, or session IDs may be operated on. Find/exists/reset behavior can disclose whether an account exists. `ResetPasswordAsync` looks up a user and generates its own reset token before applying the caller-supplied password; exposing it directly permits password reset without possession of an out-of-band token. `ChangePassword` authenticates without supplying a two-factor code, so password change fails for users whose two-factor authentication is enabled. Add endpoint authorization, ownership checks, uniform public responses, and a separate issued-token reset flow before exposing these services.");
        builder.AppendLine();
        builder.AppendLine("**Runtime and data limitations:** `UpdateUserRequest.Roles`, `UserSearchModel.RoleName`, and `UserSearchModel.OrderBy` are ignored. User-name/email search applies a second exact user-name predicate, so email-only and partial searches can unexpectedly return no rows. User creation can persist the user before confirmation or role assignment fails, and update/role/session workflows do not provide a cross-operation transaction or rollback. Many UserManager calls and feature paths do not propagate cancellation.");
        builder.AppendLine();
		builder.AppendLine("JWT bearer metadata validation is disabled, login does not reject disabled users, and the `isEnabled` claim is based on email confirmation rather than the DTO lockout calculation. Login resolves a matching user name before trying the same value as an email address, then creates a persistent session and returns its absolute access-token expiration. Logout operations require name-identifier and session claims from the active HTTP context; revocation invalidates later session validation but does not remove a cookie or bearer token from the client. Session validation touches and saves the session on authenticated traffic, refresh issuance performs repeated user/token lookups, and repositories save mutations immediately. User listing performs one role lookup per returned user and its unused `ConvertToDto` hook throws `NotImplementedException`, making the implementation dependent on its custom page-conversion path. Account for this database write/query amplification and do not call that conversion hook independently.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.Identity.Postgresql", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** version `10.0.0` above is the current workspace/root documentation version, but this provider version was not published at the time of review. Use an actually published version for NuGet installation.");
        builder.AppendLine();
        builder.AppendLine("Install this package with Identity Core and pass `database => database.AddPostgresqlIdentityDbContext()` as the module's provider callback. The callback registers the internal concrete context under the exact `postgresql` key; configure `Identity:Database:provider` as `postgresql`. Core runs configured migrations during `BuildAsync`, so startup requires a reachable PostgreSQL database and migration privileges.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.Identity.Sqlite", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** version `10.0.0` above is the current workspace/root documentation version, but this provider version was not published at the time of review. Use an actually published version for NuGet installation.");
        builder.AppendLine();
        builder.AppendLine("Install this package with Identity Core and pass `database => database.AddSqliteIdentityDbContext()` as the module's provider callback. The callback registers the internal concrete context under the exact `sqlite` key; configure `Identity:Database:provider` as `sqlite`. Core runs configured migrations during `BuildAsync`, so the process needs access to the SQLite file and its directory.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.Locations.Abstractions", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest package when this surface was reviewed; `10.0.0` itself was not available.");
        builder.AppendLine();
        builder.AppendLine("Inject the feature contracts into application services or controllers after a concrete implementation, normally Locations Core, has registered them:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Extensions.Paging;");
        builder.AppendLine("using KamiSama.Modules.Locations.Features;");
        builder.AppendLine();
        builder.AppendLine("public sealed class LocationsController(IListCities cities, IAddProvince addProvince)");
        builder.AppendLine("{");
        builder.AppendLine("    public Task<PagedResult<CityDto>> ListCitiesAsync(Guid provinceId, CancellationToken token)");
        builder.AppendLine("        => cities.ListAsync(new CitySearchModel(1, 20, provinceId, null, null, \"province\"), token);");
        builder.AppendLine();
        builder.AppendLine("    public Task<ProvinceDto> AddProvinceAsync(string name, CancellationToken token)");
        builder.AppendLine("        => addProvince.AddAsync(new AddProvinceRequest(name), token);");
        builder.AppendLine("}");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("This package contains contracts and data shapes only: it registers no services, controllers, endpoints, persistence, validation pipeline, authentication, or authorization. Core's city queries can filter by city-name substring, exact province id, or province-name substring; `OrderBy = \"province\"` sorts by province then city, while every other value sorts by city. Province queries always sort by name regardless of `OrderBy`. The contracts do not promise those implementation details for alternative providers.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.Locations.Core", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest package when this surface was reviewed; `10.0.0` itself was not available.");
        builder.AppendLine();
        builder.AppendLine("Install Core plus at least the selected provider package. Configure one provider key and connection string, pass a callback that registers that key, and finish through `BuildAsync` before resolving or using Locations features:");
        builder.AppendLine();
        builder.AppendLine("```json");
        builder.AppendLine("{");
        builder.AppendLine("  \"Locations\": {");
        builder.AppendLine("    \"initialization\": {");
        builder.AppendLine("      \"migrate\": true,");
        builder.AppendLine("      \"initialize\": false,");
        builder.AppendLine("      \"test-data\": false");
        builder.AppendLine("    },");
        builder.AppendLine("    \"database\": {");
        builder.AppendLine("      \"provider\": \"postgresql\",");
        builder.AppendLine("      \"connection-string\": \"Host=localhost;Database=locations;Username=app;Password=...\"");
        builder.AppendLine("    }");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Modules;");
        builder.AppendLine("using KamiSama.Modules.Locations;");
        builder.AppendLine();
        builder.AppendLine("var webBuilder = WebApplication.CreateBuilder(args);");
        builder.AppendLine("IConfigurationSection locations = webBuilder.Configuration.GetSection(\"Locations\");");
        builder.AppendLine();
        builder.AppendLine("ExtendedWebApplicationBuilder builder = webBuilder.Extend()");
        builder.AppendLine("    .AddLocationsModule(");
        builder.AppendLine("        locations,");
        builder.AppendLine("        locations.GetSection(\"database\"),");
        builder.AppendLine("        database => database.AddPostgresqlLocationsDbContext());");
        builder.AppendLine();
        builder.AppendLine("WebApplication app = await builder.BuildAsync(CancellationToken.None);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("The callback receives `IMultiProviderDbContextBuilder<LocationsDbContext>`. Use `AddPostgresqlLocationsDbContext` for configured key `postgresql` or `AddSqliteLocationsDbContext` for `sqlite`; keys are lowercased before resolution. A callback may register both installed providers, but configuration selects exactly one keyed context for a running host. The nullable callback is mandatory in a normal setup: without a matching keyed registration, post-build context resolution fails.");
        builder.AppendLine();
        builder.AppendLine("`BuildAsync` first runs module service registration, then builds the app, then initializes Locations. Initialization options are read from `Locations:initialization` under the named `Locations` options instance. The default fallback initializer runs EF migrations only when `migrate` is true; its `initialize` and `test-data` stages are no-ops. A registered `IDatabaseInitializer<LocationsDbContext>` can implement those seed stages. Migration therefore happens during startup and requires database connectivity, schema privileges, and a provider package containing compatible migrations.");
        builder.AppendLine();
        builder.AppendLine("Core discovers scoped feature and repository implementations and adds memory caching, but it maps no controllers or endpoints. Inject abstraction interfaces after build. Adds and updates do not perform duplicate-name checks. Adding or moving a city requires an existing province and otherwise throws `NotFoundException<Province>`. Province deletion is restricted by the relationship and can fail at save time while cities reference it. Repository mutations save immediately; list/find queries are tracked, and provider registrations enable lazy-loading proxies.");
        builder.AppendLine();
        builder.AppendLine("City name and province-name filters call `ToLower().Contains(...)` in the translated database query; matching and index use therefore depend on provider translation and collation. City order token `province` sorts by province then city, all other values sort by city, and province ordering always uses name. `IListCitiesByProvinceName` starts from `CitySearchModel.All`, so it returns all matching rows in a page-shaped result rather than applying a finite page. `City` represents its parent through a required `Province` navigation and exposes no separate public `ProvinceId` property.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.Locations.Postgresql", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest provider package when reviewed; `10.0.0` itself was not available.");
        builder.AppendLine();
        builder.AppendLine("Install this package with Locations Core, configure the database provider as `postgresql`, and pass `database => database.AddPostgresqlLocationsDbContext()` to `AddLocationsModule`. The callback registers `PostgresqlLocationsDbContext` under the exact `postgresql` key, enables lazy-loading proxies, uses `__EFMigrationsHistory_Locations`, and supplies this package's migrations. `BuildAsync` can apply pending migrations during startup, so the PostgreSQL database must be reachable and the application principal needs migration privileges.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.Locations.Sqlite", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest provider package when reviewed; `10.0.0` itself was not available.");
        builder.AppendLine();
        builder.AppendLine("Install this package with Locations Core, configure the database provider as `sqlite`, and pass `database => database.AddSqliteLocationsDbContext()` to `AddLocationsModule`. The callback registers `SqliteLocationsDbContext` under the exact `sqlite` key, enables lazy-loading proxies, uses `__EFMigrationsHistory_Locations`, and supplies this package's migrations. `BuildAsync` can apply pending migrations during startup, so the process needs write access to the SQLite database file and its directory.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.Ticketing.Abstractions", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest package when this surface was reviewed; `10.0.0` itself was not available.");
        builder.AppendLine();
        builder.AppendLine("Inject only the Ticketing feature contracts needed by an application service or controller after a concrete implementation has registered them:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Extensions.Paging;");
        builder.AppendLine("using KamiSama.Modules.Ticketing.Features.Tickets;");
        builder.AppendLine();
        builder.AppendLine("public sealed class TicketsController(IListTickets listTickets, IFindTicketById findTicket)");
        builder.AppendLine("{");
        builder.AppendLine("    public Task<PagedResult<TicketListItemDto>> ListAsync(Guid authorId, CancellationToken token)");
        builder.AppendLine("        => listTickets.ListAsync(");
        builder.AppendLine("            new TicketSearchModel(1, 20, null, null, authorId, [TicketStatus.Open], null, \"updatedat\"),");
        builder.AppendLine("            token);");
        builder.AppendLine();
        builder.AppendLine("    public Task<TicketDto> FindAsync(Guid id, CancellationToken token)");
        builder.AppendLine("        => findTicket.FindByIdAsync(id, token);");
        builder.AppendLine("}");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("This package contains contracts and data shapes only: it registers no services, controllers, endpoints, persistence, content storage, validation pipeline, authentication, or authorization. Alternative implementations define query and mutation semantics. Current Core permits unchanged ticket status, open or reopened to resolved, and resolved to reopened or closed; invalid transitions produce HTTP 409. Core ignores `TicketSearchModel.TicketCategoryId`; its comment update accepts both a method key and `UpdateTicketCommentRequest.CommentId` but uses only the request identifier. Treat request author identifiers and comment sides as untrusted input at an authenticated endpoint boundary.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.Ticketing.Core", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest package when this surface was reviewed; `10.0.0` itself was not available.");
        builder.AppendLine();
        builder.AppendLine("Install Core plus at least the selected provider package. Configure one provider key and connection string, pass the matching provider callback, and finish through `BuildAsync` before resolving Ticketing features:");
        builder.AppendLine();
        builder.AppendLine("```json");
        builder.AppendLine("{");
        builder.AppendLine("  \"Ticketing\": {");
        builder.AppendLine("    \"initialization\": {");
        builder.AppendLine("      \"migrate\": true,");
        builder.AppendLine("      \"initialize\": false,");
        builder.AppendLine("      \"test-data\": false");
        builder.AppendLine("    },");
        builder.AppendLine("    \"database\": {");
        builder.AppendLine("      \"provider\": \"postgresql\",");
        builder.AppendLine("      \"connection-string\": \"Host=localhost;Database=ticketing;Username=app;Password=...\"");
        builder.AppendLine("    }");
        builder.AppendLine("  }");
        builder.AppendLine("}");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Modules;");
        builder.AppendLine("using KamiSama.Modules.Ticketing;");
        builder.AppendLine();
        builder.AppendLine("var webBuilder = WebApplication.CreateBuilder(args);");
        builder.AppendLine("IConfigurationSection ticketing = webBuilder.Configuration.GetSection(\"Ticketing\");");
        builder.AppendLine();
        builder.AppendLine("ExtendedWebApplicationBuilder builder = webBuilder.Extend()");
        builder.AppendLine("    .AddTicketingModule(");
        builder.AppendLine("        ticketing,");
        builder.AppendLine("        ticketing.GetSection(\"database\"),");
        builder.AppendLine("        database => database.AddPostgresqlTicketingDbContext());");
        builder.AppendLine();
        builder.AppendLine("WebApplication app = await builder.BuildAsync(CancellationToken.None);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("`AddTicketingModule` only queues work. During `BuildAsync`, `ConfigureServices` binds named `ConnectionStringOption` and `DataInitializationOptions`, scans the Core assembly for attributed scoped services, creates `IMultiProviderDbContextBuilder<TicketingDbContext>`, selects `__EFMigrationsHistory_Ticketing`, and invokes the provider callback. The callback may register both installed providers, but the lowercased configured key selects one base-context alias. Although nullable in the signature, the callback is required in a normal host unless an equivalent keyed context registration already exists.");
        builder.AppendLine();
        builder.AppendLine("After the application is built, Ticketing creates a scope, resolves `IDatabaseInitializer<TicketingDbContext>` or a migration-only default initializer, reads the named initialization options, and runs selected stages. The default initializer migrates when `migrate` is true; `initialize` and `test-data` do no work unless the host registers a custom initializer. Startup therefore needs database connectivity, schema privileges, and compatible provider migrations. Core maps no controllers, endpoints, middleware, authentication, or authorization.");
        builder.AppendLine();
        builder.AppendLine("**Registration limitation:** `DeleteTicketCategory`, `ListTicketCategories`, and `ExistsTicketCategoryByName` carry scoped auto-registration attributes for specialized contracts they do not implement. These descriptors cannot create the requested service. Service-provider validation can therefore fail during `BuildAsync`; without validation, resolving `IDeleteTicketCategory`, `IListTicketCategories`, or `IExistsTicketCategoryByName` fails. The other attributed features and both repositories are assignable registrations.");
        builder.AppendLine();
        builder.AppendLine("**Query and mutation limitations:** ticket search applies text across title/comments, status, priority, and ticket-or-comment author filters but ignores `TicketCategoryId`. It recognizes `priority`, `status`, and `updatedat`; every other token orders by priority then update time. Category name lookup/filtering lowercases both operands, category names have no unique database index, and duplicate checks are separate read-before-write operations. Repository mutations save immediately with no cross-operation transaction supplied by these features.");
        builder.AppendLine();
        builder.AppendLine("`UpdateTicketComment.UpdateAsync` ignores its method key and targets `request.CommentId`. Comment and attachment additions trust caller-supplied author identifiers, and comment addition also trusts the requested user/operator side. Comment update and attachment addition compare only author identifiers; attachment removal and ticket-state update perform no ownership check. Ticket-state updates permit unchanged status, open or reopened to resolved, and resolved to reopened or closed; invalid transitions throw `ConflictException`. Other mutation features do not consistently call `Ticket.IsEditable`. Add authenticated endpoint authorization, ownership and side checks, and identifier-consistency validation before exposing these services.");
        builder.AppendLine();
        builder.AppendLine("Entities store external attachment content IDs only. Provider migrations create required category-to-ticket, ticket-to-comment, and comment-to-attachment relationships with cascading deletes, non-unique relationship indexes, 50/100/400 character limits, and integer enums. Provider registration enables lazy-loading proxies; list and lookup queries are tracked, so complete DTO mapping depends on navigations being available. No controllers exist in this package.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.Ticketing.Postgresql", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest provider package when reviewed; `10.0.0` itself was not available.");
        builder.AppendLine();
        builder.AppendLine("Install this package with Ticketing Core, configure the database provider as `postgresql`, and pass `database => database.AddPostgresqlTicketingDbContext()` to `AddTicketingModule`. The callback registers `PostgresqlTicketingDbContext` under the exact `postgresql` key, enables lazy-loading proxies, uses `__EFMigrationsHistory_Ticketing`, and applies the shared PostgreSQL provider's process-wide legacy timestamp and infinity-conversion switches. Its V1_0_0 migration creates the four Ticketing tables and cascading relationships. `BuildAsync` can apply it during startup, so PostgreSQL must be reachable and the application principal needs migration privileges.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Modules.Ticketing.Sqlite", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest provider package when reviewed; `10.0.0` itself was not available.");
        builder.AppendLine();
        builder.AppendLine("Install this package with Ticketing Core, configure the database provider as `sqlite`, and pass `database => database.AddSqliteTicketingDbContext()` to `AddTicketingModule`. The callback registers `SqliteTicketingDbContext` under the exact `sqlite` key, enables lazy-loading proxies, uses `__EFMigrationsHistory_Ticketing`, and supplies a V1_0_0 migration that creates the four Ticketing tables and cascading relationships. `BuildAsync` can apply it during startup, so the process needs write access to the SQLite database file and its directory.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Extensions.RestSharp", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Register an `HttpClient` before adding the RestSharp services. Inject `IRestBuilder`, start each request with `ForServiceUrl`, add request data, and then call the required HTTP verb:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Extensions.RestSharp;");
        builder.AppendLine();
        builder.AppendLine("services.AddHttpClient();");
        builder.AppendLine("services.AddKamiSamaRestSharp();");
        builder.AppendLine();
        builder.AppendLine("ProductDto product = await restBuilder");
        builder.AppendLine("    .ForServiceUrl(\"https://api.example.com\", \"products/{id}\")");
        builder.AppendLine("    .AddUrlSegment(\"id\", 42)");
        builder.AppendLine("    .GetAsync<ProductDto>(cancellationToken);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("`IRestBuilder` is scoped and stores the current request. Call `ForServiceUrl` before configuring every request, and do not share one builder across concurrent operations.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.ExternalServices.Exceptions", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Throw these exceptions at an external-service boundary so KamiSama problem-details handling can expose a consistent localization key, arguments, and status code:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.ExternalServices.Exceptions.Exceptions;");
        builder.AppendLine();
        builder.AppendLine("if (provider is null)");
        builder.AppendLine("    throw new CannotFindExternalServiceException(\"Email\", configuredProvider);");
        builder.AppendLine();
        builder.AppendLine("if (response.TimedOut)");
        builder.AppendLine("    throw new ExternalServiceTimedOutException(\"Email\", \"The provider did not respond in time.\");");
        builder.AppendLine();
        builder.AppendLine("if (!response.IsValid)");
        builder.AppendLine("    throw new InvalidResponseForExternalServiceException(\"Email\", \"The provider response was invalid.\");");
        builder.AppendLine("```");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.ExternalServices.Email.Abstractions", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Inject `ISendEmail` into application code and pass a provider-neutral request. Set `IsHtml` only when the body contains HTML:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.ExternalServices.Email.Features;");
        builder.AppendLine();
        builder.AppendLine("var request = new SendEmailRequest(");
        builder.AppendLine("    \"customer@example.com\",");
        builder.AppendLine("    \"Order received\",");
        builder.AppendLine("    \"<p>Thank you for your order.</p>\",");
        builder.AppendLine("    IsHtml: true);");
        builder.AppendLine();
        builder.AppendLine("await sendEmail.SendEmailAsync(request, cancellationToken);");
        builder.AppendLine("```");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.ExternalServices.Email.Core", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Add the core module with a configuration section whose `email` value names the keyed provider. The built-in `mock` provider only logs method entry; add a transport package and use its key for real delivery:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.ExternalServices.Email;");
        builder.AppendLine("using KamiSama.Modules;");
        builder.AppendLine();
        builder.AppendLine("var webBuilder = WebApplication.CreateBuilder(args);");
        builder.AppendLine("var builder = webBuilder.Extend()");
        builder.AppendLine("    .AddCoreEmailServices(webBuilder.Configuration.GetSection(\"EmailDefaults\"));");
        builder.AppendLine();
        builder.AppendLine("var app = await builder.BuildAsync(CancellationToken.None);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("Configure `EmailDefaults:email` as `mock` for the built-in no-delivery implementation or as the key registered by an installed provider. If no keyed `ISendEmail` exists for that value, the dispatcher throws `CannotFindExternalServiceException`.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.ExternalServices.Email.Smtp", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Add the SMTP module with the section that contains `host`, `port`, `username`, `password`, `use-ssl`, `sender-address`, and `sender-name`:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.ExternalServices.Email.Smtp;");
        builder.AppendLine();
        builder.AppendLine("builder.AddSmtpEmailServiceModule(");
        builder.AppendLine("    webBuilder.Configuration.GetSection(\"Email:Smtp\"));");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("**Known runtime defect:** the internal SMTP sender currently throws `InvalidOperationHttpException` when `SmtpOptions.IsValid()` returns `true`. Complete settings are therefore rejected before any SMTP send is attempted, while incomplete settings continue and fail later. This documentation does not claim successful delivery; the runtime condition must be corrected in a future code change before relying on this provider.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.ExternalServices.Sms.Abstractions", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Version `10.0.0` in the install command is the current workspace/root documentation version. This package version was not published at the time of review; when installing from NuGet, replace it with a version that is actually available:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.ExternalServices.Sms.Features;");
        builder.AppendLine();
        builder.AppendLine("var request = new SendSmsRequest(\"+15551234567\", \"Your code is 123456\");");
        builder.AppendLine("await sendSms.SendSmsAsync(request, cancellationToken);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("This package defines contracts only. It does not register a provider, select one, or send an SMS; the injected `ISendSms` implementation determines delivery and error behavior.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.ExternalServices.Sms.Core", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Version `10.0.0` in the install command is the current workspace/root documentation version. This package version was not published at the time of review; when installing from NuGet, replace it with a version that is actually available.");
        builder.AppendLine();
        builder.AppendLine("Add the core module with a configuration section whose `sms` value is exactly `mock`, `kavenegar`, or `neo-zarin`. Add the selected provider module, then build through the extended builder; merely calling an `Add*Module` method does not run module service registration:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.ExternalServices.Sms;");
        builder.AppendLine("using KamiSama.Modules;");
        builder.AppendLine();
        builder.AppendLine("var webBuilder = WebApplication.CreateBuilder(args);");
        builder.AppendLine("var builder = webBuilder.Extend()");
        builder.AppendLine("    .AddSmsCoreServicesModule(webBuilder.Configuration.GetSection(\"SmsDefaults\"));");
        builder.AppendLine();
        builder.AppendLine("var app = await builder.BuildAsync(CancellationToken.None);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("The core module registers a scoped unkeyed `ISendSms` dispatcher and the scoped keyed `mock` implementation. Provider packages register scoped keyed implementations under `kavenegar` and `neo-zarin`; application code normally injects unkeyed `ISendSms`. The mock logs method entry and does not deliver a message.");
        builder.AppendLine();
        builder.AppendLine("**Runtime caveats:** an unknown configured key actually fails in `GetRequiredKeyedService` with `InvalidOperationException`; the following null check and `CannotFindExternalServiceException` are not reached. The dispatcher returns the provider task without awaiting it, so only exceptions thrown synchronously while invoking the provider are wrapped as `InvalidResponseForExternalServiceException`; exceptions faulting the returned task are not logged or wrapped. `HttpExceptionBase` exceptions and cancellation behavior remain provider-specific.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.ExternalServices.Sms.Kavenegar", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Version `10.0.0` in the install command is the current workspace/root documentation version. This package version was not published at the time of review; when installing from NuGet, replace it with a version that is actually available.");
        builder.AppendLine();
        builder.AppendLine("Load `api-key` from a secret store or protected configuration and optionally configure `sender-phone-number`. Select the exact `kavenegar` key in the core defaults section, add both modules, and finish with `Build` or `BuildAsync` so their scoped registrations are applied:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.ExternalServices.Sms;");
        builder.AppendLine("using KamiSama.ExternalServices.Sms.Kavenegar;");
        builder.AppendLine("using KamiSama.Modules;");
        builder.AppendLine();
        builder.AppendLine("var webBuilder = WebApplication.CreateBuilder(args);");
        builder.AppendLine("var builder = webBuilder.Extend()");
        builder.AppendLine("    .AddSmsCoreServicesModule(webBuilder.Configuration.GetSection(\"SmsDefaults\"))");
        builder.AppendLine("    .AddKavenegarSmsServiceModule(webBuilder.Configuration.GetSection(\"Sms:Kavenegar\"));");
        builder.AppendLine();
        builder.AppendLine("var app = await builder.BuildAsync(CancellationToken.None);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("The provider is scoped and keyed as `kavenegar`; the core package supplies the scoped unkeyed dispatcher used by callers. Never commit the Kavenegar API key or include it in examples, logs, or error messages.");
        builder.AppendLine();
        builder.AppendLine("**Known runtime defect:** the internal sender throws `InvalidOperationHttpException` when `KavenegarSmsOptions.IsValid()` returns `true`. A configured API key is rejected before any send, while a missing key continues into provider construction. Successful delivery is not claimed until that condition is corrected. In addition, the Kavenegar SDK call is synchronous, the method returns `Task.CompletedTask`, and the supplied cancellation token is ignored; cancellation cannot stop an in-progress send.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.ExternalServices.Sms.NeoZarin", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Version `10.0.0` in the install command is the current workspace/root documentation version. This package version was not published at the time of review; when installing from NuGet, replace it with a version that is actually available.");
        builder.AppendLine();
        builder.AppendLine("Register `HttpClient` and KamiSama RestSharp before adding the SMS modules. Select the exact `neo-zarin` key in core defaults and bind `base-url`, `username`, `password`, `sms-api-path`, `sms-sender-number`, and `sms-api-key` from protected configuration:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Extensions.RestSharp;");
        builder.AppendLine("using KamiSama.ExternalServices.Sms;");
        builder.AppendLine("using KamiSama.ExternalServices.Sms.NeoZarin;");
        builder.AppendLine("using KamiSama.Modules;");
        builder.AppendLine();
        builder.AppendLine("var webBuilder = WebApplication.CreateBuilder(args);");
        builder.AppendLine("webBuilder.Services.AddHttpClient();");
        builder.AppendLine("webBuilder.Services.AddKamiSamaRestSharp();");
        builder.AppendLine();
        builder.AppendLine("var builder = webBuilder.Extend()");
        builder.AppendLine("    .AddSmsCoreServicesModule(webBuilder.Configuration.GetSection(\"SmsDefaults\"))");
        builder.AppendLine("    .AddNeoZarinSmsModule(webBuilder.Configuration.GetSection(\"Sms:NeoZarin\"));");
        builder.AppendLine();
        builder.AppendLine("var app = await builder.BuildAsync(CancellationToken.None);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("The provider is scoped and keyed as `neo-zarin`; the core package supplies the scoped unkeyed dispatcher. Store the username, password, and SMS API key in a secret provider, never source control. The default base URL is plain HTTP, so configure an HTTPS provider endpoint when available. If request execution is reached, the cancellation token is forwarded to RestSharp.");
        builder.AppendLine();
        builder.AppendLine("**Known runtime defect:** the internal sender throws `InvalidOperationHttpException` when `NeoZarinSmsOptions.IsValidForSms()` returns `true`. Complete settings are rejected before any HTTP request, while incomplete settings continue toward request construction. Successful delivery is not claimed until that condition is corrected.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.IranSystem", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Create an `IranSystemEncoding` instance and use its string-based methods for complete buffers:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.IranSystem;");
        builder.AppendLine();
        builder.AppendLine("var encoding = new IranSystemEncoding();");
        builder.AppendLine("string text = encoding.GetString(iranSystemBytes);");
        builder.AppendLine("byte[] bytes = encoding.GetBytes(text);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("Iran System stores contextual glyph shapes, so decoded Persian text contains Arabic presentation-form characters rather than normalized letters. Encoding requires those exact mapped code points; unsupported characters are written as `0xFF`, which decodes as a non-breaking space.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Extensions.Logging", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Import the logging extension and inject an `ILogger<T>` into the service that emits method-entry events:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Extensions.Logging;");
        builder.AppendLine("using Microsoft.Extensions.Logging;");
        builder.AppendLine();
        builder.AppendLine("public sealed class OrderService(ILogger<OrderService> logger)");
        builder.AppendLine("{");
        builder.AppendLine("    public void Process(Guid orderId)");
        builder.AppendLine("    {");
        builder.AppendLine("        logger.LogMethodEntry(argsToLog: orderId);");
        builder.AppendLine("    }");
        builder.AppendLine("}");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("Enable the `Trace` level for the relevant environment and category, for example with `Logging:LogLevel:Default` set to `Trace`. Argument values are written to logs, so select them deliberately and never include secrets, credentials, tokens, personal data, or other sensitive information.");
        builder.AppendLine();
    }
    if (library.Name.Equals("KamiSama.Extensions.NLog", StringComparison.OrdinalIgnoreCase))
    {
        builder.AppendLine("Register the extension assembly in `NLog.config`, then select the renderer that matches the required timestamp shape:");
        builder.AppendLine();
        builder.AppendLine("```xml");
        builder.AppendLine("<nlog>");
        builder.AppendLine("  <extensions>");
        builder.AppendLine("    <add assembly=\"KamiSama.Extensions.NLog\" />");
        builder.AppendLine("  </extensions>");
        builder.AppendLine("  <targets>");
        builder.AppendLine("    <target xsi:type=\"File\" name=\"file\" fileName=\"${baseDir}/app.log\"");
        builder.AppendLine("            layout=\"${persian-date:format=yyyy/MM/dd HH\\:mm\\:ss.fff} ${message}\" />");
        builder.AppendLine("  </targets>");
        builder.AppendLine("</nlog>");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("The available renderer names are `persian-date`, `persian-longDate`, and `persian-shortDate`. To password-protect archives, assign the NLog file compressor in application startup:");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine("using KamiSama.Extensions.NLog;");
        builder.AppendLine("using NLog.Targets;");
        builder.AppendLine();
        builder.AppendLine("string archivePassword = Environment.GetEnvironmentVariable(\"NLOG_ARCHIVE_PASSWORD\")");
        builder.AppendLine("    ?? throw new InvalidOperationException(\"NLOG_ARCHIVE_PASSWORD is not configured.\");");
        builder.AppendLine();
        builder.AppendLine("PasswordFunc passwordFunc = (fileName, archiveFileName) => archivePassword;");
        builder.AppendLine("ConcurrentFileTarget.FileCompressor = new EncryptedZipArchiveFileCompressor(passwordFunc);");
        builder.AppendLine("```");
        builder.AppendLine();
        builder.AppendLine("Resolve archive passwords from a secret store or protected configuration. Never hardcode them in source code or `NLog.config`.");
        builder.AppendLine();
    }
    builder.AppendLine("## Namespaces");
    builder.AppendLine();
    foreach (var group in library.Types.GroupBy(t => t.Namespace).OrderBy(g => g.Key))
    {
        builder.AppendLine($"- [{Markdown(group.Key)}]({Slug(group.Key)}/index.md) ({group.Count()} types)");
    }

    builder.AppendLine();
    builder.AppendLine("## Types");
    builder.AppendLine();
    foreach (var type in library.Types)
    {
        builder.AppendLine($"- [{Markdown(type.FullName)}]({Slug(type.Namespace)}/{TypeFolderName(type)}/index.md) - {Markdown(type.Description)}");
    }

    File.WriteAllText(Path.Combine(libraryRoot, "index.md"), builder.ToString(), Encoding.UTF8);
}

static void WriteNamespaceIndex(string namespaceRoot, LibraryDoc library, string namespaceName, List<TypeDoc> types)
{
    var builder = new StringBuilder();
    builder.AppendLine($"# {namespaceName}");
    builder.AppendLine();
    builder.AppendLine($"[Back to {Markdown(library.Name)}](../index.md)");
    builder.AppendLine();
    builder.AppendLine("| Type | Kind | Description | Source |");
    builder.AppendLine("| --- | --- | --- | --- |");
    foreach (var type in types.OrderBy(t => t.Name))
    {
        builder.AppendLine($"| [{Markdown(type.Name)}]({TypeFolderName(type)}/index.md) | {type.Kind} | {Markdown(type.Description)} | [source]({type.SourceUrl}) |");
    }

    File.WriteAllText(Path.Combine(namespaceRoot, "index.md"), builder.ToString(), Encoding.UTF8);
}

static void WriteTypePage(string namespaceRoot, LibraryDoc library, TypeDoc type)
{
    var typeRoot = Path.Combine(namespaceRoot, TypeFolderName(type));
    Directory.CreateDirectory(typeRoot);

    var builder = new StringBuilder();
    builder.AppendLine($"# {type.Name}");
    builder.AppendLine();
    builder.AppendLine($"<a id=\"{Anchor(type.Name)}\"></a>");
    builder.AppendLine();
    builder.AppendLine($"[Back to namespace](../index.md) | [Back to {Markdown(library.Name)}](../../index.md) | [Back to package index](../../../index.md)");
    builder.AppendLine();
    builder.AppendLine($"Source: [{Markdown(type.SourceFile)}:{type.Line}]({type.SourceUrl})");
    builder.AppendLine();
    builder.AppendLine($"Namespace: `{Markdown(type.Namespace)}`");
    builder.AppendLine();
    builder.AppendLine($"Kind: `{type.Kind}`");
    builder.AppendLine();
    builder.AppendLine("## Description");
    builder.AppendLine();
    builder.AppendLine(type.Description);
    builder.AppendLine();
    builder.AppendLine("## Declaration");
    builder.AppendLine();
    builder.AppendLine("```csharp");
    builder.AppendLine(type.Signature);
    builder.AppendLine("```");
    builder.AppendLine();

    if (!string.IsNullOrWhiteSpace(type.Remarks))
    {
        builder.AppendLine("## Remarks");
        builder.AppendLine();
        builder.AppendLine(type.Remarks);
        builder.AppendLine();
    }

    if (!string.IsNullOrWhiteSpace(type.Example))
    {
        builder.AppendLine("## Example");
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine(type.Example.Trim());
        builder.AppendLine("```");
        builder.AppendLine();
    }

    WriteConstructors(builder, type);
    WriteMemberList(builder, type);
    File.WriteAllText(Path.Combine(typeRoot, "index.md"), builder.ToString(), Encoding.UTF8);

    foreach (var member in type.Members)
    {
        WriteMemberPage(typeRoot, library, type, member);
    }
}

static void WriteConstructors(StringBuilder builder, TypeDoc type)
{
    builder.AppendLine("## Constructors");
    builder.AppendLine();
    if (type.Constructors.Count == 0)
    {
        builder.AppendLine("This type does not declare a non-private constructor in source.");
        builder.AppendLine();
        return;
    }

    foreach (var constructor in type.Constructors)
    {
        builder.AppendLine($"### {Markdown(constructor.Name)}");
        builder.AppendLine();
        builder.AppendLine($"[source]({constructor.SourceUrl})");
        builder.AppendLine();
        builder.AppendLine(constructor.Description);
        builder.AppendLine();
        builder.AppendLine("```csharp");
        builder.AppendLine(constructor.Signature);
        builder.AppendLine("```");
        builder.AppendLine();
        WriteParameterTable(builder, constructor.Parameters);
    }
}

static void WriteMemberList(StringBuilder builder, TypeDoc type)
{
    builder.AppendLine("## Members");
    builder.AppendLine();
    if (type.Members.Count == 0)
    {
        builder.AppendLine("No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.");
        builder.AppendLine();
        return;
    }

    foreach (var group in type.Members.GroupBy(m => m.Kind).OrderBy(g => g.Key))
    {
        builder.AppendLine($"### {Plural(group.Key)}");
        builder.AppendLine();
        builder.AppendLine("| Member | Description |");
        builder.AppendLine("| --- | --- |");
        foreach (var member in group.OrderBy(m => m.Name))
        {
            builder.AppendLine($"| [{Markdown(member.Name)}]({member.FileName}) | {Markdown(member.Description)} |");
        }

        builder.AppendLine();
    }
}

static void WriteMemberPage(string typeRoot, LibraryDoc library, TypeDoc type, MemberDoc member)
{
    var builder = new StringBuilder();
    builder.AppendLine($"# {member.Name}");
    builder.AppendLine();
    builder.AppendLine($"[Back to {Markdown(type.Name)}](index.md) | [Back to namespace](../index.md) | [Back to {Markdown(library.Name)}](../../index.md)");
    builder.AppendLine();
    builder.AppendLine($"Source: [{Markdown(member.SourceFile)}:{member.Line}]({member.SourceUrl})");
    builder.AppendLine();
    builder.AppendLine($"Type: `{Markdown(type.FullName)}`");
    builder.AppendLine();
    builder.AppendLine($"Kind: `{member.Kind}`");
    builder.AppendLine();
    builder.AppendLine("## Description");
    builder.AppendLine();
    builder.AppendLine(member.Description);
    builder.AppendLine();
    builder.AppendLine("## Declaration");
    builder.AppendLine();
    builder.AppendLine("```csharp");
    builder.AppendLine(member.Signature);
    builder.AppendLine("```");
    builder.AppendLine();

    if (member.TypeParameters.Count > 0)
    {
        builder.AppendLine("## Type Parameters");
        builder.AppendLine();
        builder.AppendLine("| Name | Description |");
        builder.AppendLine("| --- | --- |");
        foreach (var parameter in member.TypeParameters)
        {
            builder.AppendLine($"| `{Markdown(parameter.Name)}` | {Markdown(parameter.Description)} |");
        }

        builder.AppendLine();
    }

    if (member.Kind is "Method" or "Indexer" or "Operator")
    {
        WriteParameterTable(builder, member.Parameters);
        if (!string.IsNullOrWhiteSpace(member.ReturnType) && member.ReturnType != "void")
        {
            builder.AppendLine("## Returns");
            builder.AppendLine();
            builder.AppendLine("| Type | Description |");
            builder.AppendLine("| --- | --- |");
            builder.AppendLine($"| `{Markdown(member.ReturnType)}` | {Markdown(string.IsNullOrWhiteSpace(member.Returns) ? $"Returns a `{member.ReturnType}` value." : member.Returns)} |");
            builder.AppendLine();
        }
    }
    else
    {
        builder.AppendLine("## Value");
        builder.AppendLine();
        builder.AppendLine("| Detail | Description |");
        builder.AppendLine("| --- | --- |");
        builder.AppendLine($"| `{Markdown(member.Kind)}` | {Markdown(member.Value)} |");
        builder.AppendLine();
    }

    if (!string.IsNullOrWhiteSpace(member.Remarks))
    {
        builder.AppendLine("## Remarks");
        builder.AppendLine();
        builder.AppendLine(member.Remarks);
        builder.AppendLine();
    }

    builder.AppendLine("## Example");
    builder.AppendLine();
    if (string.IsNullOrWhiteSpace(member.Example))
    {
        builder.AppendLine("No concise standalone example is available yet.");
    }
    else
    {
        builder.AppendLine("```csharp");
        builder.AppendLine(member.Example.Trim());
        builder.AppendLine("```");
    }

    builder.AppendLine();
    File.WriteAllText(Path.Combine(typeRoot, member.FileName), builder.ToString(), Encoding.UTF8);
}

static void WriteParameterTable(StringBuilder builder, List<ParameterDoc> parameters)
{
    builder.AppendLine("## Parameters");
    builder.AppendLine();
    if (parameters.Count == 0)
    {
        builder.AppendLine("This member does not declare parameters.");
        builder.AppendLine();
        return;
    }

    builder.AppendLine("| Name | Type | Default | Description |");
    builder.AppendLine("| --- | --- | --- | --- |");
    foreach (var parameter in parameters)
    {
        var name = parameter.IsExtensionReceiver ? $"{parameter.Name} (extension receiver)" : parameter.Name;
        if (parameter.IsOut)
        {
            name += " (out)";
        }
        else if (parameter.IsRef)
        {
            name += " (ref)";
        }

        builder.AppendLine($"| `{Markdown(name)}` | `{Markdown(parameter.Type)}` | `{Markdown(string.IsNullOrWhiteSpace(parameter.DefaultValue) ? "-" : parameter.DefaultValue)}` | {Markdown(parameter.Description)} |");
    }

    builder.AppendLine();
}

static void WriteMkDocs(string docsRoot, List<LibraryDoc> libraries, string docsVersion)
{
    var builder = new StringBuilder();
    builder.AppendLine("site_name: KamiSama.Extensions");
    builder.AppendLine("site_description: Developer documentation for the KamiSama.Extensions libraries.");
    builder.AppendLine("docs_dir: content");
    builder.AppendLine("site_dir: site");
    builder.AppendLine("extra:");
    builder.AppendLine($"  version: !ENV [KAMISAMA_DOCS_VERSION, \"{docsVersion}\"]");
    builder.AppendLine("theme:");
    builder.AppendLine("  name: readthedocs");
    builder.AppendLine("markdown_extensions:");
    builder.AppendLine("  - tables");
    builder.AppendLine("  - toc:");
    builder.AppendLine("      permalink: true");
    builder.AppendLine("nav:");
    builder.AppendLine("  - Home: index.md");
    builder.AppendLine("  - API:");
    builder.AppendLine("      - Package Index: api/index.md");
    builder.AppendLine("      - Symbol Index: api/symbols.md");
    foreach (var library in libraries)
    {
        builder.AppendLine($"      - {YamlQuote(library.Name)}:");
        builder.AppendLine($"          - Overview: api/{library.Slug}/index.md");
        foreach (var namespaceGroup in library.Types.GroupBy(t => t.Namespace).OrderBy(g => g.Key))
        {
            builder.AppendLine($"          - {YamlQuote(namespaceGroup.Key)}:");
            builder.AppendLine($"              - Overview: api/{library.Slug}/{Slug(namespaceGroup.Key)}/index.md");
            foreach (var type in namespaceGroup.OrderBy(t => t.Name))
            {
                builder.AppendLine($"              - {YamlQuote(type.Name)}: api/{library.Slug}/{Slug(type.Namespace)}/{TypeFolderName(type)}/index.md");
            }
        }
    }

    var topicFiles = Directory.Exists(Path.Combine(docsRoot, "content", "topics"))
        ? Directory.EnumerateFiles(Path.Combine(docsRoot, "content", "topics"), "*.md").OrderBy(path => path).ToList()
        : [];
    if (topicFiles.Count > 0)
    {
        builder.AppendLine("  - Topic Guides:");
        foreach (var topic in topicFiles)
        {
            builder.AppendLine($"      - {YamlQuote(Path.GetFileNameWithoutExtension(topic))}: topics/{Path.GetFileName(topic)}");
        }
    }

    File.WriteAllText(Path.Combine(docsRoot, "mkdocs.yml"), builder.ToString(), Encoding.UTF8);
}

static string TypeRelativePath(LibraryDoc library, TypeDoc type) =>
    $"{library.Slug}/{Slug(type.Namespace)}/{TypeFolderName(type)}/index.md";

static string TypeFolderName(TypeDoc type) =>
    Slug(type.FullName);

static string MemberFileName(string kind, string name, int line) =>
    Slug(kind + "-" + name + "-" + line) + ".md";

static string ProjectSlug(string value) =>
    Slug(value.Replace("KamiSama.", "", StringComparison.OrdinalIgnoreCase));

static string Slug(string value)
{
    var normalized = value
        .Replace("(global namespace)", "global", StringComparison.OrdinalIgnoreCase)
        .Replace("<", "-")
        .Replace(">", "")
        .Replace(",", "-")
        .Replace(".", "-")
        .Replace("_", "-")
        .Replace("[]", "-array")
        .ToLowerInvariant();
    normalized = Regex.Replace(normalized, "[^a-z0-9]+", "-").Trim('-');
    return string.IsNullOrWhiteSpace(normalized) ? "global" : normalized;
}

static string Anchor(string value) => Slug(value);

static string Markdown(string value) => value.Replace("|", "\\|").Replace("\r", " ").Replace("\n", " ");

static string YamlQuote(string value) => "\"" + value.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";

static string NormalizeText(string value) =>
    Regex.Replace(value.Replace("\r\n", "\n").Replace('\r', '\n'), "\\s+", " ").Trim();

static string DeveloperDescription(string value, string fallback)
{
    var text = NormalizeText(string.IsNullOrWhiteSpace(value) ? fallback : value);
    if (text.Length < 25 || text.EndsWith(" for", StringComparison.OrdinalIgnoreCase))
    {
        text = NormalizeText(fallback);
    }

    if (SentenceCount(text) < 2)
    {
        text = EnsureSentence(text) + " Use it with the surrounding package APIs when composing application code.";
    }

    return text;
}

static int SentenceCount(string text) =>
    Regex.Matches(text, @"[.!?](\s|$)").Count;

static string EnsureSentence(string text) =>
    Regex.IsMatch(text, @"[.!?]$") ? text : text + ".";

static string InstallCommand(string packageId, string docsVersion) =>
    $"dotnet add package {packageId} --version {docsVersion}";

static string PackageDescription(ProjectDoc project)
{
    var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        ["KamiSama.Chassis.Commons"] = "Reusable feature and repository base classes for common CRUD-style application flows. Use this package when building service-layer features around entities, DTOs, repositories, and paged results.",
        ["KamiSama.Chassis.Commons.Abstractions"] = "Feature and repository contracts for the KamiSama chassis layer. Reference this package from application or module projects that need to depend on abstractions instead of concrete implementations.",
        ["KamiSama.Chassis.HttpExceptions"] = "HTTP-oriented exception types with status codes, localization keys, and extra problem details. Use these exceptions to keep application errors consistent across ASP.NET Core APIs.",
        ["KamiSama.Chassis.ProblemDetails"] = "ASP.NET Core ProblemDetails integration for converting KamiSama HTTP exceptions into standardized API error responses.",
        ["KamiSama.Extensions.Core"] = "Common .NET extension methods for byte and string conversion, hashing, symmetric and RSA cryptography, Persian dates, streams, arrays, queues, logging, and TimeSpan creation. Also includes lightweight paging records and an IQueryable<T> helper for producing paged results.",
        ["KamiSama.Extensions.DependencyInjection"] = "Automatically register attributed service implementations with Microsoft.Extensions.DependencyInjection by scanning selected assemblies. Choose transient, scoped, or singleton lifetimes, keyed or unkeyed registrations, explicit or inferred service types, and single or multiple registrations.",
        ["KamiSama.Extensions.Json"] = "System.Text.Json convenience extensions for serialization, deserialization, dynamic JSON object graphs, and converter registration. Includes converters for BigInteger, hexadecimal byte arrays, TimeSpan, and discriminator-based polymorphic types.",
        ["KamiSama.Extensions.Logging"] = "Trace method entry through Microsoft.Extensions.Logging without repeating caller names. LogMethodEntry emits a Trace event containing the inferred calling type and member name and can include selected argument values for diagnostics.",
        ["KamiSama.Extensions.NLog"] = "Provides three NLog layout renderers for Persian-calendar timestamps and an IFileCompressor implementation for creating password-protected ZIP archives through SharpZipLib.",
        ["KamiSama.Modules"] = "Composable ASP.NET Core modules that register services before application build and apply middleware or endpoints afterward. Use this package to assemble startup behavior in explicit module order through `ExtendedWebApplicationBuilder`.",
        ["KamiSama.Extensions.RestSharp"] = "Fluent RestSharp request construction and dependency injection registration for HTTP integrations. Build GET, POST, PUT, and DELETE requests with parameters, headers, URL segments, files, or JSON bodies, then deserialize successful responses.",
        ["KamiSama.Extensions.Xml"] = "Serialize objects to XML strings and deserialize XML strings using configurable XmlSerializer and XmlWriterSettings instances. Build attribute-driven XmlAttributeOverrides for polymorphic elements and array items.",
        ["KamiSama.ExternalServices.Exceptions"] = "HTTP-oriented exceptions for external-service discovery failures, timeouts, and invalid provider responses. Use them at integration boundaries to expose consistent localization keys, arguments, and 500 or 504 status codes.",
        ["KamiSama.ExternalServices.Email.Abstractions"] = "Provider-neutral contract and request model for sending email through KamiSama external-service implementations. Reference it from callers and providers that need to exchange recipient, subject, body, and HTML-format data without depending on SMTP or another transport.",
        ["KamiSama.ExternalServices.Email.Core"] = "Provider-selecting email registration for ASP.NET Core applications, including default-provider options and a built-in mock provider. Use it to route `ISendEmail` calls to keyed transport implementations.",
        ["KamiSama.ExternalServices.Email.Smtp"] = "SMTP transport registration and configuration for KamiSama email services. The current implementation contains a known inverted validation defect that rejects complete SMTP settings before sending.",
        ["KamiSama.ExternalServices.Sms.Abstractions"] = "Provider-neutral SMS sending contracts and request data. This package contains abstractions only and does not send messages or register an SMS provider.",
        ["KamiSama.ExternalServices.Sms.Core"] = "Provider-selecting SMS registration for ASP.NET Core applications, including default-provider options and a scoped mock provider. Use it to route unkeyed `ISendSms` calls to scoped keyed providers.",
        ["KamiSama.ExternalServices.Sms.Kavenegar"] = "Scoped Kavenegar SMS provider registration and configuration for KamiSama SMS services. The current sender contains a known inverted validation defect that rejects a configured API key before sending.",
        ["KamiSama.ExternalServices.Sms.NeoZarin"] = "Scoped NeoZarin HTTP SMS provider registration and configuration for KamiSama SMS services. It requires KamiSama RestSharp and `AddHttpClient`, and the current sender contains a known inverted validation defect.",
        ["KamiSama.IranSystem"] = "Iran System encoding conversion helpers for legacy Persian text interoperability. Use this package when integrating with systems that still exchange Iran System encoded data.",
		["KamiSama.Modules.Identity.Abstractions"] = "Provider-neutral Identity feature contracts, requests, responses, search models, role constants, and failure metadata for login, token refresh, logout, user, role, password, session, and two-factor workflows. Reference this package from callers or alternative implementations that should not depend on ASP.NET Core Identity, Entity Framework Core, or a database provider.",
		["KamiSama.Modules.Identity.Core"] = "ASP.NET Core Identity implementation for KamiSama login, token refresh, logout, user, role, password, two-factor, and session feature contracts, with revocable JWT sessions, EF Core persistence, mappings, and modular startup registration. Install it with exactly one Identity database provider and review the documented security and runtime limitations before exposing its features.",
        ["KamiSama.Modules.Identity.Postgresql"] = "PostgreSQL EF Core provider registration for KamiSama.Modules.Identity.Core. Install it in an Identity host and select the required provider callback so the module can resolve its database context and run startup migrations.",
        ["KamiSama.Modules.Identity.Sqlite"] = "SQLite EF Core provider registration for KamiSama.Modules.Identity.Core. Install it in an Identity host and select the required provider callback so the module can resolve its database context and run startup migrations.",
        ["KamiSama.Modules.Localization.Abstractions"] = "Provider-neutral localization feature contracts and culture metadata for listing, reading, and selecting application cultures. Reference this package when callers or implementations should not depend on the ASP.NET Core localization module.",
        ["KamiSama.Modules.Localization.Core"] = "ASP.NET Core localization registration and scoped features for configured culture discovery, current-culture lookup, and culture-selection cookies. Use it to bind localization settings and compose request localization through `KamiSama.Modules`.",
        ["KamiSama.Modules.Locations.Abstractions"] = "Provider-neutral province and city feature contracts, requests, DTOs, and paging search models. Reference this package from callers or alternative implementations that should not depend on EF Core, ASP.NET Core module setup, or a database provider.",
        ["KamiSama.Modules.Locations.Core"] = "ASP.NET Core Locations implementation with EF Core province and city persistence, scoped feature services, modular registration, and startup database initialization. Install it with at least the selected PostgreSQL or SQLite provider and complete setup through the extended builder.",
        ["KamiSama.Modules.Locations.Postgresql"] = "PostgreSQL EF Core context and provider registration for KamiSama.Modules.Locations.Core, including Locations migrations and keyed context resolution. Select it from the Core provider callback when the configured database provider is `postgresql`.",
        ["KamiSama.Modules.Locations.Sqlite"] = "SQLite EF Core context and provider registration for KamiSama.Modules.Locations.Core, including Locations migrations and keyed context resolution. Select it from the Core provider callback when the configured database provider is `sqlite`.",
        ["KamiSama.Modules.PolicyEngine.Abstractions"] = "Provider-neutral CRUD contracts, DTOs, search models, and evaluation-shaped data for policy definitions. It intentionally provides no evaluator, condition parser, action execution, transport, or authorization integration.",
        ["KamiSama.Modules.PolicyEngine.Core"] = "EF Core data management for policy actions, rules, lists, and their relationships, with scoped CRUD features and modular startup registration. Install one provider, provision the schema separately, and supply evaluation and authorization in the host.",
        ["KamiSama.Modules.PolicyEngine.Postgresql"] = "PostgreSQL EF Core context registration for PolicyEngine Core under the `postgresql` provider key. It configures Npgsql and lazy loading but currently ships no PolicyEngine migrations.",
        ["KamiSama.Modules.PolicyEngine.Sqlite"] = "SQLite EF Core context registration for PolicyEngine Core under the `sqlite` provider key. It configures SQLite and lazy loading but currently ships no PolicyEngine migrations.",
        ["KamiSama.Modules.ServicePlans.Abstractions"] = "Provider-neutral ServicePlans feature contracts, requests, DTOs, search models, and subscription data types. Reference this package from callers or alternative implementations that should not depend on EF Core, ASP.NET Core module setup, or a database provider.",
        ["KamiSama.Modules.ServicePlans.Core"] = "ASP.NET Core ServicePlans implementation with EF Core plan, offer, subscriber, and subscription entities, scoped CRUD features, modular registration, and startup initialization. Install one provider, provision the schema separately, and enforce authorization and domain validation in the host.",
        ["KamiSama.Modules.ServicePlans.Postgresql"] = "PostgreSQL EF Core context registration for ServicePlans Core under the `postgresql` provider key. It configures Npgsql and lazy loading but currently ships no ServicePlans migrations.",
        ["KamiSama.Modules.ServicePlans.Sqlite"] = "SQLite EF Core context registration for ServicePlans Core under the `sqlite` provider key. It configures SQLite and lazy loading but currently ships no ServicePlans migrations.",
		["KamiSama.ServicePlans.PolicyAction"] = "ASP.NET Core registration and contracts for a ServicePlans-oriented handler over PolicyEngine contexts. The registered handler is currently unimplemented, and the package does not dispatch resolved actions or call ServicePlans features.",
        ["KamiSama.Modules.Ticketing.Abstractions"] = "Provider-neutral Ticketing feature contracts, requests, DTOs, search models, statuses, priorities, and comment sides. Reference this package from callers or alternative implementations that should not depend on EF Core, ASP.NET Core module setup, or a database provider.",
        ["KamiSama.Modules.Ticketing.Core"] = "ASP.NET Core Ticketing implementation with EF Core entities, validated ticket workflows, repositories, scoped features, modular registration, and startup database initialization. Install it with at least the selected PostgreSQL or SQLite provider and review the documented registration and authorization limitations before exposing its features.",
        ["KamiSama.Modules.Ticketing.Postgresql"] = "PostgreSQL EF Core context and provider registration for KamiSama.Modules.Ticketing.Core, including Ticketing migrations and keyed context resolution. Select it from the Core provider callback when the configured database provider is `postgresql`.",
        ["KamiSama.Modules.Ticketing.Sqlite"] = "SQLite EF Core context and provider registration for KamiSama.Modules.Ticketing.Core, including Ticketing migrations and keyed context resolution. Select it from the Core provider callback when the configured database provider is `sqlite`.",
        ["KamiSama.Repositories.Core"] = "Repository contracts, an in-memory implementation, connection-string options, and database initialization abstractions. Use it to keep callers independent of persistence or to hold transient entities in tests and lightweight processes.",
        ["KamiSama.Repositories.EntityFramework"] = "Entity Framework 6 repositories with immediate persistence and ordered-query paging. Use this package to expose tracked EF6 queries through KamiSama repository contracts and produce paged UI or API results.",
        ["KamiSama.Repositories.EntityFrameworkCore"] = "Entity Framework Core repositories, paging, database initialization, and multi-provider DbContext registration. Use it for tracked repository access, migration and seed workflows, or configuration-selected provider contexts.",
        ["KamiSama.Repositories.EntityFrameworkCore.Postgresql"] = "PostgreSQL registration for KamiSama multi-provider Entity Framework Core DbContexts. It adds scoped keyed context resolution, lazy-loading proxies, migration-history configuration, and process-wide Npgsql compatibility switches.",
        ["KamiSama.Repositories.EntityFrameworkCore.Sqlite"] = "SQLite registration for KamiSama multi-provider Entity Framework Core DbContexts. It adds scoped keyed context resolution, lazy-loading proxies, and migration-history configuration.",
        ["KamiSama.Repositories.Json"] = "Lazy-loading JSON file repository with synchronous and asynchronous query and mutation APIs. It caches entities in memory and rewrites an existing JSON array file after each mutation, with important failure, atomicity, and concurrency limitations.",
        ["KamiSama.Repositories.Xml"] = "Read-oriented XML directory repositories that load one entity per file into memory. Version 10.0.0 has an incompatible default serializer and a broken mutation path, so use these types only for reads with an explicit per-entity serializer.",
        ["KamiSama.Testing.NSubstitute"] = "A DI-first test builder that registers configured substitutes and creates NSubstitute doubles for missing constructor dependencies. Use it to build focused service tests through a scoped Microsoft.Extensions.DependencyInjection container."
    };

    if (map.TryGetValue(project.Name, out var description))
    {
        return description;
    }

    if (!string.IsNullOrWhiteSpace(project.Description))
    {
        return project.Description;
    }

    return $"{project.Name} provides reusable APIs for the {project.Group} area of KamiSama.Extensions.";
}

static string CuratedTypeDescription(string fullName, string typeName)
{
    var shortName = ShortTypeName(typeName);
    var moduleDescription = fullName switch
    {
        "KamiSama.Modules.AntiForgeryModule" => "Adds antiforgery middleware after build but does not register the required antiforgery services. Register them separately before adding this module.",
        "KamiSama.Modules.AuthorizationModule" => "Registers authorization services before build and adds authorization middleware afterward. Its position in module order determines middleware order.",
        "KamiSama.Modules.CascadingAuthenticationModule" => "Registers Blazor cascading authentication-state services before build. It performs no post-build application configuration.",
        "KamiSama.Modules.ControllersModule" => "Registers MVC controllers, supports MVC-builder customization, and maps controller endpoints after build. Use the callback or a derived override to customize registration.",
        "KamiSama.Modules.CorsModule" => "Registers CORS options and adds inline-policy CORS middleware. Service options and middleware policy use separate callbacks.",
        "KamiSama.Modules.CustomActionModule" => "Conditionally awaits a caller-provided application action during post-build configuration. It ignores the build cancellation token and registers no services.",
        "KamiSama.Modules.ForwardedHeadersModule" => "Constructs forwarded-header options after build and adds the middleware. It does not register services during the first module phase.",
        "KamiSama.Modules.HstsModule" => "Adds HSTS middleware after build with framework-configured options. It performs no service registration.",
        "KamiSama.Modules.HttpsRedirectionModule" => "Adds HTTPS redirection middleware after build with framework-configured options. It performs no service registration.",
        "KamiSama.Modules.RazorComponentModule<TRootComponent>" => "Registers Razor component services and maps the selected root component after build. The endpoint callback can add conventions to the mapped component.",
        "KamiSama.Modules.RazorPagesModule" => "Registers configured Razor Pages services and maps page endpoints after build. Its endpoint mapping follows module insertion order.",
        "KamiSama.Modules.RequestLocalizationModule" => "Registers localization and request-localization options before build, then adds request-localization middleware. The required callback defines provider and supported-culture behavior.",
        "KamiSama.Modules.ResponseCachingModule" => "Registers response-caching services but always throws `NotImplementedException` during post-build configuration. Adding it causes both extended build methods to fail.",
        "KamiSama.Modules.ResponseCompressionModule" => "Registers configured response-compression services and adds compression middleware after build. Middleware position follows module insertion order.",
        "KamiSama.Modules.RoutingModule" => "Registers route options and explicitly adds routing middleware after build. Add endpoint-producing modules in an order consistent with the intended pipeline.",
        "KamiSama.Modules.StaticFilesModule" => "Maps ASP.NET Core static assets after build through `MapStaticAssets`. It does not add conventional static-file middleware.",
        "KamiSama.Modules.SwaggerModule" => "Registers Swagger generation and exposes Swagger document and UI middleware in Development or when production exposure is enabled. Generation and UI use separate callbacks.",
        "KamiSama.Modules.WebApplicationBuilderExtension" => "Wraps a standard `WebApplicationBuilder` in an `ExtendedWebApplicationBuilder`. Wrapping alone does not register services or build the application.",
        "KamiSama.Modules.Localization.LocalizationOptions" => "Holds mutable supported-culture metadata and the default culture name bound from configuration. Culture arrays are exposed directly rather than copied.",
        "KamiSama.Modules.Localization.LocalizationModule" => "Registers localization options, resources, and attributed scoped feature implementations. A preceding request-localization module owns middleware configuration.",
        "KamiSama.Modules.Localization.ExtendedWebApplicationBuilderExtensions" => "Adds request localization and the localization core module in the required order. Provider insertion produces Accept-Language, query-string, then cookie precedence.",
        "KamiSama.Modules.Localization.Features.ListAvailableCultures" => "Returns the configured mutable culture array directly and substitutes an empty array only for a null option value. It ignores cancellation.",
        "KamiSama.Modules.Localization.Features.GetCurrentCulture" => "Maps the current UI culture to configured metadata, using the configured default only for neutral cultures. It synthesizes metadata for an unmatched culture and ignores cancellation.",
        "KamiSama.Modules.Localization.Features.SetCulture" => "Validates configured culture metadata and appends a one-year request-culture cookie to the active response. It requires `AddHttpContextAccessor`, affects a later request, and ignores cancellation.",
        "KamiSama.Modules.Localization.Features.IListAvailableCultures" => "Defines provider-neutral culture discovery. Implementations decide storage, cancellation, and whether returned arrays are mutable or copied.",
        "KamiSama.Modules.Localization.Features.IGetCurrentCulture" => "Defines provider-neutral current-culture lookup. Implementations decide the execution context, matching, fallback, and cancellation behavior.",
        "KamiSama.Modules.Localization.Features.ISetCulture" => "Defines provider-neutral culture selection. Implementations decide validation, persistence, request effects, and cancellation behavior.",
        "KamiSama.Modules.Localization.Features.CultureInfoDto" => "Carries a display label, application-defined flag representation, and .NET culture name. It is shared by localization contracts and implementations.",
        "KamiSama.Modules.Identity.DataTypes.KnownRoles" => "Defines the canonical `SuperAdmin`, `Operator`, and `User` role-name strings. These constants neither seed roles nor grant authorization.",
        "KamiSama.Modules.Identity.Exceptions.AddUserFailedException" => "Reports an Identity user-creation failure as HTTP 500 and retains only the first Identity error description as localization metadata.",
		"KamiSama.Modules.Identity.Services.Authentication.LoginRequest" => "Carries one user name or email address, a password, and an optional authenticator code into `ILogin`. Using one login value avoids conflicting identity selectors; the implementation defines lookup and normalization behavior.",
		"KamiSama.Modules.Identity.Services.Authentication.LoginResponse" => "Returns the provider-neutral authenticated user together with the token pair issued for a newly created session. Callers can establish identity state without invoking a separate public token-issuance service.",
		"KamiSama.Modules.Identity.Services.Authentication.RefreshTokenRequest" => "Carries the access and refresh tokens that identify and prove authority over an existing session. Implementations validate the pair before issuing replacements.",
		"KamiSama.Modules.Identity.Services.Authentication.TokenPairDto" => "Carries access and refresh tokens for one session plus the access token's absolute UTC expiration. Clients can schedule renewal without decoding provider-specific token contents.",
		"KamiSama.Modules.Identity.Services.Authentication.ILogin" => "Defines credential validation and new-session token issuance as one operation. Core accepts a user name or email login, validates password and configured two-factor authentication, persists a revocable session, and returns its user and tokens.",
		"KamiSama.Modules.Identity.Services.Authentication.IRefreshToken" => "Defines replacement-token issuance for the session represented by an access/refresh-token pair. Core validates access-token signature and claims, active session state, and the session-scoped refresh token before returning replacements.",
		"KamiSama.Modules.Identity.Services.Authentication.ILogout" => "Defines revocation of the current authenticated application session. Core reads user and session claims from the active HTTP context and marks that session revoked in the Identity database.",
		"KamiSama.Modules.Identity.Services.Authentication.ILogoutAll" => "Defines revocation of every application session for the current authenticated user, including the caller's session. Core resolves the user claim from the active HTTP context and persists revocation for all active sessions.",
        "KamiSama.Modules.Identity.Entities.ApplicationUser" => "ASP.NET Core Identity user with a `Guid` key and application-session navigation. Inherited Identity state stores credentials, confirmation, and lockout data.",
        "KamiSama.Modules.Identity.Entities.ApplicationRole" => "ASP.NET Core Identity role with a `Guid` key. Use it with the Core Identity store and role feature implementations.",
        "KamiSama.Modules.Identity.Entities.ApplicationSession" => "Persistent revocable authentication session. Validation updates and saves `LastConnection`, producing database writes on authenticated traffic.",
        "KamiSama.Modules.Identity.DtoMappings" => "Maps Identity users and roles to abstraction DTOs. User mapping requires roles to be loaded separately and calculates enabled state from lockout fields.",
        "KamiSama.Modules.Identity.Repositories.Database.KamiSamaIdentityDbContext" => "Identity EF Core context for users, roles, claims, tokens, and revocable sessions. Core can migrate it during the extended builder's post-build startup phase.",
        "KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationUserRepository" => "Defines Core user persistence, paging, and lookup. The current implementation saves immediately and does not honor every `UserSearchModel` field.",
        "KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationRoleRepository" => "Combines Core role mutation, paging, and identifier/name lookup contracts. Concrete repository behavior determines normalization and save boundaries.",
        "KamiSama.Modules.Identity.KamiSamaIdentityWebModule" => "Registers Identity, authentication, scanned feature implementations, and a multi-provider DbContext, then performs configured database initialization after build. A concrete provider callback and correctly ordered authentication middleware are required in practice.",
        "KamiSama.Modules.Identity.ExtendedWebApplicationBuilderExtensions" => "Adds the Identity Core web module to an extended builder. Its provider callback must register one installed Identity database provider before startup context resolution.",
        "KamiSama.Modules.Identity.IdentityPostgresqlDbContextBuilderExtensions" => "Registers the internal PostgreSQL Identity context under the shared multi-provider infrastructure's `postgresql` key.",
        "KamiSama.Modules.Identity.IdentitySqliteDbContextBuilderExtensions" => "Registers the internal SQLite Identity context under the shared multi-provider infrastructure's `sqlite` key.",
        "KamiSama.Modules.PolicyEngine.Contexts.PolicyContext" => "Carries ordinally keyed runtime facts together with mutable resolved-action and diagnostic collections. These packages define the data shape but provide no service that evaluates or populates it.",
        "KamiSama.Modules.PolicyEngine.Contexts.ResolvedPolicyAction" => "Carries a selected action identifier, handler name, opaque configuration, and order for later application. No included API resolves or executes this data.",
        "KamiSama.Modules.PolicyEngine.Contexts.PolicyEvaluationDiagnostic" => "Carries a machine code, human message, and severity for a separately implemented evaluator. PolicyEngine Core does not create these diagnostics.",
        "KamiSama.Modules.PolicyEngine.DataTypes.PolicyConditionResult" => "Represents false, true, or undefined condition outcomes for a separately implemented evaluator. Undefined is intended for unavailable required facts.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyActions.IListPolicyActions" => "Defines paged policy-action definition listing. Current Core attributes a non-assignable implementation for this contract, so resolving it fails.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyActions.IAddPolicyAction" => "Defines creation of a reusable action definition. Core checks name duplication and stores handler/configuration text but does not resolve or execute a handler.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyActions.IUpdatePolicyAction" => "Defines replacement of an action definition by `Guid`. Core checks the replacement name and saves immediately.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyActions.IDeletePolicyAction" => "Defines deletion of an action definition by `Guid`. Current Core attributes a non-assignable implementation for this contract, so resolving it fails.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyActions.IFindPolicyActionById" => "Defines lookup of one complete action definition by `Guid`. Core returns opaque handler configuration without executing it.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyLists.IListPolicyLists" => "Defines paged policy-list definition listing without list items. Current Core attributes a non-assignable implementation for this contract, so resolving it fails.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyLists.IAddPolicyList" => "Defines creation of a named typed list definition. The public feature surface provides no operation for adding exact or range items.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyLists.IUpdatePolicyList" => "Defines replacement of a list definition by `Guid`. Changing its declared type does not convert existing item rows.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyLists.IDeletePolicyList" => "Defines deletion of a list definition by `Guid`. Current Core attributes a non-assignable implementation for this contract, so resolving it fails.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyLists.IFindPolicyListById" => "Defines lookup of one list definition by `Guid`. The returned DTO omits exact and range items.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyRules.IListPolicyRules" => "Defines paged policy-rule definition listing without condition source. Current Core attributes a non-assignable implementation for this contract, so resolving it fails.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyRules.IAddPolicyRule" => "Defines creation of an ordered rule definition. Core stores condition source as opaque text and does not parse or evaluate it.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyRules.IUpdatePolicyRule" => "Defines replacement of a rule definition by `Guid`. Core stores the replacement condition source without validation.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyRules.IDeletePolicyRule" => "Defines deletion of a rule definition by `Guid`. Current Core attributes a non-assignable implementation for this contract, so resolving it fails.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyRules.IFindPolicyRuleById" => "Defines lookup of one complete rule definition by `Guid`. The returned DTO includes opaque condition source but no action assignments.",
        "KamiSama.Modules.PolicyEngine.PolicyEngineOptions" => "Represents the currently empty module-options object bound from the PolicyEngine section. Database and initialization values use separate repository options.",
        "KamiSama.Modules.PolicyEngine.PolicyEngineExtendedWebApplicationBuilderExtensions" => "Adds PolicyEngine CRUD discovery, keyed provider setup, and post-build initialization. It maps no endpoints and current service validation can fail on six non-assignable feature registrations.",
        "KamiSama.Modules.PolicyEngine.Repositories.Database.PolicyEngineDbContext" => "Provider-neutral tracked EF Core context for action, rule, assignment, list, and polymorphic item entities. A concrete keyed provider is required, and current provider packages contain no migrations to provision its schema.",
        "KamiSama.Modules.PolicyEngine.PolicyEnginePostgresqlDbContextBuilderExtensions" => "Registers the PostgreSQL PolicyEngine context under the exact `postgresql` keyed base-context service. It enables lazy loading and shared Npgsql switches but supplies no migrations.",
        "KamiSama.Modules.PolicyEngine.Repositories.Database.Postgresql.PostgresqlPolicyEngineDbContext" => "Concrete PostgreSQL PolicyEngine context registered through `AddPostgresqlPolicyEngineDbContext`. Its provider package currently contains no migrations.",
        "KamiSama.Modules.PolicyEngine.PolicyEngineSqliteDbContextBuilderExtensions" => "Registers the SQLite PolicyEngine context under the exact `sqlite` keyed base-context service. It enables lazy loading but supplies no migrations.",
        "KamiSama.Modules.PolicyEngine.Repositories.Database.Sqlite.SqlitePolicyEngineDbContext" => "Concrete SQLite PolicyEngine context registered through `AddSqlitePolicyEngineDbContext`. Its provider package currently contains no migrations.",
        "KamiSama.Modules.ServicePlans.Features.Plans.IListPlans" => "Defines paged plan listing. Core filters by exact case-normalized name, period, and enabled state, then recognizes `id`, `name`, `computationunits`, `ratelimit`, `periodtype`, `durationindays`, `isenabled`, `createdat`, and `updatedat` ordering tokens.",
        "KamiSama.Modules.ServicePlans.Features.Plans.IAddPlan" => "Defines plan creation. Core checks name duplication before immediately saving but performs no numeric, period/duration, or enabled-state domain validation.",
        "KamiSama.Modules.ServicePlans.Features.Plans.IUpdatePlan" => "Defines replacement of a plan by `Guid`. Core performs a separate duplicate-name read, updates timestamps, and saves immediately.",
        "KamiSama.Modules.ServicePlans.Features.Plans.IDeletePlan" => "Defines deletion of a plan by `Guid`. Core applies no deletion guard before saving the deletion.",
        "KamiSama.Modules.ServicePlans.Features.Plans.IFindPlanById" => "Defines plan lookup by `Guid`. Core throws the generic plan not-found HTTP exception when no row matches.",
        "KamiSama.Modules.ServicePlans.Features.Plans.IFindPlanByName" => "Defines plan lookup by case-normalized exact name. Core's translated lowercase comparison depends on provider behavior.",
        "KamiSama.Modules.ServicePlans.Features.Plans.IExistsPlanById" => "Defines an existence check for a plan `Guid`.",
        "KamiSama.Modules.ServicePlans.Features.Plans.IExistsPlanByName" => "Defines an existence check for a case-normalized exact plan name.",
        "KamiSama.Modules.ServicePlans.Features.Subscribers.IListSubscribers" => "Defines paged subscriber listing by external user identifier and enabled state. Core recognizes `externaluserid`, `createdat`, and `updatedat` ordering tokens.",
        "KamiSama.Modules.ServicePlans.Features.Subscribers.IAddSubscriber" => "Defines subscriber creation for an externally managed user. Core performs a race-prone duplicate read and does not authenticate or validate ownership of the supplied external identifier.",
        "KamiSama.Modules.ServicePlans.Features.Subscribers.IUpdateSubscriber" => "Defines replacement of a subscriber's external identifier and enabled state. Core does not authorize reassignment and saves immediately.",
        "KamiSama.Modules.ServicePlans.Features.Subscribers.IDeleteSubscriber" => "Defines deletion of a subscriber by `Guid`. Core applies no ownership or deletion guard.",
        "KamiSama.Modules.ServicePlans.Features.Subscribers.IFindSubscriberById" => "Defines subscriber lookup by `Guid`.",
        "KamiSama.Modules.ServicePlans.Features.Subscriptions.IListSubscriptions" => "Defines paged subscription listing by subscriber, plan, and status set. Core recognizes `status`, `startsat`, `endsat`, and `updatedat` ordering tokens.",
        "KamiSama.Modules.ServicePlans.Features.Subscriptions.IAddSubscription" => "Defines subscription creation for an existing subscriber and plan. Core accepts caller-selected lifecycle and usage values without eligibility, transition, range, or ownership validation.",
        "KamiSama.Modules.ServicePlans.Features.Subscriptions.IUpdateSubscription" => "Defines replacement of a subscription's subscriber, plan, lifecycle, and usage values. Core allows relationship reassignment and saves immediately without domain validation.",
        "KamiSama.Modules.ServicePlans.Features.Subscriptions.IDeleteSubscription" => "Defines deletion of a subscription by `Guid`. Core applies no ownership or lifecycle guard.",
        "KamiSama.Modules.ServicePlans.Features.Subscriptions.IFindSubscriptionById" => "Defines subscription lookup by `Guid` and returns related subscriber and plan identifiers from navigations.",
        "KamiSama.Modules.ServicePlans.ServicePlansOptions" => "Represents the currently empty object bound from the ServicePlans `options` section. Database and initialization settings use separate repository option types.",
        "KamiSama.Modules.ServicePlans.ServicePlansWebModule" => "Registers ServicePlans options, assignable scoped features and repositories, keyed provider setup, and named post-build initialization. It maps no transport or security layer, and current providers contain no ServicePlans migrations.",
        "KamiSama.Modules.ServicePlans.ExtendedWebApplicationBuilderExtensions" => "Adds ServicePlans registration and post-build initialization to an extended builder. A matching provider callback is required in normal setup, and `BuildAsync` cannot provision the module schema from current provider packages.",
        "KamiSama.Modules.ServicePlans.Repositories.Database.ServicePlansDbContext" => "Provider-neutral tracked EF Core context for plans, offers, offer restrictions, subscribers, and subscriptions. Relationships use convention-created shadow foreign keys, and a concrete keyed provider is required.",
        "KamiSama.Modules.ServicePlans.ServicePlansPostgresqlDbContextBuilderExtensions" => "Registers the PostgreSQL ServicePlans context under the exact `postgresql` keyed base-context service. It enables lazy loading and shared Npgsql switches but supplies no migrations.",
        "KamiSama.Modules.ServicePlans.Repositories.Database.Postgresql.PostgresqlServicePlansDbContext" => "Concrete PostgreSQL ServicePlans context registered through `AddPostgresqlServicePlansDbContext`. Its provider package currently contains no migrations.",
        "KamiSama.Modules.ServicePlans.ServicePlansSqliteDbContextBuilderExtensions" => "Registers the SQLite ServicePlans context under the exact `sqlite` keyed base-context service. It enables lazy loading but supplies no migrations.",
        "KamiSama.Modules.ServicePlans.Repositories.Database.Sqlite.SqliteServicePlansDbContext" => "Concrete SQLite ServicePlans context registered through `AddSqliteServicePlansDbContext`. Its provider package currently contains no migrations.",
		"KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionHandlerNames" => "Defines the exact `service-plans` routing name exposed by this package. PolicyEngine treats the value as opaque and does not dispatch it.",
		"KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionConfiguration" => "Carries an intended computation-unit cost expression. The current package defines no serialization format, expression grammar, validation, or evaluator.",
		"KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionResult" => "Carries a decimal computation-unit amount. The registered handler cannot currently produce this result because execution always throws.",
		"KamiSama.ServicePlans.PolicyAction.IServicePlansPolicyActionHandler" => "Defines this package's handler identity and execution boundary over a PolicyEngine `PolicyContext`. It is not a PolicyEngine contract, and the included scoped implementation always throws from execution.",
		"KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionModule" => "Scans this assembly to register the internal handler as scoped and performs no post-build work. It does not register PolicyEngine, ServicePlans, dispatch, middleware, or endpoints.",
		"KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionWebApplicationBuilderExtensions" => "Queues the package module on an `ExtendedWebApplicationBuilder`. The host must add any PolicyEngine, ServicePlans, and action-dispatch capabilities separately.",
        "KamiSama.Modules.Locations.Features.ProvinceSearchModel" => "Carries province paging, optional name filtering, and an ordering token. Core performs a lowercased name substring filter and always orders by province name, ignoring the ordering token.",
        "KamiSama.Modules.Locations.Features.CitySearchModel" => "Carries city paging, city and parent-province filters, and ordering. Core supports exact province-id filtering, lowercased city/province-name substrings, and the exact `province` ordering token.",
        "KamiSama.Modules.Locations.Features.ProvinceDto" => "Returns a province identifier and name across the provider-neutral feature boundary. It contains no child-city collection.",
        "KamiSama.Modules.Locations.Features.CityDto" => "Returns a city together with the identifier and name of its parent province. Parent values are copied from the loaded province navigation when Core creates the DTO.",
        "KamiSama.Modules.Locations.Features.AddProvinceRequest" => "Carries the name for a new province. The name has a 100-character data-annotation limit, while uniqueness is not enforced by the Core add feature.",
        "KamiSama.Modules.Locations.Features.UpdateProvinceRequest" => "Carries the replacement name for an existing province. The name has a 100-character data-annotation limit, while uniqueness is not enforced by the Core update feature.",
        "KamiSama.Modules.Locations.Features.AddCityRequest" => "Carries an existing parent-province identifier and city name for creation. Core throws `NotFoundException<Province>` when the parent does not exist.",
        "KamiSama.Modules.Locations.Features.UpdateCityRequest" => "Carries the parent-province identifier and replacement city name. Core loads the requested parent before assigning both values and throws when that province does not exist.",
        "KamiSama.Modules.Locations.Features.IListProvinces" => "Defines paged province listing through `ProvinceSearchModel`. Core filters by a case-normalized name substring and always orders by name.",
        "KamiSama.Modules.Locations.Features.IFindProvinceById" => "Defines province lookup by `Guid`. Core throws the generic province not-found HTTP exception when no row matches.",
        "KamiSama.Modules.Locations.Features.IAddProvince" => "Defines province creation from `AddProvinceRequest`. Core saves immediately and performs no duplicate-name check.",
        "KamiSama.Modules.Locations.Features.IUpdateProvince" => "Defines province update by `Guid`. Core replaces the name, saves immediately, and performs no duplicate-name check.",
        "KamiSama.Modules.Locations.Features.IDeleteProvince" => "Defines province deletion by `Guid`. Core saves immediately; the restricted relationship can make deletion fail while cities reference the province.",
        "KamiSama.Modules.Locations.Features.IListCities" => "Defines paged city listing through `CitySearchModel`. Core can shape the query by city name, parent id, parent name, and the `province` order token.",
        "KamiSama.Modules.Locations.Features.IFindCityById" => "Defines city lookup by `Guid` and returns parent province data in the DTO. Core throws the generic city not-found HTTP exception when absent.",
        "KamiSama.Modules.Locations.Features.IAddCity" => "Defines city creation beneath an existing province. Core loads the parent, saves the new city immediately, and does not check duplicate names.",
        "KamiSama.Modules.Locations.Features.IUpdateCity" => "Defines updating a city's name and parent province. Core requires the new parent to exist and saves the tracked entity immediately.",
        "KamiSama.Modules.Locations.Features.IDeleteCity" => "Defines city deletion by `Guid`. Core loads the row and saves its deletion immediately.",
        "KamiSama.Modules.Locations.Features.IListCitiesByProvinceName" => "Defines city listing by a parent-province name substring. Core starts from `CitySearchModel.All`, so the result is page-shaped but contains all matches rather than a finite page.",
        "KamiSama.Modules.Locations.ExtendedWebApplicationBuilderExtensions" => "Adds the Locations web module, which discovers scoped features and repositories, configures a keyed provider-neutral context, and performs named database initialization after build. A matching provider callback is required in a normal host, and the module maps no controllers or endpoints.",
        "KamiSama.Modules.Locations.Entities.Province" => "EF Core province entity with a required 100-character name and a virtual city collection. The model restricts deletion while related cities remain.",
        "KamiSama.Modules.Locations.Entities.City" => "EF Core city entity with a required name and required virtual parent-province navigation. It exposes no separate public province-id property.",
        "KamiSama.Modules.Locations.Repositories.Database.LocationsDbContext" => "Provider-neutral EF Core context consumed by Locations repositories. It exposes tracked province and city sets and configures restricted city-to-province deletion; a concrete provider context must be registered for runtime resolution.",
        "KamiSama.Modules.Locations.LocationsPostgresqlDbContextBuilderExtensions" => "Registers the PostgreSQL Locations context under the exact `postgresql` keyed base-context service. Use it from the callback passed to `AddLocationsModule`.",
        "KamiSama.Modules.Locations.Repositories.Database.Postgresql.PostgresqlLocationsDbContext" => "Concrete PostgreSQL Locations context targeted by this provider package's migrations. Normal hosts register it through `AddPostgresqlLocationsDbContext` rather than constructing it directly.",
        "KamiSama.Modules.Locations.LocationsSqliteDbContextBuilderExtensions" => "Registers the SQLite Locations context under the exact `sqlite` keyed base-context service. Use it from the callback passed to `AddLocationsModule`.",
        "KamiSama.Modules.Locations.Repositories.Database.Sqlite.SqliteLocationsDbContext" => "Concrete SQLite Locations context targeted by this provider package's migrations. Normal hosts register it through `AddSqliteLocationsDbContext` rather than constructing it directly.",
        "KamiSama.Modules.Ticketing.Features.Tickets.TicketSearchModel" => "Carries ticket paging, text, category, author, status, priority, and ordering criteria. Current Core ignores the category identifier and recognizes only `priority`, `status`, and `updatedat` ordering tokens.",
        "KamiSama.Modules.Ticketing.Features.Tickets.UpdateTicketStateRequest" => "Carries replacement title, status, and priority values. Core accepts unchanged status, open or reopened to resolved, and resolved to reopened or closed; every other transition produces an HTTP 409 conflict.",
        "KamiSama.Modules.Ticketing.Features.Tickets.IUpdateTicketState" => "Defines keyed replacement of a ticket's title, status, and priority. Core validates the requested workflow transition before changing or saving the tracked ticket and reports invalid transitions as HTTP 409 conflicts.",
        "KamiSama.Modules.Ticketing.Features.Tickets.UpdateTicketCommentRequest" => "Carries the actual comment identifier, claimed author identifier, and replacement text used by Core. Core ignores the separate update-method key and authorizes only by equality with the stored author identifier.",
        "KamiSama.Modules.Ticketing.Features.Tickets.IUpdateTicketComment" => "Defines comment update through a method key plus a request that contains another comment identifier. Current Core uses only the request identifier, so callers must not assume the key selects or validates the target.",
        "KamiSama.Modules.Ticketing.ExtendedWebApplicationBuilderExtensions" => "Adds Ticketing service discovery, multi-provider context setup, and named database initialization to an extended builder. A matching provider callback is required in normal hosts; the module maps no controllers or endpoints.",
        "KamiSama.Modules.Ticketing.DataTypes.TicketStatus" => "Defines the open, reopened, resolved, and closed workflow states. Core permits unchanged status, open or reopened to resolved, and resolved to reopened or closed; closed is terminal.",
        "KamiSama.Modules.Ticketing.Entities.Ticket" => "EF Core ticket aggregate root with a required category, comments, attachment references, workflow state, priority, author, and timestamps. `CanTransitionTo` exposes Core's transition table, while `IsEditable` identifies open and reopened tickets.",
        "KamiSama.Modules.Ticketing.Entities.TicketCategory" => "EF Core ticket category with a required 50-character name and timestamps. Duplicate checks occur in feature code, while provider migrations create no unique name index.",
        "KamiSama.Modules.Ticketing.Entities.TicketComment" => "EF Core comment belonging to one ticket, with caller-attributed side and author, 400-character text, timestamps, and attachment references. Provider migrations cascade its deletion to attachments.",
        "KamiSama.Modules.Ticketing.Entities.TicketAttachment" => "EF Core reference from a ticket comment to an external content identifier. It stores no content bytes or metadata and is cascade-deleted with its comment.",
        "KamiSama.Modules.Ticketing.Repositories.Database.TicketingDbContext" => "Provider-neutral EF Core context consumed by Ticketing repositories and startup initialization. It exposes tracked aggregate sets; a concrete provider must be registered under the configured keyed context for normal module use.",
        "KamiSama.Modules.Ticketing.TicketingPostgresqlDbContextBuilderExtensions" => "Registers the PostgreSQL Ticketing context under the exact `postgresql` keyed base-context service. Use it from the callback passed to `AddTicketingModule`.",
        "KamiSama.Modules.Ticketing.Repositories.Database.Postgresql.PostgresqlTicketingDbContext" => "Concrete PostgreSQL Ticketing context targeted by this provider package's migrations. Normal hosts register it through `AddPostgresqlTicketingDbContext` rather than constructing it directly.",
        "KamiSama.Modules.Ticketing.TicketingSqliteDbContextBuilderExtensions" => "Registers the SQLite Ticketing context under the exact `sqlite` keyed base-context service. Use it from the callback passed to `AddTicketingModule`.",
        "KamiSama.Modules.Ticketing.Repositories.Database.Sqlite.SqliteTicketingDbContext" => "Concrete SQLite Ticketing context targeted by this provider package's migrations. Normal hosts register it through `AddSqliteTicketingDbContext` rather than constructing it directly.",
        "KamiSama.Testing.NSubstitute.TesterBuilderBase" => "Builds a target service in a DI scope and substitutes unresolved parameters from the first public constructor. Registrations accumulate, captured substitutes do not follow normal scoped or transient instance semantics, and created providers and scopes are not disposed.",
        _ => ""
    };
    if (!string.IsNullOrWhiteSpace(moduleDescription))
    {
        return moduleDescription;
    }

    if (fullName == "KamiSama.Repositories.ConnectionStringOption")
    {
        return "Contains the provider identifier and connection string bound from configuration. Provider packages decide which identifiers they accept and how the connection string is used.";
    }

    if (fullName == "KamiSama.Repositories.Initialization.DataInitializationOptions")
    {
        return "Selects whether a database initializer should migrate, create required application data, or create test data. The `IDatabaseInitializer<TDbContext>` implementation defines the actual work and ordering.";
    }

    if (fullName == "KamiSama.Repositories.IRepository<TEntity>")
    {
        return "Defines synchronous add, update, delete, and first-match lookup operations. Implementations determine persistence, transaction, duplicate, and missing-entity behavior.";
    }

    if (fullName == "KamiSama.Repositories.IAsyncRepository<_EntityType>")
    {
        return "Adds asynchronous mutation and lookup methods to `IRepository<TEntity>`. Implementations determine whether work is truly asynchronous and how cancellation, failures, and persistence are handled.";
    }

    if (fullName == "KamiSama.Repositories.IQueryableRepository<TEntity>")
    {
        return "Adds predicate-based query access to the synchronous repository contract. The implementation decides whether the returned `IQueryable<TEntity>` is translated, deferred, live, or an in-memory snapshot.";
    }

    if (fullName == "KamiSama.Repositories.IAsyncQueryableRepository<TEntity>")
    {
        return "Combines asynchronous repository operations with a synchronous `Where` method returning `IQueryable<TEntity>`. The interface name does not make query creation or enumeration asynchronous.";
    }

    if (fullName == "KamiSama.Repositories.Initialization.IDatabaseInitializer<TDbContext>")
    {
        return "Defines migration and seed-data initialization for one database context type. Implementations interpret `DataInitializationOptions` and own ordering, idempotency, persistence, and failure behavior.";
    }

    if (fullName == "KamiSama.Repositories.InMemoryRepository<TEntity>")
    {
        return "Stores entities in an in-process `HashSet<TEntity>` for tests and transient scenarios. Add and delete are serialized per instance, update is a no-op, duplicate semantics follow the comparer, and reads or live queries are not synchronized with mutations.";
    }

    if (fullName == "KamiSama.Repositories.RepositoriesExtensions")
    {
        return "Provides first-match and all-entity convenience queries for `IQueryableRepository<TEntity>`. Both methods delegate to the repository's `Where` implementation and preserve its query and concurrency semantics.";
    }

    if (fullName is "KamiSama.Repositories.EntityFramework.DbRepository<TEntity>" or "KamiSama.Repositories.EntityFramework.DbRepository<TEntity, TDbContext>")
    {
        return "EF6 repository over a borrowed `DbContext`. Queries track by default, every mutation saves immediately, and repository disposal does not dispose the context.";
    }

    if (fullName == "KamiSama.Repositories.EntityFramework.IOrderedQueryableExtensions")
    {
        return "Pages ordered EF6 queries by synchronously counting all matches and asynchronously materializing one page. Cancellation does not cover the count, and count and data are separate queries.";
    }

    if (fullName is "KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>" or "KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity, TDbContext>")
    {
        return "EF Core repository over a borrowed `DbContext`. Queries track by default, every mutation saves immediately, and repository disposal does not dispose the context.";
    }

    if (fullName == "KamiSama.Repositories.EntityFrameworkCore.IQueryableExtensions")
    {
        return "Pages EF Core queries using caller-supplied ordering. It synchronously counts all matches before cancellable asynchronous materialization, using two separate database queries.";
    }

    if (fullName is "KamiSama.Repositories.EntityFrameworkCore.IMultiProviderDbContextBuilder" or "KamiSama.Repositories.EntityFrameworkCore.IMultiProviderDbContextBuilder<TBaseContext>")
    {
        return "Carries the services, configuration-selected provider, base context type, and migration-history table used by concrete provider registration extensions.";
    }

    if (fullName == "KamiSama.Repositories.EntityFrameworkCore.ServiceCollectionExtensions")
    {
        return "Binds `provider` and `connection-string`, then adds scoped keyed resolution for an application-facing base context. Concrete provider packages must register the lowercased configured key.";
    }

    if (fullName == "KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>")
    {
        return "Runs selected migration, application-data, and test-data stages sequentially for an EF Core context. Derived initializers implement both seed hooks and can use `TryAdd` for immediate conditional persistence.";
    }

    if (fullName == "KamiSama.Repositories.EntityFrameworkCore.Initialization.DefaultDatabaseInitializer<TDbContext>")
    {
        return "Migration-only EF Core initializer. Migration runs when selected, while application-data and test-data stages complete without performing work.";
    }

    if (fullName == "KamiSama.Repositories.EntityFrameworkCore.Postgresql.MultiProviderDbContextBuilderPostgresqlExtensions")
    {
        return "Registers a scoped PostgreSQL context under the exact `postgresql` key, enables lazy-loading proxies, configures migration history, and sets two process-wide Npgsql compatibility switches.";
    }

    if (fullName == "KamiSama.Repositories.EntityFrameworkCore.Sqlite.MultiProviderDbContextBuilderSqliteExtensions")
    {
        return "Registers a scoped SQLite context under the exact `sqlite` key, enables lazy-loading proxies, and configures the provider migration-history table.";
    }

    if (fullName == "KamiSama.Repositories.Json.JsonRepository<TEntity>")
    {
        return "Lazily reads an existing JSON array into a `HashSet<TEntity>` and rewrites the complete file after mutations. Writes are non-atomic, update only persists prior in-memory changes, failures are event-reported and suppressed, and locking does not coordinate live queries or other instances.";
    }

    if (fullName == "KamiSama.Repositories.Xml.XmlFileRepository<TEntity>")
    {
        return "Loads one XML entity per file from a directory for read-oriented access. In version 10.0.0 the default serializer cannot read the per-entity files and mutation writes to the directory path rather than mapped files, so pass a per-entity serializer and do not rely on add, update, or delete for persistence.";
    }

    if (fullName == "KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>")
    {
        return "Loads one XML entity per file from a directory for read-oriented access. In version 10.0.0 the default serializer cannot read the per-entity files and mutation writes to the directory path rather than mapped files, so pass a per-entity serializer and do not rely on add, update, or delete for persistence.";
    }

    if (fullName == "KamiSama.Extensions.RestSharp.IRestBuilder")
    {
        return "Builds and executes one RestSharp request through a fluent API. Start each request with `ForServiceUrl`, add the required request data, and then call an HTTP verb method.";
    }

    if (fullName == "KamiSama.Extensions.RestSharp.ServiceCollectionExtensions")
    {
        return "Registers the RestSharp client and fluent request builder used by this package. Call `AddKamiSamaRestSharp` during service configuration after making `HttpClient` available from dependency injection.";
    }

    if (fullName == "KamiSama.ExternalServices.Exceptions.Exceptions.CannotFindExternalServiceException")
    {
        return "Represents a server error caused by the absence of a configured external service implementation. The service name and configuration value are retained as localization arguments.";
    }

    if (fullName == "KamiSama.ExternalServices.Exceptions.Exceptions.ExternalServiceTimedOutException")
    {
        return "Represents an external service operation that did not complete before its timeout. The service name and timeout details are retained as localization arguments.";
    }

    if (fullName == "KamiSama.ExternalServices.Exceptions.Exceptions.InvalidResponseForExternalServiceException")
    {
        return "Represents an invalid or unusable response returned by an external service. The service name and response details are retained as localization arguments.";
    }

    if (fullName == "KamiSama.ExternalServices.Email.Features.ISendEmail")
    {
        return "Defines the provider-neutral operation for sending an email message. Implement this contract in a transport package or inject it into application code that sends email.";
    }

    if (fullName == "KamiSama.ExternalServices.Email.Features.SendEmailRequest")
    {
        return "Contains the provider-neutral data required to send one email message. Use it with `ISendEmail.SendEmailAsync` regardless of the underlying email transport.";
    }

    if (fullName == "KamiSama.ExternalServices.Email.EmailCoreServicesModule")
    {
        return "Registers the default-provider options and scans the core email package for service implementations. Add it when `ISendEmail` should dispatch to the keyed provider selected by configuration.";
    }

    if (fullName == "KamiSama.ExternalServices.Email.EmailDefaultsOptions")
    {
        return "Selects the keyed email provider used by the core dispatcher. The default `mock` provider performs no delivery; set `Email` to a key registered by a transport package for another implementation.";
    }

    if (fullName == "KamiSama.ExternalServices.Email.ExtendedWebApplicationBuilderExtensions")
    {
        return "Adds core email provider selection and service registrations to an `ExtendedWebApplicationBuilder`. Pass the configuration section that contains the `email` provider key.";
    }

    if (fullName == "KamiSama.ExternalServices.Email.Smtp.ExtendedWebApplicationBuilderExtensions")
    {
        return "Adds SMTP options binding and the keyed `smtp` email provider registration to an `ExtendedWebApplicationBuilder`. The current provider has a known inverted validation defect and rejects complete settings before sending.";
    }

    if (fullName == "KamiSama.ExternalServices.Email.Smtp.SmtpOptions")
    {
        return "Contains SMTP connection, credential, TLS, and sender settings. `IsValid` checks required value presence, but the current internal sender incorrectly throws when that check succeeds.";
    }

    if (fullName == "KamiSama.ExternalServices.Sms.Features.ISendSms")
    {
        return "Defines the provider-neutral operation for sending one SMS message. Implement it in a provider package or inject an implementation into application code; this contracts package performs no delivery itself.";
    }

    if (fullName == "KamiSama.ExternalServices.Sms.Features.SendSmsRequest")
    {
        return "Contains the destination phone number and text for one provider-neutral SMS request. Pass it to `ISendSms.SendSmsAsync`; an external implementation determines delivery behavior.";
    }

    if (fullName == "KamiSama.ExternalServices.Sms.SmsCoreServicesModule")
    {
        return "Registers the scoped unkeyed SMS dispatcher, scoped keyed `mock` provider, and default-provider options. Its registrations run when the containing `ExtendedWebApplicationBuilder` is built.";
    }

    if (fullName == "KamiSama.ExternalServices.Sms.SmsDefaultsOptions")
    {
        return "Selects the scoped keyed provider used by the unkeyed SMS dispatcher. The exact keys supplied by these packages are `mock`, `kavenegar`, and `neo-zarin`.";
    }

    if (fullName == "KamiSama.ExternalServices.Sms.ExtendedWebApplicationBuilderExtensions")
    {
        return "Adds core SMS provider selection, the unkeyed dispatcher, and the keyed `mock` registration to an `ExtendedWebApplicationBuilder`. Call `Build` or `BuildAsync` to apply the module registrations.";
    }

    if (fullName == "KamiSama.ExternalServices.Sms.Kavenegar.ExtendedWebApplicationBuilderExtensions")
    {
        return "Adds Kavenegar options binding and the scoped keyed `kavenegar` SMS provider. The current provider has an inverted validation defect and rejects a configured API key before sending.";
    }

    if (fullName == "KamiSama.ExternalServices.Sms.Kavenegar.KavenegarSmsOptions")
    {
        return "Contains the Kavenegar sender number and API key. `IsValid` checks for an API key, but the current internal sender incorrectly throws when that check succeeds.";
    }

    if (fullName == "KamiSama.ExternalServices.Sms.NeoZarin.ExtendedWebApplicationBuilderExtensions")
    {
        return "Adds NeoZarin options binding and the scoped keyed `neo-zarin` SMS provider. Register `HttpClient` and KamiSama RestSharp first; the current provider also has an inverted validation defect.";
    }

    if (fullName == "KamiSama.ExternalServices.Sms.NeoZarin.NeoZarinSmsOptions")
    {
        return "Contains NeoZarin endpoint, credential, sender, and API settings. `IsValidForSms` checks required value presence, but the current internal sender incorrectly throws when that check succeeds.";
    }

    if (fullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "FeatureDefinitionBase")
    {
        return "Binds the entity, DTO, add request, update request, repository, search model, and key types once for a CRUD-style feature set. Use it as a typed shell when several features in the same module work over the same entity and repository.";
    }

    if (fullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "AddFeatureBase")
    {
        return "Nested create-flow base class from `FeatureDefinitionBase`. Use it after the feature definition has already bound the entity, DTO, add-request, repository, search-model, and key types, so each concrete add feature only implements duplicate checking and mapping.";
    }

    if (fullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "UpdateFeatureBase")
    {
        return "Nested update-flow base class from `FeatureDefinitionBase`. Use it for update features that load an entity by id, optionally check duplicate state, patch the entity from the request, and save through the bound repository.";
    }

    if (fullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "DeleteFeatureBase")
    {
        return "Nested delete-flow base class from `FeatureDefinitionBase`. Use it for delete features that load an entity by id, optionally check whether deletion is allowed, and delete through the bound repository.";
    }

    if (fullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "ListFeatureBase")
    {
        return "Nested list-flow base class from `FeatureDefinitionBase`. Use it for paged list features that read a repository page and map each entity to the DTO type bound by the feature definition.";
    }

    if (fullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "FindByIdFeatureBase")
    {
        return "Nested find-by-id base class from `FeatureDefinitionBase`. Use it for query features that load a single entity by key, throw the package not-found exception when missing, and map the entity to a DTO.";
    }

    if (fullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "ExistsByIdFeatureBase")
    {
        return "Nested exists-by-id base class from `FeatureDefinitionBase`. Use it for simple features that expose repository existence checks through an application feature interface.";
    }

    return shortName switch
    {
        "GenericAddFeature" when fullName == "KamiSama.Chassis.Commons.Features.GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>" => "Base implementation for create use cases. `AddAsync` checks duplicate state, converts the request to an entity, persists it through the repository, and returns a DTO.",
        "GenericUpdateFeature" when fullName == "KamiSama.Chassis.Commons.Features.GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>" => "Base implementation for update use cases. `UpdateAsync` loads the entity by id, runs duplicate checks, lets the derived class patch the entity, and saves it through the repository.",
        "GenericDeleteFeature" when fullName == "KamiSama.Chassis.Commons.Features.GenericDeleteFeature<TEntity, TRepository, TKey>" => "Base implementation for delete use cases. `DeleteAsync` loads the entity by id, calls `CanBeDeletedAsync`, and deletes the entity only when the hook allows it.",
        "GenericListFeature" when fullName.StartsWith("KamiSama.Chassis.Commons.Features.GenericListFeature<", StringComparison.Ordinal) => "Base implementation for paged list use cases. It delegates paging to the repository and maps repository entities into the DTO result shape expected by callers.",
        "GenericFindByIdFeature" when fullName == "KamiSama.Chassis.Commons.Features.GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>" => "Base implementation for find-by-id use cases. It loads an entity through the repository, throws `NotFoundException<TEntity>` when missing, and maps the entity to a DTO.",
        "GenericFindByNameFeature" when fullName == "KamiSama.Chassis.Commons.Features.GenericFindByNameFeature<TEntity, TEntityDto, TRepository>" => "Base implementation for find-by-name use cases. It loads an entity through the repository, throws `NotFoundException<TEntity>` when missing, and maps the entity to a DTO.",
        "GenericExistsByIdFeature" when fullName == "KamiSama.Chassis.Commons.Features.GenericExistsByIdFeature<TEntity, TRepository, TKey>" => "Base implementation for exists-by-id checks. It keeps application feature code thin by delegating directly to the repository contract.",
        "GenericExistsByNameFeature" when fullName == "KamiSama.Chassis.Commons.Features.GenericExistsByNameFeature<TEntity, TRepository>" => "Base implementation for exists-by-name checks. It keeps application feature code thin by delegating directly to the repository contract.",
        "GenericRepository" when fullName.StartsWith("KamiSama.Chassis.Commons.Repositories.GenericRepository<", StringComparison.Ordinal) => "Base EF Core repository for paged application repositories. Derive from it when you need the common list/count flow and only want to provide entity-specific search filtering.",
        "DbRepository" => "Repository wrapper around an EF DbContext. Use it when you want the standard KamiSama repository methods over a DbSet without writing the same CRUD code in each repository.",
        "DatabaseInitializerBase" => "Base EF Core database initializer with migration and seed hooks. Derive from it to centralize production seed data and optional test seed data for one DbContext.",
        "WebModule" => "Base abstraction for modular ASP.NET Core setup. Implement it when a feature area needs to register services before build and apply middleware or endpoints after build.",
        "ExtendedWebApplicationBuilder" => "Composable wrapper around `WebApplicationBuilder` that collects web modules and applies them in a predictable build flow.",
        "AutoInjectAttributeBase" => "Base attribute for convention-based dependency injection registration. Derived attributes use it to register the decorated type against an explicit or inferred service type.",
        "AutoInjectAttribute" => "General-purpose dependency injection attribute where service type and lifetime can be configured directly on the implementation type.",
        "AutoInjectScopedAttribute" => "Dependency injection attribute for scoped services. Use it on implementations that should be created once per request or scope.",
        "AutoInjectSingletonAttribute" => "Dependency injection attribute for singleton services. Use it on implementations that should be shared for the application lifetime.",
        "AutoInjectTransientAttribute" => "Dependency injection attribute for transient services. Use it on implementations that should be created each time they are requested.",
        "ServiceCollectionExtensions" when fullName == "KamiSama.Extensions.DependencyInjection.ServiceCollectionExtensions" => "Assembly-scanning extensions for registering implementations decorated with `AutoInjectAttributeBase`. Scan explicit assemblies or use marker types to select one or two assemblies.",
        "KamiSamaProblemDetailsOptions" when fullName == "KamiSama.Chassis.ProblemDetails.KamiSamaProblemDetailsOptions" => "Options object for configuring how KamiSama converts exceptions into ASP.NET Core `ProblemDetails`. Use it to choose the provider and optional localization behavior.",
        "TesterBuilderBase" => "DI-first testing helper that builds services and creates NSubstitute mocks for missing dependencies. Derive a small test builder from it to keep unit tests focused on the service under test.",
        "IranSystemEncoding" when fullName == "KamiSama.IranSystem.IranSystemEncoding" => "A `System.Text.Encoding` implementation for converting between legacy single-byte Iran System data and Unicode characters. Use its complete-buffer string methods when exchanging data with legacy Persian systems.",
        _ => ""
    };
}

static string CuratedTypeExample(string fullName, string typeName)
{
    var shortName = ShortTypeName(typeName);
    var reviewedExample = fullName switch
    {
        "KamiSama.Modules.AntiForgeryModule" => "webBuilder.Services.AddAntiforgery();\nvar builder = webBuilder.Extend().AddModule(new AntiForgeryModule());",
        "KamiSama.Modules.AuthorizationModule" => "var builder = webBuilder.Extend().AddModule(new AuthorizationModule());",
        "KamiSama.Modules.CascadingAuthenticationModule" => "var builder = webBuilder.Extend().AddModule(new CascadingAuthenticationModule());",
        "KamiSama.Modules.ControllersModule" => "var builder = webBuilder.Extend()\n    .AddModule(new ControllersModule(mvc => mvc.AddApplicationPart(typeof(Program).Assembly)));",
        "KamiSama.Modules.CorsModule" => "var builder = webBuilder.Extend()\n    .AddModule(new CorsModule(null, policy => policy.AllowAnyOrigin()));",
        "KamiSama.Modules.CustomActionModule" => "var builder = webBuilder.Extend()\n    .AddModule(new CustomActionModule(app =>\n    {\n        app.MapGet(\"/health\", () => Results.Ok());\n        return Task.CompletedTask;\n    }, condition: true));",
        "KamiSama.Modules.ForwardedHeadersModule" => "using Microsoft.AspNetCore.HttpOverrides;\n\nvar builder = webBuilder.Extend()\n    .AddModule(new ForwardedHeadersModule(options =>\n        options.ForwardedHeaders = ForwardedHeaders.XForwardedFor));",
        "KamiSama.Modules.HstsModule" => "var builder = webBuilder.Extend().AddModule(new HstsModule());",
        "KamiSama.Modules.HttpsRedirectionModule" => "var builder = webBuilder.Extend().AddModule(new HttpsRedirectionModule());",
        "KamiSama.Modules.RazorComponentModule<TRootComponent>" => "var builder = webBuilder.Extend()\n    .AddModule(new RazorComponentModule<App>(endpoints => endpoints.AddInteractiveServerRenderMode()));",
        "KamiSama.Modules.RazorPagesModule" => "var builder = webBuilder.Extend()\n    .AddModule(new RazorPagesModule(options => options.Conventions.AuthorizeFolder(\"/Admin\")));",
        "KamiSama.Modules.RequestLocalizationModule" => "using System.Globalization;\nusing Microsoft.AspNetCore.Localization;\n\nvar builder = webBuilder.Extend().AddModule(new RequestLocalizationModule(options =>\n{\n    options.DefaultRequestCulture = new RequestCulture(\"en-US\");\n    options.SupportedCultures = [new CultureInfo(\"en-US\")];\n    options.SupportedUICultures = options.SupportedCultures;\n}));",
        "KamiSama.Modules.ResponseCachingModule" => "var module = new ResponseCachingModule(options => options.MaximumBodySize = 1024);\n// Do not add this module to a runnable builder: its application phase always throws.",
        "KamiSama.Modules.ResponseCompressionModule" => "var builder = webBuilder.Extend()\n    .AddModule(new ResponseCompressionModule(options => options.EnableForHttps = true));",
        "KamiSama.Modules.RoutingModule" => "var builder = webBuilder.Extend()\n    .AddModule(new RoutingModule(options => options.LowercaseUrls = true));",
        "KamiSama.Modules.StaticFilesModule" => "var builder = webBuilder.Extend().AddModule(new StaticFilesModule());",
        "KamiSama.Modules.SwaggerModule" => "var builder = webBuilder.Extend()\n    .AddModule(new SwaggerModule(addEndPointInProduction: false, genConfigure: null, uiConfigure: null));",
        "KamiSama.Modules.Localization.Features.IListAvailableCultures" => "CultureInfoDto[] cultures = await listAvailableCultures.ListAsync(cancellationToken);",
        "KamiSama.Modules.Localization.Features.IGetCurrentCulture" => "CultureInfoDto current = await getCurrentCulture.GetCurrentCultureAsync(cancellationToken);",
        "KamiSama.Modules.Localization.Features.ISetCulture" => "CultureInfoDto selected = await setCulture.SetAsync(\"fa-IR\", cancellationToken);",
        "KamiSama.Modules.Localization.LocalizationOptions" => "using KamiSama.Modules.Localization;\nusing KamiSama.Modules.Localization.Features;\n\nvar options = new LocalizationOptions\n{\n    DefaultCulture = \"en-US\",\n    AvailableCultures =\n    [\n        new CultureInfoDto(\"English\", \"us\", \"en-US\"),\n        new CultureInfoDto(\"Persian\", \"ir\", \"fa-IR\")\n    ]\n};",
        "KamiSama.Modules.Localization.LocalizationModule" => "var section = webBuilder.Configuration.GetSection(\"Localization\");\nvar builder = webBuilder.Extend().AddModule(new LocalizationModule(section, \"Resources\"));",
        "KamiSama.Modules.Localization.Features.ListAvailableCultures" => "var feature = new ListAvailableCultures(options);\nCultureInfoDto[] cultures = await feature.ListAsync(CancellationToken.None);",
        "KamiSama.Modules.Localization.Features.GetCurrentCulture" => "var feature = new GetCurrentCulture(options);\nCultureInfoDto current = await feature.GetCurrentCultureAsync(CancellationToken.None);",
        "KamiSama.Modules.Localization.Features.SetCulture" => "webBuilder.Services.AddHttpContextAccessor();\n// Resolve ISetCulture in an active request, then append a cookie for a later request.\nCultureInfoDto selected = await setCulture.SetAsync(\"fa-IR\", CancellationToken.None);",
        "KamiSama.Modules.Identity.DataTypes.KnownRoles" => "using KamiSama.Modules.Identity.DataTypes;\n\nservices.AddAuthorization(options =>\n    options.AddPolicy(\"Operators\", policy => policy.RequireRole(KnownRoles.SuperAdmin, KnownRoles.Operator)));",
        "KamiSama.Modules.Identity.Exceptions.AddUserFailedException" => "try\n{\n    UserDto user = await addUser.AddAsync(request, cancellationToken);\n}\ncatch (AddUserFailedException exception)\n{\n    logger.LogWarning(exception, \"Identity rejected user creation\");\n}",
        "KamiSama.Modules.Identity.Services.Roles.IListRoles" => "PagedResult<RoleDto> roles = await listRoles.ListAsync(RoleSearchModel.All, cancellationToken);",
        "KamiSama.Modules.Identity.Services.Roles.IAddRole" => "RoleDto role = await addRole.AddAsync(new AddRoleRequest(\"Auditor\"), cancellationToken);",
        "KamiSama.Modules.Identity.Services.Roles.IUpdateRole" => "await updateRole.UpdateAsync(roleId, new UpdateRoleRequest(\"Reviewer\"), cancellationToken);",
        "KamiSama.Modules.Identity.Services.Roles.IDeleteRole" => "await deleteRole.DeleteAsync(roleId, cancellationToken);",
        "KamiSama.Modules.Identity.Services.Roles.IFindRoleById" => "RoleDto role = await findRoleById.FindByIdAsync(roleId, cancellationToken);",
        "KamiSama.Modules.Identity.Services.Roles.IFindRoleByName" => "RoleDto role = await findRoleByName.FindByNameAsync(\"Operator\", cancellationToken);",
        "KamiSama.Modules.Identity.Services.Roles.IExistsRoleById" => "bool exists = await existsRoleById.ExistsByIdAsync(roleId, cancellationToken);",
        "KamiSama.Modules.Identity.Services.Roles.IExistsRoleByName" => "bool exists = await existsRoleByName.ExistsByNameAsync(\"Operator\", cancellationToken);",
        "KamiSama.Modules.Identity.Services.Users.IFindCurrentUser" => "UserDto user = await currentUser.GetCurrentUserAsync(cancellationToken);",
        "KamiSama.Modules.Identity.Services.Users.IAddUser" => "UserDto user = await addUser.AddAsync(new AddUserRequest(\"ada\", \"ada@example.com\", \"+15551234567\", password, true, [KnownRoles.User]), cancellationToken);",
        "KamiSama.Modules.Identity.Services.Users.IUpdateUser" => "await updateUser.UpdateAsync(userId, new UpdateUserRequest(\"ada\", \"ada@example.com\", \"+15551234567\", [KnownRoles.User]), cancellationToken);\n// Core currently ignores the Roles value.",
        "KamiSama.Modules.Identity.Services.Users.IDeleteUser" => "await deleteUser.DeleteAsync(userId, cancellationToken);",
        "KamiSama.Modules.Identity.Services.Users.IDisable2fa" => "await disable2fa.DisableAsync(userId, cancellationToken);",
        "KamiSama.Modules.Identity.Services.Users.IEnable2fa" => "await enable2fa.EnableAsync(new Enable2faRequest(userId, authenticatorCode), cancellationToken);",
        "KamiSama.Modules.Identity.Services.Users.IDisableUser" => "await disableUser.DisableUserAsync(userId, cancellationToken);",
        "KamiSama.Modules.Identity.Services.Users.IEnableUser" => "await enableUser.EnableUserAsync(userId, cancellationToken);",
        "KamiSama.Modules.Identity.Services.Users.IExistsUserById" => "bool exists = await existsUserById.ExistsByIdAsync(userId, cancellationToken);",
        "KamiSama.Modules.Identity.Services.Users.IFindUserById" => "UserDto user = await findUserById.FindByIdAsync(userId, cancellationToken);",
        "KamiSama.Modules.Identity.Services.Users.IExistsUserByName" => "bool exists = await existsUserByName.ExistsByNameAsync(\"ada\", cancellationToken);",
        "KamiSama.Modules.Identity.Services.Users.IFindUserByName" => "UserDto user = await findUserByName.FindByNameAsync(\"ada\", cancellationToken);",
        "KamiSama.Modules.Identity.Services.Users.IListUsers" => "PagedResult<UserDto> users = await listUsers.ListAsync(new UserSearchModel(1, 20, \"ada\", null, null), cancellationToken);",
        "KamiSama.Modules.Identity.Services.Users.IExistsUserByEmail" => "bool exists = await existsUserByEmail.ExistsAsync(\"ada@example.com\", cancellationToken);",
        "KamiSama.Modules.Identity.Services.Users.IFindUserByEmail" => "UserDto user = await findUserByEmail.FindByEmailAsync(\"ada@example.com\", cancellationToken);",
		"KamiSama.Modules.Identity.Services.Authentication.ILogin" => "LoginResponse result = await login.LoginAsync(\n    new LoginRequest(\"ada@example.com\", password, authenticatorCode),\n    cancellationToken);\n\nDateTimeOffset renewBefore = result.Tokens.AccessTokenExpiresAt;",
		"KamiSama.Modules.Identity.Services.Authentication.IRefreshToken" => "TokenPairDto tokens = await refreshToken.RefreshAsync(\n    new RefreshTokenRequest(accessToken, refreshTokenValue),\n    cancellationToken);",
		"KamiSama.Modules.Identity.Services.Authentication.ILogout" => "// Core resolves the user and session from the current authenticated HTTP context.\nawait logout.LogoutAsync(cancellationToken);",
		"KamiSama.Modules.Identity.Services.Authentication.ILogoutAll" => "// Revokes the current session and every other active session for the current user.\nawait logoutAll.LogoutAllAsync(cancellationToken);",
        "KamiSama.Modules.Identity.Services.Password.IValidatePassword" => "PasswordValidationError[] errors = await validatePassword.ValidateAsync(new ValidatePasswordRequest(\"ada\", \"ada@example.com\", null, candidatePassword), cancellationToken);",
        "KamiSama.Modules.Identity.Services.Password.IResetPassword" => "// Do not expose Core's implementation directly: it generates its own reset token.\nawait resetPassword.ResetPasswordAsync(new ResetPasswordRequest(\"ada@example.com\", replacementPassword), cancellationToken);",
        "KamiSama.Modules.Identity.Services.AccountSecurity.IListActiveSessions" => "IReadOnlyList<ActiveSessionDto> sessions = await listActiveSessions.ListAsync(userId, cancellationToken);",
        "KamiSama.Modules.Identity.Services.AccountSecurity.ITerminateAllOtherSessions" => "await terminateAllOtherSessions.TerminateAllOtherAsync(userId, cancellationToken);",
        "KamiSama.Modules.Identity.Services.AccountSecurity.ITerminateSession" => "await terminateSession.TerminateAsync(userId, sessionId, cancellationToken);",
        "KamiSama.Modules.Identity.Services.AccountSecurity.IGetAuthenticatorSecret" => "string secret = await getAuthenticatorSecret.GetAsync(userId, cancellationToken);",
        "KamiSama.Modules.Identity.Services.AccountSecurity.IChangePassword" => "await changePassword.ChangeAsync(new ChangePasswordRequest(userId, username, email, currentPassword, newPassword), cancellationToken);",
        "KamiSama.Modules.Identity.Services.AccountSecurity.IIsTwoFactorAuthenticationEnabled" => "bool enabled = await twoFactorStatus.IsEnabledAsync(userId, cancellationToken);",
        "KamiSama.Modules.Identity.Services.AccountSecurity.ISetTwoFactorAuthenticationEnabled" => "await setTwoFactorAuthenticationEnabled.SetAsync(userId, true, cancellationToken);",
        "KamiSama.Modules.Identity.Services.AccountSecurity.IValidateAuthenticatorCode" => "await validateAuthenticatorCode.ValidateAsync(new ValidateAuthenticatorCodeRequest(userId, authenticatorCode), cancellationToken);",
        "KamiSama.Modules.Identity.Entities.ApplicationUser" => "var user = new ApplicationUser(\"ada\")\n{\n    Id = Guid.NewGuid(),\n    Email = \"ada@example.com\"\n};",
        "KamiSama.Modules.Identity.Entities.ApplicationRole" => "var role = new ApplicationRole(KnownRoles.Operator)\n{\n    Id = Guid.NewGuid()\n};",
        "KamiSama.Modules.Identity.Entities.ApplicationSession" => "var session = new ApplicationSession\n{\n    Id = Guid.NewGuid(),\n    UserId = user.Id,\n    SessionKey = Convert.ToHexString(RandomNumberGenerator.GetBytes(32)),\n    DeviceModel = \"Web browser\",\n    IpAddress = \"203.0.113.10\",\n    IsRevoked = false,\n    CreatedAt = DateTime.UtcNow,\n    LastConnection = DateTime.UtcNow\n};",
        "KamiSama.Modules.Identity.DtoMappings" => "UserDto userDto = user.ToDto([KnownRoles.User]);\nRoleDto roleDto = role.ToDto();",
        "KamiSama.Modules.Identity.Repositories.Database.KamiSamaIdentityDbContext" => "services.AddMultiProviderDbContext<KamiSamaIdentityDbContext>(configuration.GetSection(\"Identity:Database\"))\n    .AddPostgresqlIdentityDbContext();",
        "KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationUserRepository" => "ApplicationUser? user = await repository.FindByIdAsync(userId, cancellationToken);",
        "KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationRoleRepository" => "ApplicationRole? role = await repository.FindByNameAsync(\"Operator\", cancellationToken);",
        "KamiSama.Modules.Identity.KamiSamaIdentityWebModule" => "var builder = webBuilder.Extend().AddModule(new KamiSamaIdentityWebModule(\n    webBuilder.Configuration.GetSection(\"Identity\"),\n    webBuilder.Configuration.GetSection(\"Identity:Database\"),\n    registerIdentity: true,\n    useJwtAuth: true,\n    configureDbContext: database => database.AddPostgresqlIdentityDbContext()));",
        "KamiSama.Modules.PolicyEngine.Contexts.PolicyContext" => "var context = new PolicyContext();\ncontext.Facts[\"subject.country\"] = \"US\";\n// A host-supplied evaluator must inspect facts and populate Actions and EvaluationDiagnostics.",
        "KamiSama.Modules.PolicyEngine.Contexts.PolicyEvaluationDiagnostic" => "context.EvaluationDiagnostics.Add(new PolicyEvaluationDiagnostic\n{\n    Code = \"missing-fact\", Message = \"subject.country was not supplied\",\n    Severity = PolicyEvaluationDiagnosticSeverity.Warning\n});",
        "KamiSama.Modules.PolicyEngine.Contexts.ResolvedPolicyAction" => "context.Actions.Add(new ResolvedPolicyAction\n{\n    ActionId = actionId,\n    HandlerName = \"service-plan\",\n    ConfigurationSource = \"{\\\"plan\\\":\\\"premium\\\"}\",\n    Order = 10\n});",
        "KamiSama.Modules.PolicyEngine.Features.PolicyActions.IListPolicyActions" => "PagedResult<PolicyActionListItemDto> actions = await listActions.ListAsync(\n    new PolicyActionSearchModel(1, 20, null, \"service-plan\", true, \"name\"),\n    cancellationToken);\n// Current Core registration for this contract is non-assignable.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyActions.IAddPolicyAction" => "PolicyActionDto action = await addAction.AddAsync(new AddPolicyActionRequest(\n    \"Premium plan\", \"service-plan\", configurationSource, false, true), cancellationToken);",
        "KamiSama.Modules.PolicyEngine.Features.PolicyActions.IUpdatePolicyAction" => "await updateAction.UpdateAsync(actionId, new UpdatePolicyActionRequest(\n    \"Premium plan\", \"service-plan\", configurationSource, false, true), cancellationToken);",
        "KamiSama.Modules.PolicyEngine.Features.PolicyActions.IDeletePolicyAction" => "await deleteAction.DeleteAsync(actionId, cancellationToken);\n// Current Core registration for this contract is non-assignable.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyActions.IFindPolicyActionById" => "PolicyActionDto action = await findAction.FindByIdAsync(actionId, cancellationToken);",
        "KamiSama.Modules.PolicyEngine.Features.PolicyLists.IListPolicyLists" => "PagedResult<PolicyListListItemDto> lists = await listPolicyLists.ListAsync(\n    new PolicyListSearchModel(1, 20, null, PolicyListType.IpAddress, true, \"name\"),\n    cancellationToken);\n// Current Core registration for this contract is non-assignable.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyLists.IAddPolicyList" => "PolicyListDto list = await addPolicyList.AddAsync(\n    new AddPolicyListRequest(\"Trusted IPs\", PolicyListType.IpAddress, true), cancellationToken);",
        "KamiSama.Modules.PolicyEngine.Features.PolicyLists.IUpdatePolicyList" => "await updatePolicyList.UpdateAsync(listId,\n    new UpdatePolicyListRequest(\"Trusted IPs\", PolicyListType.IpAddress, true), cancellationToken);",
        "KamiSama.Modules.PolicyEngine.Features.PolicyLists.IDeletePolicyList" => "await deletePolicyList.DeleteAsync(listId, cancellationToken);\n// Current Core registration for this contract is non-assignable.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyLists.IFindPolicyListById" => "PolicyListDto list = await findPolicyList.FindByIdAsync(listId, cancellationToken);",
        "KamiSama.Modules.PolicyEngine.Features.PolicyRules.IListPolicyRules" => "PagedResult<PolicyRuleListItemDto> rules = await listRules.ListAsync(\n    new PolicyRuleSearchModel(1, 20, null, true, \"processorder\"), cancellationToken);\n// Current Core registration for this contract is non-assignable.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyRules.IAddPolicyRule" => "PolicyRuleDto rule = await addRule.AddAsync(new AddPolicyRuleRequest(\n    \"Trusted network\", 10, conditionSource, true), cancellationToken);",
        "KamiSama.Modules.PolicyEngine.Features.PolicyRules.IUpdatePolicyRule" => "await updateRule.UpdateAsync(ruleId,\n    new UpdatePolicyRuleRequest(\"Trusted network\", 10, conditionSource, true), cancellationToken);",
        "KamiSama.Modules.PolicyEngine.Features.PolicyRules.IDeletePolicyRule" => "await deleteRule.DeleteAsync(ruleId, cancellationToken);\n// Current Core registration for this contract is non-assignable.",
        "KamiSama.Modules.PolicyEngine.Features.PolicyRules.IFindPolicyRuleById" => "PolicyRuleDto rule = await findRule.FindByIdAsync(ruleId, cancellationToken);",
        "KamiSama.Modules.PolicyEngine.Entities.PolicyAction" => "var action = new PolicyAction\n{\n    Name = \"Premium plan\", HandlerName = \"service-plan\", ConfigurationSource = configurationSource,\n    AllowsMultiple = false, IsEnabled = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow\n};",
        "KamiSama.Modules.PolicyEngine.Entities.PolicyRule" => "var rule = new PolicyRule\n{\n    Name = \"Trusted network\", ProcessOrder = 10, ConditionSource = conditionSource,\n    IsEnabled = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow\n};",
        "KamiSama.Modules.PolicyEngine.Entities.PolicyRuleAction" => "rule.PolicyRuleActions.Add(new PolicyRuleAction\n{\n    PolicyRule = rule, PolicyAction = action, Order = 10,\n    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow\n});",
        "KamiSama.Modules.PolicyEngine.Entities.PolicyList" => "var list = new PolicyList\n{\n    Name = \"Trusted IPs\", Type = PolicyListType.IpAddress, IsEnabled = true,\n    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow\n};",
        "KamiSama.Modules.PolicyEngine.Entities.ExactPolicyListItem" => "list.Items.Add(new ExactPolicyListItem\n{\n    PolicyList = list, Value = \"203.0.113.10\", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow\n});",
        "KamiSama.Modules.PolicyEngine.Entities.RangePolicyListItem" => "list.Items.Add(new RangePolicyListItem\n{\n    PolicyList = list, From = \"203.0.113.1\", To = \"203.0.113.254\",\n    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow\n});",
        "KamiSama.Modules.PolicyEngine.Repositories.Database.PolicyEngineDbContext" => "using IServiceScope scope = app.Services.CreateScope();\nPolicyEngineDbContext context = scope.ServiceProvider.GetRequiredService<PolicyEngineDbContext>();\nList<PolicyRule> enabled = await context.PolicyRules.AsNoTracking()\n    .Where(rule => rule.IsEnabled).OrderBy(rule => rule.ProcessOrder).ToListAsync(cancellationToken);",
        "KamiSama.Modules.PolicyEngine.Repositories.Database.Postgresql.PostgresqlPolicyEngineDbContext" => "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddPolicyEngineModule(\n    policySection, databaseSection, database => database.AddPostgresqlPolicyEngineDbContext());",
        "KamiSama.Modules.PolicyEngine.Repositories.Database.Sqlite.SqlitePolicyEngineDbContext" => "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddPolicyEngineModule(\n    policySection, databaseSection, database => database.AddSqlitePolicyEngineDbContext());",
        "KamiSama.Modules.ServicePlans.Features.Plans.IListPlans" => "PagedResult<PlanListItemDto> plans = await listPlans.ListAsync(\n    new PlanSearchModel(1, 20, null, SubscriptionPeriodType.Monthly, true, \"name\"), cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Plans.IAddPlan" => "PlanDto plan = await addPlan.AddAsync(new AddPlanRequest(\n    \"Standard\", 1000m, 20, SubscriptionPeriodType.Monthly, 30, true), cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Plans.IUpdatePlan" => "await updatePlan.UpdateAsync(planId, new UpdatePlanRequest(\n    \"Standard\", 1500m, 25, SubscriptionPeriodType.Monthly, 30, true), cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Plans.IDeletePlan" => "await deletePlan.DeleteAsync(planId, cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Plans.IFindPlanById" => "PlanDto plan = await findPlanById.FindByIdAsync(planId, cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Plans.IFindPlanByName" => "PlanDto plan = await findPlanByName.FindByNameAsync(\"Standard\", cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Plans.IExistsPlanById" => "bool exists = await existsPlanById.ExistsByIdAsync(planId, cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Plans.IExistsPlanByName" => "bool exists = await existsPlanByName.ExistsByNameAsync(\"Standard\", cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Subscribers.IListSubscribers" => "PagedResult<SubscriberDto> subscribers = await listSubscribers.ListAsync(\n    new SubscriberSearchModel(1, 20, externalUserId, true, \"updatedat\"), cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Subscribers.IAddSubscriber" => "SubscriberDto subscriber = await addSubscriber.AddAsync(\n    new AddSubscriberRequest(externalUserId, true), cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Subscribers.IUpdateSubscriber" => "await updateSubscriber.UpdateAsync(subscriberId,\n    new UpdateSubscriberRequest(externalUserId, true), cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Subscribers.IDeleteSubscriber" => "await deleteSubscriber.DeleteAsync(subscriberId, cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Subscribers.IFindSubscriberById" => "SubscriberDto subscriber = await findSubscriberById.FindByIdAsync(subscriberId, cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Subscriptions.IListSubscriptions" => "PagedResult<SubscriptionDto> subscriptions = await listSubscriptions.ListAsync(\n    new SubscriptionSearchModel(1, 20, subscriberId, null, [SubscriptionStatus.Active], \"startsat\"), cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Subscriptions.IAddSubscription" => "// Validate authorization and domain values before calling Core.\nSubscriptionDto subscription = await addSubscription.AddAsync(request, cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Subscriptions.IUpdateSubscription" => "// Core permits subscriber, plan, lifecycle, and balance replacement.\nawait updateSubscription.UpdateAsync(subscriptionId, request, cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Subscriptions.IDeleteSubscription" => "await deleteSubscription.DeleteAsync(subscriptionId, cancellationToken);",
        "KamiSama.Modules.ServicePlans.Features.Subscriptions.IFindSubscriptionById" => "SubscriptionDto subscription = await findSubscriptionById.FindByIdAsync(subscriptionId, cancellationToken);",
        "KamiSama.Modules.ServicePlans.ServicePlansWebModule" => "var module = new ServicePlansWebModule(\n    servicePlansSection, databaseSection,\n    database => database.AddPostgresqlServicePlansDbContext());",
        "KamiSama.Modules.ServicePlans.Entities.Plan" => "var plan = new Plan\n{\n    Name = \"Standard\", ComputationUnits = 1000m, RateLimit = 20,\n    PeriodType = SubscriptionPeriodType.Monthly, DurationInDays = 30, IsEnabled = true,\n    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow\n};",
        "KamiSama.Modules.ServicePlans.Entities.Offer" => "var offer = new Offer\n{\n    Plan = plan, Name = \"Standard monthly\", Type = OfferType.Primary,\n    StartsAt = null, EndsAt = null, IsEnabled = true,\n    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow\n};",
        "KamiSama.Modules.ServicePlans.Entities.OfferCountry" => "offer.Countries.Add(new OfferCountry\n{\n    Offer = offer, CountryCode = \"US\", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow\n});",
        "KamiSama.Modules.ServicePlans.Entities.OfferPaymentMethod" => "offer.PaymentMethods.Add(new OfferPaymentMethod\n{\n    Offer = offer, Type = PaymentMethodType.FiatGateway, CurrencyCode = \"USD\",\n    ExternalProviderId = \"primary\", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow\n});",
        "KamiSama.Modules.ServicePlans.Entities.Subscriber" => "var subscriber = new Subscriber\n{\n    ExternalUserId = externalUserId, IsEnabled = true,\n    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow\n};",
        "KamiSama.Modules.ServicePlans.Entities.Subscription" => "var subscription = new Subscription\n{\n    Subscriber = subscriber, Plan = plan, Status = SubscriptionStatus.Active,\n    StartsAt = DateTime.UtcNow, EndsAt = DateTime.UtcNow.AddDays(30),\n    RemainingComputationUnits = 1000m, DailyComputationUnits = 0m,\n    MonthlyComputationUnits = 0m, ConsumedTrafficBytes = 0,\n    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow\n};",
        "KamiSama.Modules.ServicePlans.Repositories.Database.ServicePlansDbContext" => "using IServiceScope scope = app.Services.CreateScope();\nServicePlansDbContext context = scope.ServiceProvider.GetRequiredService<ServicePlansDbContext>();\nList<Plan> enabled = await context.Plans.AsNoTracking()\n    .Where(plan => plan.IsEnabled).ToListAsync(cancellationToken);",
        "KamiSama.Modules.ServicePlans.Repositories.Database.Postgresql.PostgresqlServicePlansDbContext" => "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddServicePlansModule(\n    servicePlansSection, databaseSection,\n    database => database.AddPostgresqlServicePlansDbContext());",
        "KamiSama.Modules.ServicePlans.Repositories.Database.Sqlite.SqliteServicePlansDbContext" => "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddServicePlansModule(\n    servicePlansSection, databaseSection,\n    database => database.AddSqliteServicePlansDbContext());",
		"KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionHandlerNames" => "if (action.HandlerName == ServicePlansPolicyActionHandlerNames.ServicePlans)\n{\n    // A host-supplied dispatcher decides how to route the opaque action.\n}",
		"KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionConfiguration" => "var configuration = new ServicePlansPolicyActionConfiguration\n{\n    CostExpression = \"request.units * 0.5\"\n};\n// The current package does not serialize, parse, or evaluate this value.",
		"KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionResult" => "var result = new ServicePlansPolicyActionResult\n{\n    ComputationUnits = 12.5m\n};\n// A replacement handler can return this shape; the included handler cannot.",
		"KamiSama.ServicePlans.PolicyAction.IServicePlansPolicyActionHandler" => "IServicePlansPolicyActionHandler handler = scope.ServiceProvider\n    .GetRequiredService<IServicePlansPolicyActionHandler>();\nstring handlerName = handler.HandlerName;\n// ExecuteAsync currently throws NotImplementedException synchronously.",
		"KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionModule" => "ExtendedWebApplicationBuilder builder = webBuilder.Extend()\n    .AddModule(new ServicePlansPolicyActionModule());\nWebApplication app = await builder.BuildAsync(cancellationToken);",
        "KamiSama.Modules.Locations.Features.IListProvinces" => "PagedResult<ProvinceDto> provinces = await listProvinces.ListAsync(\n    new ProvinceSearchModel(1, 20, \"north\", null), cancellationToken);",
        "KamiSama.Modules.Locations.Features.IFindProvinceById" => "ProvinceDto province = await findProvinceById.FindByIdAsync(provinceId, cancellationToken);",
        "KamiSama.Modules.Locations.Features.IAddProvince" => "ProvinceDto province = await addProvince.AddAsync(new AddProvinceRequest(\"Central\"), cancellationToken);",
        "KamiSama.Modules.Locations.Features.IUpdateProvince" => "await updateProvince.UpdateAsync(provinceId, new UpdateProvinceRequest(\"Central District\"), cancellationToken);",
        "KamiSama.Modules.Locations.Features.IDeleteProvince" => "await deleteProvince.DeleteAsync(provinceId, cancellationToken);\n// Core's restricted relationship prevents deleting a province that still has cities.",
        "KamiSama.Modules.Locations.Features.IListCities" => "PagedResult<CityDto> cities = await listCities.ListAsync(\n    new CitySearchModel(1, 20, provinceId, null, null, \"province\"), cancellationToken);",
        "KamiSama.Modules.Locations.Features.IFindCityById" => "CityDto city = await findCityById.FindByIdAsync(cityId, cancellationToken);",
        "KamiSama.Modules.Locations.Features.IAddCity" => "CityDto city = await addCity.AddAsync(new AddCityRequest(provinceId, \"Springfield\"), cancellationToken);",
        "KamiSama.Modules.Locations.Features.IUpdateCity" => "await updateCity.UpdateAsync(cityId, new UpdateCityRequest(provinceId, \"New Springfield\"), cancellationToken);",
        "KamiSama.Modules.Locations.Features.IDeleteCity" => "await deleteCity.DeleteAsync(cityId, cancellationToken);",
        "KamiSama.Modules.Locations.Features.IListCitiesByProvinceName" => "PagedResult<CityDto> cities = await listCitiesByProvinceName.ListAsync(\"central\", cancellationToken);\n// Core returns every match because this operation uses CitySearchModel.All.",
        "KamiSama.Modules.Locations.Repositories.Database.LocationsDbContext" => "using IServiceScope scope = app.Services.CreateScope();\nLocationsDbContext context = scope.ServiceProvider.GetRequiredService<LocationsDbContext>();\nList<Province> provinces = await context.Provinces.AsNoTracking().ToListAsync(cancellationToken);",
        "KamiSama.Modules.Locations.Repositories.Database.Postgresql.PostgresqlLocationsDbContext" => "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddLocationsModule(\n    locationsSection, databaseSection,\n    database => database.AddPostgresqlLocationsDbContext());",
        "KamiSama.Modules.Locations.Repositories.Database.Sqlite.SqliteLocationsDbContext" => "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddLocationsModule(\n    locationsSection, databaseSection,\n    database => database.AddSqliteLocationsDbContext());",
        "KamiSama.Modules.Ticketing.Features.TicketCategories.IListTicketCategories" => "PagedResult<TicketCategoryListItemDto> categories = await listCategories.ListAsync(\n    new TicketCategorySearchModel(1, 20, null, \"name\"), cancellationToken);\n// Current Core registration for this specialized contract is non-assignable.",
        "KamiSama.Modules.Ticketing.Features.TicketCategories.IAddTicketCategory" => "TicketCategoryDto category = await addCategory.AddAsync(\n    new AddTicketCategoryRequest(\"Billing\"), cancellationToken);",
        "KamiSama.Modules.Ticketing.Features.TicketCategories.IUpdateTicketCategory" => "await updateCategory.UpdateAsync(categoryId,\n    new UpdateTicketCategoryRequest(\"Accounts\"), cancellationToken);",
        "KamiSama.Modules.Ticketing.Features.TicketCategories.IDeleteTicketCategory" => "await deleteCategory.DeleteAsync(categoryId, cancellationToken);\n// Current Core registration for this specialized contract is non-assignable.",
        "KamiSama.Modules.Ticketing.Features.TicketCategories.IFindTicketCategoryById" => "TicketCategoryDto category = await findCategory.FindByIdAsync(categoryId, cancellationToken);",
        "KamiSama.Modules.Ticketing.Features.TicketCategories.IFindTicketCategoryByName" => "TicketCategoryDto category = await findCategory.FindByNameAsync(\"Billing\", cancellationToken);",
        "KamiSama.Modules.Ticketing.Features.TicketCategories.IExistsTicketCategoryById" => "bool exists = await categoryExists.ExistsByIdAsync(categoryId, cancellationToken);",
        "KamiSama.Modules.Ticketing.Features.TicketCategories.IExistsTicketCategoryByName" => "bool exists = await categoryExists.ExistsByNameAsync(\"Billing\", cancellationToken);\n// Current Core registration for this specialized contract is non-assignable.",
        "KamiSama.Modules.Ticketing.Features.Tickets.IListTickets" => "PagedResult<TicketListItemDto> tickets = await listTickets.ListAsync(\n    new TicketSearchModel(1, 20, null, null, userId, [TicketStatus.Open], null, \"updatedat\"),\n    cancellationToken);",
        "KamiSama.Modules.Ticketing.Features.Tickets.IAddTicket" => "TicketDto ticket = await addTicket.AddAsync(new AddTicketRequest(\n    userId, \"Cannot sign in\", categoryId, \"The login form rejects my password.\",\n    TicketPriority.High, []), cancellationToken);",
        "KamiSama.Modules.Ticketing.Features.Tickets.IUpdateTicketState" => "// Open and reopened tickets can transition to resolved.\nawait updateTicket.UpdateAsync(ticketId,\n    new UpdateTicketStateRequest(\"Cannot sign in\", TicketStatus.Resolved, TicketPriority.High),\n    cancellationToken);",
        "KamiSama.Modules.Ticketing.Features.Tickets.IFindTicketById" => "TicketDto ticket = await findTicket.FindByIdAsync(ticketId, cancellationToken);",
        "KamiSama.Modules.Ticketing.Features.Tickets.IAddCommentToTicket" => "TicketDto ticket = await addComment.AddAsync(new AddTicketCommentRequest(\n    ticketId, userId, TicketCommentSide.User, \"This still occurs.\", []), cancellationToken);",
        "KamiSama.Modules.Ticketing.Features.Tickets.IUpdateTicketComment" => "await updateComment.UpdateAsync(commentId,\n    new UpdateTicketCommentRequest(commentId, userId, \"Corrected details.\"), cancellationToken);\n// Current Core ignores the first commentId and uses the request value.",
        "KamiSama.Modules.Ticketing.Features.Tickets.IAddAttachmentToTicketComment" => "TicketDto ticket = await addAttachment.AddAsync(\n    new AddAttachmentToTicketCommentRequest(commentId, userId, [contentId]),\n    cancellationToken);",
        "KamiSama.Modules.Ticketing.Features.Tickets.IRemoveAttachementFromTicketComment" => "await removeAttachment.DeleteAsync(attachmentId, cancellationToken);",
        "KamiSama.Modules.Ticketing.Entities.Ticket" => "bool mayResolve = ticket.CanTransitionTo(TicketStatus.Resolved);\nbool mayEdit = ticket.IsEditable();\n// Endpoint policy must still authorize the caller before a mutation.",
        "KamiSama.Modules.Ticketing.Entities.TicketCategory" => "var category = new TicketCategory\n{\n    Id = Guid.NewGuid(),\n    Name = \"Billing\",\n    CreatedAt = DateTime.UtcNow,\n    UpdatedAt = DateTime.UtcNow\n};",
        "KamiSama.Modules.Ticketing.Entities.TicketComment" => "var comment = new TicketComment\n{\n    Ticket = ticket,\n    AuthorUserId = userId,\n    Comment = \"Additional details\",\n    Side = TicketCommentSide.User,\n    CreatedAt = DateTime.UtcNow,\n    UpdatedAt = DateTime.UtcNow\n};",
        "KamiSama.Modules.Ticketing.Entities.TicketAttachment" => "var attachment = new TicketAttachment\n{\n    Comment = comment,\n    ContentId = contentId,\n    AuthorUserId = userId\n};",
        "KamiSama.Modules.Ticketing.Repositories.Database.TicketingDbContext" => "using IServiceScope scope = app.Services.CreateScope();\nTicketingDbContext context = scope.ServiceProvider.GetRequiredService<TicketingDbContext>();\nList<Ticket> open = await context.Tickets.AsNoTracking()\n    .Where(ticket => ticket.Status == TicketStatus.Open)\n    .ToListAsync(cancellationToken);",
        "KamiSama.Modules.Ticketing.Repositories.Database.Postgresql.PostgresqlTicketingDbContext" => "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddTicketingModule(\n    ticketingSection, databaseSection,\n    database => database.AddPostgresqlTicketingDbContext());",
        "KamiSama.Modules.Ticketing.Repositories.Database.Sqlite.SqliteTicketingDbContext" => "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddTicketingModule(\n    ticketingSection, databaseSection,\n    database => database.AddSqliteTicketingDbContext());",
        "KamiSama.Testing.NSubstitute.TesterBuilderBase" => "using KamiSama.Testing.NSubstitute;\nusing NSubstitute;\n\npublic sealed class ProductServiceTestsBuilder : TesterBuilderBase\n{\n    public IProductRepository Repository { get; }\n\n    public ProductServiceTestsBuilder()\n    {\n        Repository = AddScoped<IProductRepository>();\n        AddOption<ProductOptions>(options => options.PageSize = 20);\n    }\n\n    public ProductService Build() => BuildService<ProductService>();\n}\n\nvar builder = new ProductServiceTestsBuilder();\nbuilder.Repository.Find(42).Returns(new Product(42, \"Keyboard\"));\nProductService service = builder.Build();\nILogger<ProductService> logger = builder.For<ILogger<ProductService>>();",
        _ => ""
    };
    if (!string.IsNullOrWhiteSpace(reviewedExample))
    {
        return reviewedExample;
    }

    if (fullName == "KamiSama.Repositories.ConnectionStringOption")
    {
        return """
using KamiSama.Repositories;

var database = new ConnectionStringOption
{
    Provider = "sqlite",
    ConnectionString = "Data Source=app.db"
};
""";
    }

    if (fullName == "KamiSama.Repositories.Initialization.DataInitializationOptions")
    {
        return """
using KamiSama.Repositories.Initialization;

await initializer.InitializeAsync(new DataInitializationOptions
{
    Migrate = true,
    InitializeData = true,
    InitializeTestData = false
}, cancellationToken);
""";
    }

    if (fullName == "KamiSama.Repositories.InMemoryRepository<TEntity>")
    {
        return """
using KamiSama.Repositories;

using var repository = new InMemoryRepository<User>(users, UserIdComparer.Instance);
repository.Add(new User { Id = 42, Name = "Ada" });

User? user = repository.Find(x => x.Id == 42);
List<User> allUsers = repository.GetAll().ToList();
""";
    }

    if (fullName == "KamiSama.Repositories.IRepository<TEntity>")
    {
        return """
using KamiSama.Repositories;

public sealed class UserService(IRepository<User> users)
{
    public User? FindByEmail(string email) => users.Find(user => user.Email == email);
}
""";
    }

    if (fullName == "KamiSama.Repositories.IAsyncRepository<_EntityType>")
    {
        return """
using KamiSama.Repositories;

public sealed class UserService(IAsyncRepository<User> users)
{
    public Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken)
        => users.FindAsync(user => user.Email == email, cancellationToken);
}
""";
    }

    if (fullName == "KamiSama.Repositories.IQueryableRepository<TEntity>")
    {
        return """
using KamiSama.Repositories;

IQueryable<User> activeUsers = repository.Where(user => user.IsActive);
""";
    }

    if (fullName == "KamiSama.Repositories.IAsyncQueryableRepository<TEntity>")
    {
        return """
using KamiSama.Repositories;

// Where returns IQueryable<TEntity> synchronously even on this async repository contract.
IQueryable<User> activeUsers = repository.Where(user => user.IsActive);
User? user = await repository.FindAsync(user => user.Id == userId, cancellationToken);
""";
    }

    if (fullName == "KamiSama.Repositories.Initialization.IDatabaseInitializer<TDbContext>")
    {
        return """
using KamiSama.Repositories.Initialization;

public sealed class StartupDatabase(AppDbContext context) : IDatabaseInitializer<AppDbContext>
{
    public Task InitializeAsync(DataInitializationOptions options, CancellationToken cancellationToken)
        => options.InitializeData ? SeedAsync(context, cancellationToken) : Task.CompletedTask;
}
""";
    }

    if (fullName == "KamiSama.Repositories.EntityFramework.DbRepository<TEntity>")
    {
        return """
using KamiSama.Repositories.EntityFramework;

var repository = new DbRepository<User>(dbContext);
await repository.AddAsync(new User { Name = "Ada" }, cancellationToken);
User? user = await repository.FindAsync(x => x.Id == userId, cancellationToken);
// The repository saves immediately and does not own dbContext.
""";
    }

    if (fullName == "KamiSama.Repositories.EntityFramework.DbRepository<TEntity, TDbContext>")
    {
        return """
using KamiSama.Repositories.EntityFramework;

public sealed class UserRepository(AppDbContext context)
    : DbRepository<User, AppDbContext>(context)
{
    public IQueryable<User> Active() => Context.Users.Where(user => user.IsActive);
}
""";
    }

    if (fullName == "KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>")
    {
        return """
using KamiSama.Repositories.EntityFrameworkCore;

var repository = new DbRepository<User>(dbContext);
await repository.AddAsync(new User { Name = "Ada" }, cancellationToken);
User? user = await repository.FindAsync(x => x.Id == userId, cancellationToken);
// The repository saves immediately and does not own dbContext.
""";
    }

    if (fullName == "KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity, TDbContext>")
    {
        return """
using KamiSama.Repositories.EntityFrameworkCore;

public sealed class UserRepository(AppDbContext context)
    : DbRepository<User, AppDbContext>(context)
{
    public IQueryable<User> Active() => Context.Users.Where(user => user.IsActive);
}
""";
    }

    if (fullName == "KamiSama.Repositories.EntityFrameworkCore.IQueryableExtensions")
    {
        return """
using KamiSama.Extensions.Paging;
using KamiSama.Repositories.EntityFrameworkCore;

PagedResult<User> page = await dbContext.Users
    .AsNoTracking()
    .OrderBy(user => user.Id)
    .MakePagedAsync(SearchModel.FromPage(1, 20), cancellationToken);
""";
    }

    if (fullName == "KamiSama.Repositories.EntityFrameworkCore.IMultiProviderDbContextBuilder")
    {
        return """
using KamiSama.Repositories.EntityFrameworkCore;

static void Inspect(IMultiProviderDbContextBuilder builder)
{
    Console.WriteLine($"{builder.ConnectionStringOption.Provider}: {builder.BaseContextType.Name}");
}
""";
    }

    if (fullName == "KamiSama.Repositories.EntityFrameworkCore.IMultiProviderDbContextBuilder<TBaseContext>")
    {
        return """
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;

IMultiProviderDbContextBuilder<AppDbContext> contexts = services
    .AddMultiProviderDbContext<AppDbContext>(configuration.GetSection("Database"));
contexts.WithMigrationHistoryTable("__AppMigrationsHistory")
    .AddPostgresql<PostgresqlAppDbContext>();
""";
    }

    if (fullName == "KamiSama.Repositories.EntityFrameworkCore.ServiceCollectionExtensions")
    {
        return """
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;
using KamiSama.Repositories.EntityFrameworkCore.Sqlite;

services.AddMultiProviderDbContext<AppDbContext>(configuration.GetSection("Database"))
    .WithMigrationHistoryTable("__AppMigrationsHistory")
    .AddPostgresql<PostgresqlAppDbContext>()
    .AddSqlite<SqliteAppDbContext>();
""";
    }

    if (fullName == "KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>")
    {
        return """
using KamiSama.Repositories.EntityFrameworkCore.Initialization;

public sealed class AppDatabaseInitializer(AppDbContext context)
    : DatabaseInitializerBase<AppDbContext>(context)
{
    protected override async Task InitializeDataAsync(CancellationToken cancellationToken)
    {
        await TryAdd(user => user.Name == "Admin", new User { Name = "Admin" }, cancellationToken);
    }

    protected override Task InitializeTestDataAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
""";
    }

    if (fullName == "KamiSama.Repositories.EntityFrameworkCore.Initialization.DefaultDatabaseInitializer<TDbContext>")
    {
        return """
using KamiSama.Repositories.EntityFrameworkCore.Initialization;
using KamiSama.Repositories.Initialization;

var initializer = new DefaultDatabaseInitializer<AppDbContext>(dbContext);
await initializer.InitializeAsync(
    new DataInitializationOptions { Migrate = true }, cancellationToken);
""";
    }

    if (fullName == "KamiSama.Repositories.Json.JsonRepository<TEntity>")
    {
        return """
using KamiSama.Repositories.Json;

using var repository = new JsonRepository<User>("data/users.json", UserIdComparer.Instance);
repository.LoadFailed += (_, error) => logger.LogError(error, "Could not load users");
repository.SaveFailed += (_, error) => logger.LogError(error, "Could not save users");

User? user = await repository.FindAsync(x => x.Id == userId, cancellationToken);
""";
    }

    if (fullName == "KamiSama.Repositories.Xml.XmlFileRepository<TEntity>")
    {
        return """
using System.Xml.Serialization;
using KamiSama.Repositories.Xml;

var serializer = new XmlSerializer(typeof(User));
using var fileRepository = new XmlFileRepository<User>(
    "data/users", user => $"{user.Id}.xml", serializer, UserIdComparer.Instance);

User? user = await fileRepository.FindAsync(x => x.Id == userId, cancellationToken);
// Read only: version 10.0.0 cannot durably add, update, or delete XML files.
""";
    }

    if (fullName == "KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>")
    {
        return """
using System.Xml.Serialization;
using KamiSama.Repositories.Xml;

var serializer = new XmlSerializer(typeof(User));
using var directoryRepository = new XmlDirectoryRepository<User>(
    "data/users", user => $"{user.Id}.xml", serializer, UserIdComparer.Instance);

IQueryable<User> activeUsers = await directoryRepository.WhereAsync(
    user => user.IsActive, cancellationToken);
// Read only: version 10.0.0 cannot durably add, update, or delete XML files.
""";
    }

    if (fullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "AddFeatureBase")
    {
        return """
using KamiSama.Chassis.Commons.Features;
using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Chassis.HttpExceptions;
using KamiSama.Extensions.Paging;

public sealed record AddProductRequest(string Name, decimal Price);
public sealed record UpdateProductRequest(string Name, decimal Price);
public sealed record ProductDto(Guid Id, string Name, decimal Price);
public sealed class Product { public Guid Id { get; set; } public string Name { get; set; } = ""; public decimal Price { get; set; } }

public interface IProductRepository :
    IGenericRepository<Product, SearchModel>,
    ILookupByIdRepository<Product, Guid>,
    ILookupByNameRepository<Product>
{
}

public sealed class ProductFeatures
    : FeatureDefinitionBase<Product, ProductDto, AddProductRequest, UpdateProductRequest, IProductRepository, SearchModel, Guid>
{
    public sealed class AddProduct(IProductRepository repository) : AddFeatureBase(repository)
    {
        protected override async Task CheckDuplicateAsync(AddProductRequest request, CancellationToken cancellationToken)
        {
            if (await Repository.ExistsByNameAsync(request.Name, cancellationToken))
                throw new AlreadyExistsException<Product>(request.Name, nameof(request.Name));
        }

        protected override Task<Product> ConvertToEntity(AddProductRequest request, CancellationToken cancellationToken)
            => Task.FromResult(new Product { Id = Guid.NewGuid(), Name = request.Name, Price = request.Price });

        protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
            => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
    }
}
""";
    }

    if (fullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "FeatureDefinitionBase")
    {
        return """
using KamiSama.Chassis.Commons.Features;
using KamiSama.Extensions.Paging;

public sealed class ProductFeatures
    : FeatureDefinitionBase<Product, ProductDto, AddProductRequest, UpdateProductRequest, IProductRepository, SearchModel, Guid>
{
    public sealed class FindProduct(IProductRepository repository) : FindByIdFeatureBase(repository)
    {
        protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
            => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
    }
}
""";
    }

    if (fullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "UpdateFeatureBase")
    {
        return """
public sealed class ProductFeatures
    : FeatureDefinitionBase<Product, ProductDto, AddProductRequest, UpdateProductRequest, IProductRepository, SearchModel, Guid>
{
    public sealed class UpdateProduct(IProductRepository repository) : UpdateFeatureBase(repository)
    {
        protected override Task PatchEntityAsync(Product entity, UpdateProductRequest request, CancellationToken cancellationToken)
        {
            entity.Name = request.Name;
            entity.Price = request.Price;
            return Task.CompletedTask;
        }
    }
}
""";
    }

    if (fullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "DeleteFeatureBase")
    {
        return """
public sealed class ProductFeatures
    : FeatureDefinitionBase<Product, ProductDto, AddProductRequest, UpdateProductRequest, IProductRepository, SearchModel, Guid>
{
    public sealed class DeleteProduct(IProductRepository repository) : DeleteFeatureBase(repository)
    {
        protected override Task<bool> CanBeDeletedAsync(IProductRepository repository, Product entity)
            => Task.FromResult(!entity.HasOpenOrders);
    }
}
""";
    }

    if (fullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "ListFeatureBase")
    {
        return """
public sealed class ProductFeatures
    : FeatureDefinitionBase<Product, ProductDto, AddProductRequest, UpdateProductRequest, IProductRepository, SearchModel, Guid>
{
    public sealed class ListProducts(IProductRepository repository) : ListFeatureBase(repository)
    {
        protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
            => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
    }
}
""";
    }

    if (fullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "FindByIdFeatureBase")
    {
        return """
public sealed class ProductFeatures
    : FeatureDefinitionBase<Product, ProductDto, AddProductRequest, UpdateProductRequest, IProductRepository, SearchModel, Guid>
{
    public sealed class FindProduct(IProductRepository repository) : FindByIdFeatureBase(repository)
    {
        protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
            => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
    }
}
""";
    }

    if (fullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "ExistsByIdFeatureBase")
    {
        return """
public sealed class ProductFeatures
    : FeatureDefinitionBase<Product, ProductDto, AddProductRequest, UpdateProductRequest, IProductRepository, SearchModel, Guid>
{
    public sealed class ProductExists(IProductRepository repository) : ExistsByIdFeatureBase(repository);
}
""";
    }

    if (fullName == "KamiSama.Chassis.Commons.Features.GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>")
    {
        return """
using KamiSama.Chassis.Commons.Features;
using KamiSama.Chassis.HttpExceptions;

public sealed class AddProductFeature(IProductRepository repository)
    : GenericAddFeature<AddProductRequest, IProductRepository, Product, ProductDto>(repository)
{
    protected override async Task CheckDuplicateAsync(AddProductRequest request, CancellationToken cancellationToken)
    {
        if (await Repository.ExistsByNameAsync(request.Name, cancellationToken))
            throw new AlreadyExistsException<Product>(request.Name, nameof(request.Name));
    }

    protected override Task<Product> ConvertToEntity(AddProductRequest request, CancellationToken cancellationToken)
        => Task.FromResult(new Product { Id = Guid.NewGuid(), Name = request.Name, Price = request.Price });

    protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
        => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
}
""";
    }

    if (fullName == "KamiSama.Chassis.Commons.Features.GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>")
    {
        return """
public sealed class UpdateProductFeature(IProductRepository repository)
    : GenericUpdateFeature<UpdateProductRequest, Product, IProductRepository, Guid>(repository)
{
    protected override Task PatchEntityAsync(Product entity, UpdateProductRequest request, CancellationToken cancellationToken)
    {
        entity.Name = request.Name;
        entity.Price = request.Price;
        return Task.CompletedTask;
    }
}
""";
    }

    if (fullName == "KamiSama.Chassis.Commons.Features.GenericDeleteFeature<TEntity, TRepository, TKey>")
    {
        return """
public sealed class DeleteProductFeature(IProductRepository repository)
    : GenericDeleteFeature<Product, IProductRepository, Guid>(repository)
{
    protected override Task<bool> CanBeDeletedAsync(IProductRepository repository, Product entity)
        => Task.FromResult(!entity.HasOpenOrders);
}
""";
    }

    if (fullName == "KamiSama.Chassis.Commons.Features.GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>")
    {
        return """
using KamiSama.Extensions.Paging;

public sealed class ListProductsFeature(IProductRepository repository)
    : GenericListFeature<Product, ProductDto, SearchModel, IProductRepository>(repository)
{
    protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
        => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
}
""";
    }

    if (fullName == "KamiSama.Chassis.Commons.Features.GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository, TPagedResult, TRepositoryPagedResult>")
    {
        return """
public sealed class ListProductsFeature(IProductRepository repository)
    : GenericListFeature<Product, ProductDto, ProductSearch, IProductRepository, ProductPage, ProductEntityPage>(repository)
{
    protected override Task<ProductPage> ConvertResult(ProductEntityPage result, CancellationToken cancellationToken)
        => Task.FromResult(new ProductPage(result.Items.Select(ProductDto.FromEntity), result.TotalCount));
}
""";
    }

    if (fullName == "KamiSama.Chassis.Commons.Features.GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>")
    {
        return """
public sealed class FindProductById(IProductRepository repository)
    : GenericFindByIdFeature<Product, ProductDto, IProductRepository, Guid>(repository)
{
    protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
        => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
}
""";
    }

    if (fullName == "KamiSama.Chassis.Commons.Features.GenericFindByNameFeature<TEntity, TEntityDto, TRepository>")
    {
        return """
public sealed class FindProductByName(IProductRepository repository)
    : GenericFindByNameFeature<Product, ProductDto, IProductRepository>(repository)
{
    protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
        => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
}
""";
    }

    if (fullName == "KamiSama.Chassis.Commons.Features.GenericExistsByIdFeature<TEntity, TRepository, TKey>")
    {
        return """
public sealed class ProductExistsById(IProductRepository repository)
    : GenericExistsByIdFeature<Product, IProductRepository, Guid>(repository);

bool exists = await productExistsById.ExistsByIdAsync(productId, cancellationToken);
""";
    }

    if (fullName == "KamiSama.Chassis.Commons.Features.GenericExistsByNameFeature<TEntity, TRepository>")
    {
        return """
public sealed class ProductExistsByName(IProductRepository repository)
    : GenericExistsByNameFeature<Product, IProductRepository>(repository);

bool exists = await productExistsByName.ExistsByNameAsync("Keyboard", cancellationToken);
""";
    }

    if (fullName == "KamiSama.Chassis.Commons.Repositories.GenericRepository<TEntity, TSearchModel, TDbContext>")
    {
        return """
using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Extensions.Paging;

public sealed class ProductRepository(AppDbContext context)
    : GenericRepository<Product, SearchModel, AppDbContext>(context), IProductRepository
{
    protected override IQueryable<Product> ApplySearchModel(IQueryable<Product> query, SearchModel searchModel)
        => query;
}
""";
    }

    if (fullName == "KamiSama.Chassis.Commons.Repositories.GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>")
    {
        return """
public sealed class ProductRepository(AppDbContext context)
    : GenericRepository<Product, ProductSearch, AppDbContext, ProductPage>(context)
{
    protected override IQueryable<Product> ApplySearchModel(IQueryable<Product> query, ProductSearch search)
        => string.IsNullOrWhiteSpace(search.Name) ? query : query.Where(product => product.Name.Contains(search.Name));

    protected override async Task<ProductPage> MakeResultAsync(IQueryable<Product> query, ProductSearch search, CancellationToken cancellationToken)
        => await ProductPage.CreateAsync(query, search, cancellationToken);
}
""";
    }

    return shortName switch
    {
        "HttpExceptionBase" when fullName == "KamiSama.Chassis.HttpExceptions.HttpExceptionBase" => """
using KamiSama.Chassis.HttpExceptions;

public sealed class TooManyRequestsException : HttpExceptionBase
{
    public override int StatusCode => 429;

    public TooManyRequestsException(TimeSpan retryAfter)
        : base(nameof(TooManyRequestsException), retryAfter)
    {
        ExtendedProperties["retryAfterSeconds"] = retryAfter.TotalSeconds;
    }
}
""",
        "AlreadyExistsException" when fullName == "KamiSama.Chassis.HttpExceptions.AlreadyExistsException<TEntity>" => """
using KamiSama.Chassis.HttpExceptions;

if (await repository.ExistsByNameAsync(request.Name, cancellationToken))
    throw new AlreadyExistsException<Product>(request.Name, nameof(request.Name));
""",
        "NotFoundException" when fullName == "KamiSama.Chassis.HttpExceptions.NotFoundException<TEntity>" => """
using KamiSama.Chassis.HttpExceptions;

Product product = await repository.FindByIdAsync(id, cancellationToken)
    ?? throw new NotFoundException<Product>(id, nameof(id));
""",
        "ServiceUnavailableException" when fullName == "KamiSama.Chassis.HttpExceptions.ServiceUnavailableException" => """
using KamiSama.Chassis.HttpExceptions;

if (!catalogHealth.IsAvailable)
    throw new ServiceUnavailableException("Catalog");
""",
        "IProblemDetailsDataProvider" when fullName == "KamiSama.Chassis.ProblemDetails.IProblemDetailsDataProvider" => """
using KamiSama.Chassis.ProblemDetails;

public sealed class SafeProblemDetailsProvider : IProblemDetailsDataProvider
{
    public IStringLocalizer? Localizer { get; set; }
    public bool LocalizeArguments { get; set; }

    public ProblemDetails ConvertExceptionToProblemDetails(Exception exception)
        => new() { Title = "The request failed.", Status = 500 };
}
""",
        "KamiSamaProblemDetailsProvider" when fullName == "KamiSama.Chassis.ProblemDetails.KamiSamaProblemDetailsProvider" => """
using KamiSama.Chassis.ProblemDetails;

var provider = new KamiSamaProblemDetailsProvider
{
    Localizer = errorLocalizer,
    LocalizeArguments = true
};

ProblemDetails details = provider.ConvertExceptionToProblemDetails(exception);
""",
        "ProblemDetailsExceptionFilter" when fullName == "KamiSama.Chassis.ProblemDetails.ProblemDetailsExceptionFilter" => """
using KamiSama.Chassis.ProblemDetails;

services.AddControllers()
    .AddExceptionFilterForProblemDetails(options => options.UseDefaultProblemDetailsProvider());
// MVC resolves and invokes ProblemDetailsExceptionFilter globally.
""",
        "IAddFeature" when fullName == "KamiSama.Chassis.Commons.Features.IAddFeature<TAddRequest, TEntityDto>" => """
ProductDto created = await addProduct.AddAsync(
    new AddProductRequest("Keyboard", 120m), cancellationToken);
""",
        "IDeleteFeature" when fullName == "KamiSama.Chassis.Commons.Features.IDeleteFeature<TKey>" => """
await deleteProduct.DeleteAsync(productId, cancellationToken);
""",
        "IExistsByIdFeature" when fullName == "KamiSama.Chassis.Commons.Features.IExistsByIdFeature<TKey>" => """
bool exists = await productExists.ExistsByIdAsync(productId, cancellationToken);
""",
        "IExistsByNameFeature" when fullName == "KamiSama.Chassis.Commons.Features.IExistsByNameFeature" => """
bool exists = await productExists.ExistsByNameAsync("Keyboard", cancellationToken);
""",
        "IFindByIdFeature" when fullName == "KamiSama.Chassis.Commons.Features.IFindByIdFeature<TEntityDto, TKey>" => """
ProductDto product = await findProduct.FindByIdAsync(productId, cancellationToken);
""",
        "IFindByNameFeature" when fullName == "KamiSama.Chassis.Commons.Features.IFindByNameFeature<TEntityDto>" => """
ProductDto product = await findProduct.FindByNameAsync("Keyboard", cancellationToken);
""",
        "IListFeature" when fullName == "KamiSama.Chassis.Commons.Features.IListFeature<TEntityDto, TSearchModel, TPageResult>" => """
ProductPage page = await listProducts.ListAsync(
    new ProductSearch { PageNumber = 1, PageSize = 20 }, cancellationToken);
""",
        "IUpdateFeature" when fullName == "KamiSama.Chassis.Commons.Features.IUpdateFeature<TEntityDto, TKey>" => """
await updateProduct.UpdateAsync(
    productId, new UpdateProductRequest("Keyboard", 120m), cancellationToken);
""",
        "IAddableRepository" when fullName == "KamiSama.Chassis.Commons.Repositories.IAddableRepository<TEntity>" => """
await products.AddAsync(product, cancellationToken);
""",
        "IDeletableRepository" when fullName == "KamiSama.Chassis.Commons.Repositories.IDeletableRepository<TEntity>" => """
await products.DeleteAsync(product, cancellationToken);
""",
        "IGenericRepository" when fullName == "KamiSama.Chassis.Commons.Repositories.IGenericRepository<TEntity, TSeaerchModel, TPagedResult>" => """
public interface IProductRepository
    : IGenericRepository<Product, ProductSearch, ProductPage>,
      ILookupByIdRepository<Product, Guid>
{
}
""",
        "IListingRepository" when fullName == "KamiSama.Chassis.Commons.Repositories.IListingRepository<TEntity, TSearchModel, TPagedResult>" => """
ProductPage page = await products.ListAsync(search, cancellationToken);
int total = await products.CountAsync(search, cancellationToken);
""",
        "ILookupByIdRepository" when fullName == "KamiSama.Chassis.Commons.Repositories.ILookupByIdRepository<TEntity, TKey>" => """
Product? product = await products.FindByIdAsync(productId, cancellationToken);
bool exists = await products.ExistsByIdAsync(productId, cancellationToken);
""",
        "ILookupByNameRepository" when fullName == "KamiSama.Chassis.Commons.Repositories.ILookupByNameRepository<TEntity>" => """
Product? product = await products.FindByNameAsync("Keyboard", cancellationToken);
bool exists = await products.ExistsByNameAsync("Keyboard", cancellationToken);
""",
        "IUpdatableRepository" when fullName == "KamiSama.Chassis.Commons.Repositories.IUpdatableRepository<TEntity>" => """
product.Name = "Mechanical Keyboard";
await products.UpdateAsync(product, cancellationToken);
""",
        "IRestBuilder" when fullName == "KamiSama.Extensions.RestSharp.IRestBuilder" => """
using KamiSama.Extensions.RestSharp;

ProductDto product = await restBuilder
    .ForServiceUrl("https://api.example.com", "products/{id}")
    .AddUrlSegment("id", 42)
    .AddHeader("X-Correlation-Id", correlationId)
    .GetAsync<ProductDto>(cancellationToken);
""",
        "ServiceCollectionExtensions" when fullName == "KamiSama.Extensions.RestSharp.ServiceCollectionExtensions" => """
using KamiSama.Extensions.RestSharp;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddHttpClient();
services.AddKamiSamaRestSharp();
""",
        "CannotFindExternalServiceException" when fullName == "KamiSama.ExternalServices.Exceptions.Exceptions.CannotFindExternalServiceException" => """
using KamiSama.ExternalServices.Exceptions.Exceptions;

throw new CannotFindExternalServiceException("Email", configuredProvider);
""",
        "ExternalServiceTimedOutException" when fullName == "KamiSama.ExternalServices.Exceptions.Exceptions.ExternalServiceTimedOutException" => """
using KamiSama.ExternalServices.Exceptions.Exceptions;

throw new ExternalServiceTimedOutException("Email", "The provider did not respond in time.");
""",
        "InvalidResponseForExternalServiceException" when fullName == "KamiSama.ExternalServices.Exceptions.Exceptions.InvalidResponseForExternalServiceException" => """
using KamiSama.ExternalServices.Exceptions.Exceptions;

throw new InvalidResponseForExternalServiceException("Email", "The provider response was invalid.");
""",
        "ISendEmail" when fullName == "KamiSama.ExternalServices.Email.Features.ISendEmail" => """
using KamiSama.ExternalServices.Email.Features;

var request = new SendEmailRequest(
    "customer@example.com",
    "Order received",
    "<p>Thank you for your order.</p>",
    IsHtml: true);

await sendEmail.SendEmailAsync(request, cancellationToken);
""",
        "EmailCoreServicesModule" when fullName == "KamiSama.ExternalServices.Email.EmailCoreServicesModule" => """
using KamiSama.ExternalServices.Email;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
var builder = webBuilder.Extend();
builder.AddModule(new EmailCoreServicesModule(
    webBuilder.Configuration.GetSection("EmailDefaults")));
""",
        "EmailDefaultsOptions" when fullName == "KamiSama.ExternalServices.Email.EmailDefaultsOptions" => """
using KamiSama.ExternalServices.Email;

var defaults = new EmailDefaultsOptions
{
    Email = "mock"
};
""",
        "ExtendedWebApplicationBuilderExtensions" when fullName == "KamiSama.ExternalServices.Email.ExtendedWebApplicationBuilderExtensions" => """
using KamiSama.ExternalServices.Email;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
var builder = webBuilder.Extend()
    .AddCoreEmailServices(webBuilder.Configuration.GetSection("EmailDefaults"));
""",
        "ExtendedWebApplicationBuilderExtensions" when fullName == "KamiSama.ExternalServices.Email.Smtp.ExtendedWebApplicationBuilderExtensions" => """
using KamiSama.ExternalServices.Email.Smtp;

builder.AddSmtpEmailServiceModule(
    webBuilder.Configuration.GetSection("Email:Smtp"));
""",
        "SmtpOptions" when fullName == "KamiSama.ExternalServices.Email.Smtp.SmtpOptions" => """
using KamiSama.ExternalServices.Email.Smtp;

var options = new SmtpOptions
{
    Host = "smtp.example.com",
    Port = 587,
    Username = "smtp-user",
    Password = smtpPassword,
    UseSsl = true,
    SenderAddress = "noreply@example.com",
    SenderAddressName = "Example App"
};

bool valuesArePresent = options.IsValid();
// Known defect: the current internal sender throws when this value is true.
""",
        "ISendSms" when fullName == "KamiSama.ExternalServices.Sms.Features.ISendSms" => """
using KamiSama.ExternalServices.Sms.Features;

var request = new SendSmsRequest("+15551234567", "Your code is 123456");
await sendSms.SendSmsAsync(request, cancellationToken);
""",
        "SmsCoreServicesModule" when fullName == "KamiSama.ExternalServices.Sms.SmsCoreServicesModule" => """
using KamiSama.ExternalServices.Sms;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
var builder = webBuilder.Extend();
builder.AddModule(new SmsCoreServicesModule(
    webBuilder.Configuration.GetSection("SmsDefaults")));

var app = await builder.BuildAsync(CancellationToken.None);
""",
        "SmsDefaultsOptions" when fullName == "KamiSama.ExternalServices.Sms.SmsDefaultsOptions" => """
using KamiSama.ExternalServices.Sms;

var defaults = new SmsDefaultsOptions
{
    Sms = "mock"
};
""",
        "ExtendedWebApplicationBuilderExtensions" when fullName == "KamiSama.ExternalServices.Sms.ExtendedWebApplicationBuilderExtensions" => """
using KamiSama.ExternalServices.Sms;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
var builder = webBuilder.Extend()
    .AddSmsCoreServicesModule(webBuilder.Configuration.GetSection("SmsDefaults"));

var app = await builder.BuildAsync(CancellationToken.None);
""",
        "ExtendedWebApplicationBuilderExtensions" when fullName == "KamiSama.ExternalServices.Sms.Kavenegar.ExtendedWebApplicationBuilderExtensions" => """
using KamiSama.ExternalServices.Sms;
using KamiSama.ExternalServices.Sms.Kavenegar;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
var builder = webBuilder.Extend()
    .AddSmsCoreServicesModule(webBuilder.Configuration.GetSection("SmsDefaults"))
    .AddKavenegarSmsServiceModule(webBuilder.Configuration.GetSection("Sms:Kavenegar"));

var app = await builder.BuildAsync(CancellationToken.None);
""",
        "KavenegarSmsOptions" when fullName == "KamiSama.ExternalServices.Sms.Kavenegar.KavenegarSmsOptions" => """
using KamiSama.ExternalServices.Sms.Kavenegar;

var options = new KavenegarSmsOptions
{
    SenderPhoneNumber = "+15551230000",
    ApiKey = Environment.GetEnvironmentVariable("KAVENEGAR_API_KEY")
};

bool apiKeyIsPresent = options.IsValid();
// Known defect: the current internal sender throws when this value is true.
""",
        "ExtendedWebApplicationBuilderExtensions" when fullName == "KamiSama.ExternalServices.Sms.NeoZarin.ExtendedWebApplicationBuilderExtensions" => """
using KamiSama.Extensions.RestSharp;
using KamiSama.ExternalServices.Sms;
using KamiSama.ExternalServices.Sms.NeoZarin;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
webBuilder.Services.AddHttpClient();
webBuilder.Services.AddKamiSamaRestSharp();

var builder = webBuilder.Extend()
    .AddSmsCoreServicesModule(webBuilder.Configuration.GetSection("SmsDefaults"))
    .AddNeoZarinSmsModule(webBuilder.Configuration.GetSection("Sms:NeoZarin"));

var app = await builder.BuildAsync(CancellationToken.None);
""",
        "NeoZarinSmsOptions" when fullName == "KamiSama.ExternalServices.Sms.NeoZarin.NeoZarinSmsOptions" => """
using KamiSama.ExternalServices.Sms.NeoZarin;

var options = new NeoZarinSmsOptions
{
    BaseUrl = "https://dashboard.neozarin.com",
    Username = Environment.GetEnvironmentVariable("NEOZARIN_USERNAME"),
    Password = Environment.GetEnvironmentVariable("NEOZARIN_PASSWORD"),
    SmsApiPath = "/api/json/sendgroupget",
    SmsSenderPhoneNumber = "+15551230000",
    SmsApi = Environment.GetEnvironmentVariable("NEOZARIN_SMS_API_KEY")
};

bool valuesArePresent = options.IsValidForSms();
// Known defect: the current internal sender throws when this value is true.
""",
        "IranSystemEncoding" when fullName == "KamiSama.IranSystem.IranSystemEncoding" => """
using KamiSama.IranSystem;

var encoding = new IranSystemEncoding();
string text = encoding.GetString(new byte[] { 0x80, 0x81, 0x82 });
byte[] bytes = encoding.GetBytes(text);
""",
        "ArrayExtensions" when fullName == "KamiSama.Extensions.ArrayExtensions" => """
int[] values = [1, 2];
int[] padded = values.Pad(4, 0);       // [1, 2, 0, 0]
int[] trimmed = padded.TrimEnd(0);     // [1, 2]
""",
        "ByteArrayExtensions" when fullName == "KamiSama.Extensions.ByteArrayExtensions" => """
byte[] data = [0xCA, 0xFE];
string hex = data.ToHex("-");          // CA-FE
string base64 = data.ToBase64();
""",
        "ConversionExtensions" when fullName == "KamiSama.Extensions.ConversionExtensions" => """
object value = "42";
int number = value.ConvertTo(-1);       // 42
int fallback = "invalid".ConvertTo(-1); // -1
""",
        "CryptographyExtensions" when fullName == "KamiSama.Extensions.CryptographyExtensions" => """
using System.Security.Cryptography;
using System.Text;

byte[] key = RandomNumberGenerator.GetBytes(32);
byte[] iv = RandomNumberGenerator.GetBytes(16);
byte[] plaintext = Encoding.UTF8.GetBytes("secret");

byte[] cipher = plaintext.AesEncrypt(key, iv, padding: PaddingMode.PKCS7);
byte[] restored = cipher.AesDecrypt(key, iv, padding: PaddingMode.PKCS7);
""",
        "HashExtensions" when fullName == "KamiSama.Extensions.HashExtensions" => """
using System.Security.Cryptography;

using var sha256 = SHA256.Create();
string digest = "message".ComputeHashHex(sha256);
""",
        "IQueryableExtensions" when fullName == "KamiSama.Extensions.IQueryableExtensions" => """
using KamiSama.Extensions.Paging;

IQueryable<string> query = new[] { "one", "two", "three" }.AsQueryable();
PagedResult<string> page = query.MakePaged(SearchModel.FromPage(1, 2));
""",
        "LoggerExtensions" when fullName == "KamiSama.Extensions.LoggerExtensions" => """
using Microsoft.Extensions.Logging;

void ProcessOrder(ILogger logger, Guid orderId)
{
    logger.LogMethodEntry(argsToLog: orderId);
}
""",
        "LoggerExtensions" when fullName == "KamiSama.Extensions.Logging.LoggerExtensions" => """
using KamiSama.Extensions.Logging;
using Microsoft.Extensions.Logging;

public sealed class OrderService(ILogger<OrderService> logger)
{
    public void Process(Guid orderId)
    {
        logger.LogMethodEntry(argsToLog: orderId);
    }
}
""",
        "PersianDateLayoutRenderer" when fullName == "KamiSama.Extensions.NLog.PersianDateLayoutRenderer" => """
using KamiSama.Extensions.NLog;
using NLog.LayoutRenderers;

LayoutRenderer.Register<PersianDateLayoutRenderer>("persian-date");
var layout = NLog.Layouts.Layout.FromString("${persian-date:format=yyyy/MM/dd}");
""",
        "PersianLongDateLayoutRenderer" when fullName == "KamiSama.Extensions.NLog.PersianLongDateLayoutRenderer" => """
using KamiSama.Extensions.NLog;
using NLog.LayoutRenderers;

LayoutRenderer.Register<PersianLongDateLayoutRenderer>("persian-longDate");
var layout = NLog.Layouts.Layout.FromString("${persian-longDate}");
""",
        "PersianShortDateLayoutRenderer" when fullName == "KamiSama.Extensions.NLog.PersianShortDateLayoutRenderer" => """
using KamiSama.Extensions.NLog;
using NLog.LayoutRenderers;

LayoutRenderer.Register<PersianShortDateLayoutRenderer>("persian-shortDate");
var layout = NLog.Layouts.Layout.FromString("${persian-shortDate}");
""",
        "EncryptedZipArchiveFileCompressor" when fullName == "KamiSama.Extensions.NLog.EncryptedZipArchiveFileCompressor" => """
using KamiSama.Extensions.NLog;
using NLog.Targets;

string password = Environment.GetEnvironmentVariable("NLOG_ARCHIVE_PASSWORD")
    ?? throw new InvalidOperationException("NLOG_ARCHIVE_PASSWORD is not configured.");

PasswordFunc passwordFunc = (fileName, archiveFileName) => password;
ConcurrentFileTarget.FileCompressor = new EncryptedZipArchiveFileCompressor(passwordFunc);
""",
        "PersianDateTimeExtensions" when fullName == "KamiSama.Extensions.PersianDateTimeExtensions" => """
DateTime date = new(2026, 3, 21);
string persianDate = date.ToPersianString("yyyy/MM/dd");
DateTime parsed = persianDate.ParseExactAsPersianDateTime("yyyy/MM/dd");
""",
        "QueueExtensions" when fullName == "KamiSama.Extensions.QueueExtensions" => """
var queue = new Queue<string>();
string value = queue.DequeueOrDefault("none"); // none
""",
        "StreamExtensions" when fullName == "KamiSama.Extensions.StreamExtensions" => """
using var stream = new MemoryStream([1, 2, 3, 4]);
byte[] header = stream.ReadExact(2); // [1, 2]
""",
        "StringExtensions" when fullName == "KamiSama.Extensions.StringExtensions" => """
byte[] bytes = "KamiSama".ToBytes();
byte[] hexBytes = "CAFE".FromHex();
byte[] base64Bytes = "S2FtaVNhbWE=".FromBase64();
""",
        "TimeSpanExtensions" when fullName == "KamiSama.Extensions.TimeSpanExtensions" => """
TimeSpan timeout = 30.Seconds();
TimeSpan interval = 1.5.Minutes();
""",
        "BigIntegerJsonConverter" when fullName == "KamiSama.Extensions.Json.BigIntegerJsonConverter" => """
using System.Numerics;
using System.Text.Json;
using KamiSama.Extensions.Json;

var options = new JsonSerializerOptions();
options.Converters.Add(new BigIntegerJsonConverter());

string json = JsonSerializer.Serialize(BigInteger.Parse("12345678901234567890"), options);
BigInteger value = JsonSerializer.Deserialize<BigInteger>(json, options);
""",
        "DynamicObjectConverter" when fullName == "KamiSama.Extensions.Json.DynamicObjectConverter" => """
using System.Collections.Generic;
using System.Text.Json;
using KamiSama.Extensions.Json;

var options = new JsonSerializerOptions();
options.Converters.Add(new DynamicObjectConverter());

var value = JsonSerializer.Deserialize<object>("{\"name\":\"KamiSama\"}", options);
var properties = (IDictionary<string, object?>)value!;
""",
        "HexByteArrayJsonConverter" when fullName == "KamiSama.Extensions.Json.HexByteArrayJsonConverter" => """
using System.Text.Json;
using KamiSama.Extensions;

var options = new JsonSerializerOptions().AddHexByteConverter();
string json = JsonSerializer.Serialize(new byte[] { 0xCA, 0xFE }, options); // "CAFE"
byte[]? value = JsonSerializer.Deserialize<byte[]>(json, options);
""",
        "HierarchicalJsonConverter" when fullName.StartsWith("KamiSama.Extensions.Json.HierarchicalJsonConverter<", StringComparison.Ordinal) => """
using System.Text.Json;
using System.Text.Json.Serialization;
using KamiSama.Extensions;
using KamiSama.Extensions.Json;

public abstract record Contact
{
    [JsonHirerarchyDiscriminator]
    [JsonPropertyName("kind")]
    public abstract string Kind { get; }
}

public sealed record EmailContact(string Address) : Contact
{
    public override string Kind => "email";
}

HierarchicalJsonConverter<Contact>.Register<EmailContact>("email");
var options = new JsonSerializerOptions().AddHierarchicalConverter<Contact>();
Contact? contact = JsonSerializer.Deserialize<Contact>("{\"kind\":\"email\",\"address\":\"dev@example.com\"}", options);
""",
        "JsonHirerarchyDiscriminatorAttribute" when fullName == "KamiSama.Extensions.Json.JsonHirerarchyDiscriminatorAttribute" => """
using System.Text.Json.Serialization;
using KamiSama.Extensions.Json;

public abstract record Message
{
    [JsonHirerarchyDiscriminator]
    [JsonPropertyName("kind")]
    public abstract string Kind { get; }
}
""",
        "JsonSerializationExtensions" when fullName == "KamiSama.Extensions.JsonSerializationExtensions" => """
using KamiSama.Extensions;

var payload = new { Id = 42, Name = "KamiSama" };
string json = payload.SerializeToJson(options => options.WriteIndented = true);
dynamic? value = json.ConvertJsonToDynamicObject();
""",
        "TimeSpanJsonConverter" when fullName == "KamiSama.Extensions.Json.TimeSpanJsonConverter" => """
using System.Text.Json;
using KamiSama.Extensions;

var options = new JsonSerializerOptions().AddTimeSpanJsonConverter();
string json = JsonSerializer.Serialize(TimeSpan.FromMinutes(5), options);
TimeSpan value = JsonSerializer.Deserialize<TimeSpan>(json, options);
""",
        "XmlSerializationExtensions" when fullName == "KamiSama.Extensions.XmlSerializationExtensions" => """
using KamiSama.Extensions;

var product = new Product { Id = 42, Name = "Keyboard" };
string xml = product.SerializeToXml(settings => settings.Indent = true);
Product? copy = xml.DeserializeFromXml<Product>();
""",
        "XmlAttributeOverridesExtensions" when fullName == "KamiSama.Extensions.XmlAttributeOverridesExtensions" => """
using System.Xml.Serialization;
using KamiSama.Extensions;

var overrides = new XmlAttributeOverrides();
overrides.AddAutoXmlAttributes(typeof(Document), [typeof(TextContent), typeof(ImageContent)]);

var serializer = new XmlSerializer(typeof(Document), overrides);
string xml = document.SerializeToXml(serializer: serializer);
""",
        "AutoXmlElementAttribute" when fullName == "KamiSama.Extensions.AutoXmlElementAttribute" => """
public abstract class Content;
public sealed class TextContent : Content { public string Text { get; set; } = ""; }

public sealed class Document
{
    [AutoXmlElement]
    public Content? Content { get; set; }
}
""",
        "AutoXmlArrayItemAttribute" when fullName == "KamiSama.Extensions.AutoXmlArrayItemAttribute" => """
public abstract class Content;
public sealed class TextContent : Content { public string Text { get; set; } = ""; }

public sealed class Document
{
    [AutoXmlArrayItem]
    public Content[] Items { get; set; } = [];
}
""",
        "AutoXmlElement" when fullName.StartsWith("KamiSama.Extensions.AutoXmlElement<", StringComparison.Ordinal) => """
public abstract class Content;
public sealed class TextContent : Content { public string Text { get; set; } = ""; }

AutoXmlElement<Content> content = new TextContent { Text = "Hello" };
Content wrappedValue = content.Value;
""",
        "WebModule" when fullName == "KamiSama.Modules.WebModule" => """
using KamiSama.Modules;

public sealed class ProductsModule : WebModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
    }

    public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
    {
        app.MapGet("/products", () => Results.Ok());
        return Task.CompletedTask;
    }
}
""",
        "ExtendedWebApplicationBuilder" when fullName == "KamiSama.Modules.ExtendedWebApplicationBuilder" => """
using KamiSama.Modules;

var builder = WebApplication.CreateBuilder(args)
    .Extend()
    .AddControllers()
    .AddSwagger();

var app = await builder.BuildAsync(CancellationToken.None);
""",
        "AutoInjectAttributeBase" => """
using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

public sealed class AutoInjectPerRequestAttribute : AutoInjectAttributeBase
{
    public AutoInjectPerRequestAttribute(Type serviceType)
    {
        ServiceType = serviceType;
        Lifetime = ServiceLifetime.Scoped;
    }
}

[AutoInjectPerRequest(typeof(IProductService))]
public sealed class ProductService : IProductService;
""",
        "AutoInjectAttribute" => """
using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[AutoInject(ServiceType = typeof(IProductService), Lifetime = ServiceLifetime.Scoped)]
public sealed class ProductService : IProductService;
""",
        "AutoInjectScopedAttribute" when !typeName.Contains('<') => """
using KamiSama.Extensions.DependencyInjection;

[AutoInjectScoped(typeof(IProductService))]
public sealed class ProductService : IProductService;
""",
        "AutoInjectScopedAttribute" => """
using KamiSama.Extensions.DependencyInjection;

[AutoInjectScoped<IProductService>]
public sealed class ProductService : IProductService;
""",
        "AutoInjectSingletonAttribute" when !typeName.Contains('<') => """
using KamiSama.Extensions.DependencyInjection;

[AutoInjectSingleton(typeof(ICacheService))]
public sealed class MemoryCacheService : ICacheService;
""",
        "AutoInjectSingletonAttribute" => """
using KamiSama.Extensions.DependencyInjection;

[AutoInjectSingleton<ICacheService>]
public sealed class MemoryCacheService : ICacheService;
""",
        "AutoInjectTransientAttribute" when !typeName.Contains('<') => """
using KamiSama.Extensions.DependencyInjection;

[AutoInjectTransient(typeof(IMessageFactory))]
public sealed class MessageFactory : IMessageFactory;
""",
        "AutoInjectTransientAttribute" => """
using KamiSama.Extensions.DependencyInjection;

[AutoInjectTransient<IMessageFactory>]
public sealed class MessageFactory : IMessageFactory;
""",
        "ServiceCollectionExtensions" when fullName == "KamiSama.Extensions.DependencyInjection.ServiceCollectionExtensions" => """
using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[AutoInjectScoped<IProductService>]
public sealed class ProductService : IProductService;

var services = new ServiceCollection();
services.AutoAddDependenciesFrom<Program>();
""",
        "KamiSamaProblemDetailsOptions" when fullName == "KamiSama.Chassis.ProblemDetails.KamiSamaProblemDetailsOptions" => """
using KamiSama.Chassis.ProblemDetails;

services.AddControllers()
    .AddExceptionFilterForProblemDetails(options => options
        .UseDefaultProblemDetailsProvider()
        .UseResourceLocalizer<ErrorMessages>());
""",
        "DatabaseInitializerBase" => """
using KamiSama.Repositories.EntityFrameworkCore.Initialization;

public sealed class AppDbInitializer(AppDbContext context) : DatabaseInitializerBase<AppDbContext>(context)
{
    protected override Task InitializeDataAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    protected override Task InitializeTestDataAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
""",
        "TesterBuilderBase" when fullName == "KamiSama.Testing.NSubstitute.TesterBuilderBase" => """
using KamiSama.Testing.NSubstitute;

public sealed class ProductServiceTestsBuilder : TesterBuilderBase
{
    public ProductService Build() => BuildService<ProductService>();
}
""",
        _ => ""
    };
}

static string CuratedMemberDescription(string typeFullName, string typeName, string memberName, string kind)
{
    var repositoryMember = ShortMemberName(memberName);
    if (typeFullName.StartsWith("KamiSama.ServicePlans.PolicyAction.", StringComparison.Ordinal))
    {
        return (typeFullName, repositoryMember) switch
        {
            ("KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionHandlerNames", "ServicePlans") => "Returns the exact `service-plans` routing value. A host-supplied dispatcher must compare this opaque name explicitly.",
            ("KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionConfiguration", "CostExpression") => "Gets or sets opaque intended expression text. The current package defines no format, parser, validation, fact binding, or evaluation semantics.",
            ("KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionResult", "ComputationUnits") => "Gets or sets a decimal computation-unit amount without domain validation. The included handler never produces it because execution throws.",
            ("KamiSama.ServicePlans.PolicyAction.IServicePlansPolicyActionHandler", "HandlerName") => "Gets the routing name exposed by an implementation. The package's scoped implementation returns `service-plans`.",
            ("KamiSama.ServicePlans.PolicyAction.IServicePlansPolicyActionHandler", "ExecuteAsync") => "Would apply serialized configuration to policy facts and return computation units. The included implementation instead throws `NotImplementedException` synchronously without observing any argument.",
            ("KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionModule", "ConfigureServices") => "Scans this assembly and registers its internal handler as scoped `IServicePlansPolicyActionHandler`. It does not register either domain module or a dispatcher.",
            ("KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionModule", "ApplyConfigurationToAsync") => "Returns a completed task without adding middleware, endpoints, dispatch, or any other post-build behavior.",
            ("KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionWebApplicationBuilderExtensions", "AddServicePlansPolicyActionModule") => "Queues the package module for service discovery during `BuildAsync`. PolicyEngine, ServicePlans, and host action dispatch remain separate setup responsibilities.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Modules.PolicyEngine.PolicyEngineExtendedWebApplicationBuilderExtensions" && repositoryMember == "AddPolicyEngineModule")
    {
        return "Queues PolicyEngine option binding, attributed CRUD registration, keyed provider setup, and post-build initialization. The callback must register the lowercased configured provider key; `BuildAsync` can fail during service validation because six current list/delete feature registrations are non-assignable.";
    }

    if (typeFullName == "KamiSama.Modules.PolicyEngine.PolicyEnginePostgresqlDbContextBuilderExtensions" && repositoryMember == "AddPostgresqlPolicyEngineDbContext")
    {
        return "Registers `PostgresqlPolicyEngineDbContext` and its exact `postgresql` keyed `PolicyEngineDbContext` alias with lazy-loading proxies, the PolicyEngine migration-history table, and shared process-wide Npgsql compatibility switches. The provider currently has no PolicyEngine migrations.";
    }

    if (typeFullName == "KamiSama.Modules.PolicyEngine.PolicyEngineSqliteDbContextBuilderExtensions" && repositoryMember == "AddSqlitePolicyEngineDbContext")
    {
        return "Registers `SqlitePolicyEngineDbContext` and its exact `sqlite` keyed `PolicyEngineDbContext` alias with lazy-loading proxies and the PolicyEngine migration-history table. The provider currently has no PolicyEngine migrations.";
    }

    if (typeFullName == "KamiSama.Modules.PolicyEngine.Repositories.Database.PolicyEngineDbContext")
    {
        return repositoryMember switch
        {
            "PolicyActions" => "Gets or sets the tracked reusable policy-action definition set used by Core repositories.",
            "PolicyRules" => "Gets or sets the tracked ordered policy-rule definition set used by Core repositories.",
            "PolicyRuleActions" => "Gets or sets the tracked rule-to-action assignment set; no public Core feature manages it.",
            "PolicyLists" => "Gets or sets the tracked typed policy-list definition set used by Core repositories.",
            "PolicyListItems" => "Gets or sets the tracked polymorphic exact/range item set; no public Core feature manages it.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Modules.ServicePlans.ExtendedWebApplicationBuilderExtensions" && repositoryMember == "AddServicePlansModule")
    {
        return "Queues ServicePlans service discovery, keyed provider setup, and post-build initialization. The callback must register the lowercased configured provider key; current provider packages contain no migrations, so `BuildAsync` cannot create the schema from this checkout.";
    }

    if (typeFullName == "KamiSama.Modules.ServicePlans.ServicePlansPostgresqlDbContextBuilderExtensions" && repositoryMember == "AddPostgresqlServicePlansDbContext")
    {
        return "Registers `PostgresqlServicePlansDbContext` and its exact `postgresql` keyed `ServicePlansDbContext` alias with lazy-loading proxies, the ServicePlans migration-history table, and shared process-wide Npgsql compatibility switches. The provider has no ServicePlans migrations.";
    }

    if (typeFullName == "KamiSama.Modules.ServicePlans.ServicePlansSqliteDbContextBuilderExtensions" && repositoryMember == "AddSqliteServicePlansDbContext")
    {
        return "Registers `SqliteServicePlansDbContext` and its exact `sqlite` keyed `ServicePlansDbContext` alias with lazy-loading proxies and the ServicePlans migration-history table. The provider has no ServicePlans migrations.";
    }

    if (typeFullName == "KamiSama.Modules.ServicePlans.Repositories.Database.ServicePlansDbContext")
    {
        return repositoryMember switch
        {
            "Plans" => "Gets or sets the tracked plan set used by public Core plan features.",
            "Offers" => "Gets or sets the tracked offer set; Core exposes no public offer feature service.",
            "OfferCountries" => "Gets or sets the tracked offer-country restriction set; Core exposes no public management feature.",
            "OfferPaymentMethods" => "Gets or sets the tracked offer payment-method set; Core exposes no public management feature.",
            "Subscribers" => "Gets or sets the tracked subscriber set used by public Core subscriber features.",
            "Subscriptions" => "Gets or sets the tracked subscription set used by public Core subscription features.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Modules.Locations.Features.IListCitiesByProvinceName" && repositoryMember == "ListAsync")
    {
        return "Builds `CitySearchModel.All` with the supplied parent-province name, lists through the Core city repository, and converts every matching tracked entity to a `CityDto`. The result is page-shaped but unpaged.";
    }

    if (typeFullName == "KamiSama.Modules.Locations.ExtendedWebApplicationBuilderExtensions" && repositoryMember == "AddLocationsModule")
    {
        return "Queues Locations service registration and post-build initialization. The callback must register a provider matching the database section's lowercased key; call `BuildAsync` before resolving feature services so registration, context resolution, and selected migration or seed stages complete.";
    }

    if (typeFullName == "KamiSama.Modules.Locations.LocationsPostgresqlDbContextBuilderExtensions" && repositoryMember == "AddPostgresqlLocationsDbContext")
    {
        return "Registers `PostgresqlLocationsDbContext` and its exact `postgresql` keyed `LocationsDbContext` alias, using the configured connection string, lazy-loading proxies, and Locations migration-history table.";
    }

    if (typeFullName == "KamiSama.Modules.Locations.LocationsSqliteDbContextBuilderExtensions" && repositoryMember == "AddSqliteLocationsDbContext")
    {
        return "Registers `SqliteLocationsDbContext` and its exact `sqlite` keyed `LocationsDbContext` alias, using the configured connection string, lazy-loading proxies, and Locations migration-history table.";
    }

    if (typeFullName == "KamiSama.Modules.Locations.Repositories.Database.LocationsDbContext")
    {
        return repositoryMember switch
        {
            "Provinces" => "Gets or sets the tracked province entity set used by Core repositories.",
            "Cities" => "Gets or sets the tracked city entity set used by Core repositories.",
            "OnModelCreating" => "Applies the base model and configures each city to have one province, each province to have many cities, and province deletion as restricted rather than cascading.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Modules.Ticketing.ExtendedWebApplicationBuilderExtensions" && repositoryMember == "AddTicketingModule")
    {
        return "Queues Ticketing service discovery, keyed context setup, and post-build database initialization. The callback must register the lowercased configured provider key; `BuildAsync` can fail during service validation because three current category-feature registrations are non-assignable.";
    }

    if (typeFullName == "KamiSama.Modules.Ticketing.Entities.Ticket" && repositoryMember == "CanTransitionTo")
    {
        return "Returns whether the requested status is unchanged or follows Core's workflow table: open or reopened to resolved, or resolved to reopened or closed. Undefined enum values and every other transition return `false`.";
    }

    if (typeFullName == "KamiSama.Modules.Ticketing.TicketingPostgresqlDbContextBuilderExtensions" && repositoryMember == "AddPostgresqlTicketingDbContext")
    {
        return "Registers `PostgresqlTicketingDbContext` and its exact `postgresql` keyed `TicketingDbContext` alias with lazy-loading proxies, the Ticketing migration-history table, and shared process-wide Npgsql compatibility switches.";
    }

    if (typeFullName == "KamiSama.Modules.Ticketing.TicketingSqliteDbContextBuilderExtensions" && repositoryMember == "AddSqliteTicketingDbContext")
    {
        return "Registers `SqliteTicketingDbContext` and its exact `sqlite` keyed `TicketingDbContext` alias with lazy-loading proxies and the Ticketing migration-history table.";
    }

    if (typeFullName == "KamiSama.Modules.Ticketing.Repositories.Database.TicketingDbContext")
    {
        return repositoryMember switch
        {
            "Tickets" => "Gets or sets the tracked ticket aggregate set used by Core repositories.",
            "TicketCategories" => "Gets or sets the tracked category set used by Core repositories.",
            "TicketComments" => "Gets or sets the tracked comment set used for direct comment lookup.",
            "TicketAttachments" => "Gets or sets the tracked attachment-reference set used for direct attachment lookup.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Repositories.ConnectionStringOption")
    {
        return repositoryMember switch
        {
            "ConnectionString" => "Gets or sets the database connection string bound from the `connection-string` configuration key.",
            "Provider" => "Gets or sets the provider identifier bound from the `provider` configuration key; a provider package defines accepted values.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Repositories.Initialization.DataInitializationOptions")
    {
        return repositoryMember switch
        {
            "Migrate" => "Gets or sets whether the initializer should run its database migration stage.",
            "InitializeData" => "Gets or sets whether the initializer should create required application data.",
            "InitializeTestData" => "Gets or sets whether the initializer should create test data; production callers normally leave this disabled.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Repositories.IRepository<TEntity>")
    {
        return repositoryMember switch
        {
            "Add" => "Adds an entity according to the implementation's persistence and duplicate rules.",
            "Update" => "Updates an entity according to the implementation's matching and persistence rules; the contract does not require replacement or merging.",
            "Delete" => "Deletes an entity according to the implementation's matching and persistence rules.",
            "Find" => "Returns the first entity matching the predicate, or `null` when none matches.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Repositories.IAsyncRepository<_EntityType>")
    {
        return repositoryMember switch
        {
            "AddAsync" => "Asynchronously adds an entity according to the implementation's persistence, duplicate, cancellation, and failure rules.",
            "UpdateAsync" => "Asynchronously updates an entity according to the implementation's matching, persistence, cancellation, and failure rules.",
            "DeleteAsync" => "Asynchronously deletes an entity according to the implementation's matching, persistence, cancellation, and failure rules.",
            "FindAsync" => "Asynchronously returns the first entity matching the predicate, or `null` when none matches.",
            _ => ""
        };
    }

    if (typeFullName is "KamiSama.Repositories.IQueryableRepository<TEntity>" or "KamiSama.Repositories.IAsyncQueryableRepository<TEntity>" && repositoryMember == "Where")
    {
        return "Returns an `IQueryable<TEntity>` filtered by the predicate. The implementation determines whether the query is translated, deferred, live, or a snapshot; this method is synchronous on both interfaces.";
    }

    if (typeFullName == "KamiSama.Repositories.Initialization.IDatabaseInitializer<TDbContext>" && repositoryMember == "InitializeAsync")
    {
        return "Runs the migration and seed stages selected by `DataInitializationOptions`; the implementation owns ordering, idempotency, persistence, and failure behavior.";
    }

    if (typeFullName == "KamiSama.Repositories.RepositoriesExtensions")
    {
        return repositoryMember switch
        {
            "FirstOrDefault" => "Delegates filtering to the repository's `Where` method and returns the first result or the default value.",
            "GetAll" => "Returns all entities by calling the repository's `Where` method with an always-true predicate.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Repositories.InMemoryRepository<TEntity>")
    {
        return repositoryMember switch
        {
            "Add" or "AddAsync" => "Adds the entity to the in-memory set unless an equal entity already exists. Mutation is serialized per instance, but concurrent reads are not locked.",
            "Delete" or "DeleteAsync" => "Removes an equal entity from the in-memory set when present. Mutation is serialized per instance, but concurrent reads are not locked.",
            "Update" or "UpdateAsync" => "Performs no operation; this repository does not replace or merge entities.",
            "Find" or "FindAsync" => "Returns the first in-memory entity matching the compiled predicate, or the default value when no predicate or match is available.",
            "Where" => "Returns a live, unsynchronized query over the in-memory set. Do not enumerate it concurrently with add, delete, or disposal.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Repositories.Json.JsonRepository<TEntity>")
    {
        return repositoryMember switch
        {
            "LoadFailed" => "Raised after reading or deserializing the JSON file fails. The load otherwise returns `false` and query methods return default or empty results.",
            "SaveFailed" => "Raised after an in-memory mutation or non-atomic full-file write fails. The changed cache is not rolled back and the operation otherwise completes normally.",
            "TryLoadFileAsync" => "Loads an existing JSON array unless already cached, optionally discarding the cache first. Failures raise `LoadFailed` and return `false`.",
            "Add" or "AddAsync" => "Adds according to `HashSet<TEntity>` equality and rewrites the complete JSON file. Equal duplicates are ignored, and failed writes do not roll back memory.",
            "Delete" or "DeleteAsync" => "Removes according to `HashSet<TEntity>` equality and rewrites the complete JSON file. Failed writes do not restore the removed entity.",
            "Update" or "UpdateAsync" => "Ignores the supplied entity and rewrites the current set, so it only persists prior changes made to an object already cached by the repository.",
            "Find" or "FindAsync" => "Loads on demand and returns the first matching cached entity, or the default value after a load failure, a null predicate, or no match.",
            "Where" or "WhereAsync" => "Loads on demand and returns a live query over the cached set, or an empty query after load failure. Enumeration is not synchronized with mutations.",
            _ => ""
        };
    }

    if (typeFullName is "KamiSama.Repositories.Xml.XmlFileRepository<TEntity>" or "KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>")
    {
        return repositoryMember switch
        {
            "LoadFailed" => "Raised when directory enumeration, per-entity deserialization, or exact file-name validation fails. One bad file fails the complete load.",
            "SaveFailed" => "Raised after the broken mutation path attempts to write serialized entities to the directory path. In-memory changes are not rolled back.",
            "TryLoadFileAsync" => "Loads all `*.xml` files as individual entities and validates mapped names. The version 10.0.0 default array serializer cannot perform these per-entity reads, and equal entities are silently collapsed.",
            "Add" or "AddAsync" => "Changes the in-memory set but cannot durably create a mapped XML entity file in version 10.0.0; the save path writes to the directory path.",
            "Delete" or "DeleteAsync" => "Changes the in-memory set but does not delete the mapped XML file in version 10.0.0, including when the final cached entity is removed.",
            "Update" or "UpdateAsync" => "Ignores the supplied entity and cannot durably update XML in version 10.0.0; saving also ignores the supplied serializer.",
            "Find" or "FindAsync" => "Loads on demand and returns the first matching cached entity, or the default value after a load failure, a null predicate, or no match.",
            "Where" or "WhereAsync" => "Loads on demand and returns a live query over the cached set, or an empty query after load failure. Enumeration is not synchronized with mutations.",
            _ => ""
        };
    }

    if (kind != "Method" && kind != "Property")
    {
        return "";
    }

    var typeShortName = ShortTypeName(typeName);
    var memberShortName = ShortMemberName(memberName);

    if (typeFullName == "KamiSama.Chassis.Commons.Features.GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>" ||
        typeFullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && typeShortName == "AddFeatureBase")
    {
        return memberShortName switch
        {
            "Repository" => "Protected repository used by derived feature implementations. Use it inside mapping and validation hooks when the feature needs data access beyond the base add flow.",
            "CheckDuplicateAsync" => "Validation hook called at the start of `AddAsync`. Override it to detect duplicate or conflicting data and throw a domain or HTTP exception before the entity is created.",
            "ConvertToEntity" => "Mapping hook called after duplicate validation. Override it to create the entity that will be persisted from the incoming add request.",
            "ConvertToDto" => "Mapping hook called after the repository add succeeds. Override it to return the DTO shape expected by callers.",
            "AddAsync" => "Runs the complete create flow: check duplicates, convert the request to an entity, add it through the repository, convert the saved entity to a DTO, and return it.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Chassis.Commons.Features.GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>" ||
        typeFullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && typeShortName == "UpdateFeatureBase")
    {
        return memberShortName switch
        {
            "Repository" => "Protected repository used by derived update features. Use it when duplicate checks or patching need repository access.",
            "CheckDuplicateAsync" => "Validation hook called after the entity is loaded and before it is patched. Override it to reject conflicting update requests.",
            "PatchEntityAsync" => "Mutation hook called after duplicate validation. Override it to copy request values onto the loaded entity before the base class saves it.",
            "UpdateAsync" => "Runs the complete update flow: load the entity by id, throw when missing, check duplicate state, patch the entity, and save it through the repository.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Chassis.Commons.Features.GenericDeleteFeature<TEntity, TRepository, TKey>" ||
        typeFullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && typeShortName == "DeleteFeatureBase")
    {
        return memberShortName switch
        {
            "Repository" => "Protected repository used by derived delete features. Use it when the deletion rule needs additional repository data.",
            "CanBeDeletedAsync" => "Deletion guard called after the entity is loaded and before deletion. Override it to prevent deletes for entities that are still referenced or otherwise protected.",
            "DeleteAsync" => "Runs the complete delete flow: load the entity by id, throw when missing, ask `CanBeDeletedAsync`, and delete through the repository only when allowed.",
            _ => ""
        };
    }

    if (typeFullName.StartsWith("KamiSama.Chassis.Commons.Features.GenericListFeature<", StringComparison.Ordinal) ||
        typeFullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && typeShortName == "ListFeatureBase")
    {
        return memberShortName switch
        {
            "Repository" => "Protected repository used by derived list features. The base list flow delegates paging to this repository.",
            "ConvertToDto" => "Mapping hook called for each entity in the repository page. Override it to produce the DTO returned to callers.",
            "ConvertToPagedResultAsync" => "Result-shaping hook that converts a repository `PagedResult<TEntity>` into a `PagedResult<TEntityDto>`. Override it only when the default item-by-item DTO mapping is not enough.",
            "ConvertResult" => "Result-shaping hook for custom paged result types. Override it to translate the repository result into the result type exposed by the feature.",
            "ListAsync" => "Runs the list flow: request a page from the repository and convert the repository result into the DTO result returned to callers.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Chassis.Commons.Features.GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>" ||
        typeFullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && typeShortName == "FindByIdFeatureBase")
    {
        return memberShortName switch
        {
            "Repository" => "Protected repository used by the find-by-id flow and available to derived mapping code.",
            "ConvertToDto" => "Mapping hook called after the entity is found. Override it to return the DTO shape expected by callers.",
            "FindByIdAsync" => "Loads an entity by key through the repository, throws `NotFoundException<TEntity>` when no entity exists, and maps the entity to a DTO.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Chassis.Commons.Features.GenericFindByNameFeature<TEntity, TEntityDto, TRepository>")
    {
        return memberShortName switch
        {
            "Repository" => "Protected repository used by the find-by-name flow and available to derived mapping code.",
            "ConvertToDto" => "Mapping hook called after the entity is found. Override it to return the DTO shape expected by callers.",
            "FindByNameAsync" => "Loads an entity by name through the repository, throws `NotFoundException<TEntity>` when no entity exists, and maps the entity to a DTO.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Chassis.Commons.Features.GenericExistsByIdFeature<TEntity, TRepository, TKey>" ||
        typeFullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && typeShortName == "ExistsByIdFeatureBase")
    {
        return memberShortName switch
        {
            "Repository" => "Protected repository used by the exists-by-id flow.",
            "ExistsByIdAsync" => "Checks whether an entity exists for the supplied key by delegating to the repository.",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Chassis.Commons.Features.GenericExistsByNameFeature<TEntity, TRepository>")
    {
        return memberShortName switch
        {
            "Repository" => "Protected repository used by the exists-by-name flow.",
            "ExistsByNameAsync" => "Checks whether an entity exists for the supplied name by delegating to the repository.",
            _ => ""
        };
    }

    if (typeFullName.StartsWith("KamiSama.Chassis.Commons.Repositories.GenericRepository<", StringComparison.Ordinal))
    {
        return memberShortName switch
        {
            "ApplySearchModel" => "Filtering hook called before list/count results are materialized. Override it to apply search criteria, ordering, and any entity-specific query conditions.",
            "ListAsync" => "Applies the search model and returns a paged repository result.",
            "CountAsync" => "Applies the search model and returns the total matching entity count.",
            "MakeResultAsync" => "Creates the paged result object after the filtered query is materialized.",
            _ => ""
        };
    }

    if (typeShortName == "WebModule")
    {
        return memberShortName switch
        {
            "ConfigureServices" => "Registers services before `WebApplicationBuilder.Build` runs. Override it for DI, MVC, options, authentication, and other service registrations.",
            "ApplyConfigurationToAsync" => "Applies middleware, endpoint mapping, or post-build application configuration after the app is built.",
            "Builder" => "Optional reference to the extended web application builder that owns this module.",
            _ => ""
        };
    }

    return "";
}

static string ShortTypeName(string typeName)
{
    var generic = typeName.IndexOf('<');
    return generic >= 0 ? typeName[..generic] : typeName;
}

static string TypeFallbackDescription(string typeName, string kind)
{
    var shortName = ShortTypeName(typeName);
    if (shortName.EndsWith("Options", StringComparison.Ordinal) || shortName.EndsWith("Option", StringComparison.Ordinal))
    {
        return $"Configuration object for `{typeName}`. Use it when binding settings or configuring the related package services.";
    }

    if (shortName.EndsWith("Attribute", StringComparison.Ordinal))
    {
        return $"Attribute used by the package to describe `{typeName}` behavior declaratively. Apply it to a type or member when you want the surrounding scanner or framework code to pick it up.";
    }

    if (shortName.EndsWith("Module", StringComparison.Ordinal))
    {
        return $"ASP.NET Core web-module implementation for `{typeName}`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.";
    }

    if (shortName.EndsWith("Repository", StringComparison.Ordinal))
    {
        return $"Repository implementation or contract for `{typeName}`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.";
    }

    return kind switch
    {
        "Interface" => $"Defines the contract for `{typeName}` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.",
        "Enum" => $"Lists the supported `{typeName}` values. Use these values anywhere the package needs a strongly typed option.",
        "Delegate" => $"Defines the callback signature used by `{typeName}`. Provide a compatible method or lambda when configuring the related API.",
        _ => $"Provides the `{typeName}` API for the surrounding package. Use this type with the members listed below to compose the feature in an application."
    };
}

static string MemberFallbackDescription(string typeName, string memberName, string kind) =>
    kind switch
    {
        "Method" => $"Runs the `{memberName}` operation on `{typeName}`. Use it when your code needs this specific behavior from the package.",
        "Property" => $"Exposes the `{memberName}` value on `{typeName}`. Read or set it as part of configuring or using the type.",
        "Field" => $"Stores the `{memberName}` value for `{typeName}`. Use it where the package exposes this field as part of its API.",
        "Event" => $"Notifies subscribers about `{memberName}` events raised by `{typeName}`.",
        "Operator" => $"Provides the `{memberName}` operator behavior for `{typeName}`.",
        "Enum member" => $"Represents the `{memberName}` option of `{typeName}`.",
        _ => $"Documents the `{memberName}` member of `{typeName}`."
    };

static string BuildFallbackExample(string typeFullName, MemberDoc member)
{
    if (member.Kind == "Property" && member.Name == "All" && typeFullName == "KamiSama.Extensions.Paging.SearchModel")
    {
        return "using KamiSama.Extensions.Paging;\n\nvar search = SearchModel.All;";
    }

    if (member.Kind != "Method")
    {
        return "";
    }

    var key = ShortMemberName(member.Name);
    if (typeFullName == "KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionWebApplicationBuilderExtensions" && key == "AddServicePlansPolicyActionModule")
    {
        return "ExtendedWebApplicationBuilder builder = webBuilder.Extend()\n    .AddServicePlansPolicyActionModule();\nWebApplication app = await builder.BuildAsync(cancellationToken);";
    }

    if (typeFullName == "KamiSama.ServicePlans.PolicyAction.IServicePlansPolicyActionHandler")
    {
        return key switch
        {
            "HandlerName" => "string handlerName = handler.HandlerName; // service-plans",
            "ExecuteAsync" => "// The included handler always throws; provide a replacement before execution.\nServicePlansPolicyActionResult result = await handler.ExecuteAsync(context, configurationSource, cancellationToken);",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Modules.Locations.Features.IListCitiesByProvinceName" && key == "ListAsync")
    {
        return "PagedResult<CityDto> cities = await listCitiesByProvinceName.ListAsync(\"central\", cancellationToken);";
    }

    if (typeFullName == "KamiSama.Modules.ServicePlans.ExtendedWebApplicationBuilderExtensions" && key == "AddServicePlansModule")
    {
        return "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddServicePlansModule(\n    servicePlansSection, databaseSection,\n    database => database.AddPostgresqlServicePlansDbContext());\nWebApplication app = await builder.BuildAsync(cancellationToken);";
    }

    if (typeFullName == "KamiSama.Modules.ServicePlans.ServicePlansPostgresqlDbContextBuilderExtensions" && key == "AddPostgresqlServicePlansDbContext")
    {
        return "database.AddPostgresqlServicePlansDbContext(); // Registers the exact postgresql provider key.";
    }

    if (typeFullName == "KamiSama.Modules.ServicePlans.ServicePlansSqliteDbContextBuilderExtensions" && key == "AddSqliteServicePlansDbContext")
    {
        return "database.AddSqliteServicePlansDbContext(); // Registers the exact sqlite provider key.";
    }

    if (typeFullName == "KamiSama.Modules.Ticketing.Entities.Ticket" && key == "CanTransitionTo")
    {
        return "bool mayResolve = ticket.CanTransitionTo(TicketStatus.Resolved);";
    }

    if (typeFullName == "KamiSama.Modules.Locations.ExtendedWebApplicationBuilderExtensions" && key == "AddLocationsModule")
    {
        return "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddLocationsModule(\n    locationsSection, databaseSection,\n    database => database.AddPostgresqlLocationsDbContext());\nWebApplication app = await builder.BuildAsync(cancellationToken);";
    }

    if (typeFullName == "KamiSama.Modules.Locations.LocationsPostgresqlDbContextBuilderExtensions" && key == "AddPostgresqlLocationsDbContext")
    {
        return "database.AddPostgresqlLocationsDbContext(); // Registers the exact postgresql provider key.";
    }

    if (typeFullName == "KamiSama.Modules.Locations.LocationsSqliteDbContextBuilderExtensions" && key == "AddSqliteLocationsDbContext")
    {
        return "database.AddSqliteLocationsDbContext(); // Registers the exact sqlite provider key.";
    }

    if (typeFullName == "KamiSama.Modules.Ticketing.ExtendedWebApplicationBuilderExtensions" && key == "AddTicketingModule")
    {
        return "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddTicketingModule(\n    ticketingSection, databaseSection,\n    database => database.AddPostgresqlTicketingDbContext());\nWebApplication app = await builder.BuildAsync(cancellationToken);";
    }

    if (typeFullName == "KamiSama.Modules.Ticketing.TicketingPostgresqlDbContextBuilderExtensions" && key == "AddPostgresqlTicketingDbContext")
    {
        return "database.AddPostgresqlTicketingDbContext(); // Registers the exact postgresql provider key.";
    }

    if (typeFullName == "KamiSama.Modules.Ticketing.TicketingSqliteDbContextBuilderExtensions" && key == "AddSqliteTicketingDbContext")
    {
        return "database.AddSqliteTicketingDbContext(); // Registers the exact sqlite provider key.";
    }

    if (typeFullName.StartsWith("KamiSama.Modules.Identity.Services.", StringComparison.Ordinal))
    {
        return CuratedTypeExample(typeFullName, typeFullName);
    }

    if (typeFullName == "KamiSama.Modules.Identity.DtoMappings" && key == "ToDto")
    {
        return member.Parameters.FirstOrDefault()?.Type switch
        {
            "ApplicationUser" => "UserDto dto = user.ToDto([KnownRoles.User]);",
            "ApplicationRole" => "RoleDto dto = role.ToDto();",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Modules.Identity.KamiSamaIdentityWebModule")
    {
        return CuratedTypeExample(typeFullName, typeFullName);
    }

    if (typeFullName == "KamiSama.Modules.Identity.ExtendedWebApplicationBuilderExtensions" && key == "AddKamiSamaIdentityModule")
    {
        return "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddKamiSamaIdentityModule(\n    identitySection, databaseSection, registerIdentity: true, useJwtAuth: true,\n    configureDbContext: database => database.AddPostgresqlIdentityDbContext());";
    }

    if (typeFullName == "KamiSama.Modules.Identity.IdentityPostgresqlDbContextBuilderExtensions" && key == "AddPostgresqlIdentityDbContext")
    {
        return "builder.AddPostgresqlIdentityDbContext(); // Registers the exact postgresql provider key.";
    }

    if (typeFullName == "KamiSama.Modules.Identity.IdentitySqliteDbContextBuilderExtensions" && key == "AddSqliteIdentityDbContext")
    {
        return "builder.AddSqliteIdentityDbContext(); // Registers the exact sqlite provider key.";
    }

    if (typeFullName == "KamiSama.Chassis.Commons.Features.GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>" ||
        typeFullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && typeFullName.EndsWith(".AddFeatureBase", StringComparison.Ordinal))
    {
        return key switch
        {
            "AddAsync" => "var dto = await addProductFeature.AddAsync(new AddProductRequest(\"Keyboard\", 120), cancellationToken);",
            "CheckDuplicateAsync" => "protected override async Task CheckDuplicateAsync(AddProductRequest request, CancellationToken cancellationToken)\n{\n    if (await Repository.ExistsByNameAsync(request.Name, cancellationToken))\n        throw new AlreadyExistsException<Product>(request.Name, nameof(request.Name));\n}",
            "ConvertToEntity" => "protected override Task<Product> ConvertToEntity(AddProductRequest request, CancellationToken cancellationToken)\n    => Task.FromResult(new Product { Id = Guid.NewGuid(), Name = request.Name, Price = request.Price });",
            "ConvertToDto" => "protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)\n    => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Chassis.Commons.Features.GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>" ||
        typeFullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && typeFullName.EndsWith(".UpdateFeatureBase", StringComparison.Ordinal))
    {
        return key switch
        {
            "UpdateAsync" => "await updateProductFeature.UpdateAsync(productId, new UpdateProductRequest(\"Keyboard\", 120), cancellationToken);",
            "CheckDuplicateAsync" => "protected override async Task CheckDuplicateAsync(Guid id, UpdateProductRequest request, CancellationToken cancellationToken)\n{\n    var duplicate = await Repository.FindByNameAsync(request.Name, cancellationToken);\n    if (duplicate is not null && duplicate.Id != id)\n        throw new AlreadyExistsException<Product>(request.Name, nameof(request.Name));\n}",
            "PatchEntityAsync" => "protected override Task PatchEntityAsync(Product entity, UpdateProductRequest request, CancellationToken cancellationToken)\n{\n    entity.Name = request.Name;\n    entity.Price = request.Price;\n    return Task.CompletedTask;\n}",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Chassis.Commons.Features.GenericDeleteFeature<TEntity, TRepository, TKey>" ||
        typeFullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && typeFullName.EndsWith(".DeleteFeatureBase", StringComparison.Ordinal))
    {
        return key switch
        {
            "DeleteAsync" => "await deleteProductFeature.DeleteAsync(productId, cancellationToken);",
            "CanBeDeletedAsync" => "protected override Task<bool> CanBeDeletedAsync(IProductRepository repository, Product entity)\n    => Task.FromResult(!entity.HasOpenOrders);",
            _ => ""
        };
    }

    if (typeFullName.StartsWith("KamiSama.Chassis.Commons.Features.GenericListFeature<", StringComparison.Ordinal) ||
        typeFullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && typeFullName.EndsWith(".ListFeatureBase", StringComparison.Ordinal))
    {
        return key switch
        {
            "ListAsync" => "using KamiSama.Extensions.Paging;\n\nvar page = await listProductsFeature.ListAsync(SearchModel.FromPage(1, 20), cancellationToken);",
            "ConvertToDto" => "protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)\n    => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));",
            "ConvertToPagedResultAsync" => "protected override Task<PagedResult<ProductDto>> ConvertToPagedResultAsync(PagedResult<Product> result, CancellationToken cancellationToken)\n    => result.ConvertToAsync(ConvertToDto, cancellationToken);",
            "ConvertResult" => "protected override Task<ProductPage> ConvertResult(ProductRepositoryPage repositoryResult, CancellationToken cancellationToken)\n    => Task.FromResult(ProductPage.From(repositoryResult));",
            _ => ""
        };
    }

    if (typeFullName == "KamiSama.Chassis.Commons.Features.GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>" ||
        typeFullName.StartsWith("KamiSama.Chassis.Commons.Features.FeatureDefinitionBase<", StringComparison.Ordinal) && typeFullName.EndsWith(".FindByIdFeatureBase", StringComparison.Ordinal))
    {
        return key switch
        {
            "FindByIdAsync" => "var dto = await findProductFeature.FindByIdAsync(productId, cancellationToken);",
            "ConvertToDto" => "protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)\n    => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));",
            _ => ""
        };
    }

    return key switch
    {
        "ToBytes" => "using KamiSama.Extensions;\n\nvar bytes = \"hello\".ToBytes();",
        "FromHex" => "using KamiSama.Extensions;\n\nvar bytes = \"0A FF\".FromHex();",
        "ToHex" => "using KamiSama.Extensions;\n\nvar hex = new byte[] { 0x0A, 0xFF }.ToHex();",
        "FromBase64" => "using KamiSama.Extensions;\n\nvar bytes = \"AQID\".FromBase64();",
        "ToBase64" => "using KamiSama.Extensions;\n\nvar text = new byte[] { 1, 2, 3 }.ToBase64();",
        "GetString" when typeFullName == "KamiSama.Extensions.ByteArrayExtensions" => "using KamiSama.Extensions;\n\nvar text = new byte[] { 72, 105 }.GetString();",
        "FromPage" => "using KamiSama.Extensions.Paging;\n\nvar search = SearchModel.FromPage(1, 20);",
        "MakePaged" => "using KamiSama.Extensions;\nusing KamiSama.Extensions.Paging;\n\nvar page = new[] { 1, 2, 3, 4 }.AsQueryable().MakePaged(SearchModel.FromPage(1, 2));",
        "AddSwagger" => "using KamiSama.Modules;\n\nvar builder = WebApplication.CreateBuilder(args).Extend().AddSwagger();",
        "AddControllers" => "using KamiSama.Modules;\n\nvar builder = WebApplication.CreateBuilder(args).Extend().AddControllers();",
        "AutoAddDependenciesFrom" => "using KamiSama.Extensions.DependencyInjection;\n\nservices.AutoAddDependenciesFrom<Program>();",
        _ => ""
    };
}

static string ShortMemberName(string name)
{
    var generic = name.IndexOf('<');
    return generic >= 0 ? name[..generic] : name;
}

class ExampleProvider
{
    private readonly Dictionary<string, string> curated = new(StringComparer.OrdinalIgnoreCase)
    {
        ["KamiSama.Extensions.ArrayExtensions.Pad"] = "using KamiSama.Extensions;\n\nvar block = new byte[] { 1, 2, 3 }.Pad(len => len % 8 == 0, 0);",
        ["KamiSama.Extensions.ArrayExtensions.TrimEnd"] = "using KamiSama.Extensions;\n\nvar clean = new[] { 1, 2, 0, 0 }.TrimEnd(x => x == 0);",
        ["KamiSama.Extensions.ByteArrayExtensions.ToHex"] = "using KamiSama.Extensions;\n\nvar hex = new byte[] { 0x0A, 0xFF }.ToHex();",
        ["KamiSama.Extensions.ByteArrayExtensions.GetString"] = "using KamiSama.Extensions;\n\nvar text = new byte[] { 72, 105 }.GetString();",
        ["KamiSama.Extensions.ByteArrayExtensions.ToBase64"] = "using KamiSama.Extensions;\n\nvar base64 = new byte[] { 1, 2, 3 }.ToBase64();",
        ["KamiSama.Extensions.StringExtensions.ToBytes"] = "using KamiSama.Extensions;\n\nvar bytes = \"hello\".ToBytes();",
        ["KamiSama.Extensions.StringExtensions.FromHex"] = "using KamiSama.Extensions;\n\nvar bytes = \"0A FF\".FromHex();",
        ["KamiSama.Extensions.StringExtensions.FromBase64"] = "using KamiSama.Extensions;\n\nvar bytes = \"AQID\".FromBase64();",
        ["KamiSama.Extensions.Paging.SearchModel.FromPage"] = "using KamiSama.Extensions.Paging;\n\nvar search = SearchModel.FromPage(1, 20);",
        ["KamiSama.Extensions.Paging.PagedResult<T>.ConvertTo"] = "using KamiSama.Extensions.Paging;\n\nvar page = new PagedResult<int>(3, [1, 2, 3]);\nvar textPage = page.ConvertTo(x => x.ToString());",
        ["KamiSama.Modules.WebModule.ConfigureServices"] = "using KamiSama.Modules;\n\npublic sealed class MyModule : WebModule\n{\n    public override void ConfigureServices(IServiceCollection services)\n    {\n        services.AddControllers();\n    }\n\n    public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)\n        => Task.CompletedTask;\n}",
        ["KamiSama.Repositories.ConnectionStringOption.ConnectionString"] = "var options = new ConnectionStringOption\n{\n    Provider = \"sqlite\",\n    ConnectionString = \"Data Source=app.db\"\n};",
        ["KamiSama.Repositories.ConnectionStringOption.Provider"] = "var options = new ConnectionStringOption\n{\n    Provider = \"sqlite\",\n    ConnectionString = \"Data Source=app.db\"\n};",
        ["KamiSama.Repositories.Initialization.DataInitializationOptions.Migrate"] = "var options = new DataInitializationOptions\n{\n    Migrate = true,\n    InitializeData = true,\n    InitializeTestData = false\n};",
        ["KamiSama.Repositories.Initialization.DataInitializationOptions.InitializeData"] = "var options = new DataInitializationOptions\n{\n    Migrate = true,\n    InitializeData = true,\n    InitializeTestData = false\n};",
        ["KamiSama.Repositories.Initialization.DataInitializationOptions.InitializeTestData"] = "var options = new DataInitializationOptions\n{\n    Migrate = true,\n    InitializeData = true,\n    InitializeTestData = false\n};",
        ["KamiSama.Repositories.IRepository<TEntity>.Add"] = "repository.Add(user);",
        ["KamiSama.Repositories.IRepository<TEntity>.Update"] = "repository.Update(user); // Persistence semantics depend on the implementation.",
        ["KamiSama.Repositories.IRepository<TEntity>.Delete"] = "repository.Delete(user);",
        ["KamiSama.Repositories.IRepository<TEntity>.Find"] = "User? user = repository.Find(x => x.Id == userId);",
        ["KamiSama.Repositories.IAsyncRepository<_EntityType>.AddAsync"] = "await repository.AddAsync(user, cancellationToken);",
        ["KamiSama.Repositories.IAsyncRepository<_EntityType>.UpdateAsync"] = "await repository.UpdateAsync(user, cancellationToken);",
        ["KamiSama.Repositories.IAsyncRepository<_EntityType>.DeleteAsync"] = "await repository.DeleteAsync(user, cancellationToken);",
        ["KamiSama.Repositories.IAsyncRepository<_EntityType>.FindAsync"] = "User? user = await repository.FindAsync(x => x.Id == userId, cancellationToken);",
        ["KamiSama.Repositories.IQueryableRepository<TEntity>.Where"] = "IQueryable<User> activeUsers = repository.Where(user => user.IsActive);",
        ["KamiSama.Repositories.IAsyncQueryableRepository<TEntity>.Where"] = "// Query creation is synchronous.\nIQueryable<User> activeUsers = repository.Where(user => user.IsActive);",
        ["KamiSama.Repositories.Initialization.IDatabaseInitializer<TDbContext>.InitializeAsync"] = "await initializer.InitializeAsync(options, cancellationToken);",
        ["KamiSama.Repositories.Json.JsonRepository<TEntity>.FindAsync"] = "using KamiSama.Repositories.Json;\n\nvar repository = new JsonRepository<User>(\"users.json\");\nvar user = await repository.FindAsync(x => x.Id == 1, cancellationToken);",
        ["KamiSama.Repositories.Json.JsonRepository<TEntity>.TryLoadFileAsync"] = "bool loaded = await repository.TryLoadFileAsync(forceReload: true, cancellationToken);",
        ["KamiSama.Repositories.Json.JsonRepository<TEntity>.WhereAsync"] = "IQueryable<User> activeUsers = await repository.WhereAsync(x => x.IsActive, cancellationToken);",
        ["KamiSama.Repositories.Xml.XmlFileRepository<TEntity>.TryLoadFileAsync"] = "bool loaded = await fileRepository.TryLoadFileAsync(forceReload: true, cancellationToken);",
        ["KamiSama.Repositories.Xml.XmlFileRepository<TEntity>.FindAsync"] = "User? user = await fileRepository.FindAsync(x => x.Id == userId, cancellationToken);",
        ["KamiSama.Repositories.Xml.XmlFileRepository<TEntity>.WhereAsync"] = "IQueryable<User> activeUsers = await fileRepository.WhereAsync(x => x.IsActive, cancellationToken);",
        ["KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>.TryLoadFileAsync"] = "bool loaded = await directoryRepository.TryLoadFileAsync(forceReload: true, cancellationToken);",
        ["KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>.FindAsync"] = "User? user = await directoryRepository.FindAsync(x => x.Id == userId, cancellationToken);",
        ["KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>.WhereAsync"] = "IQueryable<User> activeUsers = await directoryRepository.WhereAsync(x => x.IsActive, cancellationToken);",
        ["KamiSama.Repositories.RepositoriesExtensions.FirstOrDefault"] = "using KamiSama.Repositories;\n\nUser? admin = repository.FirstOrDefault(user => user.IsAdmin);",
        ["KamiSama.Repositories.RepositoriesExtensions.GetAll"] = "using KamiSama.Repositories;\n\nvar all = repository.GetAll().ToList();",
        ["KamiSama.Repositories.EntityFramework.DbRepository<TEntity>.Add"] = "repository.Add(user); // Saves the EF6 context immediately.",
        ["KamiSama.Repositories.EntityFramework.DbRepository<TEntity>.AddAsync"] = "await repository.AddAsync(user, cancellationToken); // Saves immediately.",
        ["KamiSama.Repositories.EntityFramework.DbRepository<TEntity>.Update"] = "repository.Update(user); // Marks the complete entity modified and saves immediately.",
        ["KamiSama.Repositories.EntityFramework.DbRepository<TEntity>.UpdateAsync"] = "await repository.UpdateAsync(user, cancellationToken);",
        ["KamiSama.Repositories.EntityFramework.DbRepository<TEntity>.Delete"] = "repository.Delete(user); // Saves the deletion immediately.",
        ["KamiSama.Repositories.EntityFramework.DbRepository<TEntity>.DeleteAsync"] = "await repository.DeleteAsync(user, cancellationToken);",
        ["KamiSama.Repositories.EntityFramework.DbRepository<TEntity>.AsQueryable"] = "IQueryable<User> trackedUsers = repository.AsQueryable();",
        ["KamiSama.Repositories.EntityFramework.DbRepository<TEntity>.Where"] = "IQueryable<User> activeUsers = repository.Where(user => user.IsActive);",
        ["KamiSama.Repositories.EntityFramework.DbRepository<TEntity>.Any"] = "bool exists = repository.Any(user => user.Email == email);",
        ["KamiSama.Repositories.EntityFramework.DbRepository<TEntity>.AnyAsync"] = "bool exists = await repository.AnyAsync(user => user.Email == email, cancellationToken);",
        ["KamiSama.Repositories.EntityFramework.DbRepository<TEntity>.Find"] = "User? user = repository.Find(user => user.Id == userId);",
        ["KamiSama.Repositories.EntityFramework.DbRepository<TEntity>.FindAsync"] = "User? user = await repository.FindAsync(user => user.Id == userId, cancellationToken);",
        ["KamiSama.Repositories.EntityFramework.IOrderedQueryableExtensions.MakePagedAsync"] = "using KamiSama.Extensions.Paging;\nusing KamiSama.Repositories.EntityFramework;\n\nPagedResult<User> page = await query.OrderBy(user => user.Id)\n    .MakePagedAsync(SearchModel.FromPage(1, 20), cancellationToken);",
        ["KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>.Add"] = "repository.Add(user); // Saves the EF Core context immediately.",
        ["KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>.AddAsync"] = "await repository.AddAsync(user, cancellationToken); // Saves immediately.",
        ["KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>.Update"] = "repository.Update(user); // Marks the complete entity modified and saves immediately.",
        ["KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>.UpdateAsync"] = "await repository.UpdateAsync(user, cancellationToken);",
        ["KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>.Delete"] = "repository.Delete(user); // Saves the deletion immediately.",
        ["KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>.DeleteAsync"] = "await repository.DeleteAsync(user, cancellationToken);",
        ["KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>.AsQueryable"] = "IQueryable<User> trackedUsers = repository.AsQueryable();",
        ["KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>.Where"] = "IQueryable<User> activeUsers = repository.Where(user => user.IsActive);",
        ["KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>.Any"] = "bool exists = repository.Any(user => user.Email == email);",
        ["KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>.AnyAsync"] = "bool exists = await repository.AnyAsync(user => user.Email == email, cancellationToken);",
        ["KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>.Find"] = "User? user = repository.Find(user => user.Id == userId);",
        ["KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>.FindAsync"] = "User? user = await repository.FindAsync(user => user.Id == userId, cancellationToken);",
        ["KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>.Dispose"] = "repository.Dispose(); // Does not dispose the injected DbContext.",
        ["KamiSama.Repositories.EntityFrameworkCore.IQueryableExtensions.MakePagedAsync"] = "using KamiSama.Extensions.Paging;\nusing KamiSama.Repositories.EntityFrameworkCore;\n\nPagedResult<User> page = await query.OrderBy(user => user.Id)\n    .MakePagedAsync(SearchModel.FromPage(1, 20), cancellationToken);",
        ["KamiSama.Repositories.EntityFrameworkCore.IMultiProviderDbContextBuilder<TBaseContext>.WithMigrationHistoryTable"] = "builder.WithMigrationHistoryTable(\"__AppMigrationsHistory\");",
        ["KamiSama.Repositories.EntityFrameworkCore.ServiceCollectionExtensions.AddMultiProviderDbContext"] = "IMultiProviderDbContextBuilder<AppDbContext> builder = services\n    .AddMultiProviderDbContext<AppDbContext>(configuration.GetSection(\"Database\"));",
        ["KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>.MigrateAsync"] = "await MigrateAsync(cancellationToken); // Available to a derived initializer.",
        ["KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>.InitializeDataAsync"] = "protected override Task InitializeDataAsync(CancellationToken cancellationToken)\n    => SeedRequiredDataAsync(cancellationToken);",
        ["KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>.InitializeTestDataAsync"] = "protected override Task InitializeTestDataAsync(CancellationToken cancellationToken)\n    => SeedTestDataAsync(cancellationToken);",
        ["KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>.InitializeAsync"] = "await initializer.InitializeAsync(options, cancellationToken);",
        ["KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>.TryAdd"] = "User admin = await TryAdd(\n    user => user.Name == \"Admin\", new User { Name = \"Admin\" }, cancellationToken);",
        ["KamiSama.Repositories.EntityFrameworkCore.Initialization.DefaultDatabaseInitializer<TDbContext>.InitializeDataAsync"] = "// DefaultDatabaseInitializer completes this selected stage without creating data.\nawait initializer.InitializeAsync(options, cancellationToken);",
        ["KamiSama.Repositories.EntityFrameworkCore.Initialization.DefaultDatabaseInitializer<TDbContext>.InitializeTestDataAsync"] = "// DefaultDatabaseInitializer completes this selected stage without creating test data.\nawait initializer.InitializeAsync(options, cancellationToken);",
        ["KamiSama.Repositories.EntityFrameworkCore.Postgresql.MultiProviderDbContextBuilderPostgresqlExtensions.AddPostgresql"] = "builder.AddPostgresql<PostgresqlAppDbContext>();",
        ["KamiSama.Repositories.EntityFrameworkCore.Sqlite.MultiProviderDbContextBuilderSqliteExtensions.AddSqlite"] = "builder.AddSqlite<SqliteAppDbContext>();",
        ["KamiSama.Extensions.DependencyInjection.ServiceCollectionExtensions.AutoAddDependenciesFrom"] = "using KamiSama.Extensions.DependencyInjection;\n\nservices.AutoAddDependenciesFrom<Program>();",
        ["KamiSama.ExternalServices.Sms.Features.ISendSms.SendSmsAsync"] = "using KamiSama.ExternalServices.Sms.Features;\n\nawait sendSms.SendSmsAsync(\n    new SendSmsRequest(\"+15551234567\", \"Your code is 123456\"),\n    cancellationToken);",
        ["KamiSama.Modules.WebApplicationBuilderExtension.Extend"] = "using KamiSama.Modules;\n\nExtendedWebApplicationBuilder builder = WebApplication.CreateBuilder(args).Extend();",
        ["KamiSama.Modules.AntiForgeryExtension.AddAntiForgery"] = "webBuilder.Services.AddAntiforgery();\nExtendedWebApplicationBuilder builder = webBuilder.Extend().AddAntiForgery();",
        ["KamiSama.Modules.AuthorizationExtension.AddAuthorization"] = "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddAuthorization();",
        ["KamiSama.Modules.CascadingAuthenticationExtension.AddCascadingAuthentication"] = "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddCascadingAuthentication();",
        ["KamiSama.Modules.ControllersModuleExtension.AddControllers"] = "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddControllers(mvc => mvc.AddApplicationPart(typeof(Program).Assembly));",
        ["KamiSama.Modules.CorsExtension.AddCors"] = "ExtendedWebApplicationBuilder builder = webBuilder.Extend()\n    .AddCors(configurePolicy: policy => policy.AllowAnyOrigin());",
        ["KamiSama.Modules.CustomActionExtension.AddAction"] = "ExtendedWebApplicationBuilder builder = webBuilder.Extend()\n    .AddAction(app => app.MapGet(\"/health\", () => Results.Ok()));",
        ["KamiSama.Modules.ForwardedHeadersExtension.AddForwardedHeaders"] = "using Microsoft.AspNetCore.HttpOverrides;\n\nExtendedWebApplicationBuilder builder = webBuilder.Extend()\n    .AddForwardedHeaders(options => options.ForwardedHeaders = ForwardedHeaders.XForwardedFor);",
        ["KamiSama.Modules.HstsExtension.AddHsts"] = "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddHsts();",
        ["KamiSama.Modules.HttpsRedirectionExtension.AddHttpsRedirection"] = "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddHttpsRedirection();",
        ["KamiSama.Modules.RazorComponentExtension.AddRazorComponents"] = "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddRazorComponents<App>();",
        ["KamiSama.Modules.RazorPagesModuleExtension.AddRazorPages"] = "ExtendedWebApplicationBuilder builder = webBuilder.Extend()\n    .AddRazorPages(options => options.Conventions.AuthorizeFolder(\"/Admin\"));",
        ["KamiSama.Modules.RequestLocalizationExtension.AddRequestLocalization"] = "using System.Globalization;\nusing Microsoft.AspNetCore.Localization;\n\nExtendedWebApplicationBuilder builder = webBuilder.Extend()\n    .AddRequestLocalization(new RequestCulture(\"en-US\"), new CultureInfo(\"en-US\"));",
        ["KamiSama.Modules.ResponseCachingExtension.AddResponseCaching"] = "// Build or BuildAsync will throw while this module is present.\nExtendedWebApplicationBuilder builder = webBuilder.Extend().AddResponseCaching(configure: null);",
        ["KamiSama.Modules.ResponseCompressionExtension.AddResponseCompression"] = "ExtendedWebApplicationBuilder builder = webBuilder.Extend()\n    .AddResponseCompression(options => options.EnableForHttps = true);",
        ["KamiSama.Modules.RoutingExtension.AddRouting"] = "ExtendedWebApplicationBuilder builder = webBuilder.Extend()\n    .AddRouting(options => options.LowercaseUrls = true);",
        ["KamiSama.Modules.StaticFileExtension.AddStaticFiles"] = "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddStaticFiles();",
        ["KamiSama.Modules.SwaggerModuleExtension.AddSwagger"] = "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddSwagger(addEndPointInProduction: false);",
        ["KamiSama.Testing.NSubstitute.TesterBuilderBase.Services"] = "builder.Services.AddSingleton<ISystemClock>(clock);",
        ["KamiSama.Testing.NSubstitute.TesterBuilderBase.ServiceScope"] = "ProductService service = builder.Build();\nIServiceProvider scopedServices = builder.ServiceScope.ServiceProvider;",
        ["KamiSama.Testing.NSubstitute.TesterBuilderBase.AddOption"] = "builder.AddOption<ProductOptions>(options => options.PageSize = 20);",
        ["KamiSama.Testing.NSubstitute.TesterBuilderBase.AddScoped"] = "IProductRepository repository = builder.AddScoped<IProductRepository>();",
        ["KamiSama.Testing.NSubstitute.TesterBuilderBase.AddSingleton"] = "ISystemClock clock = builder.AddSingleton<ISystemClock>();",
        ["KamiSama.Testing.NSubstitute.TesterBuilderBase.AddTransient"] = "IProductValidator validator = builder.AddTransient<IProductValidator>();\n// Every resolution returns this same captured substitute.",
        ["KamiSama.Testing.NSubstitute.TesterBuilderBase.For"] = "ProductService service = builder.Build();\nILogger<ProductService> logger = builder.For<ILogger<ProductService>>();",
        ["KamiSama.Testing.NSubstitute.TesterBuilderBase.BuildService"] = "ProductService service = builder.BuildService<ProductService>();",
        ["KamiSama.Modules.Localization.Features.IListAvailableCultures.ListAsync"] = "CultureInfoDto[] cultures = await listAvailableCultures.ListAsync(cancellationToken);",
        ["KamiSama.Modules.Localization.Features.IGetCurrentCulture.GetCurrentCultureAsync"] = "CultureInfoDto current = await getCurrentCulture.GetCurrentCultureAsync(cancellationToken);",
        ["KamiSama.Modules.Localization.Features.ISetCulture.SetAsync"] = "CultureInfoDto selected = await setCulture.SetAsync(\"fa-IR\", cancellationToken);",
        ["KamiSama.Modules.Localization.LocalizationOptions.AvailableCultures"] = "options.AvailableCultures = [new CultureInfoDto(\"English\", \"us\", \"en-US\")];",
        ["KamiSama.Modules.Localization.LocalizationOptions.DefaultCulture"] = "options.DefaultCulture = \"en-US\";",
        ["KamiSama.Modules.Localization.ExtendedWebApplicationBuilderExtensions.AddLocalizationModule"] = "webBuilder.Services.AddHttpContextAccessor();\nExtendedWebApplicationBuilder builder = webBuilder.Extend()\n    .AddLocalizationModule(webBuilder.Configuration.GetSection(\"Localization\"));",
        ["KamiSama.Modules.Localization.Features.ListAvailableCultures.ListAsync"] = "CultureInfoDto[] cultures = await feature.ListAsync(CancellationToken.None);\n// The returned configured array is not copied.",
        ["KamiSama.Modules.Localization.Features.GetCurrentCulture.GetCurrentCultureAsync"] = "CultureInfoDto current = await feature.GetCurrentCultureAsync(CancellationToken.None);",
        ["KamiSama.Modules.Localization.Features.SetCulture.SetAsync"] = "CultureInfoDto selected = await setCulture.SetAsync(\"fa-IR\", CancellationToken.None);\n// The response cookie participates in culture selection on a later request.",
        ["KamiSama.Modules.Locations.Features.IListCitiesByProvinceName.ListAsync"] = "PagedResult<CityDto> cities = await listCitiesByProvinceName.ListAsync(\"central\", cancellationToken);",
        ["KamiSama.Modules.Locations.ExtendedWebApplicationBuilderExtensions.AddLocationsModule"] = "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddLocationsModule(\n    locationsSection, databaseSection,\n    database => database.AddPostgresqlLocationsDbContext());\nWebApplication app = await builder.BuildAsync(cancellationToken);",
        ["KamiSama.Modules.Locations.LocationsPostgresqlDbContextBuilderExtensions.AddPostgresqlLocationsDbContext"] = "database.AddPostgresqlLocationsDbContext(); // Registers the exact postgresql provider key.",
        ["KamiSama.Modules.Locations.LocationsSqliteDbContextBuilderExtensions.AddSqliteLocationsDbContext"] = "database.AddSqliteLocationsDbContext(); // Registers the exact sqlite provider key.",
        ["KamiSama.Modules.ServicePlans.ExtendedWebApplicationBuilderExtensions.AddServicePlansModule"] = "ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddServicePlansModule(\n    servicePlansSection, databaseSection,\n    database => database.AddPostgresqlServicePlansDbContext());\nWebApplication app = await builder.BuildAsync(cancellationToken);",
        ["KamiSama.Modules.ServicePlans.ServicePlansPostgresqlDbContextBuilderExtensions.AddPostgresqlServicePlansDbContext"] = "database.AddPostgresqlServicePlansDbContext(); // Registers the exact postgresql provider key.",
        ["KamiSama.Modules.ServicePlans.ServicePlansSqliteDbContextBuilderExtensions.AddSqliteServicePlansDbContext"] = "database.AddSqliteServicePlansDbContext(); // Registers the exact sqlite provider key."
    };

    private readonly Dictionary<string, string> testSnippets = new(StringComparer.OrdinalIgnoreCase);

    public ExampleProvider(string srcRoot)
    {
        foreach (var file in Directory.EnumerateFiles(srcRoot, "*.cs", SearchOption.AllDirectories)
                     .Where(path => path.Contains(".Tests", StringComparison.OrdinalIgnoreCase)))
        {
            var text = File.ReadAllText(file);
            foreach (Match method in Regex.Matches(text, @"(?s)\[TestMethod\]\s*public\s+(?:async\s+)?(?:Task|void)\s+\w+\s*\(\)\s*\{(?<body>.*?)^\s*\}", RegexOptions.Multiline))
            {
                var body = method.Groups["body"].Value.Trim();
                if (body.Length is < 20 or > 1800)
                {
                    continue;
                }

                foreach (Match call in Regex.Matches(body, @"\.(?<name>[A-Z]\w*)\s*\(|\b(?<name>SearchModel\.FromPage|new\s+JsonRepository|new\s+InMemoryRepository)\b"))
                {
                    var name = call.Groups["name"].Value.Replace("SearchModel.", "").Replace("new ", "");
                    testSnippets.TryAdd(name, CleanTestSnippet(body));
                }
            }
        }
    }

    public string? FindExample(string typeFullName, MemberDoc member)
    {
        var shortName = ShortName(member.Name);
        var exact = $"{typeFullName}.{shortName}";
        if (curated.TryGetValue(exact, out var example))
        {
            return example;
        }

        if (typeFullName.StartsWith("KamiSama.Repositories.", StringComparison.Ordinal))
        {
            return null;
        }

        if (testSnippets.TryGetValue(shortName, out var snippet))
        {
            return snippet;
        }

        return null;
    }

    private static string ShortName(string name)
    {
        var generic = name.IndexOf('<');
        return generic >= 0 ? name[..generic] : name;
    }

    private static string CleanTestSnippet(string body)
    {
        var lines = body.Replace("\r\n", "\n").Split('\n')
            .Select(line => Regex.Replace(line, @"^\s{2,}", ""))
            .Where(line => !line.TrimStart().StartsWith("Assert.", StringComparison.Ordinal))
            .Take(16);
        return string.Join(Environment.NewLine, lines).Trim();
    }
}

class XmlDoc
{
    public string Summary { get; set; } = "";
    public string Remarks { get; set; } = "";
    public string Returns { get; set; } = "";
    public string Value { get; set; } = "";
    public string Example { get; set; } = "";
    public Dictionary<string, string> Parameters { get; } = new(StringComparer.OrdinalIgnoreCase);
    public Dictionary<string, string> TypeParameters { get; } = new(StringComparer.OrdinalIgnoreCase);
}

record ProjectDoc(
    string Name,
    string Path,
    string Group,
    string? OutputType,
    string? PackageType,
    string? IsPackable,
    string PackageId,
    string Description);

record LibraryDoc(string Name, string Group, string Slug, string PackageId, string Description, List<TypeDoc> Types);

record TypeDoc(
    ProjectDoc Project,
    string Namespace,
    string Name,
    string FullName,
    string Kind,
    string Signature,
    string SourceFile,
    int Line,
    string SourceUrl,
    string Description,
    string Remarks,
    string Example)
{
    public List<ConstructorDoc> Constructors { get; } = [];
    public List<MemberDoc> Members { get; } = [];
}

record ConstructorDoc(
    string Name,
    string Kind,
    string Signature,
    int Line,
    string SourceUrl,
    List<ParameterDoc> Parameters,
    string Description);

record MemberDoc(
    string Name,
    string Kind,
    string Modifiers,
    string Signature,
    string SourceFile,
    int Line,
    string SourceUrl,
    string Description,
    string Remarks,
    List<ParameterDoc> Parameters,
    List<TypeParameterDoc> TypeParameters,
    string ReturnType,
    string Returns,
    string Value,
    string Anchor,
    string TypeFullName,
    string FileName)
{
    public string Example { get; set; } = "";
}

record ParameterDoc(
    string Name,
    string Type,
    string DefaultValue,
    bool IsExtensionReceiver,
    bool IsOut,
    bool IsRef,
    string Description);

record TypeParameterDoc(string Name, string Description);
