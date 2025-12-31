using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Scaling;

public static class ThreadDpiContextApi
{
    /// <summary>
    /// 获取当前线程的 <see cref="DPI_AWARENESS_CONTEXT"/> 。
    /// </summary>
    /// <returns>线程的当前 <see cref="DPI_AWARENESS_CONTEXT"/> 。</returns>
    [DllImport(Win32DllName.ExtMsWinRTCoreNtUserDPIL120, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern DPI_AWARENESS_CONTEXT GetThreadDpiAwarenessContext();

    /// <summary>
    /// 将当前线程的 DPI 感知设置为提供的值。
    /// </summary>
    /// <param name="dpiContext">当前线程的新 <see cref="DPI_AWARENESS_CONTEXT"/> 。 此上下文包括 DPI_AWARENESS 值。</param>
    /// <returns>线程的旧 <see cref="DPI_AWARENESS_CONTEXT"/> 。 如果 dpiContext 无效，则不会更新线程，并且返回值为 NULL。</returns>
    [DllImport(Win32DllName.ExtMsWinRTCoreNtUserDPIL120, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern DPI_AWARENESS_CONTEXT SetThreadDpiAwarenessContext(DPI_AWARENESS_CONTEXT dpiContext);
}
