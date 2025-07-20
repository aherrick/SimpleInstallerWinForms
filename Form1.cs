using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace SimpleInstallerWinForms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        string version =
            FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion
            ?? "Unknown";

        Text = $"My App - Version {version}";
    }

    private string? downloadedInstallerPath = null;

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        base.OnFormClosed(e);
        if (!string.IsNullOrEmpty(downloadedInstallerPath) && File.Exists(downloadedInstallerPath))
        {
            try
            {
                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = downloadedInstallerPath,
                        UseShellExecute = true,
                    }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to run installer: {ex.Message}");
            }
        }
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        string currentVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "0.0.0.0";

        var client = new HttpClient();
        client.DefaultRequestHeaders.UserAgent.ParseAdd("SimpleInstallerWinForms");

        var json = await client.GetStringAsync(
            "https://api.github.com/repos/aherrick/SimpleInstallerWinForms/releases/latest"
        );
        var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;
        string tag = root.GetProperty("tag_name").GetString();
        string latestVersion = tag.StartsWith('v') ? tag[1..] : tag;

        if (new Version(latestVersion) > new Version(currentVersion))
        {
            var assetUrl = root.GetProperty("assets")[0]
                .GetProperty("browser_download_url")
                .GetString();

            if (
                MessageBox.Show(
                    $"Update available: {latestVersion}. Download and install?",
                    "Update",
                    MessageBoxButtons.YesNo
                ) == DialogResult.Yes
            )
            {
                string tempPath = Path.Combine(Path.GetTempPath(), Path.GetFileName(assetUrl));
                var resp = await client.GetAsync(assetUrl);
                resp.EnsureSuccessStatusCode();
                var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write);
                await resp.Content.CopyToAsync(fs);
                downloadedInstallerPath = tempPath;
                MessageBox.Show(
                    "Update downloaded. It will be installed when you close the app.",
                    "Update Ready"
                );
            }
        }
        else
        {
            MessageBox.Show("You already have the latest version.");
        }
    }
}