using NeonWindows.ABI.UI.Composition;
using System.Runtime.InteropServices;

namespace NeonWindows.UI.Modern;

/// <summary>
/// 提供针对 Win32 应用的 Windows.UI.Composition 背景画笔渲染支持。
/// </summary>
public unsafe static class BackdropCompositionPatch
{
    /// <summary>
    /// 为指定非 UWP 窗口开启主机背景笔刷支持。
    /// </summary>
    /// <param name="hWnd">要开启主机背景笔刷支持的窗口。</param>
    /// <returns>指示操作是否成功。</returns>
    public static bool EnableHostBackdropBrush(nint hWnd)
    {
        // Windows.UI.Xaml.dll!DirectUI::Window::EnableHostBackdropBrush
        WindowCompositionAttribData dwAttribute;
        dwAttribute.Attrib = WindowCompositionAttrib.WCA_ACCENT_POLICY;
        AccentPolicy policy;
        policy.AccentState = AccentState.ENABLE_HOSTBACKDROP;
        dwAttribute.pvData = &policy;
        dwAttribute.cbData = (uint)Marshal.SizeOf(policy);
        return WindowCompositionNativeApi.SetWindowCompositionAttribute(hWnd, &dwAttribute);
    }

    /// <summary>
    /// 检索指定非 UWP 窗口是否已开启主机背景笔刷支持。
    /// </summary>
    /// <param name="hWnd">要检索的窗口。</param>
    /// <returns>指示是否已开启主机背景笔刷支持。</returns>
    public static bool IsHostBackdropBrushEnabled(nint hWnd)
    {
        WindowCompositionAttribData dwAttribute;
        dwAttribute.Attrib = WindowCompositionAttrib.WCA_ACCENT_POLICY;
        AccentPolicy policy;
        dwAttribute.pvData = &policy;
        dwAttribute.cbData = (uint)Marshal.SizeOf(policy);
        if (!WindowCompositionNativeApi.GetWindowCompositionAttribute(hWnd, &dwAttribute)) return false;
        return policy.AccentState == AccentState.ENABLE_HOSTBACKDROP;
    }
}
