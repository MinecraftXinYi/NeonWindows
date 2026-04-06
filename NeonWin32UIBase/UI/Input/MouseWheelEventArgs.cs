using System;
using System.Drawing;

namespace NeonWindows.UI.Input;

public sealed class MouseWheelEventArgs : EventArgs
{
    public MouseWheelEventArgs(Point wheel)
    {
        Wheel = wheel;
    }

    public Point Wheel { get; }

    public static implicit operator Point(MouseWheelEventArgs e) => e.Wheel;
}
