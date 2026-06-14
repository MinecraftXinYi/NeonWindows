using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Win32;
using Windows.Win32.UI.Shell;

namespace NeonWindows.ApplicationModel.DataTransfer;

public static class DataTransferManagerInterop
{
    public static DataTransferManager GetForWindow(nint appWindow)
        => (DataTransferManager)dataTransferManagerInterop.GetForWindow(new(appWindow), IID_IDataTransferManager);

    public static void ShowShareUIForWindow(nint appWindow)
        => dataTransferManagerInterop.ShowShareUIForWindow(new(appWindow));

    internal static readonly Guid IID_IDataTransferManager = new(2781539995u, 34568, 18897, 141, 54, 103, 210, 90, 141, 160, 12);

    private static IDataTransferManagerInterop dataTransferManagerInterop = (IDataTransferManagerInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(DataTransferManager));
}
