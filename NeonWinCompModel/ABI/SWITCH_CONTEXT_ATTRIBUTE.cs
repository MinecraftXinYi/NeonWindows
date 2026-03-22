using System.Runtime.InteropServices;
using Windows.Win32.Foundation;

namespace NeonWindows.ABI;

[StructLayout(LayoutKind.Sequential)]
internal struct SWITCH_CONTEXT_ATTRIBUTE
{
    internal ulong ContextUpdateCounter;
    internal BOOL AllowContextUpdate;
    internal BOOL EnableTrace;
    internal ulong EtwHandle;
}
