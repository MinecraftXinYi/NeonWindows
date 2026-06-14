using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Input;
using Windows.Win32;
using Windows.Win32.UI.Input.Radial;

namespace NeonWindows.UI.Input;

public static class RadialControllerInterop
{
    public static RadialController CreateForWindow(nint hwnd)
    {
        radialControllerInterop.CreateForWindow(new(hwnd), IID_IRadialController, out object radialController);
        return (RadialController)radialController;
    }

    internal static readonly Guid IID_IRadialController = new(810930632u, 57169, 17364, 178, 59, 14, 16, 55, 70, 122, 9);

    private static IRadialControllerInterop radialControllerInterop = (IRadialControllerInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(RadialController));
}
