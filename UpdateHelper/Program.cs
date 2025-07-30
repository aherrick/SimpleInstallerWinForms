using System.Diagnostics;

var pid = int.Parse(args[0]);
var installerPath = args[1];

// Wait for the main application to exit
try
{
    var proc = Process.GetProcessById(pid);
    if (!proc.HasExited)
    {
        proc.WaitForExit(1000);
    }
}
catch (ArgumentException)
{
    // Process already exited
}

try
{
    var psi = new ProcessStartInfo
    {
        FileName = installerPath,
        Arguments = "/SILENT /SUPPRESSMSGBOXES /NORESTART",
        UseShellExecute = true,
        CreateNoWindow = true,
    };
    Process.Start(psi);
}
catch
{ /* silent fail */
}