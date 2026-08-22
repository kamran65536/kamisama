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
    'kamisama-admin',
    'kamisama-empty',
    'kamisama-bounded-context',
    'kamisama-database-support',
    'kamisama-bootstrap',
    'kamisama-orchestration'
)
$retiredTemplateNames = @(
    'kamisama-props',
    'kamisama-core',
    'kamisama-abstractions',
    'kamisama-database',
    'kamisama-blazor-admin'
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
        $exitCode = $LASTEXITCODE
        if ($exitCode -ne 0) {
            throw "dotnet exited with code $exitCode."
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

function New-ConsumerProps {
    param(
        [Parameter(Mandatory)]
        [string] $Directory
    )

    $null = New-Item -ItemType Directory -Path $Directory -Force
    $props = @'
<Project>
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>
'@
    [System.IO.File]::WriteAllText((Join-Path $Directory 'props.xml'), $props)
}

function Build-Consumer {
    param(
        [Parameter(Mandatory)]
        [string] $Path,

        [Parameter(Mandatory)]
        [string] $CaseName
    )

    if (-not (Test-Path -LiteralPath $Path)) {
        throw "Case '$CaseName' did not generate expected build target '$Path'."
    }

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

function Test-SolutionCase {
    param(
        [bool] $UseProps,
        [bool] $CreateSolutionDirectory = $false
    )

    $caseName = "solution-use-props-$($UseProps.ToString().ToLowerInvariant())-directory-$($CreateSolutionDirectory.ToString().ToLowerInvariant())"
    $name = if ($UseProps) { 'Validation.SolutionWithProps' } else { 'Validation.SolutionWithoutProps' }
    $outputPath = Join-Path $generatedPath $caseName
    $solutionPath = if ($CreateSolutionDirectory) { Join-Path $outputPath $name } else { $outputPath }
    Invoke-Template -ShortName 'kamisama-solution' -Name $name -OutputPath $outputPath -Arguments @(
        '--CreateSolutionDirectory', $CreateSolutionDirectory.ToString().ToLowerInvariant(),
        '--UseProps', $UseProps.ToString().ToLowerInvariant()
    )
    Build-Consumer -Path (Join-Path $solutionPath "$name.slnx") -CaseName $caseName
}

function Test-EmptyCase {
    param([bool] $UseProps)

    $caseName = "empty-use-props-$($UseProps.ToString().ToLowerInvariant())"
    $casePath = Join-Path $generatedPath $caseName
    $name = if ($UseProps) { 'Validation.EmptyWithProps' } else { 'Validation.EmptyWithoutProps' }
    $outputPath = Join-Path $casePath $name
    if ($UseProps) {
        New-ConsumerProps -Directory $casePath
    }

    Invoke-Template -ShortName 'kamisama-empty' -Name $name -OutputPath $outputPath -Arguments @('--UseProps', $UseProps.ToString().ToLowerInvariant())
    Build-Consumer -Path (Join-Path $outputPath "$name.csproj") -CaseName $caseName
}

function Test-BoundedContextCase {
    param(
        [bool] $UseProps,
        [bool] $IncludeExample,
        [bool] $CreateSolutionDirectory = $false
    )

    $caseName = "bounded-context-props-$($UseProps.ToString().ToLowerInvariant())-example-$($IncludeExample.ToString().ToLowerInvariant())-directory-$($CreateSolutionDirectory.ToString().ToLowerInvariant())"
    $casePath = Join-Path $generatedPath $caseName
    $name = "Validation.Bounded$([int]$UseProps)$([int]$IncludeExample)"
    $outputPath = Join-Path $casePath $name
    $solutionPath = if ($CreateSolutionDirectory) { Join-Path $outputPath $name } else { $outputPath }
    if ($UseProps) {
        New-ConsumerProps -Directory $solutionPath
    }

    Invoke-Template -ShortName 'kamisama-bounded-context' -Name $name -OutputPath $outputPath -Arguments @(
        '--CreateSolutionDirectory', $CreateSolutionDirectory.ToString().ToLowerInvariant(),
        '--UseProps', $UseProps.ToString().ToLowerInvariant(),
        '--IncludeExample', $IncludeExample.ToString().ToLowerInvariant()
    )
    Build-Consumer -Path (Join-Path $solutionPath "$name.slnx") -CaseName $caseName
}

function Test-DatabaseSupportCase {
    param(
        [Parameter(Mandatory)]
        [ValidateSet('Postgresql', 'Sqlite', 'SqlServer', 'Oracle')]
        [string] $Provider
    )

    $caseName = "database-support-$($Provider.ToLowerInvariant())"
    $casePath = Join-Path $generatedPath $caseName
    $name = "Validation.Database$Provider"
    $contextPath = Join-Path $casePath $name
    $providerProjectDirectory = Join-Path $contextPath "$name.$Provider"
    $providerProject = Join-Path $providerProjectDirectory "$name.$Provider.csproj"

    Invoke-Template -ShortName 'kamisama-bounded-context' -Name $name -OutputPath $contextPath -Arguments @(
        '--UseProps', 'false',
        '--IncludeExample', 'true'
    )
    Build-Consumer -Path (Join-Path $contextPath "$name.slnx") -CaseName "$caseName-context"

    Invoke-Template -ShortName 'kamisama-database-support' -Name $name -OutputPath $contextPath -Arguments @(
        '--UseProps', 'false',
        '--Provider', $Provider,
        '--CoreProject', "../$name.Core/$name.Core.csproj"
    )
    Build-Consumer -Path $providerProject -CaseName $caseName
}

function Test-BootstrapCase {
    param(
        [Parameter(Mandatory)]
        [string] $CaseName,

        [bool] $UserManagement,

        [bool] $Ticketing,

        [ValidateSet('Postgresql', 'Sqlite')]
        [string] $UserManagementProvider = 'Postgresql',

        [ValidateSet('Postgresql', 'Sqlite')]
        [string] $TicketingProvider = 'Postgresql'
    )

    $name = "Validation.$($CaseName.Replace('-', '.'))"
    $outputPath = Join-Path $generatedPath $CaseName
    Invoke-Template -ShortName 'kamisama-bootstrap' -Name $name -OutputPath $outputPath -Arguments @(
        '--UserManagement', $UserManagement.ToString().ToLowerInvariant(),
        '--Ticketing', $Ticketing.ToString().ToLowerInvariant(),
        '--UserManagementProvider', $UserManagementProvider,
        '--TicketingProvider', $TicketingProvider
    )
    Build-Consumer -Path (Join-Path $outputPath "$name.csproj") -CaseName $CaseName
}

function Test-OrchestrationCase {
    param(
        [bool] $UseProps,
        [bool] $CreateSolutionDirectory = $false
    )

    $caseName = "orchestration-minimal-props-$($UseProps.ToString().ToLowerInvariant())-directory-$($CreateSolutionDirectory.ToString().ToLowerInvariant())"
    $casePath = Join-Path $generatedPath $caseName
    $name = if ($UseProps) { 'Validation.OrchestrationWithProps' } else { 'Validation.OrchestrationWithoutProps' }
    $outputPath = Join-Path $casePath $name
    $solutionPath = if ($CreateSolutionDirectory) { Join-Path $outputPath $name } else { $outputPath }
    if ($UseProps) {
        New-ConsumerProps -Directory $solutionPath
    }

    Invoke-Template -ShortName 'kamisama-orchestration' -Name $name -OutputPath $outputPath -Arguments @(
        '--CreateSolutionDirectory', $CreateSolutionDirectory.ToString().ToLowerInvariant(),
        '--UseProps', $UseProps.ToString().ToLowerInvariant(),
        '--IncludeClient', 'false',
        '--IncludeServer', 'false',
        '--UserManagement', 'false',
        '--Ticketing', 'false'
    )
    Build-Consumer -Path (Join-Path $solutionPath "$name.slnx") -CaseName $caseName
}

function Test-AdminCase {
    param(
        [Parameter(Mandatory)]
        [string] $CaseName,

        [bool] $UserManagement,

        [bool] $Ticketing,

        [ValidateSet('Create', 'Existing')]
        [string] $BootstrapMode,

        [ValidateSet('Postgresql', 'Sqlite')]
        [string] $UserManagementProvider = 'Postgresql',

        [ValidateSet('Postgresql', 'Sqlite')]
        [string] $TicketingProvider = 'Postgresql',

        [bool] $CreateSolutionDirectory = $false
    )

    $casePath = Join-Path $generatedPath $CaseName
    $name = "Validation.$($CaseName.Replace('-', '.'))"
    $outputPath = Join-Path $casePath $name
    $solutionPath = if ($CreateSolutionDirectory) { Join-Path $outputPath $name } else { $outputPath }
    $arguments = @(
        '--CreateSolutionDirectory', $CreateSolutionDirectory.ToString().ToLowerInvariant(),
        '--UserManagement', $UserManagement.ToString().ToLowerInvariant(),
        '--Ticketing', $Ticketing.ToString().ToLowerInvariant(),
        '--UserManagementProvider', $UserManagementProvider,
        '--TicketingProvider', $TicketingProvider,
        '--BootstrapMode', $BootstrapMode
    )

    if ($BootstrapMode -eq 'Existing') {
        $bootstrapName = "$name.Bootstrap"
        $bootstrapPath = Join-Path $casePath $bootstrapName
        Invoke-Template -ShortName 'kamisama-bootstrap' -Name $bootstrapName -OutputPath $bootstrapPath -Arguments @(
            '--UserManagement', $UserManagement.ToString().ToLowerInvariant(),
            '--Ticketing', $Ticketing.ToString().ToLowerInvariant(),
            '--UserManagementProvider', $UserManagementProvider,
            '--TicketingProvider', $TicketingProvider
        )
        Build-Consumer -Path (Join-Path $bootstrapPath "$bootstrapName.csproj") -CaseName "$CaseName-existing-bootstrap"
        $arguments += @('--BootstrapProject', "../$bootstrapName/$bootstrapName.csproj")
    }

    Invoke-Template -ShortName 'kamisama-admin' -Name $name -OutputPath $outputPath -Arguments $arguments
    Build-Consumer -Path (Join-Path $solutionPath "$name.slnx") -CaseName $CaseName
}

try {
    $null = New-Item -ItemType Directory -Path $feedPath, $hivePath, $nugetPackagesPath, $generatedPath, $repoArtifactsPath, $consumerArtifactsPath -Force

    $escapedFeedPath = [System.Security.SecurityElement]::Escape($feedPath)
    $nugetConfig = @"
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="local" value="$escapedFeedPath" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
  </packageSources>
</configuration>
"@
    [System.IO.File]::WriteAllText($nugetConfigPath, $nugetConfig)
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
        $manifests = @($entryNames | Where-Object { $_ -match '/\.template\.config/template\.json$' })
        if ($manifests.Count -ne 7) {
            throw "Packed template archive must contain exactly 7 manifests; found $($manifests.Count)."
        }
        $solutionDirectoryOptionCount = 0
        foreach ($manifestPath in $manifests) {
            $manifestEntry = $archive.GetEntry($manifestPath)
            $reader = [System.IO.StreamReader]::new($manifestEntry.Open())
            try {
                $manifest = $reader.ReadToEnd() | ConvertFrom-Json
                $directoryOption = $manifest.symbols.PSObject.Properties['CreateSolutionDirectory']
                if ($manifest.tags.type -eq 'solution') {
                    $solutionDirectoryOptionCount++
                    if ($manifest.preferNameDirectory -ne $false -or $null -eq $directoryOption -or $directoryOption.Value.defaultValue -ne 'false') {
                        throw "Solution template manifest '$manifestPath' must expose CreateSolutionDirectory with a false default and disable preferNameDirectory."
                    }
                }
                elseif ($null -ne $directoryOption) {
                    throw "Single-project template manifest '$manifestPath' must not expose CreateSolutionDirectory."
                }
            }
            finally {
                $reader.Dispose()
            }
        }
        if ($solutionDirectoryOptionCount -ne 4) {
            throw "Expected CreateSolutionDirectory on exactly 4 solution templates; found $solutionDirectoryOptionCount."
        }
        if ($entryNames | Where-Object { $_ -like 'content/content/*' }) {
            throw 'Packed template archive contains an invalid content/content path.'
        }
        if (-not ($entryNames | Where-Object { $_ -match '(^|/)\.agents/' })) {
            throw 'Packed template archive does not include .agents content.'
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

    if ($Fast) {
        Test-SolutionCase -UseProps $true -CreateSolutionDirectory $true
        Test-EmptyCase -UseProps $true
        Test-BoundedContextCase -UseProps $false -IncludeExample $true -CreateSolutionDirectory $true
        Test-DatabaseSupportCase -Provider 'Postgresql'
        Test-BootstrapCase -CaseName 'bootstrap-combined-cross' -UserManagement $true -Ticketing $true -UserManagementProvider 'Sqlite' -TicketingProvider 'Postgresql'
        Test-OrchestrationCase -UseProps $false -CreateSolutionDirectory $true
        Test-AdminCase -CaseName 'admin-both-create' -UserManagement $true -Ticketing $true -BootstrapMode 'Create' -CreateSolutionDirectory $true
        Test-AdminCase -CaseName 'admin-both-existing' -UserManagement $true -Ticketing $true -BootstrapMode 'Existing' -UserManagementProvider 'Sqlite' -TicketingProvider 'Postgresql'
    }
    else {
        Test-SolutionCase -UseProps $false
        Test-SolutionCase -UseProps $true
        Test-EmptyCase -UseProps $false
        Test-EmptyCase -UseProps $true

        Test-BoundedContextCase -UseProps $false -IncludeExample $false
        Test-BoundedContextCase -UseProps $false -IncludeExample $true
        Test-BoundedContextCase -UseProps $true -IncludeExample $false
        Test-BoundedContextCase -UseProps $true -IncludeExample $true

        Test-DatabaseSupportCase -Provider 'Postgresql'
        Test-DatabaseSupportCase -Provider 'Sqlite'
        Test-DatabaseSupportCase -Provider 'SqlServer'
        Test-DatabaseSupportCase -Provider 'Oracle'

        Test-BootstrapCase -CaseName 'bootstrap-empty' -UserManagement $false -Ticketing $false
        Test-BootstrapCase -CaseName 'bootstrap-ticketing-postgresql' -UserManagement $false -Ticketing $true -TicketingProvider 'Postgresql'
        Test-BootstrapCase -CaseName 'bootstrap-ticketing-sqlite' -UserManagement $false -Ticketing $true -TicketingProvider 'Sqlite'
        Test-BootstrapCase -CaseName 'bootstrap-users-postgresql' -UserManagement $true -Ticketing $false -UserManagementProvider 'Postgresql'
        Test-BootstrapCase -CaseName 'bootstrap-users-sqlite' -UserManagement $true -Ticketing $false -UserManagementProvider 'Sqlite'
        Test-BootstrapCase -CaseName 'bootstrap-combined-cross' -UserManagement $true -Ticketing $true -UserManagementProvider 'Sqlite' -TicketingProvider 'Postgresql'

        Test-OrchestrationCase -UseProps $false
        Test-OrchestrationCase -UseProps $true

        Test-AdminCase -CaseName 'admin-users-only' -UserManagement $true -Ticketing $false -BootstrapMode 'Create'
        Test-AdminCase -CaseName 'admin-ticketing-only' -UserManagement $false -Ticketing $true -BootstrapMode 'Create'
        Test-AdminCase -CaseName 'admin-both' -UserManagement $true -Ticketing $true -BootstrapMode 'Create'
        Test-AdminCase -CaseName 'admin-create-bootstrap' -UserManagement $true -Ticketing $true -BootstrapMode 'Create' -UserManagementProvider 'Sqlite' -TicketingProvider 'Postgresql'
        Test-AdminCase -CaseName 'admin-existing-bootstrap' -UserManagement $true -Ticketing $true -BootstrapMode 'Existing' -UserManagementProvider 'Sqlite' -TicketingProvider 'Postgresql'
        Test-AdminCase -CaseName 'admin-minimal' -UserManagement $false -Ticketing $false -BootstrapMode 'Create'
    }

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
