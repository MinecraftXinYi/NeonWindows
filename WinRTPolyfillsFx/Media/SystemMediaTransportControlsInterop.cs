using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Media;
using Windows.Win32.System.WinRT;

namespace NeonWindows.Media;

public unsafe static class SystemMediaTransportControlsInterop
{
    public static SystemMediaTransportControls GetForWindow(nint appWindow)
    {
        Guid iid = IID_ISystemMediaTransportControls;
        return (SystemMediaTransportControls)systemMediaTransportControlsInterop.GetForWindow(new(appWindow), &iid);
    }

    internal static readonly Guid IID_ISystemMediaTransportControls = new(2583314420u, 5954, 17062, 144, 46, 8, 125, 65, 249, 101, 236);

    private static ISystemMediaTransportControlsInterop systemMediaTransportControlsInterop = (ISystemMediaTransportControlsInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(SystemMediaTransportControls));
}
