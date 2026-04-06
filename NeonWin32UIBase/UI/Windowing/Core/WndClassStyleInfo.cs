using Windows.Win32;
using Windows.Win32.Foundation;

namespace NeonWindows.UI.Windowing.Core;

public struct WndClassStyleInfo
{
    public nint BackgroundBrush;
    public nint Cursor;
    public nint Icon;
    public nint SmallIcon;

    public static WndClassStyleInfo Default
        => new()
        {
            BackgroundBrush = default,
            Cursor = PInvoke.LoadCursor(HINSTANCE.Null, PInvoke.IDC_ARROW),
            Icon = default,
            SmallIcon = default,
        };
}
