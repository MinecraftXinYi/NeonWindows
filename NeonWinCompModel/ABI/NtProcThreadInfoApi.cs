using System.Runtime.InteropServices;

namespace NeonWindows.ABI;

internal static class NtProcThreadInfoApi
{
    [DllImport("ntdll.dll")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static extern nint RtlGetCurrentPeb();
}
