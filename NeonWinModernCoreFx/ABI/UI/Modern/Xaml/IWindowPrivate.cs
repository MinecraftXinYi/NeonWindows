using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Modern.Xaml;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
[Guid(WinRTXamlPrivateComGuid.IWindowPrivate)]
public interface IWindowPrivate
{
    [PreserveSig]
    int GetTransparentBackground([MarshalAs(UnmanagedType.Bool)] out bool isTransparentBackground);

    [PreserveSig]
    int SetTransparentBackground([MarshalAs(UnmanagedType.Bool)] bool isTransparentBackground);

    [PreserveSig]
    int Show();

    [PreserveSig]
    int Hide();

    [PreserveSig]
    int MoveWindow(int x, int y, int width, int height);

    [PreserveSig]
    int SetAtlasSizeHint(uint width, uint height);

    [PreserveSig]
    int ReleaseGraphicsDeviceOnSuspend([MarshalAs(UnmanagedType.Bool)] bool enable);
}
