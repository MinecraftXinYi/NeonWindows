using NeonWindows.ApplicationModel;
using NeonWindows.UI.Modern.Desktop;
using NeonWindows.UI.Scaling;
using NeonWinModernAppSample;
using System.Threading;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

if (Win32AppModel.IsRunningAsUwp) RunUwp();
else RunWin32();

static void RunUwp()
{
    Application.Start((p) =>
    {
        SynchronizationContext context = new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread());
        SynchronizationContext.SetSynchronizationContext(context);
        new App(true);
    });
}

static void RunWin32()
{
    ModernDpiAwareness.SetProcessPerMonitorDpiAware(out _);
    WinAppCompatHelper.TrySetOSMaxVersionTestedForCurrentProcess(WinAppCompatHelper.RecommendedOSMaxVersionTested_1);
    new App(false);
    Thread thread = STAThreadingModel.CreateSTAThread(() =>
    {
        CoreAppViewWindow window = new(new FrameworkView());
        Window.Current.Content = new MainPage();
        window.Show();
        window.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
    });
    thread.Start();
    thread.Join();
}
