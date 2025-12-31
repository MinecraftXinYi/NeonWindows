using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Scaling;

public static class DpiAwarenessContextApi
{
    /// <summary>
    /// 确定两个 <see cref="DPI_AWARENESS_CONTEXT"/> 值是否相同。
    /// </summary>
    /// <param name="dpiContextA">要比较的第一个值。</param>
    /// <param name="dpiContextB">要比较的第二个值。</param>
    /// <returns>如果值相等，则返回 TRUE ，否则返回 FALSE。</returns>
    [DllImport(Win32DllName.ExtMsWinRTCoreNtUserDPIL120, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool AreDpiAwarenessContextsEqual(DPI_AWARENESS_CONTEXT dpiContextA, DPI_AWARENESS_CONTEXT dpiContextB);

    /// <summary>
    /// 确定指定的 <see cref="DPI_AWARENESS_CONTEXT"/> 是否有效且受当前系统支持。
    /// </summary>
    /// <param name="value">要确定它是否受支持的上下文。</param>
    /// <returns>如果提供的上下文受支持，则为 TRUE，否则为 FALSE。</returns>
    [DllImport(Win32DllName.ExtMsWinRTCoreNtUserDPIL120, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsValidDpiAwarenessContext(DPI_AWARENESS_CONTEXT value);
}
