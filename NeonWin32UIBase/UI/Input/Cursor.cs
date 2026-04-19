using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Input;

public readonly struct Cursor
{
    internal readonly HCURSOR handle;

    public Cursor()
        => handle = new();

    public Cursor(nint hCursor)
        => handle = new(hCursor);

    public static readonly Cursor Null = default;

    public nint Handle => handle;

    public bool IsNull => handle.IsNull;

    public static Cursor StandardArrowCursor
        => new(PInvoke.LoadCursor(HINSTANCE.Null, PInvoke.IDC_ARROW));
}
