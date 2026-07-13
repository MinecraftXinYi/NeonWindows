using System.Windows.Forms;
using Windows.Win32;

namespace NeonWindows.UI.Messaging;

public static class Win32WindowMsgExtensions
{
    public static void PostMessage(this IWin32Window window, uint message, nuint wParam, nint lParam)
        => PInvoke.PostMessage(new(window.Handle), message, wParam, lParam);

    public static void SendMessage(this IWin32Window window, uint message, nuint wParam, nint lParam)
        => PInvoke.SendMessage(new(window.Handle), message, wParam, lParam);
}
