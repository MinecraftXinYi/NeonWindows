using NeonWindows.UI.Windowing;
using NeonWindows.UI.Windowing.Core;
using System.Drawing;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Content;

public static class ContentWindow
{
    public static void PrepareClientOnlyContentWindow(IWin32Window content)
    {
        int contentStyle = NativeWindowInterop2.GetWindowStyle(content.Handle);
        contentStyle = (int)((WINDOW_STYLE)contentStyle & ~WINDOW_STYLE.WS_OVERLAPPEDWINDOW & ~WINDOW_STYLE.WS_POPUPWINDOW | WINDOW_STYLE.WS_CHILDWINDOW);
        NativeWindowInterop2.SetWindowStyle(content.Handle, contentStyle);
        SET_WINDOW_POS_FLAGS setposFlags = SET_WINDOW_POS_FLAGS.SWP_FRAMECHANGED | SET_WINDOW_POS_FLAGS.SWP_NOACTIVATE | SET_WINDOW_POS_FLAGS.SWP_NOMOVE | SET_WINDOW_POS_FLAGS.SWP_NOSIZE | SET_WINDOW_POS_FLAGS.SWP_NOZORDER;
        NativeWindowInterop.SetWindowRect(content.Handle, default, default, (uint)setposFlags);
    }

    public static void SetRootContentWindow(IWin32Window content, IWin32Window parent)
    {
        NativeWindowInterop2.SetWindowParent(content.Handle, parent.Handle);
        Rectangle parentClientRect = NativeWindowInterop.GetClientRect(parent.Handle);
        NativeWindowInterop.SetWindowRect(content.Handle, default, new(default, new(parentClientRect.Width, parentClientRect.Height)), (uint)(SET_WINDOW_POS_FLAGS.SWP_NOACTIVATE | SET_WINDOW_POS_FLAGS.SWP_SHOWWINDOW));
    }
}
