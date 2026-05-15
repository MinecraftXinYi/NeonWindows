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
        Guid iid = IID_IPrintManager;
        return (PrintManager)printManagerInterop.GetForWindow(new(appWindow), &iid);
    }

    public static IAsyncOperation<bool> ShowPrintUIForWindowAsync(nint appWindow)
    {
        Guid iid = typeof(IAsyncOperation<bool>).GUID;
        return (IAsyncOperation<bool>)printManagerInterop.ShowPrintUIForWindowAsync(new(appWindow), &iid);
    }

    internal static readonly Guid IID_IPrintManager = new(4280981140u, 35993, 17661, 174, 74, 25, 217, 170, 154, 15, 10);

    private static IPrintManagerInterop printManagerInterop = (IPrintManagerInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(PrintManager));
}
