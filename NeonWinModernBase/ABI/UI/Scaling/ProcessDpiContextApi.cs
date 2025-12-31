using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Scaling;

public static class ProcessDpiContextApi
{
    /// <summary>
    /// 获取指定进程的 <see cref="DPI_AWARENESS_CONTEXT"/> 句柄。
    /// </summary>
    /// <param name="hProcess">检索其 DPI 感知上下文的进程句柄。 如果指定 NULL，则会检索当前进程的上下文。</param>
    /// <returns>指定进程的 <see cref="DPI_AWARENESS_CONTEXT"/> 。</returns>
    [DllImport(Win32DllName.Win32U, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern DPI_AWARENESS_CONTEXT NtUserGetProcessDpiAwarenessContext(nint hProcess);

    /// <summary>
    /// 将当前进程设置为指定的每英寸点数 (dpi) 感知上下文。 DPI 感知上下文来自 <see cref="DPI_AWARENESS_CONTEXT"/> 值。
    /// </summary>
    /// <param name="value">要设置的 <see cref="DPI_AWARENESS_CONTEXT"/> 句柄。</param>
    /// <returns>如果操作成功，此函数返回 TRUE，否则返回 FALSE。 要获得更多的错误信息，请调用 GetLastError。</returns>
    [DllImport(Win32DllName.ExtMsWinRTCoreNtUserDPIL120, ExactSpelling = true, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetProcessDpiAwarenessContext(DPI_AWARENESS_CONTEXT value);

    [DllImport(Win32DllName.Win32U, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool NtUserSetProcessDpiAwarenessContext(DPI_AWARENESS_CONTEXT mixedValue, [MarshalAs(UnmanagedType.Bool)] bool enforced);
}
