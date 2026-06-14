using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.ViewManagement;
using Windows.Win32;
using Windows.Win32.System.WinRT;

namespace NeonWindows.UI.ViewManagement;

public static class UIViewSettingsInterop
{
    public static UIViewSettings GetForWindow(nint hwnd)
        => (UIViewSettings)uIViewSettingsInterop.GetForWindow(new(hwnd), IID_IUIViewSettings);

    internal static readonly Guid IID_IUIViewSettings = new(3325450230u, 34896, 18189, 136, 248, 69, 94, 22, 234, 44, 38);

    private static IUIViewSettingsInterop uIViewSettingsInterop = (IUIViewSettingsInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(UIViewSettings));
}
