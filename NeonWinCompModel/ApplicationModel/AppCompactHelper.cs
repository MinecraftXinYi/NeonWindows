namespace NeonWindows.ApplicationModel;

public unsafe static class AppCompactHelper
{
    public static void SetOsMaxVersionTestedForCurrentProcess(ulong version)
        => AppCompactInfoUtils.GetSwitchContextDataForCurrentProcess()->OsMaxVersionTested = version;
}
