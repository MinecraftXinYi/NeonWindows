using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

public partial class WindowsXamlHostBase
{
    /// <summary>
    /// Draw a placeholder Rectangle with 'Xaml Content' in Design mode
    /// </summary>
    /// <param name="e">PaintEventArgs</param>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected override void OnPaint(PaintEventArgs e)
    {
        // Show 'XAML Content' with a gray Rectangle placeholder when running in the Designer
        if (ComponentHelper.IsDesigntime)
        {
            PaintOnDesignMode(e, "XAML Content");
            return;
        }
        base.OnPaint(e);
    }

    protected void PaintOnDesignMode(PaintEventArgs e, string text)
    {
        // Gray background Rectangle
        e.Graphics.FillRectangle(new SolidBrush(Color.DarkGray), ClientRectangle);
        // Text
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
