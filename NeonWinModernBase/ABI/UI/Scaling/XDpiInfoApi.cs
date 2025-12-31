using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Scaling;

public static class XDpiInfoApi
{
    /// <summary>
    /// 返回系统 DPI。
    /// </summary>
    /// <returns>系统 DPI 值。</returns>
    [DllImport(Win32DllName.ExtMsWinRTCoreNtUserDPIL120, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern uint GetDpiForSystem();

    /// <summary>
    /// 返回指定窗口的每英寸点数 (dpi) 值。
    /// </summary>
    /// <param name="hwnd">要获取其相关信息的窗口。</param>
    /// <returns>窗口的 DPI，取决于窗口 DPI_AWARENESS 。 无效的 hwnd 值将导致返回值 0。</returns>
    [DllImport(Win32DllName.ExtMsWinRTCoreNtUserDPIL120, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern uint GetDpiForWindow(nint hwnd);

    /// <summary>
    /// 从给定的 <see cref="DPI_AWARENESS_CONTEXT"/> 句柄检索 DPI。 这使你可以确定线程的 DPI，而无需检查在该线程中创建的窗口。
    /// </summary>
    /// <param name="value">要检查的 <see cref="DPI_AWARENESS_CONTEXT"/> 句柄。</param>
    /// <returns>与 <see cref="DPI_AWARENESS_CONTEXT"/> 句柄关联的 DPI 值。</returns>
    [DllImport(Win32DllName.ExtMsWinRTCoreNtUserDPIL120, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern uint GetDpiFromDpiAwarenessContext(DPI_AWARENESS_CONTEXT value);

    public const byte USER_DEFAULT_SCREEN_DPI = 96;
}
