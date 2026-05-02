using Windows.Win32.UI.Shell;

namespace NeonWindows.WinRT.Interop;

public static class InitializeWithWindow
{
    public static void Initialize(object target, nint hwnd)
        => ((IInitializeWithWindow)target).Initialize(new(hwnd));
}
