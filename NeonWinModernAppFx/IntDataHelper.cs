namespace NeonWindows;

internal static class IntDataHelper
{
    internal static uint MakeLong(ushort wLow, ushort wHigh)
        => wLow | (uint)wHigh << 16;
}
