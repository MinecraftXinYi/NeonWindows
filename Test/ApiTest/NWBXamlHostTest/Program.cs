using NeonWindows.ApplicationModel;
using NeonWindows.UI.Modern.Xaml.Desktop;
using NeonWindows.UI.Scaling;
using NWBXamlHostTest;
using System.Threading;
using Windows.UI.Xaml.Hosting;

ModernDpiAwareness.SetProcessPerMonitorDpiAware(out _);
//WinAppCompatHelper.TrySetOSMaxVersionTestedForCurrentProcess(WinAppCompatHelper.RecommendedOSMaxVersionTested_1);
App app = new();
Thread thread = STAThreadingModel.CreateSTAThread(() =>
{
    WindowsXamlManager xamlManager = WindowsXamlManager.InitializeForCurrentThread();
    XamlHostForm form = new()
    {
        Content = new MainPage()
    };
    MinXamlWindow minXamlWindow = new(new MainPage())
    {
        Text = "Min Xaml",
        Size = new(150, 150)
    };
    minXamlWindow.Show();
    System.Windows.Forms.Application.Run(form);
});
thread.Start();
thread.Join();
