using NeonWindows.ABI.UI.Modern.Xaml.Hosting;
using Windows.UI.Xaml.Hosting;
using WinRT;

namespace NeonWindows.UI.Modern.Xaml.Hosting;

public static class DesktopWindowXamlSourceNative
{
    public static void AttachToWindow(this DesktopWindowXamlSource windowXamlSource, nint parentWnd)
        => windowXamlSource.As<IDesktopWindowXamlSourceNative>().AttachToWindow(parentWnd);

    public static nint GetWindowHandle(this DesktopWindowXamlSource windowXamlSource)
        => windowXamlSource.As<IDesktopWindowXamlSourceNative>().GetWindowHandle();
}
