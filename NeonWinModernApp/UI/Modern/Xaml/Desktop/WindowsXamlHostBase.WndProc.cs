// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using NeonWindows.UI.Modern.Core;
using NeonWindows.UI.Windowing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Core;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

/// <summary>
///     WindowsXamlHostBase hosts UWP XAML content inside Windows Forms
/// </summary>
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
        // Show "XAML Content" with a gray Rectangle placeholder when running in the Designer
        if (DesignMode)
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

#if NET8_0_OR_GREATER
    [LibraryImport("user32.dll", EntryPoint = "SendMessageW", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    internal static partial IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
#else
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
#endif

    // Window Messages
    public const int WM_MOVE = (int)WM.MOVE;
    public const int WM_SIZE = (int)WM.SIZE;
    public const int WM_WINDOWPOSCHANGING = (int)WM.WINDOWPOSCHANGING;
    public const int WM_WINDOWPOSCHANGED = (int)WM.WINDOWPOSCHANGED;
    public const int WM_SETFOCUS = (int)WM.SETFOCUS;
    public const int WM_KILLFOCUS = (int)WM.KILLFOCUS;
    public const int WM_KEYDOWN = (int)WM.KEYDOWN;
    public const int WM_KEYUP = (int)WM.KEYUP;
    public const int WM_DPICHANGED_AFTERPARENT = (int)WM.DPICHANGED_AFTERPARENT;

    /// <summary>
    /// Window message values, WM_*
    /// </summary>
    internal enum WM
    {
        NULL = 0x0000,
        CREATE = 0x0001,
        DESTROY = 0x0002,
        MOVE = 0x0003,
        SIZE = 0x0005,
        ACTIVATE = 0x0006,
        SETFOCUS = 0x0007,
        KILLFOCUS = 0x0008,
        ENABLE = 0x000A,
        SETREDRAW = 0x000B,
        SETTEXT = 0x000C,
        GETTEXT = 0x000D,
        GETTEXTLENGTH = 0x000E,
        PAINT = 0x000F,
        CLOSE = 0x0010,
        QUERYENDSESSION = 0x0011,
        QUIT = 0x0012,
        QUERYOPEN = 0x0013,
        ERASEBKGND = 0x0014,
        SYSCOLORCHANGE = 0x0015,
        SHOWWINDOW = 0x0018,
        CTLCOLOR = 0x0019,
        WININICHANGE = 0x001A,
        SETTINGCHANGE = 0x001A,
        ACTIVATEAPP = 0x001C,
        SETCURSOR = 0x0020,
        MOUSEACTIVATE = 0x0021,
        CHILDACTIVATE = 0x0022,
        QUEUESYNC = 0x0023,
        GETMINMAXINFO = 0x0024,

        WINDOWPOSCHANGING = 0x0046,
        WINDOWPOSCHANGED = 0x0047,

        CONTEXTMENU = 0x007B,
        STYLECHANGING = 0x007C,
        STYLECHANGED = 0x007D,
        DISPLAYCHANGE = 0x007E,
        GETICON = 0x007F,
        SETICON = 0x0080,
        NCCREATE = 0x0081,
        NCDESTROY = 0x0082,
        NCCALCSIZE = 0x0083,
        NCHITTEST = 0x0084,
        NCPAINT = 0x0085,
        NCACTIVATE = 0x0086,
        GETDLGCODE = 0x0087,
        SYNCPAINT = 0x0088,
        NCMOUSEMOVE = 0x00A0,
        NCLBUTTONDOWN = 0x00A1,
        NCLBUTTONUP = 0x00A2,
        NCLBUTTONDBLCLK = 0x00A3,
        NCRBUTTONDOWN = 0x00A4,
        NCRBUTTONUP = 0x00A5,
        NCRBUTTONDBLCLK = 0x00A6,
        NCMBUTTONDOWN = 0x00A7,
        NCMBUTTONUP = 0x00A8,
        NCMBUTTONDBLCLK = 0x00A9,

        KEYDOWN = 0x0100,
        KEYUP = 0x0101,
        CHAR = 0x0102,

        SYSKEYDOWN = 0x0104,
        SYSKEYUP = 0x0105,
        SYSCHAR = 0x0106,
        SYSDEADCHAR = 0x0107,
        COMMAND = 0x0111,
        SYSCOMMAND = 0x0112,

        MOUSEMOVE = 0x0200,
        LBUTTONDOWN = 0x0201,
        LBUTTONUP = 0x0202,
        LBUTTONDBLCLK = 0x0203,
        RBUTTONDOWN = 0x0204,
        RBUTTONUP = 0x0205,
        RBUTTONDBLCLK = 0x0206,
        MBUTTONDOWN = 0x0207,
        MBUTTONUP = 0x0208,
        MBUTTONDBLCLK = 0x0209,
        MOUSEWHEEL = 0x020A,
        XBUTTONDOWN = 0x020B,
        XBUTTONUP = 0x020C,
        XBUTTONDBLCLK = 0x020D,
        MOUSEHWHEEL = 0x020E,
        PARENTNOTIFY = 0x0210,

        CAPTURECHANGED = 0x0215,
        POWERBROADCAST = 0x0218,
        DEVICECHANGE = 0x0219,

        ENTERSIZEMOVE = 0x0231,
        EXITSIZEMOVE = 0x0232,

        IME_SETCONTEXT = 0x0281,
        IME_NOTIFY = 0x0282,
        IME_CONTROL = 0x0283,
        IME_COMPOSITIONFULL = 0x0284,
        IME_SELECT = 0x0285,
        IME_CHAR = 0x0286,
        IME_REQUEST = 0x0288,
        IME_KEYDOWN = 0x0290,
        IME_KEYUP = 0x0291,

        NCMOUSELEAVE = 0x02A2,

        TABLET_DEFBASE = 0x02C0,

        // WM_TABLET_MAXOFFSET = 0x20,
        TABLET_ADDED = TABLET_DEFBASE + 8,
        TABLET_DELETED = TABLET_DEFBASE + 9,
        TABLET_FLICK = TABLET_DEFBASE + 11,
        TABLET_QUERYSYSTEMGESTURESTATUS = TABLET_DEFBASE + 12,

        DPICHANGED_AFTERPARENT = 0x02E3,

        CUT = 0x0300,
        COPY = 0x0301,
        PASTE = 0x0302,
        CLEAR = 0x0303,
        UNDO = 0x0304,
        RENDERFORMAT = 0x0305,
        RENDERALLFORMATS = 0x0306,
        DESTROYCLIPBOARD = 0x0307,
        DRAWCLIPBOARD = 0x0308,
        PAINTCLIPBOARD = 0x0309,
        VSCROLLCLIPBOARD = 0x030A,
        SIZECLIPBOARD = 0x030B,
        ASKCBFORMATNAME = 0x030C,
        CHANGECBCHAIN = 0x030D,
        HSCROLLCLIPBOARD = 0x030E,
        QUERYNEWPALETTE = 0x030F,
        PALETTEISCHANGING = 0x0310,
        PALETTECHANGED = 0x0311,
        HOTKEY = 0x0312,
        PRINT = 0x0317,
        PRINTCLIENT = 0x0318,
        APPCOMMAND = 0x0319,
        THEMECHANGED = 0x031A,

        DWMCOMPOSITIONCHANGED = 0x031E,
        DWMNCRENDERINGCHANGED = 0x031F,
        DWMCOLORIZATIONCOLORCHANGED = 0x0320,
        DWMWINDOWMAXIMIZEDCHANGE = 0x0321,

        GETTITLEBARINFOEX = 0x033F,
        DWMSENDICONICTHUMBNAIL = 0x0323,
        DWMSENDICONICLIVEPREVIEWBITMAP = 0x0326,

        USER = 0x0400,

        // This is the hard-coded message value used by WinForms for Shell_NotifyIcon.
        // It's relatively safe to reuse.
        TRAYMOUSEMESSAGE = 0x800, // WM_USER + 1024
        APP = 0x8000,
    }

    /// <summary>
    /// Processes Windows messages for XamlContentHost control window (not XAML window)
    /// </summary>
    /// <param name="m">message to process</param>
    protected override void WndProc(ref Message m)
    {
        if (DesignMode)
        {
            base.WndProc(ref m);
        }

        switch (m.Msg)
        {
            // SetDesktopWindowXamlSourceWindowPos must always be called after base.WndProc
            case /*NativeDefines.*/WM_MOVE:
            case /*NativeDefines.*/WM_SIZE:
            case /*NativeDefines.*/WM_WINDOWPOSCHANGED:
                base.WndProc(ref m);
                SetDesktopWindowXamlSourceWindowPos();

                IntPtr CoreWindowHandle =
                    CoreWindow.GetForCurrentThread()/*.GetInterop()*/.GetWindowHandle();
                Message CurrentMessage = m;

                // Use Delay execution for improving the resizing for ContentDialogs.
                Task.Delay(200).ContinueWith(t =>
                {
                    // Reference: https://github.com/microsoft/microsoft-ui-xaml
                    //            /issues/3577
                    // ContentDialogs don't resize themselves when the XAML island
                    // resizes. However, if we manually resize our CoreWindow, that'll
                    // actually trigger a resize of the ContentDialog.
                    SendMessage(
                        CoreWindowHandle,
                        CurrentMessage.Msg,
                        CurrentMessage.WParam,
                        CurrentMessage.LParam);
                });

               
                break;

            // BUGBUG: Focus integration with Windows.UI.Xaml.Hosting.XamlSourceFocusNavigation is
            // skipping over nested elements. Update or move back to Windows.Xaml.Input.FocusManager.
            // WM_SETFOCUS should not be handled directly. MS Internal: DesktopWindowXamlSource.NavigateFocus
            // non-directional Focus not moving Focus, not responding to keyboard input.
            case /*NativeDefines.*/WM_SETFOCUS:
                // BUGBUG: Work-around internal aggressive FAILFAST bug.  Remove this when #19043466 or nested element support is fixed.
                if (m.WParam != m.HWnd)
                {
                    // Temporarily drop some WM_SETFOCUS messages to prevent calling Focus on Focused element.  An
                    // unnecessary Focus operation may trigger a FAILFAST inside UWP XAML's DesktopWindowXamlSource.
                    return;
                }

                if (/*UnsafeNativeMethods.IntSetFocus(_xamlIslandWindowHandle)*/WindowFocus.SetFocus(new Win32Window(_xamlIslandWindowHandle)).Handle == /*System.IntPtr*/nint.Zero)
                {
                    throw new global::System.InvalidOperationException($"{nameof(WindowsXamlHostBase)}::{nameof(WndProc)}: Failed to SetFocus on UWP XAML window");
                }

                base.WndProc(ref m);
                break;

            case /*NativeDefines.*/WM_KILLFOCUS:
                // If focus is being set on the UWP XAML island window then we should prevent LostFocus by
                // handling this message.
                if (_xamlIslandWindowHandle != IntPtr.Zero || _xamlIslandWindowHandle != m.WParam || _xamlSource.HasFocus)
                {
                    base.WndProc(ref m);
                }

                break;

            case /*NativeDefines.*/WM_DPICHANGED_AFTERPARENT:
                if (_xamlIslandWindowHandle != IntPtr.Zero)
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
