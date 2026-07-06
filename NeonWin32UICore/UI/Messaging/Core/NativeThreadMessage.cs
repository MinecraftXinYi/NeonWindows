using Windows.Win32;

namespace NeonWindows.UI.Messaging.Core;

public static class NativeThreadMessage
{
    public static bool PostThreadMessage(uint threadId, uint message, nuint wParam, nint lParam)
        => PInvoke.PostThreadMessage(threadId, message, wParam, lParam);

    public static void PostQuitMessage(int exitCode)
        => PInvoke.PostQuitMessage(exitCode);
}
