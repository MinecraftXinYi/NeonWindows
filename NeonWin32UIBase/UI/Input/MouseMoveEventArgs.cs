using System;
using System.Drawing;

namespace NeonWindows.UI.Input;

public sealed class MouseMoveEventArgs : EventArgs
{
    public MouseMoveEventArgs(Point pos, Point previousPos)
    {
        Position = pos;
        PreviousPosition = previousPos;
    }

    public Point Position { get; }

    public Point PreviousPosition { get; }

    public static implicit operator Point(MouseMoveEventArgs args) => args.Position;
}
