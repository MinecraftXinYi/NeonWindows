using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Windows.UI.Xaml.Hosting;

namespace NeonWindows.ABI.UI.Modern.Xaml.Hosting;

/// <summary>
/// 提供可用于将承载 WinRT XAML 控件的 <see cref="DesktopWindowXamlSource"/> 对象附加到桌面应用中的父 UI 元素的成员。
/// </summary>
[GeneratedComInterface]
[Guid(WinRTXamlHostComGuid.IID_IDesktopWindowXamlSourceNative)]
public partial interface IDesktopWindowXamlSourceNative
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
}
