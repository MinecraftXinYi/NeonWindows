using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Scaling;

public static class ProcessDpiAwarenessApi2
{
    [DllImport(Win32DllName.User32, ExactSpelling = true, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetProcessDpiAwarenessInternal(nint hprocess, out PROCESS_DPI_AWARENESS value);

    [DllImport(Win32DllName.User32, ExactSpelling = true, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetProcessDpiAwarenessInternal(PROCESS_DPI_AWARENESS value);
}
