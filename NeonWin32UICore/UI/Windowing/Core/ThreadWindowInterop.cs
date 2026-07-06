using Windows.Win32;

namespace NeonWindows.UI.Windowing.Core;

public static class ThreadWindowInterop
{
    public static bool DestroyWindow(nint window)
        => PInvoke.DestroyWindow(new(window));
}
