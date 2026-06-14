using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Media.PlayTo;
using Windows.Win32;
using Windows.Win32.System.WinRT;

namespace NeonWindows.Media.PlayTo;

#pragma warning disable CS0618
public static class PlayToManagerInterop
{
    public static PlayToManager GetForWindow(nint appWindow)
        => (PlayToManager)playToManagerInterop.GetForWindow(new(appWindow), IID_IPlayToManager);

    internal static readonly Guid IID_IPlayToManager = new(4117373038u, 7031, 17135, 143, 13, 185, 73, 248, 217, 178, 96);

    private static IPlayToManagerInterop playToManagerInterop = (IPlayToManagerInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(PlayToManager));
}
