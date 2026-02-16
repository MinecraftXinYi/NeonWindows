using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Modern;

[Guid(CoreUIWin32InteropComGuid.IID_IInitializeWithWindow)]
public partial interface IInitializeWithWindow
{
    /// <summary>
    /// 指定桌面应用中使用的 Windows 运行时 (WinRT) 对象要使用的所有者窗口。
    /// </summary>
    /// <param name="hwnd">要用作所有者窗口的窗口的句柄。</param>
    void Initialize(nint hwnd);
}
