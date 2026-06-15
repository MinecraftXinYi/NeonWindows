using System.Drawing;
using System.Windows.Forms;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Windowing.Core;

public static class Win32WindowInterop
{
    public static void ShowWindow(this IWin32Window window, int nCmdShow)
        => PInvoke.ShowWindowAsync(new(window.Handle), (SHOW_WINDOW_CMD)nCmdShow);

    public static string GetWindowTitle(this IWin32Window window)
    {
        HWND hwnd = new(window.Handle);
        char[] buffer = new char[PInvoke.GetWindowTextLength(hwnd)];
        PInvoke.GetWindowText(hwnd, buffer);
        return new(buffer);
    }

    public static void SetWindowTitle(this IWin32Window window, string title)
        => PInvoke.SetWindowText(new(window.Handle), title);

    public static Rectangle GetWindowRect(this IWin32Window window)
    {
        PInvoke.GetWindowRect(new(window.Handle), out RECT rect);
        return (Rectangle)rect;
    }

    public static Rectangle GetWindowClientRect(this IWin32Window window)
    {
        PInvoke.GetClientRect(new(window.Handle), out RECT rect);
        return (Rectangle)rect;
    }

    public static void SetWindowRect(this IWin32Window window, Rectangle rect, uint flags)
        => PInvoke.SetWindowPos(new(window.Handle), default, rect.X, rect.Y, rect.Width, rect.Height, (SET_WINDOW_POS_FLAGS)flags);

    public static void SetWindowRect(this IWin32Window window, IWin32Window windowInsertAfter, Rectangle rect, uint flags)
        => PInvoke.SetWindowPos(new(window.Handle), new(windowInsertAfter.Handle), rect.X, rect.Y, rect.Width, rect.Height, (SET_WINDOW_POS_FLAGS)flags);

    public static void ActivateWindow(this IWin32Window window)
        => PInvoke.SetActiveWindow(new(window.Handle));

    public static void SetFocus(this IWin32Window window)
        => PInvoke.SetFocus(new(window.Handle));
}
