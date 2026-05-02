using NeonWindows.ABI;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;
using Windows.Win32.System.WinRT;

namespace NeonWindows.ApplicationModel.DataTransfer.DragDrop.Core;

public unsafe static class DragDropManagerInterop
{
    public static CoreDragDropManager GetForWindow(nint appWindow)
    {
        Guid iid = RoInterfaceIDs.IID_ICoreDragDropManager;
        dragDropManagerInterop.GetForWindow(new(appWindow), &iid, out object dragDropManager);
        return (CoreDragDropManager)dragDropManager;
    }

    private static IDragDropManagerInterop dragDropManagerInterop = (IDragDropManagerInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(CoreDragDropManager));
}
