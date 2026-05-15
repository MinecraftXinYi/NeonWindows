using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.ViewManagement;
using Windows.Win32.System.WinRT;

namespace NeonWindows.UI.ViewManagement;

public unsafe static class UIViewSettingsInterop
{
    public static UIViewSettings GetForWindow(nint hwnd)
    {
        Guid iid = IID_IUIViewSettings;
        return (UIViewSettings)uIViewSettingsInterop.GetForWindow(new(hwnd), &iid);
    }

    internal static readonly Guid IID_IUIViewSettings = new(3325450230u, 34896, 18189, 136, 248, 69, 94, 22, 234, 44, 38);

    private static IUIViewSettingsInterop uIViewSettingsInterop = (IUIViewSettingsInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(UIViewSettings));
}
