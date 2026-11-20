using NeonWindows.ABI.UI.Windowing;
using NeonWindows.UI.Scaling;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NeonWindows.UI.Modern.Desktop.Core;

public abstract class CoreUIHostControl : ContainerControl
{
    protected override void CreateHandle()
    {
        WinFormsDpiAwareness.AdjustControlDpiAwarenessForCurrentThread(this);
        base.CreateHandle();
    }

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle |= (int)WINDOW_EX_STYLE.WS_EX_NOREDIRECTIONBITMAP;
            return cp;
        }
    }

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

    protected void DefaultPaintOnDesignMode(PaintEventArgs e, Brush rectBrush, Brush textBrush, string text)
    {
        // Rectangle
        e.Graphics.FillRectangle(rectBrush, ClientRectangle);
        e.Graphics.DrawRectangle(Pens.Black, ClientRectangle);
        // Text
        StringFormat stringFormat = new()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        e.Graphics.DrawString(text, SystemFonts.DefaultFont, textBrush, ClientRectangle, stringFormat);
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
