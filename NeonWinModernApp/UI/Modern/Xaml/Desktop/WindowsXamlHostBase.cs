using NeonWindows.ABI.UI.Windowing;
using NeonWindows.UI.Modern.Desktop.Core;
using NeonWindows.UI.Modern.Xaml.Hosting;
using NeonWindows.UI.Windowing;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

/// <summary>
/// WindowsXamlHostBase hosts UWP XAML content inside Windows Forms
/// </summary>
public abstract partial class WindowsXamlHostBase : ContainerControl
{
    /// <summary>
    /// DesktopWindowXamlSource instance
    /// </summary>
    private readonly DesktopWindowXamlSource windowXamlSource = null!;

    /// <summary>
    /// Fired when XAML content has been updated
    /// </summary>
    [Browsable(true)]
    [Category("UWP XAML")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Description("Fired when UWP XAML content has been updated")]
    public event EventHandler? ContentChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowsXamlHostBase"/> class.
    /// </summary>
    public WindowsXamlHostBase()
    {
        // Return immediately if control is instantiated by the Visual Studio Designer
        // https://stackoverflow.com/questions/1166226/detecting-design-mode-from-a-controls-constructor
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        {
            return;
        }

        InitializeControlStyles();

        // Must be a container control with TabStop == false to allow nested UWP XAML Focus
        // BUGBUG: Uncomment when nested Focus is available
        // TabStop = false;

        // Respond to size changes on this Control
        SizeChanged += OnWindowXamlHostSizeChanged;

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
            if (!DesignMode)
            {
                if (value == ContentInternal) return;
                FrameworkElement? newFrameworkElement = value as FrameworkElement, oldFrameworkElement = ContentInternal as FrameworkElement;
                if (oldFrameworkElement is not null) oldFrameworkElement.SizeChanged -= OnContentSizeChanged;
                _contentInternal = value;
                windowXamlSource.Content = value;
                if (newFrameworkElement is not null) newFrameworkElement.SizeChanged += OnContentSizeChanged;
                PerformLayout();
                ContentChanged?.Invoke(this, new EventArgs());
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
        ControlDpiAwarenessHelper.AdjustControlDpiAwarenessForCurrentThread(this);
        base.CreateHandle();
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        if (!DesignMode)
        {
            // Attach window to DesktopWindowXamSource as a render target
            windowXamlSource.AttachToWindow(Handle);
            InitializeXamlSourceWin32Window();

            // Set window style required by container control to support Focus and background refresh
            if (XamlSourceWin32Window?.SetLong(WINDOW_LONG_PTR_INDEX.GWL_EXSTYLE, (int)(WINDOW_EX_STYLE.WS_EX_CONTROLPARENT | WINDOW_EX_STYLE.WS_EX_LAYERED)) == default)
            {
                throw new InvalidOperationException("WindowsXamlHostBase::OnHandleCreated: Failed to set WS_EX_CONTROLPARENT and WS_EX_LAYERED on control window.");
            }

            if (ContentInternal is not null)
            {
                windowXamlSource.Content = ContentInternal;
                //ChildInternal.SetWrapper(this);
            }

            UpdateDpiScalingFactor();
        }
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
            SizeChanged -= OnWindowXamlHostSizeChanged;
            FrameworkElement? oldFrameworkElement = ContentInternal as FrameworkElement;
            if (oldFrameworkElement is not null) oldFrameworkElement.SizeChanged -= OnContentSizeChanged;
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
