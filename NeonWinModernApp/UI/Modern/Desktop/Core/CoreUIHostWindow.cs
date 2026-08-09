using NeonWindows.ABI.UI.Messaging;
using NeonWindows.UI.Composition;
using NeonWindows.UI.Messaging;
using NeonWindows.UI.Modern.Core;
using NeonWindows.UI.Scaling;
using NeonWindows.UI.Windowing;
using System;
using System.Windows.Forms;
using Windows.ApplicationModel.Core;
using Windows.System;
using Windows.UI.Core;

namespace NeonWindows.UI.Modern.Desktop.Core;

public class CoreUIHostWindow : Form
{
    public virtual CoreWindow CoreWindow { get; } = null!;

    public virtual CoreApplicationView CoreApplicationView { get; } = null!;

    public virtual CoreDispatcher Dispatcher => CoreWindow.Dispatcher;

    public virtual DispatcherQueue DispatcherQueue => CoreWindow.DispatcherQueue;

    public CoreUIHostWindow()
    {
        Size = DesktopWindowInitialization.ModernWindowDefaultSize;
        MinimumSize = DesktopWindowInitialization.ModernWindowMinimumSize;
        Text = DesktopWindowInitialization.ModernWindowDefaultTitle;
    }

    protected override void CreateHandle()
    {
        ModernDpiAwareness.SetThreadPerMonitorDpiAware(out _);
        WinFormsDpiAwareness.SetDpiAwarenessForNativeWindow(WinFormsNativeWindowInterop.GetNativeWindowForControl(this), DpiAwarenessMode.PerMonitorV2);
        base.CreateHandle();
    }

    protected override void OnActivated(EventArgs e)
    {
        SetCoreWindowVisible();
        SetCoreWindowActivation();
        base.OnActivated(e);
    }

    protected override void OnDeactivate(EventArgs e)
    {
        SetCoreWindowActivation(false);
        base.OnDeactivate(e);
    }

    protected override void OnResizeBegin(EventArgs e)
    {
        SetCoreWindowParent();
        base.OnResizeBegin(e);
    }

    protected override void OnClientSizeChanged(EventArgs e)
    {
        SetCoreWindowRect();
        base.OnClientSizeChanged(e);
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        return;
    }

    protected bool HasCoreWindow(out IWin32Window win32Window)
    {
        if (CoreWindow != null)
        {
            win32Window = new Win32Window(CoreWindow.GetWindowHandle());
            return true;
        }
        win32Window = null!;
        return false;
    }

    protected void SetCoreUIFramework()
    {
        if (HasCoreWindow(out _)) CoreUITextInputPatch.FixTextInputBehavioursForCoreWindow(CoreWindow);
        BackdropComposition.EnableHostBackdropBrush(Handle);
    }

    protected void SetCoreWindowParent(bool initialize = false)
    {
        if (!HasCoreWindow(out IWin32Window win32Window)) return;
        if (initialize) win32Window.SetAsClientOnlyChildWindow();
        if (!win32Window.IsParent(this)) win32Window.SetParent(this);
    }

    protected void SetCoreWindowRect()
    {
        if (HasCoreWindow(out IWin32Window win32Window)) win32Window.SetRectangle(new(default, ClientSize));
    }

    protected void SetCoreWindowActivation(bool activate = true)
    {
        if (HasCoreWindow(out IWin32Window win32Window)) win32Window.SendMessage(SysMsg.WM_ACTIVATE, activate ? SysMsg.WA_CLICKACTIVE : SysMsg.WA_INACTIVE, default);
    }

    protected void SetCoreWindowVisible(bool activate = false)
    {
        if (HasCoreWindow(out IWin32Window win32Window)) win32Window.ShowAsync(activate);
    }
}
