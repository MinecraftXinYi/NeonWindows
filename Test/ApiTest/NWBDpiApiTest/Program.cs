using NeonWindows.UI.Scaling;
using NWBDpiApiTest;
using System.Runtime.InteropServices;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine($"CurrentProcessDpiAwarenessMode: {AppDpiAwareness.CurrentProcessDpiAwarenessMode}");
Console.WriteLine($"CurrentThreadDpiAwarenessMode: {AppDpiAwareness2.CurrentThreadDpiAwarenessMode}");
Console.ReadKey();
Console.WriteLine($"IsThreadBasedDpiAwarenessSupported: {AppDpiAwareness2.IsThreadBasedDpiAwarenessSupported}");
Console.ReadKey();
Console.WriteLine($"SystemScaleFactor: {ScaleInfo.DpiToScaleFactor(ScaleInfo.SystemDpi)}");
Console.WriteLine($"SystemScaleFactorDirect: {ScaleInfo.DpiToScaleFactor(ScaleInfo.SystemDpiDirect)}");
Console.ReadKey();
Console.WriteLine("Setting CurrentProcessDpiAwarenessMode to PerMonitor...");
AppDpiAwareness.SetCurrentProcessDpiAwarenessMode(DpiAwarenessMode.PerMonitor);
Console.WriteLine($"CurrentProcessDpiAwarenessMode: {AppDpiAwareness.CurrentProcessDpiAwarenessMode}");
Console.ReadKey();
Console.WriteLine("Trying to set CurrentProcessDpiAwarenessMode to PerMonitorV2...");
Console.WriteLine(AppDpiAwareness.SetCurrentProcessDpiAwarenessMode(DpiAwarenessMode.PerMonitorV2));
Console.ReadKey();
Console.WriteLine("Trying to set CurrentProcessDpiAwarenessMode to PerMonitorV2...x2");
Console.WriteLine(AppDpiAwareness2.SetCurrentProcessDpiAwarenessModeEx(DpiAwarenessMode.PerMonitorV2, true, false));
Console.WriteLine($"CurrentProcessDpiAwarenessMode: {AppDpiAwareness.CurrentProcessDpiAwarenessMode}");
Console.ReadKey();
Console.WriteLine($"CurrentThreadDpiAwarenessMode: {AppDpiAwareness2.CurrentThreadDpiAwarenessMode}");
Console.ReadKey();
Console.WriteLine("Setting CurrentThreadDpiAwarenessMode to PerMonitorV2...");
Console.WriteLine(AppDpiAwareness2.SetCurrentThreadDpiAwarenessMode(DpiAwarenessMode.PerMonitorV2));
Console.WriteLine($"CurrentThreadDpiAwarenessMode: {AppDpiAwareness2.CurrentThreadDpiAwarenessMode}");
Console.ReadKey();
Console.WriteLine($"SystemScaleFactor: {ScaleInfo.DpiToScaleFactor(ScaleInfo.SystemDpi)}");
Console.WriteLine($"SystemScaleFactorDirect: {ScaleInfo.DpiToScaleFactor(ScaleInfo.SystemDpiDirect)}");
Console.ReadKey();
Console.WriteLine($"ConsoleWindowScaleFactor: {ScaleInfo.DpiToScaleFactor(ScaleInfo.WindowDpi(GetConsoleWindow()))}");
Console.ReadKey();

[DllImport("kernel32.dll", ExactSpelling = true)]
[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
static extern nint GetConsoleWindow();
