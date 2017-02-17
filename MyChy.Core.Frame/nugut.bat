del *.nupkg
nuget pack src\MyChy.Core.Frame.Common\MyChy.Core.Frame.Common.xproj  -Prop Configuration=Release
nuget pack src\MyChy.Core.Frame.Common.Redis\MyChy.Core.Frame.Common.Redis.xproj  -Prop Configuration=Release
nuget pack src\MyChy.Core.Frame.Common.EfData\MyChy.Core.Frame.Common.EfData.xproj  -Prop Configuration=Release

nuget push *.nupkg -s http://nuget.chyenc.com 8bfc20c1-83a6-4d0f-a48e-209a8dda7ad2
