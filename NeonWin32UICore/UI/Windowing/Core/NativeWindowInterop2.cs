using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Windowing.Core;

public static class NativeWindowInterop2
{
    public static int GetWindowStyle(nint window)
        => PInvoke.GetWindowLong(new(window), WINDOW_LONG_PTR_INDEX.GWL_STYLE);

    public static int SetWindowStyle(nint window, int style)
        => PInvoke.SetWindowLong(new(window), WINDOW_LONG_PTR_INDEX.GWL_STYLE, style);

    public static void SetWindowParent(nint window, nint windowParent)
        => PInvoke.SetParent(new(window), new(windowParent));
}
