using System.ComponentModel;
using System.Windows.Forms;

namespace NeonWindows.UI.Desktop;

public abstract class ContentHostControl : ContainerControl
{
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected override void OnPaint(PaintEventArgs e)
    {
        if (ComponentHelper.IsDesigntime)
        {
            PaintOnDesignMode(e);
            return;
        }
        base.OnPaint(e);
    }

    protected virtual void PaintOnDesignMode(PaintEventArgs e) { }

    /// <summary>
    /// Prevent control from painting the background
    /// </summary>
    /// <param name="pevent">PaintEventArgs</param>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        // Do not draw the background
        return;
    }
}
