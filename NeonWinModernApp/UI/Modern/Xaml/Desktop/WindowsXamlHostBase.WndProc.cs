using NeonWindows.ABI.UI.Messaging;
using NeonWindows.UI.Messaging;
using NeonWindows.UI.Modern.Core;
using NeonWindows.UI.Modern.Xaml.Hosting;
using NeonWindows.UI.Windowing;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Windows.UI.Core;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

public unsafe partial class WindowsXamlHostBase
{
    protected bool shouldActivateCoreWindow = false;

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
            case (int)Messages.WM_DPICHANGED_AFTERPARENT:
                if (XamlSourceWin32Window is not null && XamlSourceWin32Window.Handle != default)
                {
                    UpdateDpiScalingFactor();
                    PerformLayout();
                }
                base.WndProc(ref m);
                break;
            default:
                base.WndProc(ref m);
                break;
        }
    }
}
