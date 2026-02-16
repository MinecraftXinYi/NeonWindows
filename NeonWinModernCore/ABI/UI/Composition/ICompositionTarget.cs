using System;
using System.Runtime.InteropServices;
using WinRT;

namespace NeonWindows.ABI.UI.Composition;

[Guid(WinRTUICompComGuid.IID_ICompositionTarget)]
public partial interface ICompositionTarget
{
    [PreserveSig]
    internal int GetIids(out ulong iidCount, out nint iids);

    [PreserveSig]
    internal int GetRuntimeClassName(out nint className);

    [PreserveSig]
    internal int GetTrustLevel(out TrustLevel trustLevel);

    [PreserveSig]
    int GetRoot(out nint pRoot);

    [PreserveSig]
    int SetRoot(nint pRoot);
}
