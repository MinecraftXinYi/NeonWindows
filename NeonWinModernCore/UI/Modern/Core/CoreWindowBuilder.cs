using NeonWindows.ABI.UI.Modern.Core;
using Windows.Graphics;
using Windows.UI.Core;
using WinRT;

namespace NeonWindows.UI.Modern.Core;

public static class CoreWindowBuilder
{
    public static CoreWindow CreateImmersiveHostedCoreWindow(string title, RectInt32 rect, nint hOwnerWindow)
        => CreateCoreWindowInternal(WINDOW_TYPE.IMMERSIVE_HOSTED, title, rect, hOwnerWindow);

    public static CoreWindow CreateNotImmersiveCoreWindow(string title, RectInt32 rect, nint hOwnerWindow)
        => CreateCoreWindowInternal(WINDOW_TYPE.NOT_IMMERSIVE, title, rect, hOwnerWindow);

    private static CoreWindow CreateCoreWindowInternal(WINDOW_TYPE type, string title, RectInt32 rect, nint hOwnerWindow)
    {
        ExceptionHelpers.ThrowExceptionForHR(CoreUICoreWindowApi.PrivateCreateCoreWindow(type, title, rect.X, rect.Y, (uint)rect.Width, (uint)rect.Height,
            0, hOwnerWindow, typeof(ICoreWindow).GUID, out nint pCoreWindow));
        return CoreWindow.FromAbi(pCoreWindow);
    }
}
