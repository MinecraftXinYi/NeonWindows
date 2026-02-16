using NeonWindows.ABI.UI.Composition;
using Windows.UI.Composition;
using WinRT;

namespace NeonWindows.UI.Composition;

public static class CompositorDesktopInterop
{
    public static CompositionTarget CreateDesktopWindowTarget(Compositor compositor, nint hwndTarget, bool isTopmost)
    {
        compositor.As<ICompositorDesktopInterop>().CreateDesktopWindowTarget(hwndTarget, isTopmost, out nint test);
        return CompositionTarget.FromAbi(test);
    }
}
