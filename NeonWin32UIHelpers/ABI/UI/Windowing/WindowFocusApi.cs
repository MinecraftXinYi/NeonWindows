using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Windowing;

public static class WindowFocusApi
{
    [DllImport(Win32DllName.User32, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern nint GetFocus();

    [DllImport(Win32DllName.User32, ExactSpelling = true, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern nint SetFocus(nint hWnd);
}
