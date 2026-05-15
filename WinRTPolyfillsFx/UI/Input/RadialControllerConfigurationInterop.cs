using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Input;
using Windows.Win32.UI.Input.Radial;

namespace NeonWindows.UI.Input;

public unsafe static class RadialControllerConfigurationInterop
{
    public static RadialControllerConfiguration GetForWindow(nint hwnd)
    {
        Guid iid = IID_IRadialControllerConfiguration;
        radialControllerConfigurationInterop.GetForWindow(new(hwnd), &iid, out object radialControllerConfiguration);
        return (RadialControllerConfiguration)radialControllerConfiguration;
    }

    internal static readonly Guid IID_IRadialControllerConfiguration = new(2797051595u, 27218, 17456, 145, 12, 86, 55, 10, 157, 107, 66);

    private static IRadialControllerConfigurationInterop radialControllerConfigurationInterop = (IRadialControllerConfigurationInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(RadialControllerConfiguration));
}
