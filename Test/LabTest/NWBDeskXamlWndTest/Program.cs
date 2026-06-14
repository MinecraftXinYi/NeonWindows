using NeonWindows.ApplicationModel;
using NeonWindows.UI.Modern.Desktop;
using NeonWindows.UI.Modern.Xaml.Desktop;
using NeonWindows.UI.Scaling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace NWBDeskXamlWndTest;

internal static class Program
{
    internal static void Main(string[] args)
    {
        if (Win32AppModel.IsRunningAsUwp)
        {
            Application.Start((p) =>
            {
                var context = new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread());
                SynchronizationContext.SetSynchronizationContext(context);
                new App(true);
            });
        }
        else
        {
            AppDpiAwareness2.SetCurrentProcessDpiAwarenessModeEx(DpiAwarenessMode.PerMonitorV2, true);
            WinAppCompatHelper.TrySetOSMaxVersionTestedForCurrentProcess(0xfffffffffffff);
            Thread thread1 = STAThreadingModel.CreateSTAThread(() =>
            {
                new App(false);
                CoreAppViewWindow window = new(new FrameworkView());
                Window.Current.Content = new MainPage();
                window.Show();
                window.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
            });
            thread1.Start();
            //Thread thread2 = STAThreadingModel.CreateSTAThread(() =>
            //{
            //    DesktopXamlWindow window = new();
            //    window.Content = new MainPage();
            //    window.Show();
            //    window.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
            //});
            //thread2.Start();
        }
    }
}
