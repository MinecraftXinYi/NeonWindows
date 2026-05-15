using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Input.Core;
using Windows.Win32.UI.Input.Radial;

namespace NeonWindows.UI.Input.Core;

public unsafe static class RadialControllerIndependentInputSourceInterop
{
    public static RadialControllerIndependentInputSource CreateForWindow(nint hwnd)
    {
        Guid iid = IID_IRadialControllerIndependentInputSource;
        radialControllerIndependentInputSourceInterop.CreateForWindow(new(hwnd), &iid, out object radialControllerIndependentInputSource);
        return (RadialControllerIndependentInputSource)radialControllerIndependentInputSource;
    }

    internal static readonly Guid IID_IRadialControllerIndependentInputSource = new(1029144310u, 19694, 4582, 181, 53, 0, 27, 220, 6, 171, 59);

    private static IRadialControllerIndependentInputSourceInterop radialControllerIndependentInputSourceInterop = (IRadialControllerIndependentInputSourceInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(RadialControllerIndependentInputSource));
}
