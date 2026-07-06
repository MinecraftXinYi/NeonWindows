using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Input;

public readonly struct Cursor
{
    internal readonly HCURSOR _handle;

    public Cursor(nint hCursor)
        => _handle = new(hCursor);

    public Cursor()
        => _handle = new();

    public nint Handle => _handle;

    public static Cursor Standard => new(PInvoke.LoadCursor(default, PInvoke.IDC_ARROW));
}
