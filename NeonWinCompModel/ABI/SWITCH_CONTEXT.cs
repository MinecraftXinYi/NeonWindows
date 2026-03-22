using System.Runtime.InteropServices;

namespace NeonWindows.ABI;

[StructLayout(LayoutKind.Sequential)]
internal struct SWITCH_CONTEXT
{
    internal SWITCH_CONTEXT_ATTRIBUTE Attribute;
    internal SWITCH_CONTEXT_DATA Data;
}
