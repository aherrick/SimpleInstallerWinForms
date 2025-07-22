using System.Diagnostics;

var pid = int.Parse(args[0]);
var installerPath = args[1];

// Wait for the main application to exit
try
{
    var proc = Process.GetProcessById(pid);
    proc.WaitForExit(); // Wait up to 1 second
}
catch (ArgumentException)
{
    // Process already exited
}

ProcessStartInfo psi = new()
{
    FileName = installerPath,
    UseShellExecute = true,
    CreateNoWindow = true, // Run silently
};

Process.Start(psi);