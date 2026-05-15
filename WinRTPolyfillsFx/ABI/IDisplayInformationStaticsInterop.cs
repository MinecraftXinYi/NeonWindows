using System;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Gdi;

namespace NeonWindows.ABI;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
[Guid("7449121C-382B-4705-8DA7-A795BA482013")]
internal unsafe interface IDisplayInformationStaticsInterop
{
    [return: MarshalAs(UnmanagedType.IUnknown)]
    object GetForWindow(HWND window, Guid* riid);

    [return: MarshalAs(UnmanagedType.IUnknown)]
    object GetForMonitor(HMONITOR monitor, Guid* riid);
}
