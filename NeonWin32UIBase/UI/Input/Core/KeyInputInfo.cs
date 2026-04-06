namespace NeonWindows.UI.Input.Core;

public static class KeyInputInfo
{
    public static bool IsShift(nint lParam) => (lParam & (1L << 16)) != 0;

    public static bool IsControl(nint lParam) => (lParam & (1L << 17)) != 0;

    public static bool IsAlt(nint lParam) => (lParam & (1L << 29)) != 0;

    public static bool IsSuper(nint lParam) => (lParam & (1L << 30)) != 0;

    public static bool IsCapsLock(nint lParam) => (lParam & (1L << 0)) != 0;

    public static bool IsNumLock(nint lParam) => (lParam & (1L << 1)) != 0;

    public const int MK_SHIFT = 0x0004;

    public static int GET_KEYSTATE_WPARAM(nuint wParam) => MinWinDef.LOWORD((uint)wParam);

    public static int GET_XBUTTON_WPARAM(nuint wParam) => MinWinDef.HIWORD((uint)wParam);

    public static int GET_X_LPARAM(nint lParam) => MinWinDef.LOWORD((uint)lParam);

    public static int GET_Y_LPARAM(nint lParam) => MinWinDef.HIWORD((uint)lParam);

    public static short GET_WHEEL_DELTA_WPARAM(nuint wPARAM) => (short)MinWinDef.HIWORD((uint)wPARAM);
}
