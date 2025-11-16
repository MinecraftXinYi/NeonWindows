using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Scaling;

public static class ClassicDpiAwarenessApi
{
    /// <summary>
    /// [IsProcessDPIAware 可用于“要求”部分中指定的操作系统。 它可能在后续版本中变更或不可用。 请改用 GetProcessDPIAwareness。]
    /// 确定当前进程是否为每英寸点数 (dpi) 感知，以便调整 UI 元素的大小以补偿 dpi 设置。
    /// </summary>
    /// <returns>如果进程可识别 dpi，则为 TRUE;否则为 FALSE。</returns>
    [DllImport(Win32DllName.User32, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return:MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsProcessDPIAware();

    /// <summary>
    /// 将进程默认 DPI 感知设置为系统 DPI 感知。
    /// </summary>
    /// <returns>如果该函数成功，则返回值为非零值。 否则返回值为零。</returns>
    [DllImport(Win32DllName.User32, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return:MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetProcessDPIAware();
}
