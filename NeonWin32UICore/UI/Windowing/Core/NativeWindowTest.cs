using Windows.Win32;

namespace NeonWindows.UI.Windowing.Core;

public static class NativeWindowTest
{
    public static bool IsWindow(nint handle)
        => PInvoke.IsWindow(new(handle));
}
