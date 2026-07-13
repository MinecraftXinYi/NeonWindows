using System.Drawing;

namespace NeonWindows.UI.Modern.Desktop.Core;

public static class DesktopWindowInitialization
{
    public static readonly Size
        ModernWindowDefaultSize = new(900, 600),
        ModernWindowMinimumSize = new(500, 360);

    public static readonly string
        ModernWindowDefaultTitle = "WinRT UI Desktop";
}
