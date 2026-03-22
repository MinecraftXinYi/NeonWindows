using System.Runtime.InteropServices;

namespace NeonWindows.ABI.ApplicationModel;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct APPCOMPAT_EXE_DATA
{
    internal fixed ulong Reserved[65];
    public uint Size;
    public uint Magic;
    public int LoadShimEngine;
    public ushort ExeType;
    internal SDBQUERYRESULT SdbQueryResult;
    public fixed byte DbgLogChannels[1024];
    public SWITCH_CONTEXT SwitchContext;
}
