using System.ComponentModel;

namespace NeonWindows;

internal static class ComponentHelper
{
    internal static bool IsDesigntime
    {
        // https://stackoverflow.com/questions/1166226/detecting-design-mode-from-a-controls-constructor
        get => LicenseManager.UsageMode == LicenseUsageMode.Designtime;
    }
}
