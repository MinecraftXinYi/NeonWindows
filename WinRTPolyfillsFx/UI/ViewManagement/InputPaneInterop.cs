using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.ViewManagement;
using Windows.Win32;
using Windows.Win32.System.WinRT;

namespace NeonWindows.UI.ViewManagement;

public static class InputPaneInterop
{
    public static InputPane GetForWindow(nint appWindow)
        => (InputPane)inputPaneInterop.GetForWindow(new(appWindow), IID_IInputPane);

    internal static readonly Guid IID_IInputPane = new(1678432880u, 1779, 19591, 166, 120, 152, 41, 201, 18, 124, 40);

    private static IInputPaneInterop inputPaneInterop = (IInputPaneInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(InputPane));
}
