using System;
using System.Runtime.InteropServices;
using WinRT;

namespace NeonWindows.ABI.UI.Modern.Core;

[Guid(WinRTCoreUIComGuid.IID_IInternalCoreDispatcherStatic)]
public partial interface IInternalCoreDispatcherStatic
{
    [PreserveSig]
    internal int GetIids(out ulong iidCount, out nint iids);

    [PreserveSig]
    internal int GetRuntimeClassName(out nint className);

    [PreserveSig]
    internal int GetTrustLevel(out TrustLevel trustLevel);

    [PreserveSig]
    int GetForCurrentThread(out nint pDispatcher);

    [PreserveSig]
    int GetOrCreateForCurrentThread(out nint pDispatcher);
}
