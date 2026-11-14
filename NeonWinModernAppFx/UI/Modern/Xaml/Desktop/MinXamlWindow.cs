using NeonWindows.UI.Modern.Desktop.Core;
using System.Windows.Forms;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

public class MinXamlWindow : CoreUIHostWindow
{
    protected readonly WindowsXamlHost windowsXamlHost;

    protected readonly CoreWindow coreWindow;

    public UIElement Content
    {
        get => windowsXamlHost.Content;
        set => windowsXamlHost.Content = value;
    }

    public override CoreDispatcher Dispatcher => coreWindow.Dispatcher;

    public override DispatcherQueue DispatcherQueue => coreWindow.DispatcherQueue;

    public MinXamlWindow(UIElement content) : this()
        => Content = content;

    public MinXamlWindow()
    {
        windowsXamlHost = new();
        coreWindow = CoreWindow.GetForCurrentThread();
        SetXamlHostControl();
    }

    protected void SetXamlHostControl()
    {
        if (!Controls.Contains(windowsXamlHost)) Controls.Add(windowsXamlHost);
        windowsXamlHost.AutoSize = true;
        windowsXamlHost.Dock = DockStyle.Fill;
    }
}
