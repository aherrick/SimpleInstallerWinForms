using System.Diagnostics;

int pid = int.Parse(args[0]);
string installerPath = args[1];

// Wait for the main process to fully exit
try
{
    Process.GetProcessById(pid).WaitForExit();
}
catch { }

Thread.Sleep(200); // Extra safety

Process.Start(new ProcessStartInfo { FileName = installerPath, UseShellExecute = true });