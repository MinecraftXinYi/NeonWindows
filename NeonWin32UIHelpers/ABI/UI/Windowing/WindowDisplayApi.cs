using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Windowing;

public static class WindowDisplayApi
{
    [DllImport(Win32DllName.User32, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool ShowWindowAsync(nint hWnd, int nCmdShow);

    public const int SW_SHOW = 5;
}
