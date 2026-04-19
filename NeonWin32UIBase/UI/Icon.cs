using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI;

public readonly struct Icon
{
    internal readonly HICON handle;

    public Icon()
        => handle = new();

    public Icon(nint hIcon)
        => handle = new(hIcon);

    public static readonly Icon Null = default;

    public nint Handle => handle;

    public bool IsNull => handle.IsNull;
}
