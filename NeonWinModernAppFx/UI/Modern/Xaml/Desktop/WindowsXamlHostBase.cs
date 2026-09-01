using NeonWindows.UI.Modern.Desktop.Core;
using NeonWindows.UI.Modern.Xaml.Hosting;
using NeonWindows.UI.Windowing;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

public unsafe abstract class WindowsXamlHostBase : ContainerControl
{
    private readonly DesktopWindowXamlSource windowXamlSource = null!;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public UIElement Content
    {
        get => windowXamlSource.Content;
        set => windowXamlSource.Content = value;
    }

    public WindowsXamlHostBase()
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
        InitializeControlStyle();
        windowXamlSource = new();
    }

    protected void InitializeControlStyle()
    {
        SetStyle(ControlStyles.ContainerControl, true);
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    }

    protected override void CreateHandle()
    {
        ControlDpiAwarenessHelper.AdjustControlDpiAwarenessForCurrentThread(this);
        base.CreateHandle();
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        SetXamlSourceParent(true);
        InitializeXamlSourceWin32Window();
        SetXamlSourceRect();
    }

    protected override void OnParentVisibleChanged(EventArgs e)
    {
        base.OnParentVisibleChanged(e);
        SetXamlSourceVisible(Visible);
    }

    protected override void OnClientSizeChanged(EventArgs e)
    {
        base.OnClientSizeChanged(e);
        SetXamlSourceRect();
    }

    public override bool PreProcessMessage(ref Message msg)
    {
        XamlSourcePreTranslateMessage(msg);
        return base.PreProcessMessage(ref msg);
    }

    protected bool InitializeXamlSourceWin32Window()
    {
        if (windowXamlSource is not null)
        {
            XamlSourceWin32Window = new Win32Window(windowXamlSource.GetWindowHandle());
            return true;
        }
        return false;
    }

    protected IWin32Window? XamlSourceWin32Window { get; private set; }

    protected void SetXamlSourceParent(bool initialize = false)
    {
        if (initialize) windowXamlSource?.AttachToWindow(Handle);
        else
        {
            if (XamlSourceWin32Window is null) return;
            if (!XamlSourceWin32Window.IsParent(this)) XamlSourceWin32Window.SetParent(this);
        }
    }

    protected void SetXamlSourceRect()
    {
        XamlSourceWin32Window?.SetRectangle(new(default, ClientSize));
    }

    protected void SetXamlSourceVisible(bool visible = true)
    {
        if (visible) XamlSourceWin32Window?.ShowAsync(false);
        else XamlSourceWin32Window?.HideAsync();
    }

    protected void XamlSourcePreTranslateMessage(Message message)
    {
        windowXamlSource?.PreTranslateMessage(&message);
    }
}
