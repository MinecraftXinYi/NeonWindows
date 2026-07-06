using Windows.Win32;

namespace NeonWindows.UI.Windowing.Core;

public static class WindowProc
{
    public static nint DefaultWindowProc(nint window, uint message, nuint wParam, nint lParam)
        => PInvoke.DefWindowProc(new(window), message, wParam, lParam);
}
