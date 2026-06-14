using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Input.Spatial;
using Windows.Win32;
using Windows.Win32.System.WinRT;

namespace NeonWindows.UI.Input.Spatial;

public static class SpatialInteractionManagerInterop
{
    public static SpatialInteractionManager GetForWindow(nint window)
        => (SpatialInteractionManager)spatialInteractionManagerInterop.GetForWindow(new(window), IID_ISpatialInteractionManager);

    internal static readonly Guid IID_ISpatialInteractionManager = new(849759912u, 41306, 14741, 184, 189, 128, 81, 60, 181, 173, 239);

    private static ISpatialInteractionManagerInterop spatialInteractionManagerInterop = (ISpatialInteractionManagerInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(SpatialInteractionManager));
}
