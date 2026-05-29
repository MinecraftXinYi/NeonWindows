using System.Runtime.InteropServices;
using Windows.Win32.System.WinRT;

namespace NeonWindows.WinRT;

public unsafe static class MarshalInspectable<T>
{
    public static nint FromManaged(T o)
        => Marshal.GetComInterfaceForObject<T, IInspectable>(o);

    public static void CopyManaged(T o, nint dest)
    {
        nint ptr;
        if (o == null) ptr = default;
        else ptr = Marshal.GetComInterfaceForObject<T, IInspectable>(o);
        *(nint*)dest = ptr;
    }
}
