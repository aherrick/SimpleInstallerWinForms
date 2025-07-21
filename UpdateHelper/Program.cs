using System.Diagnostics;

if (args.Length < 2)
{
    Console.WriteLine("Error: Missing arguments. Expected: <pid> <installerPath>");
    return;
}

if (!int.TryParse(args[0], out int pid))
{
    Console.WriteLine("Error: Invalid PID format.");
    return;
}

var installerPath = args[1];

try
{
    // Wait for the main application to exit
    try
    {
        var proc = Process.GetProcessById(pid);
        proc.WaitForExit(1000); // Wait up to 1 second
    }
    catch (ArgumentException)
    {
        // Process already exited
    }

    if (!File.Exists(installerPath))
    {
        Console.WriteLine($"Error: Installer not found at {installerPath}");
        return;
    }

    ProcessStartInfo psi = new()
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