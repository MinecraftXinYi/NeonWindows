using NeonWindows.ABI.UI.Modern.Core;
using Windows.UI.Core;
using WinRT;

namespace NeonWindows.UI.Modern.Core;

/// <summary>
/// 提供 <see cref="CoreWindow"/> 与 Win32 底层的互操作功能。
/// </summary>
public static class CoreWindowInterop
{
    /// <summary>
    /// 获取应用的 <see cref="CoreWindow"/> 窗口句柄 (HWND) 。
    /// </summary>
    /// <param name="coreWindow">要检索句柄的 <see cref="CoreWindow"/> 。</param>
    /// <returns><see cref="CoreWindow"/> 的窗口句柄。</returns>
    public static nint GetWindowHandle(this CoreWindow coreWindow)
        => coreWindow.As<ICoreWindowInterop>().GetWindowHandle();

    /// <summary>
    /// 设置是否已处理到 <see cref="CoreWindow"/> 的消息。
    /// </summary>
    /// <param name="coreWindow">处理的窗口消息的 <see cref="CoreWindow"/> 。</param>
    /// <param name="messageHandled">标志该消息是否已被处理。</param>
    public static void SetMessageHandled(this CoreWindow coreWindow, bool messageHandled)
        => coreWindow.As<ICoreWindowInterop>().SetMessageHandled(messageHandled);
}
