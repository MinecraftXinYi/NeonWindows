using Windows.Win32;

namespace NeonWindows.UI.Messaging.Core;

public static class NativeWindowMessage
{
    public static bool PostWindowMessage(nint window, uint message, nuint wParam, nint lParam)
        => PInvoke.PostMessage(new(window), message, wParam, lParam);

    public static nint SendWindowMessage(nint window, uint message, nuint wParam, nint lParam)
        => PInvoke.SendMessage(new(window), message, wParam, lParam);
}
