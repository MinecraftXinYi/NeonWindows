using System;
using System.Runtime.InteropServices;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

public partial class WindowsXamlHostBase
{
    /// <summary>
    /// Sets XAML window size using dimensions of the host control
    /// </summary>
    private void SetDesktopWindowXamlSourceWindowPos()
    {
        if (XamlSourceWin32Window is not null && XamlSourceWin32Window.Handle != default && Width != 0 && Height != 0)
        {
            if (/*SafeNativeMethods.*/SetWindowPos(XamlSourceWin32Window.Handle, /*NativeDefines.*/HWND_TOP, 0, 0, Width, Height, /*SetWindowPosFlags.*/SHOWWINDOW) == IntPtr.Zero)
            {
                throw new InvalidOperationException($"{nameof(WindowsXamlHostBase)}::{nameof(SetDesktopWindowXamlSourceWindowPos)} failed to set UWP XAML window position.");
            }
        }
    }

    nint HWND_TOP => nint.Zero;

    const int SHOWWINDOW = 0x0040;

    [DllImport("user32.dll")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    static extern nint SetWindowPos(nint hWnd, nint hWndInsertAfter, int x, int y, int cx, int cy, int flags);
}
