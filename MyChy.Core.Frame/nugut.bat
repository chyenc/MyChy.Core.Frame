del nupkgs\*.nupkg
dotnet pack src\MyChy.Core.Frame.Common\project.json -c Release -o nupkgs\
dotnet pack src\MyChy.Core.Frame.Common.Redis\project.json  -c Release -o nupkgs\
dotnet pack src\MyChy.Core.Frame.Common.EfData\project.json  -c Release -o nupkgs\

nuget push nupkgs\*.nupkg -s http://nuget.chyenc.com 8bfc20c1-83a6-4d0f-a48e-209a8dda7ad2

