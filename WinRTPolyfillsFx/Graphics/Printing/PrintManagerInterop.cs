using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Graphics.Printing;
using Windows.Win32;
using Windows.Win32.System.WinRT.Printing;

namespace NeonWindows.Graphics.Printing;

public static class PrintManagerInterop
{
    public static PrintManager GetForWindow(nint appWindow)
        => (PrintManager)printManagerInterop.GetForWindow(new(appWindow), IID_IPrintManager);

    public static IAsyncOperation<bool> ShowPrintUIForWindowAsync(nint appWindow)
        => (IAsyncOperation<bool>)printManagerInterop.ShowPrintUIForWindowAsync(new(appWindow), typeof(IAsyncOperation<bool>).GUID);

    internal static readonly Guid IID_IPrintManager = new(4280981140u, 35993, 17661, 174, 74, 25, 217, 170, 154, 15, 10);

    private static IPrintManagerInterop printManagerInterop = (IPrintManagerInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(PrintManager));
}
