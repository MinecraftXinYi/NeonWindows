using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using WinRT;

namespace NeonWindows.ABI.UI.Modern.Core;

[GeneratedComInterface]
[Guid(WinRTCoreUIComGuid.IID_ITextInputConsumer)]
public partial interface ITextInputConsumer
{
    [PreserveSig]
    internal int GetIids(out ulong iidCount, out nint iids);

    [PreserveSig]
    internal int GetRuntimeClassName(out nint className);

    [PreserveSig]
    internal int GetTrustLevel(out TrustLevel trustLevel);

    [PreserveSig]
    int GetTextInputProducer(out nint pTextInputProducer);

    [PreserveSig]
    int SetTextInputProducer(nint pTextInputProducer);
}
