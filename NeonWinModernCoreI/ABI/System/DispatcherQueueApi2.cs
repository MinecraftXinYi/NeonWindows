using System.Runtime.InteropServices;

namespace NeonWindows.ABI.System;

public static class DispatcherQueueApi2
{
    [DllImport(WinRTDllName.CoreMessaging, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern void CreateDispatcherQueueForCurrentThread(out nint pDispatcherQueue);

    [DllImport(WinRTDllName.CoreMessaging, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern void GetDispatcherQueueForCurrentThread(out nint pDispatcherQueue);
}
