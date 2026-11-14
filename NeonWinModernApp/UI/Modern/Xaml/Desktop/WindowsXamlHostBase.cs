using NeonWindows.ABI.UI.Messaging;
using NeonWindows.ABI.UI.Windowing;
using NeonWindows.UI.Desktop;
using NeonWindows.UI.Messaging;
using NeonWindows.UI.Modern.Core;
using NeonWindows.UI.Modern.Xaml.Hosting;
using NeonWindows.UI.Scaling;
using NeonWindows.UI.Windowing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

/// <summary>
/// WindowsXamlHostBase hosts UWP XAML content inside Windows Forms
/// </summary>
public unsafe abstract class WindowsXamlHostBase : ContentHostControl
{
    /// <summary>
    /// DesktopWindowXamlSource instance
    /// </summary>
    private readonly DesktopWindowXamlSource windowXamlSource = null!;

    /// <summary>
    /// Last Focus Request GUID to uniquely identify Focus operations, primarily used with error callbacks
    /// </summary>
    private Guid lastFocusRequest = Guid.Empty;

    protected bool shouldActivateCoreWindow = false;

    private bool forceFocusNavigation = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowsXamlHostBase"/> class.
    /// </summary>
    public WindowsXamlHostBase()
    {
        // Return immediately if control is instantiated by the Visual Studio Designer
        if (ComponentHelper.IsDesigntime) return;

        InitializeControlStyles();

        // Must be a container control with TabStop == false to allow nested UWP XAML Focus
        // BUGBUG: Uncomment when nested Focus is available
        // TabStop = false;

        // Create DesktopWindowXamlSource, host for UWP XAML content
        windowXamlSource = new();

        // Hook up method for DesktopWindowXamlSource Focus handling
        windowXamlSource.TakeFocusRequested += OnTakeFocusRequested;
    }

    /// <summary>
    /// Gets or sets XAML content for XamlContentHost
    /// </summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected UIElement ContentInternal
    {
        get => _contentInternal;
        set
        {
            if (!ComponentHelper.IsDesigntime)
            {
                if (value == ContentInternal) return;
                _contentInternal = value;
                windowXamlSource.Content = value;
                PerformLayout();
            }
            else
            {
                _contentInternal = value;
            }
        }
    }

    /// <summary>
    /// Private field that backs ContentInternal property.
    /// </summary>
    private UIElement _contentInternal = null!;

    protected void InitializeControlStyles()
    {
        SetStyle(ControlStyles.ContainerControl, true);
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    }

    protected override void CreateHandle()
    {
        WinFormsDpiAwareness.AdjustControlDpiAwarenessForCurrentThread(this);
        shouldActivateCoreWindow = true;
        base.CreateHandle();
        shouldActivateCoreWindow = false;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        if (!ComponentHelper.IsDesigntime)
        {
            windowXamlSource.AttachToWindow(Handle);
            InitializeXamlSourceWin32Window();
            AsyncXamlSourceSize();
            // Set window style required by container control to support Focus and background refresh
            if (XamlSourceWin32Window?.SetLong(WINDOW_LONG_PTR_INDEX.GWL_EXSTYLE, (int)(WINDOW_EX_STYLE.WS_EX_CONTROLPARENT | WINDOW_EX_STYLE.WS_EX_LAYERED)) == default)
                throw new Win32Exception();
            if (ContentInternal is not null) windowXamlSource.Content = ContentInternal;
        }
        base.OnHandleCreated(e);
    }

    /// <summary>
    /// Sets XAML window size using dimensions of the host control
    /// </summary>
    protected void AsyncXamlSourceSize()
    {
        XamlSourceWin32Window?.SetRectangle(new(default, new(Width, Height)));
        XamlSourceWin32Window?.SetZOrder(new Win32Window());
    }

    /// <summary>
    /// 设置 DesktopWindowXamlSource 的内部 Win32 窗口对象。
    /// </summary>
    /// <returns>操作成功则返回 <see cref="true"/> 。</returns>
    protected bool InitializeXamlSourceWin32Window()
    {
        if (windowXamlSource is null) return false;
        XamlSourceWin32Window = new Win32Window(windowXamlSource.GetWindowHandle());
        return true;
    }

