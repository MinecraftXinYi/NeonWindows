using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Composition;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(WinRTUICompComGuid.IID_ICompositorDesktopInterop)]
public interface ICompositorDesktopInterop
{
    void CreateDesktopWindowTarget(nint hwndTarget, [MarshalAs(UnmanagedType.Bool)] bool isTopmost, out nint test);
}
