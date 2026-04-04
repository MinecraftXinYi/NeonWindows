using System;
using System.Runtime.InteropServices.Marshalling;

namespace NeonWindows.ABI.UI.Modern.Core;

public unsafe static class MarshalITextInputConsumer
{
    public static nint GetAbi(this ITextInputConsumer managed)
    {
        ArgumentNullException.ThrowIfNull(managed);
        return (nint)ComInterfaceMarshaller<ITextInputConsumer>.ConvertToUnmanaged(managed);
    }
}
