using NeonWindows.ABI.UI.Windowing;

namespace NeonWindows.UI.Content;

public static class ContentWindow
{
    public static void PrepareClientOnlyContentWindow(nint hContent)
    {
        long contentLong = WindowLongApi.GetWindowLongW(hContent, WindowLongApi.GWL_STYLE);
        WindowLongApi.SetWindowLongW(hContent, WindowLongApi.GWL_STYLE, contentLong & ~WindowLongApi.WS_OVERLAPPEDWINDOW & ~WindowLongApi.WS_POPUPWINDOW | WindowLongApi.WS_CHILDWINDOW);
        uint setposFlags =/* WindowRectApi.SWP_FRAMECHANGED |*/ WindowRectApi.SWP_NOACTIVATE | WindowRectApi.SWP_NOMOVE/* | WindowRectApi.SWP_NOOWNERZORDER*/ | WindowRectApi.SWP_NOSIZE;
        WindowRectApi.SetWindowPos(hContent, default, 0, 0, 0, 0, setposFlags);
    }

    public static void SetRootContentWindow(nint hContent, nint hParent, nint hContentInsertAfter = default)
    {
        WindowParentApi.SetParent(hContent, hParent);
        WindowRectApi.GetClientRect(hParent, out RECT parentClientRect);
        int cx = parentClientRect.right - parentClientRect.left, cy = parentClientRect.bottom - parentClientRect.top;
        WindowRectApi.SetWindowPos(hContent, hContentInsertAfter, 0, 0, cx, cy, WindowRectApi.SWP_NOACTIVATE | WindowRectApi.SWP_NOZORDER | WindowRectApi.SWP_SHOWWINDOW);
    }
}
