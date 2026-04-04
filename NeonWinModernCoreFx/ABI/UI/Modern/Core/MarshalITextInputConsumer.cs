using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Modern.Core;

public static class MarshalITextInputConsumer
{
    public static nint GetAbi(this ITextInputConsumer managed)
        => Marshal.GetComInterfaceForObject<ITextInputConsumer, ITextInputConsumer>(managed);
}
