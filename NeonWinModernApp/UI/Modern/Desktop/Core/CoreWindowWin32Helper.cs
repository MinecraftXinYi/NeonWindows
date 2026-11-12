using NeonWindows.UI.Messaging;
using NeonWindows.UI.Modern.Core;
using NeonWindows.UI.Windowing;
using System.Windows.Forms;
using Windows.UI.Core;

namespace NeonWindows.UI.Modern.Desktop.Core;

public static class CoreWindowWin32Helper
{
    public static void SendMessageToCoreWindowForCurrentThread(uint message, nuint wParam, nint lParam)
    {
        CoreWindow coreWindow = CoreWindow.GetForCurrentThread();
        if (coreWindow is null) return;
        IWin32Window win32Window = new Win32Window(coreWindow.GetWindowHandle());
        win32Window.SendMessage(message, wParam, lParam);
    }

    public static void PostMessageToCoreWindowForCurrentThread(uint message, nuint wParam, nint lParam)
    {
        CoreWindow coreWindow = CoreWindow.GetForCurrentThread();
        if (coreWindow is null) return;
        IWin32Window win32Window = new Win32Window(coreWindow.GetWindowHandle());
        win32Window.PostMessage(message, wParam, lParam);
    }
}
