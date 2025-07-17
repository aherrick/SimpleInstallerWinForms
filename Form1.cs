using System.Reflection;

namespace SimpleInstallerWinForms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        var version =
            System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString()
            ?? "Unknown";

        Text = $"My App - Version {version}";
    }
}