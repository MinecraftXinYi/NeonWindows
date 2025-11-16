namespace NeonWindows.ABI;

internal static class CommonHR
{
    public const int
        S_OK = 0x00000000,
        E_INVALIDARG = unchecked((int)0x80070057),
        E_ACCESSDENIED = unchecked((int)0x80070005);
}
