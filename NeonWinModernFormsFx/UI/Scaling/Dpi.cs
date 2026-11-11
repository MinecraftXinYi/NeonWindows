using System.Windows.Forms;
using Windows.Win32;

namespace NeonWindows.UI.Scaling;

public static class Dpi
{
    public const double Base = 96.0;

    public static uint GetForWindow(this IWin32Window window)
        => PInvoke.GetDpiForWindow(new(window.Handle));
}
