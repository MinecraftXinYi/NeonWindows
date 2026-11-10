using NeonWindows.ABI.UI.Windowing;
using NeonWindows.UI.Modern.Desktop.Core;
using NeonWindows.UI.Modern.Xaml.Hosting;
using NeonWindows.UI.Windowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

public unsafe class XamlHost2 : ContainerControl
{
    public UIElement Content
    {
        get => windowXamlSource.Content;
        set => windowXamlSource.Content = value;
    }

    private readonly DesktopWindowXamlSource windowXamlSource = null!;

    public XamlHost2()
    {
        if (DesignMode) return;
        InitializeControlStyles();
        windowXamlSource = new();

    }

    protected override void CreateHandle()
    {
        ControlDpiAwarenessHelper.AdjustControlDpiAwarenessForCurrentThread(this);
        base.CreateHandle();
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        if (!DesignMode)
        {
            SetXamlSourceWindowParent();
            InitializeXamlSourceWin32Window();
            InitializeXamlSourceWindowExStyles();
        }
        base.OnHandleCreated(e);
    }

    public override bool PreProcessMessage(ref Message msg)
    {
        if (XamlSourcePreTranslateMessage(ref msg)) return true;
        return base.PreProcessMessage(ref msg);
    }

    //protected override void OnPaintBackground(PaintEventArgs e)
    //{
    //    return;
    //}

    protected void InitializeControlStyles()
    {
        SetStyle(ControlStyles.ContainerControl, true);
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    }

    private void SetXamlSourceWindowParent()
        => windowXamlSource?.AttachToWindow(Handle);

    protected void InitializeXamlSourceWindowExStyles()
        => XamlSourceWin32Window?.SetLong(WINDOW_LONG_PTR_INDEX.GWL_EXSTYLE, (int)(WINDOW_EX_STYLE.WS_EX_CONTROLPARENT | WINDOW_EX_STYLE.WS_EX_LAYERED));

    protected bool XamlSourcePreTranslateMessage(ref Message message)
        => windowXamlSource?.PreTranslateMessage(Unsafe.AsPointer(ref message)) ?? false;

    protected bool InitializeXamlSourceWin32Window()
    {
        if (windowXamlSource is null) return false;
        XamlSourceWin32Window = new Win32Window(windowXamlSource.GetWindowHandle());
        return true;
    }

    protected IWin32Window? XamlSourceWin32Window { get; private set; }
}
