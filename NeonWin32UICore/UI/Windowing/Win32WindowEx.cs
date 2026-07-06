using NeonWindows.UI.Messaging.Core;
using NeonWindows.UI.Windowing.Core;
using System.Drawing;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Windowing;

public static class Win32WindowEx
{
    extension (IWin32Window window)
    {
        public bool IsVisible
            => NativeWindowInterop.IsWindowVisible(window.Handle);

        public Point Position
        {
            get
            {
                Rectangle rect = NativeWindowInterop.GetWindowRect(window.Handle);
                return new(rect.X, rect.Y);
            }
        }

        public Size Size
        {
            get
            {
                Rectangle rect = NativeWindowInterop.GetWindowRect(window.Handle);
                return new(rect.Width, rect.Height);
            }
        }

        public Size ClientSize
        {
            get
            {
                Rectangle rect = NativeWindowInterop.GetClientRect(window.Handle);
                return new(rect.Width, rect.Height);
            }
        }

        public string Title
        {
            get => NativeWindowInterop.GetWindowTitle(window.Handle);
            set => NativeWindowInterop.SetWindowTitle(window.Handle, value);
        }
    }

    public static void Show(this IWin32Window window, bool activate = true)
        => NativeWindowInterop.ShowWindow(window.Handle, activate ? (int)SHOW_WINDOW_CMD.SW_SHOW : (int)SHOW_WINDOW_CMD.SW_SHOWNA);

    public static void Hide(this IWin32Window window)
        => NativeWindowInterop.ShowWindow(window.Handle, (int)SHOW_WINDOW_CMD.SW_HIDE);

    public static void Activate(this IWin32Window window)
        => NativeWindowInterop.ActivateWindow(window.Handle);

    public static void SetFocus(this IWin32Window window)
        => NativeWindowInterop.SetFocus(window.Handle);

    public static void Move(this IWin32Window window, Point position)
        => NativeWindowInterop.SetWindowRect(window.Handle, default, new(position, default), (uint)(SET_WINDOW_POS_FLAGS.SWP_NOSIZE | SET_WINDOW_POS_FLAGS.SWP_NOACTIVATE));

    public static void Resize(this IWin32Window window, Size size)
        => NativeWindowInterop.SetWindowRect(window.Handle, default, new(default, size), (uint)(SET_WINDOW_POS_FLAGS.SWP_NOMOVE | SET_WINDOW_POS_FLAGS.SWP_NOACTIVATE));

    public static void MoveAndResize(this IWin32Window window, Rectangle rect)
        => NativeWindowInterop.SetWindowRect(window.Handle, default, rect, (uint)SET_WINDOW_POS_FLAGS.SWP_NOACTIVATE);

    public static void MoveInZOrderAtBottom(this IWin32Window window)
        => NativeWindowInterop.SetWindowRect(window.Handle, HWND.HWND_BOTTOM, default, (uint)(SET_WINDOW_POS_FLAGS.SWP_NOMOVE | SET_WINDOW_POS_FLAGS.SWP_NOSIZE | SET_WINDOW_POS_FLAGS.SWP_NOACTIVATE));

    public static void MoveInZOrderAtTop(this IWin32Window window)
        => NativeWindowInterop.SetWindowRect(window.Handle, HWND.HWND_TOP, default, (uint)(SET_WINDOW_POS_FLAGS.SWP_NOMOVE | SET_WINDOW_POS_FLAGS.SWP_NOSIZE));

    public static void MoveInZOrderBelow(this IWin32Window window, IWin32Window windowInsertAfter)
        => NativeWindowInterop.SetWindowRect(window.Handle, windowInsertAfter.Handle, default, (uint)(SET_WINDOW_POS_FLAGS.SWP_NOMOVE | SET_WINDOW_POS_FLAGS.SWP_NOSIZE | SET_WINDOW_POS_FLAGS.SWP_NOACTIVATE));

    public static void SetIcon(this IWin32Window window, nint hIcon)
    {
        NativeWindowMessage.SendWindowMessage(window.Handle, PInvoke.WM_SETICON, PInvoke.ICON_SMALL, hIcon);
        NativeWindowMessage.SendWindowMessage(window.Handle, PInvoke.WM_SETICON, PInvoke.ICON_BIG, hIcon);
    }

    public static void SetIcon(this IWin32Window window, nint hIconSmall, nint hIconBig)
    {
        NativeWindowMessage.SendWindowMessage(window.Handle, PInvoke.WM_SETICON, PInvoke.ICON_SMALL, hIconSmall);
        NativeWindowMessage.SendWindowMessage(window.Handle, PInvoke.WM_SETICON, PInvoke.ICON_BIG, hIconBig);
    }
}
