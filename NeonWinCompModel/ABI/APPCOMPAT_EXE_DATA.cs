using System.Runtime.InteropServices;
using Windows.Win32.Foundation;

namespace NeonWindows.ABI;

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct APPCOMPAT_EXE_DATA
{
    internal fixed ulong Reserved[65];
    internal uint Size;
    internal uint Magic;
    internal BOOL LoadShimEngine;
    internal ushort ExeType;
    internal SDBQUERYRESULT SdbQueryResult;
    internal fixed byte DbgLogChannels[1024];
    internal SWITCH_CONTEXT SwitchContext;
}
