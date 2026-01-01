using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Modern.Core;

public unsafe static class CoreWindowNativeApi
{
    /// <summary>
    /// 在调用方线程中创建 CoreWindow 对象。
    /// </summary>
    /// <param name="WindowType">CoreWindow 窗口类型。</param>
    /// <param name="WindowTitle">窗口标题。</param>
    /// <param name="X">窗口的初始水平位置。</param>
    /// <param name="Y">窗口的初始垂直位置。</param>
    /// <param name="uWidth">窗口的宽度。</param>
    /// <param name="uHeight">窗口的高度。</param>
    /// <param name="dwAttributes">未知参数，应填 0。</param>
    /// <param name="hOwnerWindow">正在创建的窗口的父窗口或所有者窗口的句柄。</param>
    /// <param name="riid">对象的接口 ID。必须设置为 ICoreWindow 的 UUID，CoreWindow 的默认接口。</param>
    /// <param name="pCoreWindow">CoreWindow 对象的指针。</param>
    /// <returns>**HRESULT**</returns>
    public static int PrivateCreateCoreWindow(WINDOW_TYPE WindowType, string WindowTitle, int X, int Y, uint uWidth, uint uHeight, uint dwAttributes, nint hOwnerWindow, Guid riid, out nint pCoreWindow)
    {
        fixed (nint* ppv = &pCoreWindow)
        fixed (char* pWindowTitle = WindowTitle)
            return PrivateCreateCoreWindow(WindowType, pWindowTitle, X, Y, uWidth, uHeight, dwAttributes, hOwnerWindow, riid, ppv);
    }

    /// <summary>
    /// 在调用方线程中创建 CoreWindow 对象。
    /// </summary>
    /// <param name="WindowType">CoreWindow 窗口类型。</param>
    /// <param name="pWindowTitle">窗口标题。</param>
    /// <param name="X">窗口的初始水平位置。</param>
    /// <param name="Y">窗口的初始垂直位置。</param>
    /// <param name="uWidth">窗口的宽度。</param>
    /// <param name="uHeight">窗口的高度。</param>
    /// <param name="dwAttributes">未知参数，应填 0。</param>
    /// <param name="hOwnerWindow">正在创建的窗口的父窗口或所有者窗口的句柄。</param>
    /// <param name="riid">对象的接口 ID。必须设置为 ICoreWindow 的 UUID，CoreWindow 的默认接口。</param>
    /// <param name="ppv">用于接收 CoreWindow 对象的指针。</param>
    /// <returns>**HRESULT**</returns>
    [DllImport(WinRTDllName.WindowsUI, EntryPoint = "#1500")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern int PrivateCreateCoreWindow(WINDOW_TYPE WindowType, char* pWindowTitle, int X, int Y, uint uWidth, uint uHeight, uint dwAttributes, nint hOwnerWindow, Guid riid, nint* ppv);
}
