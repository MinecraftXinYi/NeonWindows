using NeonWindows.UI.Scaling;
using NeonWindows.ABI.UI.Scaling;
using System.Runtime.InteropServices;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("Testing null DPI_AWARENESS_CONTEXTs...");
Console.WriteLine((new DPI_AWARENESS_CONTEXT(0)).IsNull);
Console.WriteLine("Testing equal DPI_AWARENESS_CONTEXTs...");
DPI_AWARENESS_CONTEXT d1 = new(int.MinValue);
DPI_AWARENESS_CONTEXT d2 = new(int.MinValue);
Console.WriteLine(d1 == d2);
Console.WriteLine("Testing native api NtUserGetProcessDpiAwarenessContext with invalid parameters...");
Console.WriteLine(ProcessDpiContextApi.NtUserGetProcessDpiAwarenessContext(int.MinValue).IsNull);
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
Console.WriteLine("Setting ThreadDpiAwarenessContext to null...");
Console.WriteLine(!ThreadDpiContextApi.SetThreadDpiAwarenessContext(DPI_AWARENESS_CONTEXT.Null).IsNull);
Console.ReadKey();
Console.WriteLine($"CurrentThreadDpiAwarenessMode: {AppDpiAwareness2.CurrentThreadDpiAwarenessMode}");
Console.ReadKey();
Console.WriteLine($"ConsoleWindowDpiAwarenessMode: {AppDpiAwareness2.GetDpiAwarenessModeForWindow(GetConsoleWindow())}");
Console.ReadKey();

[DllImport("kernel32.dll", ExactSpelling = true)]
[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
static extern nint GetConsoleWindow();
