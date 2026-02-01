using System.Runtime.InteropServices;
using Windows.UI.Core;

namespace NeonWindows.ABI.UI.Modern.Core;

/// <summary>
/// 使应用能够获取窗口 (与此接口关联的 <see cref="CoreWindow"/>) 的窗口句柄。
/// </summary>
[Guid(WinRTCoreUIComGuid.IID_ICoreWindowInterop)]
public partial interface ICoreWindowInterop
{
    /// <summary>
    /// 获取应用的 <see cref="CoreWindow"/> 窗口句柄 (HWND) 。
    /// </summary>
    /// <returns><see cref="CoreWindow"/> 的窗口句柄。</returns>
    nint GetWindowHandle();

    /// <summary>
    /// 设置是否已处理到 <see cref="CoreWindow"/> 的消息。
    /// </summary>
    /// <param name="messageHandled">标志该消息是否已被处理。</param>
    void SetMessageHandled([MarshalAs(UnmanagedType.Bool)] bool messageHandled);
}
