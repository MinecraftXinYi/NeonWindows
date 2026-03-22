using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.ApplicationModel;

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct SDBQUERYRESULT
{
    public fixed uint Exes[16];
    public fixed uint ExeFlags[16];
    public fixed uint Layers[8];
    public uint LayerFlags;
    public uint AppHelp;
    public uint ExeCount;
    public uint LayerCount;
    public Guid ID;
    public uint ExtraFlags;
    public uint CustomSDBMap;
    public InlineArray_DB DB;

    public struct InlineArray_DB
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
    }
}
