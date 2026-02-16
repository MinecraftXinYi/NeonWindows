using NeonWindows.ABI.UI.Modern.Core;
using Windows.UI.Core;
using WinRT;

namespace NeonWindows.UI.Modern.Core;

public static class CoreWindowInterop
{
    public static nint GetWindowHandle(this CoreWindow coreWindow)
        => coreWindow.As<ICoreWindowInterop>().GetWindowHandle();

    public static void SetMessageHandled(this CoreWindow coreWindow, bool messageHandled)
        => coreWindow.As<ICoreWindowInterop>().SetMessageHandled(messageHandled);
}
