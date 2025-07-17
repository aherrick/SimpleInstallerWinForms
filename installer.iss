[Setup]
AppName=SimpleInstallerWinForms
AppVersion=1.0.0
DefaultDirName={autopf}\SimpleInstallerWinForms

[Files]
Source: "publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{autoprograms}\SimpleInstallerWinForms"; Filename: "{app}\SimpleInstallerWinForms.exe"
