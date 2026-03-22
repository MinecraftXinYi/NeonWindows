using System.Runtime.InteropServices;

namespace NeonWindows.ABI.ApplicationModel;

[StructLayout(LayoutKind.Sequential)]
public struct SWITCH_CONTEXT_ATTRIBUTE
{
    public ulong ContextUpdateCounter;
    public int AllowContextUpdate;
    public int EnableTrace;
    public ulong EtwHandle;
}
