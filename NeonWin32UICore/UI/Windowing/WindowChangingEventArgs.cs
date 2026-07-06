using System.ComponentModel;
using System.Drawing;
using Windows.Win32.Foundation;

namespace NeonWindows.UI.Windowing;

public unsafe class WindowChangingEventArgs(nint lParam) : CancelEventArgs
{
    public Rectangle NewRect { get; } = *(RECT*)lParam;

    public Point NewPosition => NewRect.Location;

    public Size NewSize => NewRect.Size;
}
