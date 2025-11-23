using NeonWindows.UI.Scaling;
using NeonWindows.ABI.UI.Scaling;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
DPI_AWARENESS_CONTEXT d1 = new(34);
DPI_AWARENESS_CONTEXT d2 = new(34);
Console.WriteLine(d1 == d2);
Console.ReadKey();
Console.WriteLine(ProcessDpiContextApi.NtUserGetProcessDpiAwarenessContext(-3).IsNull);
Console.ReadKey();
Console.WriteLine($"CurrentProcessDpiAwarenessMode: {AppDpiAwareness.CurrentProcessDpiAwarenessMode}");
Console.WriteLine($"CurrentThreadDpiAwarenessMode: {AppDpiAwareness2.CurrentThreadDpiAwarenessMode}");
Console.ReadKey();
Console.WriteLine("Setting CurrentProcessDpiAwarenessMode to PerMonitor...");
AppDpiAwareness.SetCurrentProcessDpiAwarenessMode(DpiAwarenessMode.PerMonitor);
Console.WriteLine($"CurrentProcessDpiAwarenessMode: {AppDpiAwareness.CurrentProcessDpiAwarenessMode}");
Console.ReadKey();
Console.WriteLine("Trying to set CurrentProcessDpiAwarenessMode to PerMonitorV2...");
try
{
    AppDpiAwareness.SetCurrentProcessDpiAwarenessMode(DpiAwarenessMode.PerMonitorV2);
    Console.WriteLine(true);
}
catch (Exception e)
{
    Console.WriteLine(e.GetType().Name);
}
Console.ReadKey();
Console.WriteLine($"CurrentThreadDpiAwarenessMode: {AppDpiAwareness2.CurrentThreadDpiAwarenessMode}");
Console.ReadKey();
Console.WriteLine("Setting CurrentThreadDpiAwarenessMode to PerMonitorV2...");
AppDpiAwareness2.SetCurrentThreadDpiAwarenessMode(DpiAwarenessMode.PerMonitorV2);
Console.WriteLine($"CurrentThreadDpiAwarenessMode: {AppDpiAwareness2.CurrentThreadDpiAwarenessMode}");
Console.ReadKey();
