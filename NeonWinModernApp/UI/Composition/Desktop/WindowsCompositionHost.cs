using NeonWindows.System;
using NeonWindows.UI.Desktop;
using NeonWindows.UI.Scaling;
using Windows.System;
using Windows.UI.Composition;
using Windows.UI.Composition.Desktop;

namespace NeonWindows.UI.Composition.Desktop;

public class WindowsCompositionHost : ContentHostControl
{
    public DispatcherQueue DispatcherQueue { get; }

    public Compositor Compositor { get; }

    public Visual Root
    {
        get => compositionTarget.Root;
        set => compositionTarget.Root = value;
    }

    protected readonly DesktopWindowTarget compositionTarget;

    public WindowsCompositionHost()
    {
        DispatcherQueue = DispatcherQueue.GetForCurrentThread() ?? DispatcherQueueFactory.CreateDispatcherQueueForCurrentThread(out _);
        Compositor = new();
        compositionTarget = Compositor.CreateDesktopWindowTarget(Handle, true);
        Root = Compositor.CreateContainerVisual();
    }

    protected override void CreateHandle()
    {
        WinFormsDpiAwareness.AdjustControlDpiAwarenessForCurrentThread(this);
        base.CreateHandle();
    }
}
