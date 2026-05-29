using System.Runtime.InteropServices.Marshalling;

namespace NeonWindows.ABI.UI.Modern.Core;

public unsafe static class MarshalTextInputConsumer
{
    public static nint ToUnmanaged(this ITextInputConsumer managed)
        => (nint)ComInterfaceMarshaller<ITextInputConsumer>.ConvertToUnmanaged(managed);

    public static void CopyUnmanaged(this ITextInputConsumer managed, nint dest)
        => *(void**)dest = ComInterfaceMarshaller<ITextInputConsumer>.ConvertToUnmanaged(managed);
}
