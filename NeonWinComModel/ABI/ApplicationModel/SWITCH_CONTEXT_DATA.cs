using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.ApplicationModel;

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
    public InlineArray_Elements Elements;

    public struct InlineArray_Elements
    {
        public Guid e0;
        public Guid e1;
        public Guid e2;
        public Guid e3;
        public Guid e4;
        public Guid e5;
        public Guid e6;
        public Guid e7;
        public Guid e8;
        public Guid e9;
        public Guid e10;
        public Guid e11;
        public Guid e12;
        public Guid e13;
        public Guid e14;
        public Guid e15;
        public Guid e16;
        public Guid e17;
        public Guid e18;
        public Guid e19;
        public Guid e20;
        public Guid e21;
        public Guid e22;
        public Guid e23;
        public Guid e24;
        public Guid e25;
        public Guid e26;
        public Guid e27;
        public Guid e28;
        public Guid e29;
        public Guid e30;
        public Guid e31;
        public Guid e32;
        public Guid e33;
        public Guid e34;
        public Guid e35;
        public Guid e36;
        public Guid e37;
        public Guid e38;
        public Guid e39;
        public Guid e40;
        public Guid e41;
        public Guid e42;
        public Guid e43;
        public Guid e44;
        public Guid e45;
        public Guid e46;
        public Guid e47;
    }
}
