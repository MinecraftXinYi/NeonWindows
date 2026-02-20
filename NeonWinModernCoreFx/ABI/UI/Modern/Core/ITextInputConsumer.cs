using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Modern.Core;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
[Guid(WinRTCoreUIComGuid.IID_ITextInputConsumer)]
public interface ITextInputConsumer
{
    [PreserveSig]
    int GetTextInputProducer(out nint pTextInputProducer);

    [PreserveSig]
    int SetTextInputProducer(nint pTextInputProducer);
}
