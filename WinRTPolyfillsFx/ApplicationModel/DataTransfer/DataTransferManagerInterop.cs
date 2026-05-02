using NeonWindows.ABI;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Win32.UI.Shell;

namespace NeonWindows.ApplicationModel.DataTransfer;

public unsafe static class DataTransferManagerInterop
{
    public static DataTransferManager GetForWindow(nint appWindow)
    {
        Guid iid = RoInterfaceIDs.IID_IDataTransferManager;
        return (DataTransferManager)dataTransferManagerInterop.GetForWindow(new(appWindow), &iid);
    }

    public static void ShowShareUIForWindow(nint appWindow)
        => dataTransferManagerInterop.ShowShareUIForWindow(new(appWindow));

    private static IDataTransferManagerInterop dataTransferManagerInterop = (IDataTransferManagerInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(DataTransferManager));
}
