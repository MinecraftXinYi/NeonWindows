using System;

namespace NeonWindows.UI.Input;

public sealed class MouseButtonEventArgs : EventArgs
{
    public MouseButtonEventArgs(int scanCode, InputAction action)
    {
        ScanCode = scanCode;
        Action = action;
        Button = (MouseButton)scanCode;
    }

    public MouseButton Button { get; }

    public int ScanCode { get; }

    public InputAction Action { get; }

    public static implicit operator MouseButton(MouseButtonEventArgs e) => e.Button;
}
