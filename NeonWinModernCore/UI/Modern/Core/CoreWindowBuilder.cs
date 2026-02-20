using NeonWindows.ABI.UI.Modern.Core;
using Windows.Graphics;
using Windows.UI.Core;
using WinRT;

namespace NeonWindows.UI.Modern.Core;

/// <summary>
/// 提供创建 <see cref="CoreWindow"/> 的功能。
/// </summary>
public static class CoreWindowBuilder
{
    /// <summary>
    /// 为当前线程创建 ImmersiveHosted 类型的 <see cref="CoreWindow"/> 。
    /// </summary>
    /// <param name="title">窗口标题。</param>
    /// <param name="rect">窗口的初始位置和大小。</param>
    /// <param name="hOwnerWindow">该窗口的所有者窗口句柄。</param>
    /// <returns>创建的 <see cref="CoreWindow"/> 。</returns>
    public static CoreWindow CreateImmersiveHostedCoreWindow(string title, RectInt32 rect, nint hOwnerWindow)
        => CreateCoreWindowInternal(WINDOW_TYPE.IMMERSIVE_HOSTED, title, rect, hOwnerWindow);

    /// <summary>
    /// 为当前线程创建 NotImmersive 类型的 <see cref="CoreWindow"/> 。
    /// </summary>
    /// <param name="title">窗口标题。</param>
    /// <param name="rect">窗口的初始位置和大小。</param>
    /// <param name="hOwnerWindow">该窗口的所有者窗口句柄。</param>
    /// <returns>创建的 <see cref="CoreWindow"/> 。</returns>
    public static CoreWindow CreateNotImmersiveCoreWindow(string title, RectInt32 rect, nint hOwnerWindow)
        => CreateCoreWindowInternal(WINDOW_TYPE.NOT_IMMERSIVE, title, rect, hOwnerWindow);

    private static CoreWindow CreateCoreWindowInternal(WINDOW_TYPE type, string title, RectInt32 rect, nint hOwnerWindow)
    {
        ExceptionHelpers.ThrowExceptionForHR(CoreUICoreWindowApi.PrivateCreateCoreWindow(type, title, rect.X, rect.Y, (uint)rect.Width, (uint)rect.Height,
            0, hOwnerWindow, typeof(ICoreWindow).GUID, out nint pCoreWindow));
        return CoreWindow.FromAbi(pCoreWindow);
    }
}
