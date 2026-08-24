[CmdletBinding()]
param(
    [switch] $Fast
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$repositoryRoot = (Resolve-Path (Join-Path $PSScriptRoot '../../..')).Path
$solutionPath = Join-Path $repositoryRoot 'src/kamisama.slnx'
$tempRoot = Join-Path ([System.IO.Path]::GetTempPath()) "kamisama-packed-templates-$([guid]::NewGuid().ToString('N'))"
$feedPath = Join-Path $tempRoot 'feed'
$hivePath = Join-Path $tempRoot 'template-hive'
$nugetPackagesPath = Join-Path $tempRoot 'nuget-packages'
$generatedPath = Join-Path $tempRoot 'generated'
$repoArtifactsPath = Join-Path $tempRoot 'repo-artifacts'
$consumerArtifactsPath = Join-Path $tempRoot 'consumer-artifacts'
$nugetConfigPath = Join-Path $tempRoot 'NuGet.Config'
$templateInstalled = $false
$previousNugetPackages = $env:NUGET_PACKAGES
$previousDotnetCliHome = $env:DOTNET_CLI_HOME

$requiredTemplateNames = @(
    'kamisama-solution',
    'kamisama-bc',
    'kamisama-provider',
    'kamisama-bootstrap',
    'kamisama-server',
    'kamisama-type',
    'kamisama-crud',
    'kamisama-feature',
    'kamisama-panel-crud',
    'kamisama-aspire-local',
    'kamisama-delete-button'
)
$retiredTemplateNames = @(
    'kamisama-admin',
    'kamisama-empty',
    'kamisama-bounded-context',
    'kamisama-database-support',
    'kamisama-orchestration'
)

function Invoke-DotNet {
    param(
        [Parameter(Mandatory)]
        [string[]] $Arguments,

        [string] $WorkingDirectory = $repositoryRoot,

        [switch] $CaptureOutput
    )

    Write-Host "> dotnet $($Arguments -join ' ')"
    Push-Location $WorkingDirectory
    try {
        if ($CaptureOutput) {
            $output = @(& dotnet @Arguments 2>&1)
            $exitCode = $LASTEXITCODE
            $output | ForEach-Object { Write-Host $_ }
            if ($exitCode -ne 0) {
                throw "dotnet exited with code $exitCode."
            }

            return ($output -join [Environment]::NewLine)
        }

        & dotnet @Arguments 2>&1 | ForEach-Object { Write-Host $_ }
        if ($LASTEXITCODE -ne 0) {
            throw "dotnet exited with code $LASTEXITCODE."
        }
    }
    finally {
        Pop-Location
    }
}

function Invoke-Template {
    param(
        [Parameter(Mandatory)]
        [string] $ShortName,

        [Parameter(Mandatory)]
        [string] $Name,

        [Parameter(Mandatory)]
        [string] $OutputPath,

        [string[]] $Arguments = @()
    )

    Invoke-DotNet -Arguments (@(
        'new', $ShortName,
        '--name', $Name,
        '--output', $OutputPath,
        '--debug:custom-hive', $hivePath
    ) + $Arguments)
}

function Assert-Path {
    param(
        [Parameter(Mandatory)]
        [string] $Path,

        [bool] $Exists = $true
    )

    if ((Test-Path -LiteralPath $Path) -ne $Exists) {
        $expectation = if ($Exists) { 'exist' } else { 'be absent' }
        throw "Expected '$Path' to $expectation."
    }
}

function Assert-FileContains {
    param(
        [Parameter(Mandatory)]
        [string] $Path,

        [Parameter(Mandatory)]
        [string] $Pattern
    )

    Assert-Path -Path $Path
    $content = [System.IO.File]::ReadAllText($Path)
    if ($content -notmatch $Pattern) {
        throw "Expected '$Path' to match '$Pattern'."
    }
}

function Assert-FileNotContains {
    param(
        [Parameter(Mandatory)]
        [string] $Path,

        [Parameter(Mandatory)]
        [string] $Pattern
    )

    Assert-Path -Path $Path
    $content = [System.IO.File]::ReadAllText($Path)
    if ($content -match $Pattern) {
        throw "Expected '$Path' not to match '$Pattern'."
    }
}

function Assert-NoTemplateTokens {
    param(
        [Parameter(Mandatory)]
        [string] $Path
    )

    $tokens = 'SolutionToken|ContextToken|ServerToken|PanelToken|ServiceCategoryToken|PageCategoryToken|NamespaceToken|ItemName|KeyTypeToken|ProviderToken|PropsPathToken|CoreProjectPathToken|BootstrapProjectPathToken'
    foreach ($file in Get-ChildItem -LiteralPath $Path -File -Recurse) {
        if ([System.IO.File]::ReadAllText($file.FullName) -match $tokens) {
            throw "Generated file '$($file.FullName)' contains an unresolved template token."
        }
    }
}

function New-ConsumerProps {
    param(
        [Parameter(Mandatory)]
        [string] $Directory
    )

    $null = New-Item -ItemType Directory -Path $Directory -Force
    [System.IO.File]::WriteAllText((Join-Path $Directory 'props.xml'), @'
<Project>
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>
'@)
}

function Build-Consumer {
    param(
        [Parameter(Mandatory)]
        [string] $Path,

        [Parameter(Mandatory)]
        [string] $CaseName
    )

    Assert-Path -Path $Path
    $caseArtifactsPath = Join-Path $consumerArtifactsPath $CaseName
    Invoke-DotNet -Arguments @(
        'restore', $Path,
        '--configfile', $nugetConfigPath,
        '--packages', $nugetPackagesPath,
        '--artifacts-path', $caseArtifactsPath
    )
    Invoke-DotNet -Arguments @(
        'build', $Path,
        '--no-restore',
        '--configuration', 'Release',
        '--artifacts-path', $caseArtifactsPath
    )
}

function Test-SolutionSkillCases {
    foreach ($includeLibraries in @($false, $true)) {
        foreach ($includeDesigner in @($false, $true)) {
            $caseName = "solution-skills-libraries-$($includeLibraries.ToString().ToLowerInvariant())-designer-$($includeDesigner.ToString().ToLowerInvariant())"
            $outputPath = Join-Path $generatedPath $caseName
            Invoke-Template -ShortName 'kamisama-solution' -Name 'Validation' -OutputPath $outputPath -Arguments @(
                '--IncludeKamiSamaLibrariesSkill', $includeLibraries.ToString().ToLowerInvariant(),
                '--IncludeSolutionDesignerSkill', $includeDesigner.ToString().ToLowerInvariant()
            )

            Assert-Path -Path (Join-Path $outputPath 'Validation.slnx')
            Assert-Path -Path (Join-Path $outputPath 'AGENTS.md')
            Assert-Path -Path (Join-Path $outputPath 'opencode.json')
            Assert-Path -Path (Join-Path $outputPath 'agent/design/solution.yaml')
            Assert-Path -Path (Join-Path $outputPath '.agents/skills/solution-scaffolding/SKILL.md')
            Assert-Path -Path (Join-Path $outputPath '.agents/skills/kamisama-libraries/SKILL.md') -Exists $includeLibraries
            Assert-Path -Path (Join-Path $outputPath '.agents/skills/kamisama-solution-designer/SKILL.md') -Exists $includeDesigner
            Assert-Path -Path (Join-Path $outputPath 'props.xml') -Exists $false
        }
    }
}

function Test-BoundedContextCase {
    param(
        [bool] $UseProps,
        [bool] $Build = $false
    )

    $caseName = "bc-props-$($UseProps.ToString().ToLowerInvariant())"
    $outputPath = Join-Path $generatedPath $caseName
    if ($UseProps) {
        New-ConsumerProps -Directory $outputPath
    }

    Invoke-Template -ShortName 'kamisama-bc' -Name 'Validation' -OutputPath $outputPath -Arguments @(
        '--Context', 'Catalog',
        '--UseProps', $UseProps.ToString().ToLowerInvariant()
    )

    $abstractionsProject = Join-Path $outputPath 'Validation.Catalog.Abstractions/Validation.Catalog.Abstractions.csproj'
    $coreProject = Join-Path $outputPath 'Validation.Catalog.Core/Validation.Catalog.Core.csproj'
    Assert-Path -Path $abstractionsProject
    Assert-Path -Path $coreProject
    if ($UseProps) {
        Assert-FileContains -Path $coreProject -Pattern '<Import Project="\.\./props\.xml" />'
        Assert-FileNotContains -Path $coreProject -Pattern '<TargetFramework>net10\.0</TargetFramework>'
    }
    else {
        Assert-FileContains -Path $coreProject -Pattern '<TargetFramework>net10\.0</TargetFramework>'
        Assert-FileNotContains -Path $coreProject -Pattern '<Import Project='
    }

    Assert-NoTemplateTokens -Path $outputPath
    if ($Build) {
        Build-Consumer -Path $coreProject -CaseName $caseName
    }
}

function Test-ProviderCase {
    param(
        [Parameter(Mandatory)]
        [ValidateSet('Postgresql', 'Sqlite', 'SqlServer', 'Oracle')]
        [string] $Provider
    )

    $caseName = "provider-$($Provider.ToLowerInvariant())"
    $outputPath = Join-Path $generatedPath $caseName
    Invoke-Template -ShortName 'kamisama-bc' -Name 'Validation' -OutputPath $outputPath -Arguments @('--Context', 'Catalog')
    Invoke-Template -ShortName 'kamisama-provider' -Name 'Validation' -OutputPath $outputPath -Arguments @(
        '--Context', 'Catalog',
        '--Provider', $Provider,
        '--CoreProject', '../Validation.Catalog.Core/Validation.Catalog.Core.csproj'
    )

    $providerProject = Join-Path $outputPath "Validation.Catalog.$Provider/Validation.Catalog.$Provider.csproj"
    Assert-FileContains -Path $providerProject -Pattern "KamiSama\.Repositories\.EntityFrameworkCore\.$Provider"
    Assert-FileContains -Path $providerProject -Pattern '\.\./Validation\.Catalog\.Core/Validation\.Catalog\.Core\.csproj'
    Assert-NoTemplateTokens -Path $outputPath
    Build-Consumer -Path $providerProject -CaseName $caseName
}

function Test-BootstrapCase {
    $caseName = 'bootstrap'
    $outputPath = Join-Path $generatedPath $caseName
    Invoke-Template -ShortName 'kamisama-bootstrap' -Name 'Validation.Bootstrap' -OutputPath $outputPath
    $project = Join-Path $outputPath 'Validation.Bootstrap/Validation.Bootstrap.csproj'
    Assert-FileContains -Path $project -Pattern '<RootNamespace>Validation\.Bootstrap</RootNamespace>'
    Assert-NoTemplateTokens -Path $outputPath
    Build-Consumer -Path $project -CaseName $caseName
}

function Test-ServerCase {
    param(
        [bool] $IncludeClient,
        [bool] $IncludeBootstrap
    )

    $caseName = "server-client-$($IncludeClient.ToString().ToLowerInvariant())-bootstrap-$($IncludeBootstrap.ToString().ToLowerInvariant())"
    $outputPath = Join-Path $generatedPath $caseName
    $arguments = @('--Server', 'Admin', '--IncludeClient', $IncludeClient.ToString().ToLowerInvariant())
    if ($IncludeBootstrap) {
        Invoke-Template -ShortName 'kamisama-bootstrap' -Name 'Validation.Bootstrap' -OutputPath $outputPath
        $arguments += @('--BootstrapProject', '../Validation.Bootstrap/Validation.Bootstrap.csproj')
    }

    Invoke-Template -ShortName 'kamisama-server' -Name 'Validation' -OutputPath $outputPath -Arguments $arguments
    $serverProject = Join-Path $outputPath 'Validation.Admin.Server/Validation.Admin.Server.csproj'
    Assert-Path -Path (Join-Path $outputPath 'Validation.Admin.Abstractions/Validation.Admin.Abstractions.csproj')
    Assert-Path -Path (Join-Path $outputPath 'Validation.Admin.Core/Validation.Admin.Core.csproj')
    Assert-Path -Path $serverProject
    Assert-Path -Path (Join-Path $outputPath 'Validation.Admin.Client/Validation.Admin.Client.csproj') -Exists $IncludeClient

    if ($IncludeClient) {
        Assert-FileContains -Path $serverProject -Pattern 'Validation\.Admin\.Client'
    }
    else {
        Assert-FileNotContains -Path $serverProject -Pattern 'Validation\.Admin\.Client'
    }
    if ($IncludeBootstrap) {
        Assert-FileContains -Path $serverProject -Pattern '\.\./Validation\.Bootstrap/Validation\.Bootstrap\.csproj'
    }
    else {
        Assert-FileNotContains -Path $serverProject -Pattern 'Validation\.Bootstrap'
    }

    Assert-NoTemplateTokens -Path $outputPath
    Build-Consumer -Path $serverProject -CaseName $caseName
}

function Test-TypeCases {
    foreach ($type in @('Entity', 'DataType')) {
        $caseName = "type-$($type.ToLowerInvariant())"
        $outputPath = Join-Path $generatedPath $caseName
        Invoke-Template -ShortName 'kamisama-type' -Name 'Product' -OutputPath $outputPath -Arguments @(
            '--Type', $type,
            '--Namespace', 'Validation.Catalog',
            '--KeyType', 'long'
        )

        $folder = if ($type -eq 'Entity') { 'Entities' } else { 'DataTypes' }
        $file = Join-Path $outputPath "$folder/Product.cs"
        Assert-FileContains -Path $file -Pattern 'namespace Validation\.Catalog'
        Assert-FileContains -Path $file -Pattern 'long'
        Assert-NoTemplateTokens -Path $outputPath
    }
}

function Test-FeatureCases {
    $expectedFiles = @{
        Add = 'AddProduct.cs'
        Update = 'UpdateProduct.cs'
        Delete = 'DeleteProduct.cs'
        FindById = 'FindProductById.cs'
        List = 'ListProducts.cs'
    }
    foreach ($operation in @('Add', 'Update', 'Delete', 'FindById', 'List')) {
        $caseName = "feature-$($operation.ToLowerInvariant())"
        $outputPath = Join-Path $generatedPath $caseName
        Invoke-Template -ShortName 'kamisama-feature' -Name 'Product' -OutputPath $outputPath -Arguments @(
            '--Operation', $operation,
            '--Namespace', 'Validation.Catalog',
            '--ServiceCategory', 'Products',
            '--KeyType', 'long'
        )

        $file = Join-Path $outputPath "Services/Products/$($expectedFiles[$operation])"
        Assert-FileContains -Path $file -Pattern 'namespace Validation\.Catalog\.Services\.Products'
        Assert-FileContains -Path $file -Pattern 'TODO\(ai\)'
        Assert-NoTemplateTokens -Path $outputPath
    }
}

function Test-CrudCase {
    $outputPath = Join-Path $generatedPath 'crud'
    Invoke-Template -ShortName 'kamisama-crud' -Name 'Product' -OutputPath $outputPath -Arguments @(
        '--Solution', 'Validation',
        '--Context', 'Catalog',
        '--ServiceCategory', 'Products',
        '--KeyType', 'long'
    )

    Assert-Path -Path (Join-Path $outputPath 'Validation.Catalog.Abstractions/Services/Products/Dtos.cs')
    Assert-Path -Path (Join-Path $outputPath 'Validation.Catalog.Core/Entities/Product.cs')
    Assert-Path -Path (Join-Path $outputPath 'Validation.Catalog.Core/Repositories/Abstractions/IProductRepository.cs')
    Assert-Path -Path (Join-Path $outputPath 'Validation.Catalog.Core/Services/Products/AddProductService.cs')
    Assert-NoTemplateTokens -Path $outputPath
}

function Test-PanelCrudCase {
    $outputPath = Join-Path $generatedPath 'panel-crud'
    Invoke-Template -ShortName 'kamisama-panel-crud' -Name 'Product' -OutputPath $outputPath -Arguments @(
        '--Solution', 'Validation',
        '--Panel', 'Admin',
        '--ServiceCategory', 'Products',
        '--PageCategory', 'Catalog',
        '--KeyType', 'long'
    )

    Assert-Path -Path (Join-Path $outputPath 'Validation.Admin.Abstractions/Services/Products/Dtos.cs')
    Assert-Path -Path (Join-Path $outputPath 'Validation.Admin.Core/Services/Products/AddProductService.cs')
    Assert-Path -Path (Join-Path $outputPath 'Validation.Admin.Server/Controllers/ProductsController.cs')
    Assert-Path -Path (Join-Path $outputPath 'Validation.Admin.Client/Pages/Catalog/Products/List.razor')
    Assert-NoTemplateTokens -Path $outputPath
}

function Test-AspireLocalCase {
    $outputPath = Join-Path $generatedPath 'aspire-local'
    Invoke-Template -ShortName 'kamisama-aspire-local' -Name 'AspireLocalExtensions' -OutputPath $outputPath -Arguments @('--Namespace', 'Validation.AppHost')
    $file = Join-Path $outputPath 'AspireLocalExtensions.cs'
    Assert-FileContains -Path $file -Pattern 'namespace Validation\.AppHost'
    Assert-FileContains -Path $file -Pattern 'AddMigrationForAll'
    Assert-NoTemplateTokens -Path $outputPath
}

function Test-DeleteButtonCase {
    $outputPath = Join-Path $generatedPath 'delete-button'
    Invoke-Template -ShortName 'kamisama-delete-button' -Name 'DeleteButton' -OutputPath $outputPath -Arguments @('--Namespace', 'Validation.Admin')
    $file = Join-Path $outputPath 'Components/DeleteButton.razor'
    Assert-FileContains -Path $file -Pattern '@namespace Validation\.Admin\.Components'
    Assert-FileContains -Path $file -Pattern '<ConfirmDialog'
    Assert-NoTemplateTokens -Path $outputPath
}

function Test-IntegratedSolution {
    $caseName = 'integrated-root-solution'
    $root = Join-Path $generatedPath $caseName
    Invoke-Template -ShortName 'kamisama-solution' -Name 'Validation' -OutputPath $root -Arguments @('--UseProps', 'true')
    Invoke-Template -ShortName 'kamisama-bc' -Name 'Validation' -OutputPath $root -Arguments @('--Context', 'Catalog', '--UseProps', 'true')
    Invoke-Template -ShortName 'kamisama-provider' -Name 'Validation' -OutputPath $root -Arguments @(
        '--Context', 'Catalog',
        '--Provider', 'Postgresql',
        '--CoreProject', '../Validation.Catalog.Core/Validation.Catalog.Core.csproj',
        '--UseProps', 'true'
    )
    Invoke-Template -ShortName 'kamisama-bootstrap' -Name 'Validation.Bootstrap' -OutputPath $root -Arguments @('--UseProps', 'true')
    Invoke-Template -ShortName 'kamisama-server' -Name 'Validation' -OutputPath $root -Arguments @(
        '--Server', 'Admin',
        '--IncludeClient', 'true',
        '--BootstrapProject', '../Validation.Bootstrap/Validation.Bootstrap.csproj',
        '--UseProps', 'true'
    )
    Invoke-Template -ShortName 'kamisama-crud' -Name 'Product' -OutputPath $root -Arguments @(
        '--Solution', 'Validation',
        '--Context', 'Catalog',
        '--ServiceCategory', 'Products',
        '--KeyType', 'Guid'
    )
    Invoke-Template -ShortName 'kamisama-panel-crud' -Name 'Product' -OutputPath $root -Arguments @(
        '--Solution', 'Validation',
        '--Panel', 'Admin',
        '--ServiceCategory', 'Products',
        '--PageCategory', 'Catalog',
        '--KeyType', 'Guid'
    )
    Invoke-Template -ShortName 'kamisama-delete-button' -Name 'DeleteButton' -OutputPath (Join-Path $root 'Validation.Admin.Client') -Arguments @(
        '--Namespace', 'Validation.Admin'
    )

    $solution = Join-Path $root 'Validation.slnx'
    $projects = @(
        'Validation.Catalog.Abstractions/Validation.Catalog.Abstractions.csproj',
        'Validation.Catalog.Core/Validation.Catalog.Core.csproj',
        'Validation.Catalog.Postgresql/Validation.Catalog.Postgresql.csproj',
        'Validation.Bootstrap/Validation.Bootstrap.csproj',
        'Validation.Admin.Abstractions/Validation.Admin.Abstractions.csproj',
        'Validation.Admin.Core/Validation.Admin.Core.csproj',
        'Validation.Admin.Client/Validation.Admin.Client.csproj',
        'Validation.Admin.Server/Validation.Admin.Server.csproj'
    )
    Invoke-DotNet -WorkingDirectory $root -Arguments (@('sln', $solution, 'add') + $projects)
    Assert-FileContains -Path $solution -Pattern 'Validation\.Admin\.Server'
    Assert-FileContains -Path (Join-Path $root 'Validation.Admin.Server/Validation.Admin.Server.csproj') -Pattern '<Import Project="\.\./props\.xml" />'
    Assert-Path -Path (Join-Path $root 'Validation.Catalog.Core/Services/Products/AddProductService.cs')
    Assert-Path -Path (Join-Path $root 'Validation.Admin.Client/Pages/Catalog/Products/List.razor')
    Assert-Path -Path (Join-Path $root 'Validation.Admin.Client/Components/DeleteButton.razor')
    Assert-NoTemplateTokens -Path $root
    Build-Consumer -Path $solution -CaseName $caseName
}

try {
    $null = New-Item -ItemType Directory -Path $feedPath, $hivePath, $nugetPackagesPath, $generatedPath, $repoArtifactsPath, $consumerArtifactsPath -Force

    $escapedFeedPath = [System.Security.SecurityElement]::Escape($feedPath)
    [System.IO.File]::WriteAllText($nugetConfigPath, @"
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="local" value="$escapedFeedPath" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
  </packageSources>
</configuration>
"@)
    $env:NUGET_PACKAGES = $nugetPackagesPath
    $env:DOTNET_CLI_HOME = Join-Path $tempRoot 'dotnet-home'

    Invoke-DotNet -Arguments @(
        'pack', $solutionPath,
        '--configuration', 'Release',
        '--output', $feedPath,
        '--artifacts-path', $repoArtifactsPath,
        '-p:RootNamespace=$(MSBuildProjectName)'
    )

    $templatePackages = @(Get-ChildItem -LiteralPath $feedPath -Filter 'KamiSama.Templates.*.nupkg' -File |
        Where-Object { $_.Name -notlike '*.symbols.nupkg' })
    if ($templatePackages.Count -ne 1) {
        throw "Expected exactly one packed KamiSama.Templates package, found $($templatePackages.Count)."
    }

    Add-Type -AssemblyName System.IO.Compression.FileSystem
    $archive = [System.IO.Compression.ZipFile]::OpenRead($templatePackages[0].FullName)
    try {
        $entryNames = @($archive.Entries | ForEach-Object { $_.FullName.Replace('\', '/') })
        $manifestPaths = @($entryNames | Where-Object { $_ -match '/\.template\.config/template\.json$' })
        if ($manifestPaths.Count -ne 11) {
            throw "Packed template archive must contain exactly 11 manifests; found $($manifestPaths.Count)."
        }

        $packedShortNames = foreach ($manifestPath in $manifestPaths) {
            $entry = $archive.GetEntry($manifestPath)
            $reader = [System.IO.StreamReader]::new($entry.Open())
            try {
                ($reader.ReadToEnd() | ConvertFrom-Json).shortName
            }
            finally {
                $reader.Dispose()
            }
        }
        $actualNames = @($packedShortNames | Sort-Object -Unique)
        $expectedNames = @($requiredTemplateNames | Sort-Object)
        if (($actualNames -join ',') -ne ($expectedNames -join ',')) {
            throw "Packed manifest names mismatch. Expected '$($expectedNames -join ', ')'; found '$($actualNames -join ', ')'."
        }
        if ($entryNames | Where-Object { $_ -like 'content/content/*' }) {
            throw 'Packed template archive contains an invalid content/content path.'
        }
    }
    finally {
        $archive.Dispose()
    }

    Invoke-DotNet -Arguments @(
        'new', 'install', $templatePackages[0].FullName,
        '--force',
        '--debug:custom-hive', $hivePath
    )
    $templateInstalled = $true

    $templateList = Invoke-DotNet -Arguments @(
        'new', 'list', 'kamisama',
        '--debug:custom-hive', $hivePath
    ) -CaptureOutput
    $listedTemplateNames = @([regex]::Matches($templateList, '(?m)(?<![\w-])kamisama-[a-z-]+(?![\w-])') |
        ForEach-Object { $_.Value } |
        Sort-Object -Unique)
    $expectedTemplateNames = @($requiredTemplateNames | Sort-Object)
    if (($listedTemplateNames -join ',') -ne ($expectedTemplateNames -join ',')) {
        throw "Packed template list mismatch. Expected '$($expectedTemplateNames -join ', ')'; found '$($listedTemplateNames -join ', ')'."
    }
    foreach ($shortName in $retiredTemplateNames) {
        if ($templateList -match "(?<![\w-])$([regex]::Escape($shortName))(?![\w-])") {
            throw "Packed template list still exposes retired short name '$shortName'."
        }
    }

    Test-SolutionSkillCases
    Test-TypeCases
    Test-FeatureCases
    Test-CrudCase
    Test-PanelCrudCase
    Test-AspireLocalCase
    Test-DeleteButtonCase

    if (-not $Fast) {
        Test-BoundedContextCase -UseProps $false -Build $true
        Test-BoundedContextCase -UseProps $true -Build $true
        foreach ($provider in @('Postgresql', 'Sqlite', 'SqlServer', 'Oracle')) {
            Test-ProviderCase -Provider $provider
        }
        Test-BootstrapCase
        foreach ($includeClient in @($false, $true)) {
            foreach ($includeBootstrap in @($false, $true)) {
                Test-ServerCase -IncludeClient $includeClient -IncludeBootstrap $includeBootstrap
            }
        }
    }

    Test-IntegratedSolution
    Write-Host "Packed template consumption validation passed ($($Fast ? 'fast' : 'full') matrix)."
}
finally {
    if ($templateInstalled) {
        try {
            Invoke-DotNet -Arguments @(
                'new', 'uninstall', 'KamiSama.Templates',
                '--debug:custom-hive', $hivePath
            )
        }
        catch {
            Write-Warning "Template uninstall failed: $_"
        }
    }

    $env:NUGET_PACKAGES = $previousNugetPackages
    $env:DOTNET_CLI_HOME = $previousDotnetCliHome
    if (Test-Path -LiteralPath $tempRoot) {
        Remove-Item -LiteralPath $tempRoot -Recurse -Force
    }
}
