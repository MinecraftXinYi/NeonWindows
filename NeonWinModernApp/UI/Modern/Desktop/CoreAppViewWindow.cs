using NeonWindows.ApplicationModel;
using NeonWindows.ApplicationModel.Modern.Core;
using NeonWindows.UI.Modern.Core;
using NeonWindows.UI.Modern.Desktop.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace NeonWindows.UI.Modern.Desktop;

public class CoreAppViewWindow : CoreUIHostWindow
{
    public override CoreWindow CoreWindow { get; }

    public override CoreApplicationView CoreApplicationView { get; }

    public static CoreAppViewWindow? Current => _current;

    [ThreadStatic]
    private static CoreAppViewWindow? _current;

    public static Task<CoreAppViewWindow> CreateOnNewThread(IFrameworkViewSource frameworkViewSource)
    {
        TaskCompletionSource<CoreAppViewWindow> taskCompletionSource = new();
        Thread wndThread = STAThreadingModel.CreateSTAThread(() =>
        {
            CoreAppViewWindow window = new(frameworkViewSource);
            taskCompletionSource.SetResult(window);
            window.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
        });
        wndThread.Start();
        return taskCompletionSource.Task;
    }

    public static Task<CoreAppViewWindow> CreateOnNewThread()
    {
        TaskCompletionSource<CoreAppViewWindow> taskCompletionSource = new();
        Thread wndThread = STAThreadingModel.CreateSTAThread(() =>
        {
            CoreAppViewWindow window = new();
            taskCompletionSource.SetResult(window);
            window.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
        });
        wndThread.Start();
        return taskCompletionSource.Task;
    }

    public CoreAppViewWindow(IFrameworkViewSource frameworkViewSource) : this(frameworkViewSource.CreateView()) { }

    public CoreAppViewWindow(IFrameworkView frameworkView) : this()
        => SetFrameworkView(frameworkView);

    public void SetFrameworkView(IFrameworkView frameworkView)
    {
        frameworkView.Initialize(CoreApplicationView);
        frameworkView.SetWindow(CoreWindow);
    }

    public CoreAppViewWindow()
    {
        if (_current != null) throw new NotSupportedException();
        CoreWindow = CoreWindowFactory.CreateImmersiveHostedCoreWindow(string.Empty, new(), Handle);
        SetCoreUIFramework();
        SetCoreWindowParent(true);
        SetCoreWindowRect();
        CoreApplicationView = CoreApplication2.CreateNonImmersiveView();
        _current = this;
    }
}
