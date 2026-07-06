using NeonWindows.UI.Messaging.Core;
using System.Threading;
using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Messaging;

public static class MessageProc
{
    public static void Run()
    {
        while (true)
        {
            if (PInvoke.PeekMessage(out MSG msg, default, default, default, PEEK_MESSAGE_REMOVE_TYPE.PM_REMOVE))
            {
                if (msg.message == PInvoke.WM_QUIT) break;
                PInvoke.TranslateMessage(msg);
                PInvoke.DispatchMessage(msg);
            }
            Thread.Sleep(1);
        }
    }

    public static void Exit()
        => NativeThreadMessage.PostQuitMessage(default);

    public static void ProcessOnce()
    {
        if (PInvoke.PeekMessage(out MSG msg, default, default, default, PEEK_MESSAGE_REMOVE_TYPE.PM_REMOVE))
        {
            PInvoke.TranslateMessage(msg);
            PInvoke.DispatchMessage(msg);
        }
    }
}
