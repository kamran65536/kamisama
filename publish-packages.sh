#!/bin/bash

if [ -z $1 ]
then
	echo "Package version is not set."
	exit
fi

package_version=$1

dotnet pack src/ --no-build -o nupkgs -p:PackageVersion=$package_version
# dotnet nuget push nupkgs/*.nupkg -k $nuget_apikey -s https://api.nuget.org/v3/index.json
rm -rf nupkgs