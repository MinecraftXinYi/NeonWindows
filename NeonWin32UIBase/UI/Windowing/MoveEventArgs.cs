using System;
using System.Drawing;

namespace NeonWindows.UI.Windowing;

public sealed class MoveEventArgs : EventArgs
{
    public MoveEventArgs(Point pos)
    {
        Position = pos;
    }

    public Point Position { get; }

    public static implicit operator Point(MoveEventArgs args) => args.Position;
}
