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

    protected void InitializeCoreUIFramework()
    {
        if (CoreWindow is not null) CoreUITextInputPatch.FixTextInputBehavioursForCoreWindow(CoreWindow);
        BackdropComposition.EnableHostBackdropBrush(Handle);
    }

    protected bool InitializeWin32CoreWindow()
    {
        if (CoreWindow is not null)
        {
            Win32CoreWindow = new Win32Window(CoreWindow.GetWindowHandle());
            return true;
        }
        return false;
    }

    protected IWin32Window? Win32CoreWindow { get; private set; }

    protected void SetCoreWindowParent(bool initialize = false)
    {
        if (Win32CoreWindow is null) return;
        if (initialize) Win32CoreWindow.SetAsClientOnlyChildWindow();
        if (!Win32CoreWindow.IsParent(this)) Win32CoreWindow.SetParent(this);
    }

    protected void SetCoreWindowRect()
    {
        Win32CoreWindow?.SetRectangle(new(default, ClientSize));
    }

    protected void SetCoreWindowActivation(bool activate = true)
    {
        Win32CoreWindow?.SendMessage(SysMsg.WM_ACTIVATE, activate ? SysMsg.WA_CLICKACTIVE : SysMsg.WA_INACTIVE, default);
    }

    protected void SetCoreWindowVisible(bool activate = false)
    {
        Win32CoreWindow?.ShowAsync(activate);
    }
}
