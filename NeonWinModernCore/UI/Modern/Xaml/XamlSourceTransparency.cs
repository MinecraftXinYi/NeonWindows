using NeonWindows.ABI.UI.Modern.Xaml;
using Windows.UI.Xaml;
using WinRT;

namespace NeonWindows.UI.Modern.Xaml;

public static class XamlSourceTransparency
{
    public static bool IsBackgroundTransparent(this Window window)
    {
        IWindowPrivate windowPrivate = window.As<IWindowPrivate>();
        ExceptionHelpers.ThrowExceptionForHR(windowPrivate.GetTransparentBackground(out bool enabled));
        return enabled;
    }

    public static void SetBackgroundTransparent(this Window window, bool enabled)
    {
        IWindowPrivate windowPrivate = window.As<IWindowPrivate>();
        ExceptionHelpers.ThrowExceptionForHR(windowPrivate.SetTransparentBackground(enabled));
    }
}