    /// <summary>
    ///  Win32 window associated with this UWP XAML island instance
    /// </summary>
    protected IWin32Window? XamlSourceWin32Window { get; private set; }

    /// <summary>
    /// In order to handle keyboard accelerators and TAB input, we must give a chance to <seealso cref="DesktopWindowXamlSource"/>
    /// to handle the <paramref name="msg"/> using <seealso cref="IDesktopWindowXamlSourceNative2.PreTranslateMessage(ref Message)"/>
    /// </summary>
    /// <param name="msg">The current incomming message in the queue</param>
    /// <returns>True if <seealso cref="windowXamlSource"/> was able to handle the <paramref name="msg"/></returns>
    public override bool PreProcessMessage(ref Message msg)
    {
        if (windowXamlSource?.PreTranslateMessage(Unsafe.AsPointer(ref msg)) ?? false) return true;
        return base.PreProcessMessage(ref msg);
    }

    protected override void WndProc(ref Message m)
    {
        if (ComponentHelper.IsDesigntime) base.WndProc(ref m);
        switch (m.Msg)
        {
            // AsyncXamlSourceSize must always be called after base.WndProc
            case (int)Messages.WM_MOVE:
            case (int)Messages.WM_SIZE:
            case (int)Messages.WM_WINDOWPOSCHANGED:
                base.WndProc(ref m);
                AsyncXamlSourceSize();
                if (shouldActivateCoreWindow)
                {
                    CoreWindow coreWindow = CoreWindow.GetForCurrentThread();
                    if (coreWindow is not null)
                    {
                        IWin32Window win32CoreWindow = new Win32Window(coreWindow.GetWindowHandle());
                        Rectangle coreWindowRect = win32CoreWindow.GetRectangle();
                        win32CoreWindow.SendMessage(Messages.WM_SIZE, Messages.SIZE_RESTORED, (nint)IntDataHelper.MakeLong((ushort)coreWindowRect.Width, (ushort)coreWindowRect.Height));
                    }
                }
                break;
            // BUGBUG: Focus integration with Windows.UI.Xaml.Hosting.XamlSourceFocusNavigation is
            // skipping over nested elements. Update or move back to Windows.Xaml.Input.FocusManager.
            // WM_SETFOCUS should not be handled directly. MS Internal: DesktopWindowXamlSource.NavigateFocus
            // non-directional Focus not moving Focus, not responding to keyboard input.
            case (int)Messages.WM_SETFOCUS:
                // BUGBUG: Work-around internal aggressive FAILFAST bug.  Remove this when #19043466 or nested element support is fixed.
                // Temporarily drop some WM_SETFOCUS messages to prevent calling Focus on Focused element.  An
                // unnecessary Focus operation may trigger a FAILFAST inside UWP XAML's DesktopWindowXamlSource.
                if (m.WParam != m.HWnd) return;
                if (XamlSourceWin32Window is not null) WindowFocus.SetFocus(XamlSourceWin32Window);
                base.WndProc(ref m);
                break;
            case (int)Messages.WM_KILLFOCUS:
                // If focus is being set on the UWP XAML island window then we should prevent LostFocus by
                // handling this message.
                if ((XamlSourceWin32Window is not null && (XamlSourceWin32Window.Handle != default || XamlSourceWin32Window.Handle != m.WParam)) || windowXamlSource.HasFocus)
                    base.WndProc(ref m);
                break;
            default:
                base.WndProc(ref m);
                break;
        }
    }

    public override bool Focused
    {
        get
        {
            if (!IsHandleCreated) return false;
            // Get currently focused window handle and compare with Control
            // and hosted Xaml content window handles
            return WindowFocus.GetFocus().Handle == Handle || (XamlSourceWin32Window is not null && XamlSourceWin32Window.Handle != default && windowXamlSource.HasFocus);
        }
    }

    protected override void Select(bool directed, bool forward)
        => ProcessTabKey(forward);

