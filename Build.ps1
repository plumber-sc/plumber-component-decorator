.\Lib\GitVersion.exe /output buildserver

Write-Host "Building:"
Write-Host $Env:APPVEYOR_BUILD_VERSION

dotnet build .\src\Plugin.Plumber.Component.Decorator\Plugin.Plumber.Component.Decorator.csproj
dotnet pack .\src\Plugin.Plumber.Component.Decorator\Plugin.Plumber.Component.Decorator.csproj -c Release -o ..\..\artifacts /p:Version=$Env:APPVEYOR_BUILD_VERSION