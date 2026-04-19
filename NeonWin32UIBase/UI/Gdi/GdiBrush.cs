using Windows.Win32.Graphics.Gdi;

namespace NeonWindows.UI.Gdi;

public readonly struct GdiBrush
{
    internal readonly HBRUSH handle;

    public GdiBrush()
        => handle = new();

    public GdiBrush(nint hBrush)
        => handle = new(hBrush);

    public static readonly GdiBrush Null = default;

    public nint Handle => handle;

    public bool IsNull => handle.IsNull;
}
