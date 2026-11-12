using NeonWindows.UI.Scaling;
using System;
using System.Drawing;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

public partial class WindowsXamlHostBase
{
    /// <summary>
    /// Last preferredSize returned by UWP XAML during WinForms layout pass
    /// </summary>
    private Size lastXamlContentPreferredSize;

    /// <summary>
    /// The last dpi value retrieved from the system
    /// </summary>
    private double lastDpi = Dpi.Base;

    /// <summary>
    /// Overrides the base class implementation of <see cref="GetPreferredSize(Size)" /> to provide
    /// correct layout behavior for the hosted XAML content.
    /// </summary>
    /// <returns>preferred size</returns>
    public override Size GetPreferredSize(Size proposedSize)
    {
        if (ComponentHelper.IsDesigntime) return Size;
        if (ContentInternal is not null)
        {
            double proposedWidth = proposedSize.Width;
            double proposedHeight = proposedSize.Height;
            // DockStyles will result in a constraint of 1 on the Docked axis. GetPreferredSize
            // must convert this into an unconstrained value.
            // Convert the proposed size from pixels to effective pixels if the XAML island scales the content
            if (proposedSize.Height == int.MaxValue || proposedSize.Height == 1) proposedHeight = double.PositiveInfinity;
            else proposedHeight /= lastDpi / Dpi.Base;
            if (proposedSize.Width == int.MaxValue || proposedSize.Width == 1) proposedWidth = double.PositiveInfinity;
            else proposedWidth /= lastDpi / Dpi.Base;
            windowXamlSource.Content.Measure(new(proposedWidth, proposedHeight));
        }
        Size preferredSize = Size.Empty;
        if (ContentInternal is not null) preferredSize = new((int)(windowXamlSource.Content.DesiredSize.Width * lastDpi / Dpi.Base), (int)(windowXamlSource.Content.DesiredSize.Height * lastDpi / Dpi.Base));
        return preferredSize;
    }

    /// <summary>
    /// Sets a scaling factor based on the current dpi value on the scaling panel
    /// </summary>
    protected void UpdateDpiScalingFactor()
    {
        double dpi = Dpi.Base;
        if (XamlSourceWin32Window is not null && XamlSourceWin32Window.Handle != default)
        {
            uint windowDpi = Dpi.GetForWindow(XamlSourceWin32Window);
            if (windowDpi > 0) dpi = windowDpi;
        }
        lastDpi = dpi;
    }

    // XamlContentHost's DefaultSize is 0, 0
    protected override Size DefaultSize => Size.Empty;

    /// <summary>
    /// Responds to UWP XAML's 'SizeChanged' event, fired when XAML content
    /// layout has changed.  If 'DesiredSize' has changed, re-run
    /// Windows Forms layout.
    /// </summary>
    private void OnContentSizeChanged(object sender, object e)
    {
        if (ComponentHelper.IsDesigntime) return;
        // XAML content has changed. Re-run Windows.Forms.Control Layout if parent form is
        // set to AutoSize.
        if (AutoSize)
        {
            Size prefSize = GetRootXamlElementDesiredSize();
            if (lastXamlContentPreferredSize.Height != prefSize.Height || lastXamlContentPreferredSize.Width != prefSize.Width)
            {
                lastXamlContentPreferredSize = prefSize;
                PerformLayout();
            }
        }
    }

    /// <summary>
    /// Gets XAML content's 'DesiredSize' post-Measure.
    /// </summary>
    /// <returns>desired size</returns>
    protected Size GetRootXamlElementDesiredSize()
        => new((int)windowXamlSource.Content.DesiredSize.Width, (int)windowXamlSource.Content.DesiredSize.Height);
    
    /// <summary>
    /// Event handler for <see cref="System.Windows.Forms.Control.SizeChanged" />.
    /// If the size of the host control has changed, re-run Windows Forms layout on this Control instance.
    /// </summary>
    private void OnWindowXamlHostSizeChanged(object? sender, EventArgs e)
    {
        if (ComponentHelper.IsDesigntime) return;
        if (AutoSize && ContentInternal is not null)
        {
            // XamlContenHost Control.Size has changed. XAML must perform an Arrange pass.
            // The XAML Arrange pass will expand XAML content with 'HorizontalStretch' and
            // 'VerticalStretch' properties to the bounds of the XamlContentHost Control.
            Windows.Foundation.Rect rect = new(0, 0, Width, Height);
            rect.Width /= lastDpi / Dpi.Base;
            rect.Height /= lastDpi / Dpi.Base;
            windowXamlSource.Content.Measure(new(rect.Width, rect.Height));
            windowXamlSource.Content.Arrange(rect);
            PerformLayout();
        }
    }
}
