using NeonWindows.UI.Modern.Core;
using Windows.UI.Core;

namespace NeonWindows.UI.Composition.Desktop;

public class WindowsCompositionHost2 : WindowsCompositionHost
{
    public CoreDispatcher Dispatcher { get; }

    public WindowsCompositionHost2() : base()
        => Dispatcher = CoreDispatcherFactory.GetOrCreateDispatcherForCurrentThread();
}
