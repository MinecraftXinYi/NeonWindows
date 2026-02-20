using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Composition;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
[Guid(WinRTUICompComGuid.IID_ICompositionTarget)]
public interface ICompositionTarget
{
    [PreserveSig]
    int GetRoot(out nint pRoot);

    [PreserveSig]
    int SetRoot(nint pRoot);
}
