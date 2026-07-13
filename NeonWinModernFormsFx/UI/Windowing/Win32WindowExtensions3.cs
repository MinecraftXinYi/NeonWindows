using System.Windows.Forms;
using Windows.Win32;

namespace NeonWindows.UI.Windowing;

public static class Win32WindowExtensions3
{
    public static Win32Window GetParent(this IWin32Window window)
        => new(PInvoke.GetParent(new(window.Handle)));
}
