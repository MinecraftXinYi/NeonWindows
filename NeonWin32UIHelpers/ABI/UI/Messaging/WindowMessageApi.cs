using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Messaging;

public static class WindowMessageApi
{
    [DllImport(Win32DllName.User32, ExactSpelling = true, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool PostMessageW(nint hWnd, uint Msg, nuint wParam, nint lParam);
}
