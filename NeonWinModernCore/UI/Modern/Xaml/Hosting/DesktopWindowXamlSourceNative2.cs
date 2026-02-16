using NeonWindows.ABI.UI.Modern.Xaml.Hosting;
using Windows.UI.Xaml.Hosting;
using WinRT;

namespace NeonWindows.UI.Modern.Xaml.Hosting;

public unsafe static class DesktopWindowXamlSourceNative2
{
    public static bool PreTranslateMessage(this DesktopWindowXamlSource windowXamlSource, void* message)
        => windowXamlSource.As<IDesktopWindowXamlSourceNative2>().PreTranslateMessage(message);
}
