using System.Diagnostics;

int pid = int.Parse(args[0]);
string installerPath = args[1];

try
{
    var proc = Process.GetProcessById(pid);
    proc.WaitForExit();
}
catch
{
    // Already exited
}

// Wait longer to guarantee all file locks are gone
Thread.Sleep(1000); // 1 second

try
{
    Process.Start(
        new ProcessStartInfo
        {
            FileName = installerPath,
            UseShellExecute = true,
            Verb = "runas",
        }
    );
}
catch (Exception ex)
{
    // Optionally, log or display error
    Console.WriteLine("Failed to start installer: " + ex.Message);
}