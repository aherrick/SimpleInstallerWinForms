[Setup]
AppName=SimpleInstallerWinForms
AppVersion=1.0.0.0
VersionInfoVersion={#SetupSetting("AppVersion")}
DefaultDirName={autopf}\{#SetupSetting("AppName")}
OutputBaseFilename={#SetupSetting("AppName")}-{#SetupSetting("AppVersion")}
OutputDir=Output

[Files]
Source: "publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{autoprograms}\{#SetupSetting("AppName")}"; Filename: "{app}\{#SetupSetting("AppName")}.exe"
Name: "{autodesktop}\{#SetupSetting("AppName")}"; Filename: "{app}\{#SetupSetting("AppName")}.exe"
