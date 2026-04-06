using System;

namespace NeonWindows.UI.Windowing;

public sealed class FocusEventArgs : EventArgs
{
    public FocusEventArgs(bool value)
        => Focused = value;

    public bool Focused { get; }

    public static implicit operator bool(FocusEventArgs args) => args.Focused;
}
