using NeonWindows.ApplicationModel;
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
    XamlHostForm form = new();
    form.Content = new MainPage();
    System.Windows.Forms.Application.Run(form);
});
thread.Start();
thread.Join();