    /// <summary>
    /// Processes a tab key, ensuring that Xaml has an opportunity
    /// to handle the command before normal Windows Forms processing.
    /// (Xaml must be notified of keys that invoke focus navigation.)
    /// </summary>
    /// <returns>true if the command was processed</returns>
    protected override bool ProcessTabKey(bool forward)
    {
        if (ComponentHelper.IsDesigntime) return false;
        // Determine if the currently focused element is the last element for the requested
        // navigation direction.  If the currently focused element is not the last element
        // for the requested navigation direction, navigate focus to the next focusable
        // element.
        if (!windowXamlSource.HasFocus || forceFocusNavigation)
        {
            forceFocusNavigation = false;
            XamlSourceFocusNavigationRequest request = new(forward ? XamlSourceFocusNavigationReason.First : XamlSourceFocusNavigationReason.Last, default);
            lastFocusRequest = request.CorrelationId;
            return windowXamlSource.NavigateFocus(request).WasFocusMoved;
        }
        else
        {
            // Call FocusManager.TryMoveFocus Next or Previous and return
            FocusNavigationDirection navigationDirection = forward ? FocusNavigationDirection.Next : FocusNavigationDirection.Previous;
            return FocusManager.TryMoveFocus(navigationDirection);
        }
    }

    /// <summary>
    /// Responds to DesktopWindowsXamlSource TakeFocusRequested event
    /// </summary>
    /// <param name="sender">DesktopWindowsXamlSource</param>
    /// <param name="args">DesktopWindowXamlSourceTakeFocusRequestedEventArgs</param>
    private void OnTakeFocusRequested(DesktopWindowXamlSource sender, DesktopWindowXamlSourceTakeFocusRequestedEventArgs args)
    {
        if (lastFocusRequest == args.Request.CorrelationId)
        {
            // If we've arrived at this point, then focus is being move back to us
            // therefore, we should complete the operation to avoid an infinite recursion
            // by "Restoring" the focus back to us under a new correlationId
            XamlSourceFocusNavigationRequest newRequest = new(XamlSourceFocusNavigationReason.Restore);
            windowXamlSource.NavigateFocus(newRequest);
            lastFocusRequest = newRequest.CorrelationId;
        }
        else
        {
            // Focus was not initiated by WindowsXamlHost. Continue processing the Focus request.
            XamlSourceFocusNavigationReason reason = args.Request.Reason;
            if (reason == XamlSourceFocusNavigationReason.First || reason == XamlSourceFocusNavigationReason.Last)
            {
                forceFocusNavigation = true;
                try
                {
                    Parent?.SelectNextControl(this, reason == XamlSourceFocusNavigationReason.First, tabStopOnly: true, nested: false, wrap: true);
                }
                finally
                {
                    forceFocusNavigation = false;
                }
            }
        }
    }

    /// <summary>
    /// Draw a placeholder Rectangle with 'Xaml Content' in Design mode
    /// </summary>
    /// <param name="e">PaintEventArgs</param>
    protected override void PaintOnDesignMode(PaintEventArgs e)
    {
        // Show 'XAML Content' with a gray Rectangle placeholder when running in the Designer
        // Gray background Rectangle
        e.Graphics.FillRectangle(new SolidBrush(Color.DarkGray), ClientRectangle);
        // Text
        string text = "XAML Content";
        using Font font1 = new("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
        StringFormat stringFormat = new()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        // Draw
        e.Graphics.DrawString(text, font1, Brushes.White, ClientRectangle, stringFormat);
        e.Graphics.DrawRectangle(Pens.Black, ClientRectangle);
    }

    /// <summary>
    /// Override that disposes the current instance when the parent handle has been destroyed
    /// </summary>
    /// <param name="e">Ignored</param>
    protected override void OnHandleDestroyed(EventArgs e)
    {
        Dispose(true);
        base.OnHandleDestroyed(e);
    }

    /// <summary>
    /// Clean up hosted UWP XAML content
    /// </summary>
    /// <param name="disposing">IsDisposing?</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _contentInternal = null!;
            if (windowXamlSource is not null)
            {
                windowXamlSource.TakeFocusRequested -= OnTakeFocusRequested;
                windowXamlSource.Dispose();
            }
        }
        base.Dispose(disposing);
    }
}
