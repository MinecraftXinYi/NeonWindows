using NeonWindows.UI.Gdi;
using NeonWindows.UI.Input;

namespace NeonWindows.UI.Windowing.Core;

public struct WndClassStyleInfo
{
    public GdiBrush BackgroundBrush;
    public Cursor Cursor;
    public Icon Icon;
    public Icon SmallIcon;

    public static WndClassStyleInfo Default
        => new()
        {
            BackgroundBrush = default,
            Cursor = Cursor.StandardArrowCursor,
            Icon = default,
            SmallIcon = default,
        };
}
