using System;

namespace NeonWindows.ABI.UI.Modern.Core;

[Flags]
public enum COREINPUT_POINTER_TYPE
{
    CIPT_NONE,
    CIPT_TOUCH,
    CIPT_PEN,
    CIPT_MOUSE = 4,
    CIPT_KEYBOARD = 8
}
