using System.Diagnostics;

int processId = int.Parse(args[0]);
string installerPath = args[1];

// Wait for the main app to fully exit
try
{
    var proc = Process.GetProcessById(processId);
    proc.WaitForExit();
}
catch
{ /* Already exited */
}

Thread.Sleep(300); // Extra safety

Process.Start(new ProcessStartInfo { FileName = installerPath, UseShellExecute = true });