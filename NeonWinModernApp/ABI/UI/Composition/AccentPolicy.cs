using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Composition;

[StructLayout(LayoutKind.Sequential)]
public struct AccentPolicy
{
    public AccentState AccentState;
    public uint AccentFlags;
    public uint GradientColor;
    public int AnimationId;
}
