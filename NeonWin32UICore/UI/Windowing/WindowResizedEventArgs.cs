using System;
using System.Drawing;

namespace NeonWindows.UI.Windowing;

public class WindowResizedEventArgs(int width, int height) : EventArgs
{
    public Size NewSize { get; } = new(width, height);
}
