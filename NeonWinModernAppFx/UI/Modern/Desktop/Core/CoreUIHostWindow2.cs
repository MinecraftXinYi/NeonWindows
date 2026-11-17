using NeonWindows.ABI.UI.Messaging;
using NeonWindows.UI.Messaging;
using NeonWindows.UI.Modern.Core;
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

    public static CoreUIHostWindow2? GetForCurrentThread() => _current;

    [ThreadStatic]
    protected static CoreUIHostWindow2? _current;

    public CoreUIHostWindow2()
    {
        if (_current is not null) throw new NotSupportedException();
    }

    protected override void OnActivated(EventArgs e)
    {
        SetCoreWindowActivation();
        AsyncCoreWindowVisibleProperty();
        base.OnActivated(e);
    }

    protected override void OnDeactivate(EventArgs e)
    {
        SetCoreWindowActivation(false);
        AsyncCoreWindowVisibleProperty();
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

    protected virtual void InitializeCoreUIInputFramework()
    {
        if (CoreWindow is not null) CoreUITextInputPatch.FixTextInputBehavioursForCoreWindow(CoreWindow);
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

    protected void SetCoreWindowActivation(bool activate = true)
        => Win32CoreWindow?.SendMessage(Messages.WM_ACTIVATE, activate ? Messages.WA_CLICKACTIVE : Messages.WA_INACTIVE, default);

    protected void SetCoreWindowVisible()
        => Win32CoreWindow?.ShowAsync(false);

    protected void AsyncCoreWindowTitle()
        => Win32CoreWindow?.SetTitle(Text);

    protected void AsyncCoreWindowVisibleProperty()
        => Win32CoreWindow?.SendMessage(Messages.WM_ICONERASEBKGND, default, Convert.ToByte(Visible && WindowState != FormWindowState.Minimized));
}
