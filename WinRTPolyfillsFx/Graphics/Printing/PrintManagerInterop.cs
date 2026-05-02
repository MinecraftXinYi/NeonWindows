using NeonWindows.ABI;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Graphics.Printing;
using Windows.Win32.System.WinRT.Printing;

namespace NeonWindows.Graphics.Printing;

public unsafe static class PrintManagerInterop
{
    public static PrintManager GetForWindow(nint appWindow)
    {
        Guid iid = RoInterfaceIDs.IID_IPrintManager;
        return (PrintManager)printManagerInterop.GetForWindow(new(appWindow), &iid);
    }

    public static IAsyncOperation<bool> ShowPrintUIForWindowAsync(nint appWindow)
    {
        Guid iid = typeof(IAsyncOperation<bool>).GUID;
        return (IAsyncOperation<bool>)printManagerInterop.ShowPrintUIForWindowAsync(new(appWindow), &iid);
    }

    private static IPrintManagerInterop printManagerInterop = (IPrintManagerInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(PrintManager));
}
