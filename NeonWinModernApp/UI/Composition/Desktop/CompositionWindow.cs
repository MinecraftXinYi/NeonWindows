using NeonWindows.System;
using NeonWindows.UI.Modern.Core;
using NeonWindows.UI.Modern.Desktop.Core;
using System;
using Windows.System;
using Windows.UI.Composition;
using Windows.UI.Composition.Desktop;
using Windows.UI.Core;

namespace NeonWindows.UI.Composition.Desktop;

public class CompositionWindow : CoreUIHostWindow
{
    public override CoreDispatcher Dispatcher { get; }

    public override DispatcherQueue DispatcherQueue { get; }

    public Compositor Compositor { get; }

    public Visual Root
    {
        get => compositionTarget.Root;
        set => compositionTarget.Root = value;
    }

    protected readonly DesktopWindowTarget compositionTarget;

    public CompositionWindow()
    {
        try
        {
            Dispatcher = CoreDispatcherFactory.GetOrCreateDispatcherForCurrentThread();
            DispatcherQueue = Dispatcher.GetDispatcherQueue();
        }
        catch (Exception)
        {
            DispatcherQueue = DispatcherQueue.GetForCurrentThread() ?? DispatcherQueueFactory.CreateDispatcherQueueForCurrentThread(out _);
            Dispatcher = null!;
        }
        Compositor = new();
        compositionTarget = Compositor.CreateDesktopWindowTarget(Handle, true);
        Root = Compositor.CreateContainerVisual();
    }
}
