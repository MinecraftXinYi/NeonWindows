using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Scaling;

public static class ProcessDpiAwarenessApi
{
    /// <summary>
    /// 检索每英寸点数 (dpi) 指定进程的感知。
    /// </summary>
    /// <param name="hprocess">正在查询的进程句柄。 如果此参数为 NULL，则查询当前进程。</param>
    /// <param name="value">指定进程的 DPI 感知。 可能的值来自 PROCESS_DPI_AWARENESS 枚举。</param>
    /// <returns>**HRESULT**</returns>
    [DllImport(Win32DllName.SHCore, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern int GetProcessDpiAwareness(nint hprocess, out PROCESS_DPI_AWARENESS value);

    /// <summary>
    /// 设置进程默认 DPI 感知级别。
    /// </summary>
    /// <param name="value">要设置的 DPI 感知值。 可能的值来自 PROCESS_DPI_AWARENESS 枚举。</param>
    /// <returns>**HRESULT**</returns>
    [DllImport(Win32DllName.SHCore, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern int SetProcessDpiAwareness(PROCESS_DPI_AWARENESS value);
}
