using NeonWindows.ABI.UI.Modern.Xaml;
using System.Runtime.InteropServices;
using Windows.UI.Xaml;

namespace NeonWindows.UI.Modern.Xaml;

public static class XamlWindowControl
{
    public static void Show(this Window window)
        => Marshal.ThrowExceptionForHR(((IWindowPrivate)(object)window).Show());

    public static void Hide(this Window window)
        => Marshal.ThrowExceptionForHR(((IWindowPrivate)(object)window).Hide());

    public static void MoveWindow(this Window window, int x, int y, int width, int height)
        => Marshal.ThrowExceptionForHR(((IWindowPrivate)(object)window).MoveWindow(x, y, width, height));
}
