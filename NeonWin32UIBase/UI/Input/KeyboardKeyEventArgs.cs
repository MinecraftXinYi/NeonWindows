using System;

namespace NeonWindows.UI.Input;

public sealed class KeyboardKeyEventArgs : EventArgs
{
    public KeyboardKeyEventArgs(int scanCode, InputAction action, bool altPress)
    {
        ScanCode = scanCode;
        Action = action;
        AltPressed = altPress;
        Key = (Keys)scanCode;
    }

    public Keys Key { get; }

    public int ScanCode { get; }

    public InputAction Action { get; }

    public bool AltPressed { get; }


    public static implicit operator Keys(KeyboardKeyEventArgs e) => e.Key;
}
