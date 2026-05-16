using NeonWindows.ApplicationModel;
using System.Windows.Forms;
using Windows.UI.Xaml.Hosting;

Form form = new();
WinAppCompatHelper.TrySetOSMaxVersionTestedForCurrentProcess(WinAppCompatHelper.RecommendedOSMaxVersionTested_1);
DesktopWindowXamlSource windowXamlSource = new();
Console.WriteLine("Hello, World!");
Console.WriteLine(windowXamlSource);
Application.Run(form);
