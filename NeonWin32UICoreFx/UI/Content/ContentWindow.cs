using System.Windows.Forms;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Content;

public static class ContentWindow
{
    public static void PrepareClientOnlyContentWindow(IWin32Window content)
    {
        HWND hContent = new(content.Handle);
        int contentLong = PInvoke.GetWindowLong(hContent, WINDOW_LONG_PTR_INDEX.GWL_STYLE);
        contentLong = (int)((WINDOW_STYLE)contentLong & ~WINDOW_STYLE.WS_OVERLAPPEDWINDOW & ~WINDOW_STYLE.WS_POPUPWINDOW | WINDOW_STYLE.WS_CHILDWINDOW);
        PInvoke.SetWindowLong(hContent, WINDOW_LONG_PTR_INDEX.GWL_STYLE, contentLong);
        SET_WINDOW_POS_FLAGS setposFlags = SET_WINDOW_POS_FLAGS.SWP_FRAMECHANGED | SET_WINDOW_POS_FLAGS.SWP_NOACTIVATE | SET_WINDOW_POS_FLAGS.SWP_NOMOVE | SET_WINDOW_POS_FLAGS.SWP_NOSIZE;
        PInvoke.SetWindowPos(hContent, default, 0, 0, 0, 0, setposFlags);
    }

    public static void SetRootContentWindow(IWin32Window content, IWin32Window parent, IWin32Window? contentInsertAfter = default)
    {
        HWND hContent = new(content.Handle), hParent = new(parent.Handle), hContentInsertAfter = contentInsertAfter != null ? new(contentInsertAfter.Handle) : default;
        PInvoke.SetParent(hContent, hParent);
        PInvoke.GetClientRect(hParent, out RECT parentClientRect);
        PInvoke.SetWindowPos(hContent, hContentInsertAfter, 0, 0, parentClientRect.Width, parentClientRect.Height, SET_WINDOW_POS_FLAGS.SWP_NOACTIVATE | SET_WINDOW_POS_FLAGS.SWP_SHOWWINDOW);
    }
}
