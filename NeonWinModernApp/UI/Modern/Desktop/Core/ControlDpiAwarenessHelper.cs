using NeonWindows.UI.Scaling;
using NeonWindows.UI.Windowing;
using System.Windows.Forms;

namespace NeonWindows.UI.Modern.Desktop.Core;

internal static class ControlDpiAwarenessHelper
{
    internal static void AdjustControlDpiAwarenessForCurrentThread(Control control)
        => WinFormsDpiAwareness.SetDpiAwarenessForNativeWindow(WinFormsNativeWindowInterop.GetNativeWindowForControl(control), AppDpiAwareness2.CurrentThreadDpiAwarenessMode);
}
