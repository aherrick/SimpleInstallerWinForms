[Setup]
AppName=SimpleInstallerWinForms
AppVersion=1.0.0.0
VersionInfoVersion={#SetupSetting("AppVersion")}
DefaultDirName={userappdata}\Local\Programs\{#SetupSetting("AppName")}
OutputBaseFilename={#SetupSetting("AppName")}-{#SetupSetting("AppVersion")}
OutputDir=Output
PrivilegesRequired=lowest

[Files]
Source: "publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{autoprograms}\{#SetupSetting("AppName")}"; Filename: "{app}\{#SetupSetting("AppName")}.exe"
Name: "{autodesktop}\{#SetupSetting("AppName")}"; Filename: "{app}\{#SetupSetting("AppName")}.exe"

[Run]
Filename: "{app}\{#SetupSetting("AppName")}.exe"; Flags: nowait
