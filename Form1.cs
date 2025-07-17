using System.Reflection;

namespace SimpleInstallerWinForms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        var version =
            Assembly
                .GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion ?? "Unknown";

        Text = $"SimpleInstallerWinForms - Version {version}";
    }
}