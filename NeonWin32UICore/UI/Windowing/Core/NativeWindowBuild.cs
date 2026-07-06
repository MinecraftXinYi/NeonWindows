using System.Drawing;
using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Windowing.Core;

public unsafe static class NativeWindowBuild
{
    public static nint CreateWindow(string className, string windowName, uint style, uint exStyle, Rectangle rect, nint parentWindow = default, nint menuHandle = default, nint lParam = default)
        => CreateWindow(className, windowName, style, exStyle, rect, PInvoke.GetModuleHandle(default), parentWindow, menuHandle, lParam);

    public static nint CreateWindow(string className, string windowName, uint style, uint exStyle, Rectangle rect, nint instanceHandle, nint parentWindow = default, nint menuHandle = default, nint lParam = default)
        => PInvoke.CreateWindowEx((WINDOW_EX_STYLE)exStyle, className, windowName, (WINDOW_STYLE)style, rect.X, rect.Y, rect.Width, rect.Height, new(parentWindow), new(menuHandle), new(instanceHandle), (void*)lParam);
}
