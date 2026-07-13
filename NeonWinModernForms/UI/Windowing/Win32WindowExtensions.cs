using System.Drawing;
using System.Windows.Forms;
using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Windowing;

public static class Win32WindowExtensions
{
    public static int GetLong(this IWin32Window window, int index)
        => PInvoke.GetWindowLong(new(window.Handle), (WINDOW_LONG_PTR_INDEX)index);

    public static void SetLong(this IWin32Window window, int index, int newLong)
        => PInvoke.SetWindowLong(new(window.Handle), (WINDOW_LONG_PTR_INDEX)index, newLong);

    public static bool SetParent(this IWin32Window window, IWin32Window parent)
        => !PInvoke.SetParent(new(window.Handle), new(parent.Handle)).IsNull;

    public static bool SetRectangle(this IWin32Window window, Rectangle rectangle)
        => PInvoke.SetWindowPos(new(window.Handle), default, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, SET_WINDOW_POS_FLAGS.SWP_NOZORDER);

    public static bool SetTitle(this IWin32Window window, string title)
        => PInvoke.SetWindowText(new(window.Handle), title);

    public static bool ShowAsync(this IWin32Window window, bool activate = true)
        => PInvoke.ShowWindowAsync(new(window.Handle), activate ? SHOW_WINDOW_CMD.SW_SHOW : SHOW_WINDOW_CMD.SW_SHOWNOACTIVATE);

    public static bool UpdateLong(this IWin32Window window)
        => PInvoke.SetWindowPos(new(window.Handle), default, 0, 0, 0, 0, SET_WINDOW_POS_FLAGS.SWP_FRAMECHANGED | SET_WINDOW_POS_FLAGS.SWP_NOACTIVATE | SET_WINDOW_POS_FLAGS.SWP_NOMOVE | SET_WINDOW_POS_FLAGS.SWP_NOSIZE | SET_WINDOW_POS_FLAGS.SWP_NOZORDER);
}
