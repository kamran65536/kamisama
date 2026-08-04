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
var solutionPath = Path.Combine(srcRoot, "KamiSama.Extensions.slnx");
var dryRun = args.Any(x => x.Equals("--dry-run", StringComparison.OrdinalIgnoreCase));
var docsVersion = DocsVersion();

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

if (Directory.Exists(contentRoot))
{
    Directory.Delete(contentRoot, recursive: true);
}

Directory.CreateDirectory(contentRoot);
Directory.CreateDirectory(Path.Combine(contentRoot, "api"));
Directory.CreateDirectory(Path.Combine(contentRoot, "topics"));

WriteOverview(contentRoot, api, docsVersion);
CopyTopicDocs(docsRoot, contentRoot);
WriteApiDocs(contentRoot, api, docsVersion);
WriteMkDocs(docsRoot, api);

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

static string DocsVersion()
{
    var version = Environment.GetEnvironmentVariable("KAMISAMA_DOCS_VERSION");
    return string.IsNullOrWhiteSpace(version) ? "10.0.10" : version.Trim();
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
        return true;
    }

    return HasAnyVisibilityModifier(node) || parentType is InterfaceDeclarationSyntax;
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

    return HasAnyVisibilityModifier(member);
}

static bool HasAnyVisibilityModifier(SyntaxNode node) =>
    HasModifier(node, SyntaxKind.PublicKeyword) ||
    HasModifier(node, SyntaxKind.InternalKeyword) ||
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
            member.Example = BuildFallbackExample(typeName, member);
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
    builder.AppendLine("KamiSama.Extensions is a reusable .NET and ASP.NET Core package family for building modular applications. It includes core extension methods, dependency-injection helpers, JSON/XML serialization utilities, repository implementations, HTTP exception handling, ProblemDetails integration, web modules, external service integrations, and ready-made bounded-context modules such as Identity, Localization, Locations, and Ticketing.");
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
    builder.AppendLine("| Application modules | Identity, Localization, Locations, and Ticketing bounded contexts. |");
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
    builder.AppendLine("## Install");
    builder.AppendLine();
    builder.AppendLine("```shell");
    builder.AppendLine(InstallCommand(library.PackageId, docsVersion));
    builder.AppendLine("```");
    builder.AppendLine();
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

