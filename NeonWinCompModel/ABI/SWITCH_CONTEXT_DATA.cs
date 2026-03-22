using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI;

[StructLayout(LayoutKind.Sequential)]
public struct SWITCH_CONTEXT_DATA
{
    public ulong OsMaxVersionTested;
    public uint TargetPlatform;
    public ulong ContextMinimum;
    public Guid Platform;
    public Guid MinPlatform;
    public uint ContextSource;
    public uint ElementCount;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
    public Guid[] Elements;
    //public _Elements Elements;

    //[InlineArray(48)]
    //public struct _Elements
    //{
    //    public Guid e0;
    //}
}
