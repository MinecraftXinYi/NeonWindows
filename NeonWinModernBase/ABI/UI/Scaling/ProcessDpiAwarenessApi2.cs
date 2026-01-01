using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Scaling;

public static class ProcessDpiAwarenessApi2
{
    /// <summary>
    /// 检索每英寸点数 (dpi) 指定进程的感知。
    /// </summary>
    /// <param name="hprocess">正在查询的进程句柄。 如果此参数为 NULL，则查询当前进程。</param>
    /// <param name="value">指定进程的 DPI 感知。 可能的值来自 <see cref="PROCESS_DPI_AWARENESS"/> 枚举。</param>
    /// <returns>如果操作成功，此函数返回 TRUE，否则返回 FALSE。 要获得更多的错误信息，请调用 GetLastError。</returns>
    [DllImport(Win32DllName.User32, ExactSpelling = true, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetProcessDpiAwarenessInternal(nint hprocess, out PROCESS_DPI_AWARENESS value);

    /// <summary>
    /// 设置进程默认 DPI 感知级别。
    /// </summary>
    /// <param name="value">要设置的 DPI 感知值。 可能的值来自 <see cref="PROCESS_DPI_AWARENESS"/> 枚举。</param>
    /// <returns>如果操作成功，此函数返回 TRUE，否则返回 FALSE。 要获得更多的错误信息，请调用 GetLastError。</returns>
    [DllImport(Win32DllName.User32, ExactSpelling = true, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetProcessDpiAwarenessInternal(PROCESS_DPI_AWARENESS value);
}
