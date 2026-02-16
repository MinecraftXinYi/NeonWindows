using System.Runtime.InteropServices;
using WinRT;

namespace NeonWindows.ABI.ApplicationModel.Modern.Core;

[Guid(WinRTCoreAppComGuid.IID_ICoreApplicationPrivate2)]
public partial interface ICoreApplicationPrivate2
{
    [PreserveSig]
    internal int GetIids(out ulong iidCount, out nint iids);

    [PreserveSig]
    internal int GetRuntimeClassName(out nint className);

    [PreserveSig]
    internal int GetTrustLevel(out TrustLevel trustLevel);

    [PreserveSig]
    int InitializeForAttach();

    [PreserveSig]
    int WaitForActivate(out nint pCoreWindow);

    [PreserveSig]
    int CreateNonImmersiveView(out nint pCoreApplicationView);
}
