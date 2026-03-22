// See https://aka.ms/new-console-template for more information
using NeonWindows.ApplicationModel;
using Windows.UI.Xaml.Hosting;

Console.WriteLine(WinAppCompatHelper.TrySetOsMaxVersionTestedForCurrentProcess(0xffffffffffffffff));
Console.WriteLine("Hello, World!");
Console.ReadKey();
WindowsXamlManager xamlManager = WindowsXamlManager.InitializeForCurrentThread();
Console.WriteLine(xamlManager);
Console.ReadKey();
