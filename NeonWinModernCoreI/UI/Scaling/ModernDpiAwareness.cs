namespace NeonWindows.UI.Scaling;

/// <summary>
/// 提供现代 Windows 应用 DPI 感知支持。
/// </summary>
public static class ModernDpiAwareness
{
    /// <summary>
    /// 为调用进程设置 Per-Monitor DPI 感知 (v2或旧版)。
    /// </summary>
    /// <param name="isPerMonitorV2">提供一个 <see cref="bool"/> 值，指示是否启用了 Per-Monitor DPI 感知 v2。</param>
    /// <returns>一个 <see cref="bool"/> 值，指示操作是否成功。</returns>
    public static bool SetProcessPerMonitorDpiAware(out bool isPerMonitorV2)
    {
        isPerMonitorV2 = false;
        if (AppDpiAwareness.SetCurrentProcessDpiAwarenessMode(DpiAwarenessMode.PerMonitorV2))
        {
            isPerMonitorV2 = true;
            return true;
        }
        if (AppDpiAwareness.SetCurrentProcessDpiAwarenessMode(DpiAwarenessMode.PerMonitor))
            return true;
        return false;
    }

    /// <summary>
    /// 为调用线程设置 Per-Monitor DPI 感知 (v2或旧版)。
    /// </summary>
    /// <param name="isPerMonitorV2">提供一个 <see cref="bool"/> 值，指示是否启用了 Per-Monitor DPI 感知 v2。</param>
    /// <returns>一个 <see cref="bool"/> 值，指示操作是否成功。</returns>
    public static bool SetThreadPerMonitorDpiAware(out bool isPerMonitorV2)
    {
        isPerMonitorV2 = false;
        if (AppDpiAwareness2.SetCurrentThreadDpiAwarenessMode(DpiAwarenessMode.PerMonitorV2))
        {
            isPerMonitorV2 = true;
            return true;
        }
        if (AppDpiAwareness2.SetCurrentThreadDpiAwarenessMode(DpiAwarenessMode.PerMonitor))
            return true;
        return false;
    }
}
