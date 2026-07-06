using System;
using System.Drawing;

namespace NeonWindows.UI.Windowing;

public class WindowMovedEventArgs(int x, int y) : EventArgs
{
    public Point NewPosition { get; } = new(x, y);
}
