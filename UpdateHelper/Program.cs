using System.Diagnostics;

if (!int.TryParse(args[0], out int pid))
{
    Console.WriteLine("Error: Invalid PID format.");
    return;
}

string installerPath = args[1];

try
{
    // Wait for the main application to exit
    try
    {
        var proc = Process.GetProcessById(pid);
        proc.WaitForExit(5000); // Wait up to 5 seconds
    }
    catch (ArgumentException)
    {
        // Process already exited
    }

    // Additional delay to ensure file locks are released
    Thread.Sleep(2000); // 2 seconds for safety

    if (!File.Exists(installerPath))
    {
        Console.WriteLine($"Error: Installer not found at {installerPath}");
        return;
    }

    ProcessStartInfo psi = new ProcessStartInfo
    {
        FileName = installerPath,
        UseShellExecute = true,
        Verb = "runas", // Request elevation
        CreateNoWindow = true, // Run silently
    };

    Process.Start(psi);
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to start installer: {ex.Message}");
}