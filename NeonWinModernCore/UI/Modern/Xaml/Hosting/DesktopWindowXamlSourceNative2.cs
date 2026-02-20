using NeonWindows.ABI.UI.Modern.Xaml.Hosting;
using Windows.UI.Xaml.Hosting;
using WinRT;

namespace NeonWindows.UI.Modern.Xaml.Hosting;

/// <summary>
/// 提供一种方法，使 WinRT XAML 框架能够处理承载 WinRT XAML 控件的 <see cref="DesktopWindowXamlSource"/> 对象的 Windows 消息。
/// </summary>
public unsafe static class DesktopWindowXamlSourceNative2
{
    /// <summary>
    /// 使 WinRT XAML 框架能够处理托管 WinRT XAML 控件的 <see cref="DesktopWindowXamlSource"/> 对象的 Windows 消息。
    /// </summary>
    /// <param name="windowXamlSource">要操作的 <see cref="DesktopWindowXamlSource"/> 实例。</param>
    /// <param name="message">要处理的 Windows 消息。</param>
    /// <returns>如果消息已处理，则为 true；否则为 false。</returns>
    public static bool PreTranslateMessage(this DesktopWindowXamlSource windowXamlSource, void* message)
        => windowXamlSource.As<IDesktopWindowXamlSourceNative2>().PreTranslateMessage(message);
}
