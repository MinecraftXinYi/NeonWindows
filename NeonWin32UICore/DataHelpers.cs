namespace NeonWindows;

internal static class DataHelpers
{
    extension (nuint value)
    {
        internal ushort HIWORD => (ushort)((value >> 16) & 0xffff);

        internal ushort LOWORD => (ushort)(value & 0xffff);
    }

    extension(nint value)
    {
        internal ushort HIWORD => (ushort)((value >> 16) & 0xffff);

        internal ushort LOWORD => (ushort)(value & 0xffff);
    }
}
