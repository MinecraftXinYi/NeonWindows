using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI;

internal static class RoApi
{
    [DllImport("api-ms-win-core-winrt-l1-1-0.dll")]
    public static extern int RoGetActivationFactory([MarshalAs(UnmanagedType.HString)] string activatableClassId, ref Guid iid, out nint factory);
}
