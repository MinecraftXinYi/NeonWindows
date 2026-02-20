using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Modern.Core;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
[Guid(WinRTCoreUIComGuid.IID_IInternalCoreDispatcherStatic)]
public interface IInternalCoreDispatcherStatic
{
    [PreserveSig]
    int GetForCurrentThread(out nint pDispatcher);

    [PreserveSig]
    int GetOrCreateForCurrentThread(out nint pDispatcher);
}
