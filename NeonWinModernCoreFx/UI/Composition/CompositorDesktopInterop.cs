using NeonWindows.ABI.UI.Composition;
using System.Runtime.InteropServices;
using Windows.UI.Composition;
using Windows.UI.Composition.Desktop;

namespace NeonWindows.UI.Composition;

/// <summary>
/// 提供 UWP 可视化层与传统 Win32 应用模型的互操作功能。
/// </summary>
public static class CompositorDesktopInterop
{
    /// <summary>
    /// 为指定的 <see cref="Compositor"/> 和 Win32 窗口创建 <see cref="DesktopWindowTarget"/> 。
    /// </summary>
    /// <param name="compositor">要创建 <see cref="DesktopWindowTarget"/> 的 <see cref="Compositor"/> 实例。</param>
    /// <param name="hwndTarget">Win32 窗口句柄。</param>
    /// <param name="isTopmost">指示是否在其他渲染内容的上层显示。</param>
    /// <returns>创建的 <see cref="DesktopWindowTarget"/> 。</returns>
    public static DesktopWindowTarget CreateDesktopWindowTarget(this Compositor compositor, nint hwndTarget, bool isTopmost)
    {
        ((ICompositorDesktopInterop)(object)compositor).CreateDesktopWindowTarget(hwndTarget, isTopmost, out nint pDesktopWindowTarget);
        return (DesktopWindowTarget)Marshal.GetObjectForIUnknown(pDesktopWindowTarget);
    }
}
