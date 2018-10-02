$PackageVersion = "1.2.1.1"

dotnet build -c Debug
dotnet pack -c Debug /p:Version=$PackageVersion

mkdir .\Test\bin\publish\ -Force
remove-item .\Test\bin\publish\*.*

Move-Item .\KamiSama.SecureModule\bin\Debug\*.$PackageVersion.nupkg  .\Test\bin\publish -Force
Move-Item .\KamiSama.SecureModule.Api\bin\Debug\*.$PackageVersion.nupkg .\Test\bin\publish -Force
Move-Item .\KamiSama.SecureModule.KeySerializers\bin\Debug\*.$PackageVersion.nupkg .\Test\bin\publish -Force
Move-Item .\KamiSama.SecureModule.KeySerializers.Bson\bin\Debug\*.$PackageVersion.nupkg  .\Test\bin\publish -Force
Move-Item .\KamiSama.SecureModule.KeyStores\bin\Debug\*.$PackageVersion.nupkg  .\Test\bin\publish -Force
Move-Item .\KamiSama.SecureModule.LocalSsm\bin\Debug\*.$PackageVersion.nupkg .\Test\bin\publish -Force

explorer .\Test\bin\publish\