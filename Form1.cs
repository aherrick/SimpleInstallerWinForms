using System.Diagnostics;
using System.Reflection;

namespace SimpleInstallerWinForms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        string version =
            Assembly
                .GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion ?? "Unknown";

        Text = $"My App - Version {version}";
    }
}