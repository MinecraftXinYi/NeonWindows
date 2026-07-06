using NeonWindows.UI.Messaging.Core;
using NeonWindows.UI.Windowing;

namespace NeonWindows.UI.Messaging;

public static class Win32WindowMsgEx
{
    public static void PostMessage(this IWin32Window window, uint message, nuint wParam, nint lParam)
        => NativeWindowMessage.PostWindowMessage(window.Handle, message, wParam, lParam);

    public static void SendMessage(this IWin32Window window, uint message, nuint wParam, nint lParam)
        => NativeWindowMessage.SendWindowMessage(window.Handle, message, wParam, lParam);
}
