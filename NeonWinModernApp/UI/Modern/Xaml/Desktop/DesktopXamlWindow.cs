using NeonWindows.ApplicationModel;
using NeonWindows.ApplicationModel.Modern.Core;
using NeonWindows.UI.Modern.Desktop.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

public class DesktopXamlWindow : CoreUIHostWindow
{
    protected readonly WindowsXamlHost windowsXamlHost;

    public UIElement Content
    {
        get => windowsXamlHost.Content;
        set => windowsXamlHost.Content = value;
    }

    public override CoreWindow CoreWindow { get; }

    public override CoreApplicationView CoreApplicationView { get; }

    public static DesktopXamlWindow? Current => _current;

    [ThreadStatic]
    private static DesktopXamlWindow? _current;

    public static Task<DesktopXamlWindow> CreateOnNewThread()
    {
        TaskCompletionSource<DesktopXamlWindow> taskCompletionSource = new();
        Thread wndThread = STAThreadingModel.CreateSTAThread(() =>
        {
            DesktopXamlWindow window = new();
            taskCompletionSource.SetResult(window);
            global::System.Windows.Forms.Application.Run(window);
        });
        wndThread.Start();
        return taskCompletionSource.Task;
    }

    public DesktopXamlWindow(UIElement content) : this()
        => Content = content;

    public DesktopXamlWindow()
    {
        if (_current != null) throw new NotSupportedException();
        windowsXamlHost = new();
        CoreWindow = CoreWindow.GetForCurrentThread();
        InitializeCoreUIFramework();
        InitializeWin32CoreWindow();
        CoreApplicationView = CoreApplication2.CreateNonImmersiveView();
        SetXamlHostControl(true);
        AsyncCoreWindowTitle();
        _current = this;
    }

    protected void SetXamlHostControl(bool initialize = false)
    {
        if (initialize) Controls.Add(windowsXamlHost);
        windowsXamlHost.Dock = DockStyle.Fill;
    }
}
