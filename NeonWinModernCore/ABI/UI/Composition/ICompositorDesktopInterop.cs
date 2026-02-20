using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace NeonWindows.ABI.UI.Composition;

[GeneratedComInterface]
[Guid(WinRTUICompComGuid.IID_ICompositorDesktopInterop)]
public partial interface ICompositorDesktopInterop
{
    void CreateDesktopWindowTarget(nint hwndTarget, [MarshalAs(UnmanagedType.Bool)] bool isTopmost, out nint test);
}
