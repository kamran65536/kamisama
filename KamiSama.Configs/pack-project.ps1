param($projectName, $version, $showExplorer = $true)

if ($projectName.StartsWith('.\'))
{
	$projectName = $projectName.SubString(2);
}

$project = Get-Project -Name $projectName
$configurationName = $project.ConfigurationManager.ActiveConfiguration.ConfigurationName

dotnet build $projectName -c $configurationName

nuget.exe pack .\$projectName -OutputDirectory .\$projectName\bin\publish -Prop Configuration=$configurationName -Version $version

if ($showExplorer)
{
	explorer .\$projectName\bin\publish
}