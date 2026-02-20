using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Windows.UI.Xaml.Hosting;

namespace NeonWindows.ABI.UI.Modern.Xaml.Hosting;

/// <summary>
/// 提供一种方法，使 WinRT XAML 框架能够处理承载 WinRT XAML 控件的 <see cref="DesktopWindowXamlSource"/> 对象的 Windows 消息。
/// </summary>
[GeneratedComInterface]
[Guid(WinRTXamlHostComGuid.IID_IDesktopWindowXamlSourceNative2)]
public unsafe partial interface IDesktopWindowXamlSourceNative2
{
    /// <summary>
    /// 将 <see cref="DesktopWindowXamlSource"/> 实例附加到桌面应用中与窗口句柄关联的父 UI 元素。
    /// </summary>
    /// <param name="parentWnd">要在其中托管 WinRT XAML 控件的父 UI 元素的窗口句柄。</param>
    void AttachToWindow(nint parentWnd);

    /// <summary>
    /// 获取与 <see cref="DesktopWindowXamlSource"/> 实例关联的父 UI 元素的窗口句柄。
    /// </summary>
    /// <returns>与 <see cref="DesktopWindowXamlSource"/> 实例关联的父 UI 元素的窗口句柄。</returns>
    nint GetWindowHandle();

    /// <summary>
    /// 使 WinRT XAML 框架能够处理托管 WinRT XAML 控件的 <see cref="DesktopWindowXamlSource"/> 对象的 Windows 消息。
    /// </summary>
    /// <param name="message">要处理的 Windows 消息。</param>
    /// <returns>如果消息已处理，则为 True；否则为 false。</returns>
    [return: MarshalAs(UnmanagedType.Bool)] bool PreTranslateMessage(void* message);
}
