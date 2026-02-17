using System;
using System.Runtime.InteropServices;
using WinRT;

namespace NeonWindows.ABI.UI.Modern.Xaml;

[Guid(WinRTXamlPrivateComGuid.IWindowPrivate)]
public partial interface IWindowPrivate
{
    [PreserveSig]
    internal int GetIids(out ulong iidCount, out nint iids);

    [PreserveSig]
    internal int GetRuntimeClassName(out nint className);

    [PreserveSig]
    internal int GetTrustLevel(out TrustLevel trustLevel);

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
