using System.Windows.Forms;
using Windows.Win32;

namespace NeonWindows.UI.Windowing;

public static class WindowFocus
{
    public static IWin32Window GetFocus()
        => new Win32Window(PInvoke.GetFocus());

    public static IWin32Window SetFocus(this IWin32Window window)
        => new Win32Window(PInvoke.SetFocus(new(window.Handle)));
}
