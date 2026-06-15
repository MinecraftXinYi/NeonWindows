using System.Windows.Forms;
using Windows.Win32;

namespace NeonWindows.UI.Messaging;

public static class WindowMessaging
{
    public static void PostWindowMessage(this IWin32Window window, Message message)
        => PInvoke.PostMessage(new(window.Handle), (uint)message.Msg, (nuint)(nint)message.WParam, message.LParam);

    public static void SendWindowMessage(this IWin32Window window, Message message)
        => PInvoke.SendMessage(new(window.Handle), (uint)message.Msg, (nuint)(nint)message.WParam, message.LParam);
}
