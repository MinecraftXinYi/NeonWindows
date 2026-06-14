using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Windowing;

public static class WindowParentApi
{
    [DllImport(Win32DllName.User32, ExactSpelling = true, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern nint SetParent(nint hWndChild, nint hWndNewParent);
}
