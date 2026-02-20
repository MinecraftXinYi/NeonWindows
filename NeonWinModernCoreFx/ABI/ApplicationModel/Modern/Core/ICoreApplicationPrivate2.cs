using System.Runtime.InteropServices;

namespace NeonWindows.ABI.ApplicationModel.Modern.Core;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
[Guid(WinRTCoreAppComGuid.IID_ICoreApplicationPrivate2)]
public interface ICoreApplicationPrivate2
{
    [PreserveSig]
    int InitializeForAttach();

    [PreserveSig]
    int WaitForActivate(out nint pCoreWindow);

    [PreserveSig]
    int CreateNonImmersiveView(out nint pCoreApplicationView);
}
