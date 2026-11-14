using NeonWindows.UI.Composition;
using NeonWindows.UI.Modern.Core;
using NeonWindows.UI.Scaling;
using NeonWindows.UI.Windowing;
using System;
using System.Windows.Forms;
using Windows.ApplicationModel.Core;
using Windows.System;
using Windows.UI.Core;

namespace NeonWindows.UI.Modern.Desktop.Core;

public abstract class CoreUIHostWindow2 : CoreUIHostWindow
{
    public abstract CoreWindow CoreWindow { get; }

    public abstract CoreApplicationView CoreApplicationView { get; }

    public override CoreDispatcher Dispatcher => CoreWindow.Dispatcher;

    public override DispatcherQueue DispatcherQueue => CoreWindow.DispatcherQueue;

    [ThreadStatic]
    protected static CoreUIHostWindow2? _current;

    public CoreUIHostWindow2()
    {
        if (_current is not null) throw new NotSupportedException();
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

    protected override void OnActivated(EventArgs e)
    {
        SetCoreWindowActivation();
        base.OnActivated(e);
    }

    protected override void OnDeactivate(EventArgs e)
    {
        SetCoreWindowActivation(false);
        base.OnDeactivate(e);
    }

    protected override void OnClientSizeChanged(EventArgs e)
    {
        AsyncCoreWindowSize();
        base.OnClientSizeChanged(e);
    }

    protected override void OnTextChanged(EventArgs e)
    {
        AsyncCoreWindowTitle();
        base.OnTextChanged(e);
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        return;
    }

    protected void InitializeCoreUIFramework()
    {
        if (CoreWindow is not null) CoreUITextInputPatch.FixTextInputBehavioursForCoreWindow(CoreWindow);
        BackdropComposition.EnableHostBackdropBrush(Handle);
    }

    protected bool InitializeWin32CoreWindow()
    {
        if (CoreWindow is null) return false;
        Win32CoreWindow = new Win32Window(CoreWindow.GetWindowHandle());
        return true;
    }

    protected IWin32Window? Win32CoreWindow { get; private set; }

    protected void SetCoreWindowParent(bool initialize = false)
    {
        if (Win32CoreWindow is null) return;
        if (initialize) Win32CoreWindow.SetAsClientOnlyChildWindow();
        if (!Win32CoreWindow.IsParent(this)) Win32CoreWindow.SetParent(this);
    }

    protected virtual void AsyncCoreWindowSize() { }

    protected virtual void SetCoreWindowActivation(bool activate = true) { }

    protected void SetCoreWindowVisible()
        => Win32CoreWindow?.ShowAsync(false);

    protected void AsyncCoreWindowTitle()
        => Win32CoreWindow?.SetTitle(Text);
}
