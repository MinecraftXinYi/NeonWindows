using System.Windows.Forms;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Windowing;

public static class Win32WindowExtensions2
{
    public static void SetAsClientOnlyChildWindow(this IWin32Window window)
    {
        WINDOW_STYLE wndStyle = (WINDOW_STYLE)window.GetLong((int)WINDOW_LONG_PTR_INDEX.GWL_STYLE);
        wndStyle = wndStyle & ~WINDOW_STYLE.WS_OVERLAPPEDWINDOW & ~WINDOW_STYLE.WS_POPUPWINDOW | WINDOW_STYLE.WS_CHILDWINDOW;
        window.SetLong((int)WINDOW_LONG_PTR_INDEX.GWL_STYLE, (int)wndStyle);
        window.UpdateLong();
    }
}
