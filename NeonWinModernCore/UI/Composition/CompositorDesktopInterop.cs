using NeonWindows.ABI.UI.Composition;
using Windows.UI.Composition;
using Windows.UI.Composition.Desktop;
using WinRT;

namespace NeonWindows.UI.Composition;

public static class CompositorDesktopInterop
{
    public static DesktopWindowTarget CreateDesktopWindowTarget(this Compositor compositor, nint hwndTarget, bool isTopmost)
    {
        compositor.As<ICompositorDesktopInterop>().CreateDesktopWindowTarget(hwndTarget, isTopmost, out nint pDesktopWindowTarget);
        return DesktopWindowTarget.FromAbi(pDesktopWindowTarget);
    }
}
