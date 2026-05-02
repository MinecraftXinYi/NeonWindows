using NeonWindows.ABI;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Media;
using Windows.Win32.System.WinRT;

namespace NeonWindows.Media;

public unsafe static class SystemMediaTransportControlsInterop
{
    public static SystemMediaTransportControls GetForWindow(nint appWindow)
    {
        Guid iid = RoInterfaceIDs.IID_ISystemMediaTransportControls;
        return (SystemMediaTransportControls)systemMediaTransportControlsInterop.GetForWindow(new(appWindow), &iid);
    }

    private static ISystemMediaTransportControlsInterop systemMediaTransportControlsInterop = (ISystemMediaTransportControlsInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(SystemMediaTransportControls));
}