static void WriteMkDocs(string docsRoot, List<LibraryDoc> libraries)
{
    var builder = new StringBuilder();
    builder.AppendLine("site_name: KamiSama.Extensions");
    builder.AppendLine("site_description: Developer documentation for the KamiSama.Extensions libraries.");
    builder.AppendLine("docs_dir: content");
    builder.AppendLine("site_dir: site");
    builder.AppendLine("extra:");
    builder.AppendLine("  version: !ENV [KAMISAMA_DOCS_VERSION, \"10.0.10\"]");
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
        ["KamiSama.Extensions.Core"] = "Core extension methods and paging models for common .NET tasks such as bytes, hex, base64, hashes, dates, streams, arrays, queues, and IQueryable paging.",
        ["KamiSama.Extensions.DependencyInjection"] = "Attribute-based dependency injection helpers for automatically registering services from assemblies. Use it to mark implementations with scoped, transient, or singleton service lifetimes.",
        ["KamiSama.Extensions.Json"] = "JSON serialization and deserialization helpers for files, streams, byte arrays, and strings. Use it when application code needs compact System.Text.Json convenience methods.",
        ["KamiSama.Extensions.Logging"] = "Logging abstractions and helpers used by KamiSama external service integrations.",
        ["KamiSama.Extensions.NLog"] = "NLog integration helpers for configuring KamiSama logging with ASP.NET Core applications.",
        ["KamiSama.Extensions.WebModules"] = "Modular ASP.NET Core application builder helpers for registering services and applying middleware through reusable web modules.",
        ["KamiSama.Extensions.RestSharp"] = "RestSharp registration and request helpers for KamiSama HTTP client integrations.",
        ["KamiSama.Extensions.Xml"] = "XML serialization and deserialization helpers for files, streams, strings, and byte arrays. Use it when application code needs simple XML persistence or transport helpers.",
        ["KamiSama.ExternalServices.Exceptions"] = "Shared exception types for external service integrations.",
        ["KamiSama.ExternalServices.Email.Abstractions"] = "Email service DTOs and feature contracts.",
        ["KamiSama.ExternalServices.Email.Core"] = "Core email service registrations and shared email behavior.",
        ["KamiSama.ExternalServices.Email.Smtp"] = "SMTP email service implementation and module registration.",
        ["KamiSama.ExternalServices.Sms.Abstractions"] = "SMS service DTOs and feature contracts.",
        ["KamiSama.ExternalServices.Sms.Core"] = "Core SMS service registrations and shared SMS behavior.",
        ["KamiSama.ExternalServices.Sms.Kavenegar"] = "Kavenegar SMS provider implementation.",
        ["KamiSama.ExternalServices.Sms.NeoZarin"] = "NeoZarin SMS provider implementation.",
        ["KamiSama.IranSystem"] = "Iran System encoding conversion helpers for legacy Persian text interoperability. Use this package when integrating with systems that still exchange Iran System encoded data.",
        ["KamiSama.Modules.Identity.Abstractions"] = "Identity module request, response, and feature contracts for users, roles, password flows, and tokens.",
        ["KamiSama.Modules.Identity.Core"] = "ASP.NET Core Identity module implementation with users, roles, token handling, repositories, and web-module setup.",
        ["KamiSama.Modules.Identity.Postgresql"] = "PostgreSQL provider registration for the KamiSama Identity module.",
        ["KamiSama.Modules.Identity.Sqlite"] = "SQLite provider registration for the KamiSama Identity module.",
        ["KamiSama.Modules.Localization.Abstractions"] = "Localization feature contracts and DTOs for culture selection.",
        ["KamiSama.Modules.Localization.Core"] = "Localization module implementation for available cultures, current culture, and request culture handling.",
        ["KamiSama.Modules.Locations.Abstractions"] = "Locations module contracts and DTOs for provinces and cities.",
        ["KamiSama.Modules.Locations.Core"] = "Locations module implementation with province and city entities, repositories, features, and web-module setup.",
        ["KamiSama.Modules.Locations.Postgresql"] = "PostgreSQL provider registration for the KamiSama Locations module.",
        ["KamiSama.Modules.Locations.Sqlite"] = "SQLite provider registration for the KamiSama Locations module.",
        ["KamiSama.Modules.Ticketing.Abstractions"] = "Ticketing module contracts and DTOs for tickets, comments, categories, attachments, status, and priority.",
        ["KamiSama.Modules.Ticketing.Core"] = "Ticketing module implementation with entities, repositories, feature services, and web-module setup.",
        ["KamiSama.Modules.Ticketing.Postgresql"] = "PostgreSQL provider registration for the KamiSama Ticketing module.",
        ["KamiSama.Modules.Ticketing.Sqlite"] = "SQLite provider registration for the KamiSama Ticketing module.",
        ["KamiSama.Repositories.Core"] = "Core repository interfaces, in-memory repository implementation, connection-string options, and database initialization contracts.",
        ["KamiSama.Repositories.EntityFramework"] = "Repository implementation and paging helpers for classic Entity Framework projects.",
        ["KamiSama.Repositories.EntityFrameworkCore"] = "Repository implementation, paging helpers, database initialization, and multi-provider DbContext registration for Entity Framework Core.",
        ["KamiSama.Repositories.EntityFrameworkCore.Postgresql"] = "PostgreSQL provider extension methods for Entity Framework Core multi-provider DbContext registration.",
        ["KamiSama.Repositories.EntityFrameworkCore.Sqlite"] = "SQLite provider extension methods for Entity Framework Core multi-provider DbContext registration.",
        ["KamiSama.Repositories.Json"] = "JSON-backed repository implementation for lightweight file-based persistence with synchronous and asynchronous repository APIs.",
        ["KamiSama.Repositories.Xml"] = "XML-backed repository implementations for lightweight file or directory persistence with synchronous and asynchronous repository APIs.",
        ["KamiSama.Testing.NSubstitute"] = "DI-first testing helpers that auto-create NSubstitute mocks for missing constructor dependencies."
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
    if (fullName.Contains(".FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "FeatureDefinitionBase")
    {
        return "Binds the entity, DTO, add request, update request, repository, search model, and key types once for a CRUD-style feature set. Use it as a typed shell when several features in the same module work over the same entity and repository.";
    }

    if (fullName.Contains(".FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "AddFeatureBase")
    {
        return "Nested create-flow base class from `FeatureDefinitionBase`. Use it after the feature definition has already bound the entity, DTO, add-request, repository, search-model, and key types, so each concrete add feature only implements duplicate checking and mapping.";
    }

    if (fullName.Contains(".FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "UpdateFeatureBase")
    {
        return "Nested update-flow base class from `FeatureDefinitionBase`. Use it for update features that load an entity by id, optionally check duplicate state, patch the entity from the request, and save through the bound repository.";
    }

    if (fullName.Contains(".FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "DeleteFeatureBase")
    {
        return "Nested delete-flow base class from `FeatureDefinitionBase`. Use it for delete features that load an entity by id, optionally check whether deletion is allowed, and delete through the bound repository.";
    }

    if (fullName.Contains(".FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "ListFeatureBase")
    {
        return "Nested list-flow base class from `FeatureDefinitionBase`. Use it for paged list features that read a repository page and map each entity to the DTO type bound by the feature definition.";
    }

    if (fullName.Contains(".FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "FindByIdFeatureBase")
    {
        return "Nested find-by-id base class from `FeatureDefinitionBase`. Use it for query features that load a single entity by key, throw the package not-found exception when missing, and map the entity to a DTO.";
    }

    if (fullName.Contains(".FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "ExistsByIdFeatureBase")
    {
        return "Nested exists-by-id base class from `FeatureDefinitionBase`. Use it for simple features that expose repository existence checks through an application feature interface.";
    }

    return shortName switch
    {
        "GenericAddFeature" => "Base implementation for create use cases. `AddAsync` checks duplicate state, converts the request to an entity, persists it through the repository, and returns a DTO.",
        "GenericUpdateFeature" => "Base implementation for update use cases. `UpdateAsync` loads the entity by id, runs duplicate checks, lets the derived class patch the entity, and saves it through the repository.",
        "GenericDeleteFeature" => "Base implementation for delete use cases. `DeleteAsync` loads the entity by id, calls `CanBeDeletedAsync`, and deletes the entity only when the hook allows it.",
        "GenericListFeature" => "Base implementation for paged list use cases. It delegates paging to the repository and maps repository entities into the DTO result shape expected by callers.",
        "GenericFindByIdFeature" => "Base implementation for find-by-id use cases. It loads an entity through the repository, throws `NotFoundException<TEntity>` when missing, and maps the entity to a DTO.",
        "GenericFindByNameFeature" => "Base implementation for find-by-name use cases. It loads an entity through the repository, throws `NotFoundException<TEntity>` when missing, and maps the entity to a DTO.",
        "GenericExistsByIdFeature" => "Base implementation for exists-by-id checks. It keeps application feature code thin by delegating directly to the repository contract.",
        "GenericExistsByNameFeature" => "Base implementation for exists-by-name checks. It keeps application feature code thin by delegating directly to the repository contract.",
        "GenericRepository" => "Base EF Core repository for paged application repositories. Derive from it when you need the common list/count flow and only want to provide entity-specific search filtering.",
        "DbRepository" => "Repository wrapper around an EF DbContext. Use it when you want the standard KamiSama repository methods over a DbSet without writing the same CRUD code in each repository.",
        "DatabaseInitializerBase" => "Base EF Core database initializer with migration and seed hooks. Derive from it to centralize production seed data and optional test seed data for one DbContext.",
        "WebModule" => "Base abstraction for modular ASP.NET Core setup. Implement it when a feature area needs to register services before build and apply middleware or endpoints after build.",
        "ExtendedWebApplicationBuilder" => "Composable wrapper around `WebApplicationBuilder` that collects web modules and applies them in a predictable build flow.",
        "AutoInjectAttributeBase" => "Base attribute for convention-based dependency injection registration. Derived attributes use it to register the decorated type against an explicit or inferred service type.",
        "AutoInjectAttribute" => "General-purpose dependency injection attribute where service type and lifetime can be configured directly on the implementation type.",
        "AutoInjectScopedAttribute" => "Dependency injection attribute for scoped services. Use it on implementations that should be created once per request or scope.",
        "AutoInjectSingletonAttribute" => "Dependency injection attribute for singleton services. Use it on implementations that should be shared for the application lifetime.",
        "AutoInjectTransientAttribute" => "Dependency injection attribute for transient services. Use it on implementations that should be created each time they are requested.",
        "KamiSamaProblemDetailsOptions" => "Options object for configuring how KamiSama converts exceptions into ASP.NET Core `ProblemDetails`. Use it to choose the provider and optional localization behavior.",
        "ConnectionStringOption" => "Configuration object for database provider and connection-string settings. Bind it from configuration when wiring repository or DbContext provider packages.",
        "DataInitializationOptions" => "Options object that controls database initialization work. Use it to turn migration, normal seed data, and test seed data on or off.",
        "TesterBuilderBase" => "DI-first testing helper that builds services and creates NSubstitute mocks for missing dependencies. Derive a small test builder from it to keep unit tests focused on the service under test.",
        _ => ""
    };
}

static string CuratedTypeExample(string fullName, string typeName)
{
    var shortName = ShortTypeName(typeName);
    if (fullName.Contains(".FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "AddFeatureBase")
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

    if (fullName.Contains(".FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "FeatureDefinitionBase")
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

    if (fullName.Contains(".FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "UpdateFeatureBase")
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

    if (fullName.Contains(".FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "DeleteFeatureBase")
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

    if (fullName.Contains(".FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "ListFeatureBase")
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

    if (fullName.Contains(".FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "FindByIdFeatureBase")
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

    if (fullName.Contains(".FeatureDefinitionBase<", StringComparison.Ordinal) && shortName == "ExistsByIdFeatureBase")
    {
        return """
public sealed class ProductFeatures
    : FeatureDefinitionBase<Product, ProductDto, AddProductRequest, UpdateProductRequest, IProductRepository, SearchModel, Guid>
{
    public sealed class ProductExists(IProductRepository repository) : ExistsByIdFeatureBase(repository);
}
""";
    }

    if (shortName == "GenericAddFeature")
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

    if (shortName == "GenericUpdateFeature")
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

    if (shortName == "GenericDeleteFeature")
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

    if (shortName == "GenericListFeature")
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

    if (shortName == "GenericRepository")
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

    return shortName switch
    {
        "WebModule" => """
using KamiSama.Extensions.WebModules;

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
        "ExtendedWebApplicationBuilder" => """
using KamiSama.Extensions.WebModules;

var builder = WebApplication.CreateBuilder(args)
    .Extend()
    .AddControllers()
    .AddSwagger();

var app = await builder.BuildAsync(CancellationToken.None);
""",
        "AutoInjectAttribute" => """
using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[AutoInject(ServiceType = typeof(IProductService), Lifetime = ServiceLifetime.Scoped)]
public sealed class ProductService : IProductService;
""",
        "AutoInjectScopedAttribute" => """
using KamiSama.Extensions.DependencyInjection;

[AutoInjectScoped<IProductService>]
public sealed class ProductService : IProductService;
""",
        "AutoInjectSingletonAttribute" => """
using KamiSama.Extensions.DependencyInjection;

[AutoInjectSingleton<ICacheService>]
public sealed class MemoryCacheService : ICacheService;
""",
        "AutoInjectTransientAttribute" => """
using KamiSama.Extensions.DependencyInjection;

[AutoInjectTransient<IMessageFactory>]
public sealed class MessageFactory : IMessageFactory;
""",
        "KamiSamaProblemDetailsOptions" => """
using KamiSama.Chassis.ProblemDetails;

services.AddControllers()
    .AddExceptionFilterForProblemDetails(options => options
        .UseDefaultProblemDetailsProvider()
        .UseResourceLocalizer<ErrorMessages>());
""",
        "ConnectionStringOption" => """
using KamiSama.Repositories;

var database = configuration
    .GetSection("Database")
    .Get<ConnectionStringOption>();
""",
        "DataInitializationOptions" => """
using KamiSama.Repositories.Initialization;

await initializer.InitializeAsync(new DataInitializationOptions
{
    Migrate = true,
    InitializeData = true,
    InitializeTestData = false
}, cancellationToken);
""",
        "DatabaseInitializerBase" => """
using KamiSama.Repositories.EntityFrameworkCore.Initialization;

public sealed class AppDbInitializer(AppDbContext context) : DatabaseInitializerBase<AppDbContext>(context)
{
    protected override Task InitializeDataAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    protected override Task InitializeTestDataAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
""",
        "TesterBuilderBase" => """
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
    if (kind != "Method" && kind != "Property")
    {
        return "";
    }

    var typeShortName = ShortTypeName(typeName);
    var memberShortName = ShortMemberName(memberName);

    if (typeShortName is "GenericAddFeature" or "AddFeatureBase")
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

    if (typeShortName is "GenericUpdateFeature" or "UpdateFeatureBase")
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

    if (typeShortName is "GenericDeleteFeature" or "DeleteFeatureBase")
    {
        return memberShortName switch
        {
            "Repository" => "Protected repository used by derived delete features. Use it when the deletion rule needs additional repository data.",
            "CanBeDeletedAsync" => "Deletion guard called after the entity is loaded and before deletion. Override it to prevent deletes for entities that are still referenced or otherwise protected.",
            "DeleteAsync" => "Runs the complete delete flow: load the entity by id, throw when missing, ask `CanBeDeletedAsync`, and delete through the repository only when allowed.",
            _ => ""
        };
    }

    if (typeShortName is "GenericListFeature" or "ListFeatureBase")
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

    if (typeShortName is "GenericFindByIdFeature" or "FindByIdFeatureBase")
    {
        return memberShortName switch
        {
            "Repository" => "Protected repository used by the find-by-id flow and available to derived mapping code.",
            "ConvertToDto" => "Mapping hook called after the entity is found. Override it to return the DTO shape expected by callers.",
            "FindByIdAsync" => "Loads an entity by key through the repository, throws `NotFoundException<TEntity>` when no entity exists, and maps the entity to a DTO.",
            _ => ""
        };
    }

    if (typeShortName is "GenericFindByNameFeature")
    {
        return memberShortName switch
        {
            "Repository" => "Protected repository used by the find-by-name flow and available to derived mapping code.",
            "ConvertToDto" => "Mapping hook called after the entity is found. Override it to return the DTO shape expected by callers.",
            "FindByNameAsync" => "Loads an entity by name through the repository, throws `NotFoundException<TEntity>` when no entity exists, and maps the entity to a DTO.",
            _ => ""
        };
    }

    if (typeShortName is "GenericExistsByIdFeature" or "ExistsByIdFeatureBase")
    {
        return memberShortName switch
        {
            "Repository" => "Protected repository used by the exists-by-id flow.",
            "ExistsByIdAsync" => "Checks whether an entity exists for the supplied key by delegating to the repository.",
            _ => ""
        };
    }

    if (typeShortName == "GenericExistsByNameFeature")
    {
        return memberShortName switch
        {
            "Repository" => "Protected repository used by the exists-by-name flow.",
            "ExistsByNameAsync" => "Checks whether an entity exists for the supplied name by delegating to the repository.",
            _ => ""
        };
    }

    if (typeShortName == "GenericRepository")
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

static string BuildFallbackExample(string typeName, MemberDoc member)
{
    if (member.Kind == "Property" && member.Name == "All" && typeName.Contains("SearchModel", StringComparison.Ordinal))
    {
        return "using KamiSama.Extensions.Paging;\n\nvar search = SearchModel.All;";
    }

    if (member.Kind != "Method")
    {
        return "";
    }

    var key = ShortMemberName(member.Name);
    if (typeName.Contains("GenericAddFeature", StringComparison.Ordinal) || typeName == "AddFeatureBase")
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

    if (typeName.Contains("GenericUpdateFeature", StringComparison.Ordinal) || typeName == "UpdateFeatureBase")
    {
        return key switch
        {
            "UpdateAsync" => "await updateProductFeature.UpdateAsync(productId, new UpdateProductRequest(\"Keyboard\", 120), cancellationToken);",
            "CheckDuplicateAsync" => "protected override async Task CheckDuplicateAsync(Guid id, UpdateProductRequest request, CancellationToken cancellationToken)\n{\n    var duplicate = await Repository.FindByNameAsync(request.Name, cancellationToken);\n    if (duplicate is not null && duplicate.Id != id)\n        throw new AlreadyExistsException<Product>(request.Name, nameof(request.Name));\n}",
            "PatchEntityAsync" => "protected override Task PatchEntityAsync(Product entity, UpdateProductRequest request, CancellationToken cancellationToken)\n{\n    entity.Name = request.Name;\n    entity.Price = request.Price;\n    return Task.CompletedTask;\n}",
            _ => ""
        };
    }

    if (typeName.Contains("GenericDeleteFeature", StringComparison.Ordinal) || typeName == "DeleteFeatureBase")
    {
        return key switch
        {
            "DeleteAsync" => "await deleteProductFeature.DeleteAsync(productId, cancellationToken);",
            "CanBeDeletedAsync" => "protected override Task<bool> CanBeDeletedAsync(IProductRepository repository, Product entity)\n    => Task.FromResult(!entity.HasOpenOrders);",
            _ => ""
        };
    }

    if (typeName.Contains("GenericListFeature", StringComparison.Ordinal) || typeName == "ListFeatureBase")
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

    if (typeName.Contains("GenericFindByIdFeature", StringComparison.Ordinal) || typeName == "FindByIdFeatureBase")
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
        "GetString" when typeName.Contains("ByteArrayExtensions", StringComparison.Ordinal) => "using KamiSama.Extensions;\n\nvar text = new byte[] { 72, 105 }.GetString();",
        "FromPage" => "using KamiSama.Extensions.Paging;\n\nvar search = SearchModel.FromPage(1, 20);",
        "MakePaged" => "using KamiSama.Extensions;\nusing KamiSama.Extensions.Paging;\n\nvar page = new[] { 1, 2, 3, 4 }.AsQueryable().MakePaged(SearchModel.FromPage(1, 2));",
        "AddSwagger" => "using KamiSama.Extensions.WebModules;\n\nvar builder = WebApplication.CreateBuilder(args).Extend().AddSwagger();",
        "AddControllers" => "using KamiSama.Extensions.WebModules;\n\nvar builder = WebApplication.CreateBuilder(args).Extend().AddControllers();",
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
        ["KamiSama.Extensions.WebModules.WebApplicationBuilderExtension.Extend"] = "using KamiSama.Extensions.WebModules;\n\nvar builder = WebApplication.CreateBuilder(args).Extend();",
        ["KamiSama.Extensions.WebModules.WebModule.ConfigureServices"] = "using KamiSama.Extensions.WebModules;\n\npublic sealed class MyModule : WebModule\n{\n    public override void ConfigureServices(IServiceCollection services)\n    {\n        services.AddControllers();\n    }\n\n    public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)\n        => Task.CompletedTask;\n}",
        ["KamiSama.Extensions.WebModules.SwaggerModuleExtension.AddSwagger"] = "using KamiSama.Extensions.WebModules;\n\nvar builder = WebApplication.CreateBuilder(args).Extend().AddSwagger(addEndPointInProduction: true);",
        ["KamiSama.Repositories.Json.JsonRepository<TEntity>.FindAsync"] = "using KamiSama.Repositories.Json;\n\nvar repository = new JsonRepository<User>(\"users.json\");\nvar user = await repository.FindAsync(x => x.Id == 1, cancellationToken);",
        ["KamiSama.Repositories.RepositoriesExtensions.GetAll"] = "using KamiSama.Repositories;\n\nvar all = repository.GetAll().ToList();",
        ["KamiSama.Extensions.DependencyInjection.ServiceCollectionExtensions.AutoAddDependenciesFrom"] = "using KamiSama.Extensions.DependencyInjection;\n\nservices.AutoAddDependenciesFrom<Program>();"
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
