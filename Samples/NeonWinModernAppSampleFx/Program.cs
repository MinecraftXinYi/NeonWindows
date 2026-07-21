using NeonWindows.ApplicationModel;
using NeonWindows.UI.Modern.Desktop;
using NeonWindows.UI.Scaling;
using System;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace NeonWinModernAppSampleFx;

public static class Program
{
    [STAThread]
    private static void Main()
    {
        WinAppCompatHelper.TrySetOSMaxVersionTestedForCurrentProcess(WinAppCompatHelper.RecommendedOSMaxVersionTested_1);
        ModernDpiAwareness.SetThreadPerMonitorDpiAware(out _);
        App app = new();
        CoreAppViewWindow window = new(new FrameworkView());
        Window.Current.Content = new MainPage();
        window.Show();
        window.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
        app.Close();
    }
}
