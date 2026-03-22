using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Modern.Core;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
[Guid(WinRTCoreUIComGuid.IID_IInternalDispatcher2)]
public interface IInternalDispatcher2
{
    [PreserveSig]
    int GetDispatcherQueue(out nint pDispatcherQueue);
}
