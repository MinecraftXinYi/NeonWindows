using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer.DragDrop.Core;
using Windows.Win32;
using Windows.Win32.System.WinRT;

namespace NeonWindows.ApplicationModel.DataTransfer.DragDrop.Core;

public static class DragDropManagerInterop
{
    public static CoreDragDropManager GetForWindow(nint appWindow)
    {
        dragDropManagerInterop.GetForWindow(new(appWindow), IID_ICoreDragDropManager, out object dragDropManager);
        return (CoreDragDropManager)dragDropManager;
    }

    internal static readonly Guid IID_ICoreDragDropManager = new(2102842180u, 33892, 20399, 170, 73, 55, 234, 110, 45, 123, 209);

    private static IDragDropManagerInterop dragDropManagerInterop = (IDragDropManagerInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(CoreDragDropManager));
}
