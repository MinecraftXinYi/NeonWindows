using System.Runtime.InteropServices;

namespace NeonWindows.ABI.ApplicationModel;

public static class ComASTATestApi
{
    [DllImport(WinRTDllName.Combase, EntryPoint = "#100")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern void CoSetASTATestMode(ASTA_TEST_MODE_FLAGS flags);
}
