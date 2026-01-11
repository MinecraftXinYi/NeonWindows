using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Composition;

public unsafe static class WindowCompositionNativeApi2
{
    /// <summary>
    /// Retrieves the current value of a specified Desktop Window Manager (DWM) attribute applied to a window.
    /// </summary>
    /// <param name="hwnd">An HWND specifying the handle to the window for which the attribute value is to be retrieved.</param>
    /// <param name="pwcad">A pointer to a <see cref="WindowCompositionAttribData"/> structure describing which attribute to retrieve and a memory location to hold its value.</param>
    /// <returns>TRUE if the function succeeds; otherwise, FALSE.</returns>
    [DllImport(Win32DllName.Win32U, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool NtUserGetWindowCompositionAttribute(nint hwnd, WindowCompositionAttribData* pwcad);

    /// <summary>
    /// Sets the current value of a specified Desktop Window Manager (DWM) attribute applied to a window.
    /// </summary>
    /// <param name="hwnd">An HWND specifying the handle to the window for which the attribute value is to be set.</param>
    /// <param name="pwcad">A pointer to a <see cref="WindowCompositionAttribData"/> structure describing which attribute to set and its new value.</param>
    /// <returns>TRUE if the function succeeds; otherwise, FALSE.</returns>
    [DllImport(Win32DllName.Win32U, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool NtUserSetWindowCompositionAttribute(nint hwnd, WindowCompositionAttribData* pwcad);
}
