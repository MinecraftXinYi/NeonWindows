using NeonWindows.UI.Composition;
using NeonWindows.UI.Scaling;
using System;
using System.Windows.Forms;
using Windows.System;
using Windows.UI.Core;

namespace NeonWindows.UI.Modern.Desktop.Core;

public abstract class CoreUIHostWindow : Form
{
    public abstract CoreDispatcher Dispatcher { get; }

    public abstract DispatcherQueue DispatcherQueue { get; }

    public CoreUIHostWindow()
    {
        Size = DesktopWindowInitialization.ModernWindowDefaultSize;
        MinimumSize = DesktopWindowInitialization.ModernWindowMinimumSize;
        Text = DesktopWindowInitialization.ModernWindowDefaultTitle;
    }

    protected override void CreateHandle()
    {
        ModernDpiAwareness.SetThreadPerMonitorDpiAware(out _);
        WinFormsDpiAwareness.AdjustControlDpiAwarenessForCurrentThread(this);
        base.CreateHandle();
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        SetHostWindowCompositionAttribute();
        base.OnHandleCreated(e);
    }

    protected virtual void SetHostWindowCompositionAttribute()
        => BackdropComposition.EnableHostBackdropBrush(Handle);

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        return;
    }
}
