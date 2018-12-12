$PackageVersion = "1.2.3.1"
$configurationName = "Debug"
dotnet build -c Debug
dotnet pack -c Debug /p:Version=$PackageVersion
.\pack-project.ps1 -projectName KamiSama.Configs.EntityFramework -version $PackageVersion -showExplorer $false

mkdir .\publish\ -Force
remove-item .\publish\*.*

Move-Item .\KamiSama.Configs\bin\Debug\*.$PackageVersion.nupkg  .\publish\ -Force
Move-Item .\KamiSama.Configs.Json\bin\Debug\*.$PackageVersion.nupkg .\publish\ -Force
Move-Item .\KamiSama.Configs.Xml\bin\Debug\*.$PackageVersion.nupkg .\publish\ -Force
Move-Item .\KamiSama.Configs.EntityFramework\bin\publish\*.$PackageVersion.nupkg .\publish\ -Force

explorer .\publish\