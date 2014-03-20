@echo off

if not exist ".\Thirdparty\Advanced Combat Tracker.exe" (
	echo [エラー]
	echo  ビルドを実行するためには、"Thirdparty"ディレクトリに"Advanced Combat Tracker.exe"をコピーする必要があります。
	goto END
)

set DOTNET_PATH=%windir%\Microsoft.NET\Framework\v4.0.30319
if not exist %DOTNET_PATH% (
	echo [エラー]
	echo  .NET Frameworkのディレクトリ（%DOTNET_PATH%）が見つかりません。
	echo  ビルドを実行するためには.NET Framework 4.5.1がインストールされている必要があります。
	goto END
)


%DOTNET_PATH%\msbuild /t:Rebuild /p:Configuration=Release /p:OutputPath=..\Build RainbowMage.ActLocalizer.sln


:END
pause
