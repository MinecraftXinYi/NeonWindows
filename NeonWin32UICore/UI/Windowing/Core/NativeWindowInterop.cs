using System.Drawing;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Windowing.Core;

public static class NativeWindowInterop
{
    public static void ShowWindow(nint window, int nCmdShow)
        => PInvoke.ShowWindowAsync(new(window), (SHOW_WINDOW_CMD)nCmdShow);

    public static void ActivateWindow(nint window)
        => PInvoke.SetActiveWindow(new(window));

    public static void SetFocus(nint window)
        => PInvoke.SetFocus(new(window));

    public static bool IsWindowVisible(nint window)
        => PInvoke.IsWindowVisible(new(window));

    public static string GetWindowTitle(nint window)
    {
        HWND hwnd = new(window);
        char[] buffer = new char[PInvoke.GetWindowTextLength(hwnd)];
        PInvoke.GetWindowText(hwnd, buffer);
        return new(buffer);
    }

    public static void SetWindowTitle(nint window, string title)
        => PInvoke.SetWindowText(new(window), title);

    public static Rectangle GetWindowRect(nint window)
    {
        PInvoke.GetWindowRect(new(window), out RECT rect);
        return (Rectangle)rect;
    }

    public static Rectangle GetClientRect(nint window)
    {
        PInvoke.GetClientRect(new(window), out RECT rect);
        return (Rectangle)rect;
    }

    public static void SetWindowRect(nint window, nint windowInsertAfter, Rectangle rect, uint flags)
        => PInvoke.SetWindowPos(new(window), new(windowInsertAfter), rect.X, rect.Y, rect.Width, rect.Height, (SET_WINDOW_POS_FLAGS)flags);
}
