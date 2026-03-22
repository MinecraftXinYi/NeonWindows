using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI;

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct SDBQUERYRESULT
{
    internal fixed uint Exes[16];
    internal fixed uint ExeFlags[16];
    internal fixed uint Layers[8];
    internal uint LayerFlags;
    internal uint AppHelp;
    internal uint ExeCount;
    internal uint LayerCount;
    internal Guid ID;
    internal uint ExtraFlags;
    internal uint CustomSDBMap;
    internal Guid DB0;
    internal Guid DB1;
    internal Guid DB2;
    internal Guid DB3;
    internal Guid DB4;
    internal Guid DB5;
    internal Guid DB6;
    internal Guid DB7;
    internal Guid DB8;
    internal Guid DB9;
    internal Guid DB10;
    internal Guid DB11;
    internal Guid DB12;
    internal Guid DB13;
    internal Guid DB14;
    internal Guid DB15;
    //internal _DB DB;

    //[InlineArray(16)]
    //internal struct _DB
    //{
    //    internal Guid e0;
    //}
}
