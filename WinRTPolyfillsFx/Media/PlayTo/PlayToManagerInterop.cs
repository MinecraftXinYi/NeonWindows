using NeonWindows.ABI;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Media.PlayTo;
using Windows.Win32.System.WinRT;

namespace NeonWindows.Media.PlayTo;

#pragma warning disable CS0618
public unsafe static class PlayToManagerInterop
{
    public static PlayToManager GetForWindow(nint appWindow)
    {
        Guid iid = RoInterfaceIDs.IID_IPlayToManager;
        return (PlayToManager)playToManagerInterop.GetForWindow(new(appWindow), &iid);
    }

    private static IPlayToManagerInterop playToManagerInterop = (IPlayToManagerInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(PlayToManager));
}
