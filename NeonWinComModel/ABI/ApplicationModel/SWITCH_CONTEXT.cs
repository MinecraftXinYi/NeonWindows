using System.Runtime.InteropServices;

namespace NeonWindows.ABI.ApplicationModel;

[StructLayout(LayoutKind.Sequential)]
public struct SWITCH_CONTEXT
{
    public SWITCH_CONTEXT_ATTRIBUTE Attribute;
    public SWITCH_CONTEXT_DATA Data;
}
