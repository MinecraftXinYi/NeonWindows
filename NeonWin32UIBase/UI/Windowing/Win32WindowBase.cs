using System.Drawing;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Windowing;

public unsafe abstract class Win32WindowBase
{
    public abstract nint Handle { get; }

    internal HWND HWnd => (HWND)Handle;

    public Rectangle Rect
    {
        get
        {
            PInvoke.GetWindowRect(HWnd, out RECT rect);
            return new(rect.X, rect.Y, rect.Width, rect.Height);
        }
        set
        {
            PInvoke.SetWindowPos(HWnd, default, value.Left, value.Top, value.Right, value.Bottom,
                SET_WINDOW_POS_FLAGS.SWP_NOZORDER | SET_WINDOW_POS_FLAGS.SWP_SHOWWINDOW);
        }
    }

    public Point Position
    {
        get
        {
            Rectangle rect = Rect;
            return new(rect.Left, rect.Top);
        }
        set
        {
            PInvoke.SetWindowPos(HWnd, default, value.X, value.Y, 0, 0,
                SET_WINDOW_POS_FLAGS.SWP_NOSIZE | SET_WINDOW_POS_FLAGS.SWP_NOZORDER | SET_WINDOW_POS_FLAGS.SWP_SHOWWINDOW);
        }
    }

    public Size Size
    {
        get
        {
            Rectangle rect = Rect;
            return new(rect.Right, rect.Bottom);
        }
        set
        {
            PInvoke.SetWindowPos(HWnd, default, 0, 0, value.Width, value.Height,
                SET_WINDOW_POS_FLAGS.SWP_NOMOVE | SET_WINDOW_POS_FLAGS.SWP_NOZORDER | SET_WINDOW_POS_FLAGS.SWP_SHOWWINDOW);
        }
    }

    public Rectangle ClientRect
    {
        get
        {
            PInvoke.GetClientRect(HWnd, out RECT rect);
            return new(rect.X, rect.Y, rect.Width, rect.Height);
        }
    }

    public Size ClientSize
    {
        get
        {
            Rectangle rect = ClientRect;
            return new(rect.Right, rect.Bottom);
        }
    }

    public Point ClientPosition
    {
        get
        {
            Rectangle rect = ClientRect;
            return new(rect.Left, rect.Top);
        }
    }

    public Point Center
    {
        get
        {
            PInvoke.GetWindowRect(HWnd, out var rect);
            return new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
        }
    }

    public float AspectRatio
    {
        get
        {
            Size size = ClientSize;
            return size.Width / (float)size.Height;
        }
    }

    public string Title
    {
        get
        {
            int length = PInvoke.GetWindowTextLength(HWnd) + 1;
            char[] text = new char[length];
            fixed (char* pText = text)
            {
                PInvoke.GetWindowText(HWnd, pText, length);
                return new(pText);
            }
        }
        set
        {
            fixed (char* pText = value)
            {
                PInvoke.SetWindowText(HWnd, pText);
            }
        }
    }

    public void Show()
        => PInvoke.ShowWindow(HWnd, SHOW_WINDOW_CMD.SW_SHOW);

    public void ShowAsync()
        => PInvoke.ShowWindowAsync(HWnd, SHOW_WINDOW_CMD.SW_SHOW);
}
