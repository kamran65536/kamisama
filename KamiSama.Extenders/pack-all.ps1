param($versionTemplate="?.?.+", $o="d:\publish\kamisama", $c="Debug")

function ApplyTemplate($base, $template)
{
	if ($base -lt 0)
	{
		return $base = 0
	}

	if ($template -eq "+")
	{
		return  ($base + 1)
	}
	elseif ($template  -eq "-")
	{
		if ($base -lt 1)
		{
			return 0
		}
		else
		{
			return ($base - 1)
		}
	}
	elseif ($template -eq "?")
	{
		return $base
	}
	else
	{
		return $template
	}
}

[Version] $currentVersion=Get-Content .\Package-Version.txt

$arr = $versionTemplate.Split('.')

$majorTemplate = $arr[0]
$minorTemplate = if ($arr.Length -gt 1) {$arr[1]} else {$currentVersion.Minor}
$buildTemplate = if ($arr.Length -gt 2) {$arr[2]} else {$currentVersion.Build}
$revisionTemplate = if ($arr.Length -gt 3) {$arr[3]} else {$currentVersion.Revision}

$major = ApplyTemplate -base $currentVersion.Major -template $majorTemplate
$minor = ApplyTemplate -base $currentVersion.Minor -template $minorTemplate
$build = ApplyTemplate -base $currentVersion.Build -template $buildTemplate
$revision = ApplyTemplate -base $currentVersion.Revision -template $revisionTemplate

$currentVersion = New-Object -TypeName System.Version -ArgumentList ($major, $minor, $build, $revision)

Set-Content .\Package-Version.txt $currentVersion

Remove-Item ($o + "\*.nupkg")

dotnet pack .\KamiSama.Agents -c $c -p:Version=$currentVersion -o $o
dotnet pack .\KamiSama.Extenders -c $c -p:Version=$currentVersion -o $o
dotnet pack .\KamiSama.Extenders.Attributes -c $c -p:Version=$currentVersion -o $o
dotnet pack .\KamiSama.Extenders.DependencyInjection -c $c -p:Version=$currentVersion -o $o
dotnet pack .\KamiSama.Extenders.EntityFramework -c $c -p:Version=$currentVersion -o $o
dotnet pack .\KamiSama.Extenders.MsTest -c $c -p:Version=$currentVersion -o $o
dotnet pack .\KamiSama.Extenders.Ninject -c $c -p:Version=$currentVersion -o $o
dotnet pack .\KamiSama.Extenders.Serialization -c $c -p:Version=$currentVersion -o $o