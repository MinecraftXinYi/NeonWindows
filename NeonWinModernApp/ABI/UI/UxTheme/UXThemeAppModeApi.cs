using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.UxTheme;

public static class UXThemeAppModeApi
{
    [DllImport(Win32DllName.ExtMsWinUxThemeThemesL112, EntryPoint = "#135")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern PreferredAppMode SetPreferredAppMode(PreferredAppMode preferredAppMode);

    [DllImport(Win32DllName.ExtMsWinUxThemeThemesL112, EntryPoint = "#136")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern void FlushMenuThemes();
}
