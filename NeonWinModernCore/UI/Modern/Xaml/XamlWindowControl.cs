using NeonWindows.ABI.UI.Modern.Xaml;
using Windows.UI.Xaml;
using WinRT;

namespace NeonWindows.UI.Modern.Xaml;

public static class XamlWindowControl
{
    public static void Show(this Window window)
        => ExceptionHelpers.ThrowExceptionForHR(window.As<IWindowPrivate>().Show());

    public static void Hide(this Window window)
        => ExceptionHelpers.ThrowExceptionForHR(window.As<IWindowPrivate>().Hide());

    public static void MoveWindow(this Window window, int x, int y, int width, int height)
        => ExceptionHelpers.ThrowExceptionForHR(window.As<IWindowPrivate>().MoveWindow(x, y, width, height));
}
