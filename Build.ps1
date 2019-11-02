.\Lib\GitVersion.exe /output buildserver

Write-Host "Building:"
Write-Host $Env:APPVEYOR_BUILD_VERSION
Write-Host $Env:GitVersion_NuGetVersion

dotnet build .\src\Plugin.Plumber.Component.Decorator\Plugin.Plumber.Component.Decorator.csproj
dotnet pack .\src\Plugin.Plumber.Component.Decorator\Plugin.Plumber.Component.Decorator.csproj -c Release -o ..\..\artifacts /p:Version=$Env:GitVersion_NuGetVersion -p:NuspecFile=.\src\Plugin.Plumber.Component.Decorator\Plugin.Plumber.Component.Decorator.nuspec