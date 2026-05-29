using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Modern.Core;

public unsafe static class MarshalTextInputConsumer
{
    public static nint ToUnmanaged(this ITextInputConsumer managed)
    {
        if (managed == null) return default;
        return Marshal.GetComInterfaceForObject<ITextInputConsumer, ITextInputConsumer>(managed);
    }

    public static void CopyUnmanaged(this ITextInputConsumer managed, nint dest)
    {
        nint ptr;
        if (managed == null) ptr = default;
        else ptr = Marshal.GetComInterfaceForObject<ITextInputConsumer, ITextInputConsumer>(managed);
        *(nint*)dest = ptr;
    }
}
