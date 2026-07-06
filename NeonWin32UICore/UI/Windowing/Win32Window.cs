using Windows.Win32.Foundation;

namespace NeonWindows.UI.Windowing;

public readonly struct Win32Window : IWin32Window
{
    internal readonly HWND _handle;

    public Win32Window(nint hWnd)
        => _handle = new(hWnd);

    public Win32Window()
        => _handle = new();

    public nint Handle => _handle;
}
