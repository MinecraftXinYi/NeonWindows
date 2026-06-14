using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Windowing;

public static class WindowLongApi
{
    [DllImport(Win32DllName.User32, ExactSpelling = true, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern long GetWindowLongW(nint hWnd, int nIndex);

    [DllImport(Win32DllName.User32, ExactSpelling = true, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern long SetWindowLongW(nint hWnd, int nIndex, long dwNewLong);

    public const int GWL_STYLE = -16;

    public const long
        WS_OVERLAPPEDWINDOW = 0x00CF0000,
        WS_POPUPWINDOW = 0x80880000,
        WS_CHILDWINDOW = 0x40000000;
}
