using NeonWindows.ABI.UI.Modern.Xaml;
using Windows.UI.Xaml;
using WinRT;

namespace NeonWindows.UI.Modern.Xaml;

public static class XamlSourceTransparency
{
    public static bool IsBackgroundTransparent(this Window window)
    {
        ExceptionHelpers.ThrowExceptionForHR(window.As<IWindowPrivate>().GetTransparentBackground(out bool enabled));
        return enabled;
    }

    public static void SetBackgroundTransparent(this Window window, bool enabled)
        => ExceptionHelpers.ThrowExceptionForHR(window.As<IWindowPrivate>().SetTransparentBackground(enabled));
}
