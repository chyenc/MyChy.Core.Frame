del nupkgs\*.nupkg
dotnet pack src\MyChy.Core.Frame.Common\MyChy.Core.Frame.Common.csproj -c Release -o nupkgs\
dotnet pack src\MyChy.Core.Frame.Common.Redis\MyChy.Core.Frame.Common.Redis.csproj  -c Release -o nupkgs\
dotnet pack src\MyChy.Core.Frame.Common.EfData\MyChy.Core.Frame.Common.EfData.csproj  -c Release -o nupkgs\

nuget push nupkgs\*.nupkg -s http://nuget.chyenc.com 8bfc20c1-83a6-4d0f-a48e-209a8dda7ad2

