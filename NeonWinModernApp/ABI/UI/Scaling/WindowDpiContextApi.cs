using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Scaling;

public static class WindowDpiContextApi
{
    /// <summary>
    /// 返回与窗口关联的 DPI_AWARENESS_CONTEXT 。
    /// </summary>
    /// <param name="hwnd">要查询的窗口。</param>
    /// <returns>提供的窗口的 DPI_AWARENESS_CONTEXT 。 如果窗口无效，则返回值为 NULL。</returns>
    [DllImport(Win32DllName.ExtMsWinRTCoreNtUserDPIL120, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern DPI_AWARENESS_CONTEXT GetWindowDpiAwarenessContext(nint hwnd);
}
