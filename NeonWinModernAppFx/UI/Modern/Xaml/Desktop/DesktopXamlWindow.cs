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
    private readonly WindowsXamlHost windowsXamlHost;

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
            window.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
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
        SetCoreWindowParent(true);
        SetCoreWindowRect();
        CoreApplicationView = CoreApplication2.CreateNonImmersiveView();
        InitializeWindowsXamlHost();
        _current = this;
    }

    protected void InitializeWindowsXamlHost()
    {
        try
        {
            Controls.Add(windowsXamlHost);
        }
        catch (Exception) { }
        windowsXamlHost.Dock = DockStyle.Fill;
    }
}
