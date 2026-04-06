using System;
using System.Drawing;

namespace NeonWindows.UI.Windowing;

public sealed class ResizeEventArgs : EventArgs
{
    public ResizeEventArgs(Size size)
    {
        Size = size;
    }

    public Size Size { get; }

    public float AspectRatio => Size.Width / (float)Size.Height;

    public static implicit operator Size(ResizeEventArgs args) => args.Size;
}
