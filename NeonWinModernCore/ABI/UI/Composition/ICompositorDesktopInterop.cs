using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Composition;

[Guid(WinRTUICompComGuid.IID_ICompositorDesktopInterop)]
public partial interface ICompositorDesktopInterop
{
    void CreateDesktopWindowTarget(nint hwndTarget, [MarshalAs(UnmanagedType.Bool)] bool isTopmost, out nint test);
}
