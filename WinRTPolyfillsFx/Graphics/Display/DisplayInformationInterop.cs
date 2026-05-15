using NeonWindows.ABI;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Graphics.Display;

namespace NeonWindows.Graphics.Display;

public unsafe static class DisplayInformationInterop
{
    public static DisplayInformation GetForWindow(nint window)
    {
        Guid iid = IID_IDisplayInformation;
        return (DisplayInformation)displayInformationInterop.GetForWindow(new(window), &iid);
    }

    public static DisplayInformation GetForMonitor(nint monitor)
    {
        Guid iid = IID_IDisplayInformation;
        return (DisplayInformation)displayInformationInterop.GetForMonitor(new(monitor), &iid);
    }

    internal static readonly Guid IID_IDisplayInformation = new(3201372846u, 44483, 19913, 174, 101, 133, 31, 77, 125, 71, 153);

    private static IDisplayInformationStaticsInterop displayInformationInterop = (IDisplayInformationStaticsInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(DisplayInformation));
}
