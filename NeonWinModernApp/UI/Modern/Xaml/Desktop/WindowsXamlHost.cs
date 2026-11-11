using System.ComponentModel;
using System.Windows.Forms;
using Windows.UI.Xaml;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

/// <summary>
/// A sample Windows Forms control that hosts XAML content
/// </summary>
public class WindowsXamlHost : WindowsXamlHostBase
{
    /// <summary>
    /// Gets or sets a value indicating whether the control dynamically sizes to its content
    /// </summary>
    [ReadOnly(false)]
    [Browsable(true)]
    [DefaultValue(false)]
    [Category("Layout")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override bool AutoSize
    {
        get => base.AutoSize;
        set => base.AutoSize = value;
    }

    /// <summary>
    /// Gets or sets the automatic size mode.
    /// </summary>
    /// <value>The automatic size mode.</value>
    /// <remarks>A value indicating if the control dynamically sizes to its content.</remarks>
    [ReadOnly(false)]
    [Browsable(true)]
    [Category("Layout")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public AutoSizeMode AutoSizeMode
    {
        get => GetAutoSizeMode();
        set => SetAutoSizeMode(value);
    }

    /// <summary>
    /// Gets or sets XAML content for XamlContentHost
    /// </summary>
    /// <value>The <see cref="UIElement"/>.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public UIElement Content
    {
        get => ContentInternal;
        set => ContentInternal = value;
    }
}
