namespace NeonWindows;

internal static class MinWinDef
{

    public static int HIWORD(uint l) => (int)((l >> 16) & 0xFFFF);

    public static int LOWORD(uint l) => (int)(l & 0xFFFF);
}
