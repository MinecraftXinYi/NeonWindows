using NeonWindows.ABI.UI.Modern.Xaml;
using System.Runtime.InteropServices;
using Windows.UI.Xaml;

namespace NeonWindows.UI.Modern.Xaml;

public static class XamlSourceTransparency
{
    public static bool IsBackgroundTransparent(this Window window)
    {
        Marshal.ThrowExceptionForHR(((IWindowPrivate)(object)window).GetTransparentBackground(out bool enabled));
        return enabled;
    }

    public static void SetBackgroundTransparent(this Window window, bool enabled)
        => Marshal.ThrowExceptionForHR(((IWindowPrivate)(object)window).SetTransparentBackground(enabled));
}
