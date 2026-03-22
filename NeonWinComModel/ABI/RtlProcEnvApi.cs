using System.Runtime.InteropServices;

namespace NeonWindows.ABI;

internal unsafe static class RtlProcEnvApi
{
    [DllImport("ntdll.dll")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static extern PEB* RtlGetCurrentPeb();
}
