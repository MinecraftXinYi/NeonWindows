namespace NeonWindows.UI.Scaling;

public static class ModernDpiAwareness
{
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
