using NeonWindows.UI.Modern.Xaml.Desktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Windows.UI.Xaml;

namespace NWBXamlHostTest;

internal partial class XamlHostForm : Form
{
    private readonly WindowsXamlHost windowsXamlHost = new();

    public XamlHostForm()
    {
        Controls.Add(windowsXamlHost);
        windowsXamlHost.AutoSize = true;
        windowsXamlHost.Dock = DockStyle.Fill;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public UIElement Content
    {
        get => windowsXamlHost.Content;
        set => windowsXamlHost.Content = value;
    }
}
