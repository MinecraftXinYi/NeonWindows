using NeonWindows.ABI.UI.Composition;
using System;
using System.Runtime.InteropServices;

namespace NeonWindows.UI.Modern;

/// <summary>
/// 提供针对 Win32 应用的 Windows.UI.Composition 背景画笔渲染支持。
/// </summary>
public unsafe static class BackdropCompositionPatch
{
    /// <summary>
    /// 检索指定非 UWP 窗口是否已开启主机背景笔刷支持。
    /// </summary>
    /// <param name="hWnd">要检索的窗口。</param>
    /// <param name="enabled">指示是否已开启主机背景笔刷支持。</param>
    /// <returns>指示操作是否成功。</returns>
    public static bool GetHostBackdropBrushEnabled(nint hWnd, out bool enabled)
    {
        WindowCompositionAttribData dwAttribute;
        dwAttribute.Attrib = WindowCompositionAttrib.WCA_ACCENT_POLICY;
        AccentPolicy policy;
        dwAttribute.pvData = &policy;
        dwAttribute.cbData = (uint)Marshal.SizeOf(policy);
        try
        {
            bool retval = WindowCompositionNativeApi2.NtUserGetWindowCompositionAttribute(hWnd, &dwAttribute);
            enabled = policy.AccentState == AccentState.ENABLE_HOSTBACKDROP;
            return retval;
        }
        catch (TypeLoadException)
        {
            enabled = false;
            return false;
        }
    }

    /// <summary>
    /// 为指定非 UWP 窗口开启主机背景笔刷支持。
    /// </summary>
    /// <param name="hWnd">要开启主机背景笔刷支持的窗口。</param>
    /// <returns>指示操作是否成功。</returns>
    public static bool EnableHostBackdropBrush(nint hWnd)
    {
        WindowCompositionAttribData dwAttribute;
        dwAttribute.Attrib = WindowCompositionAttrib.WCA_ACCENT_POLICY;
        AccentPolicy policy;
        policy.AccentState = AccentState.ENABLE_HOSTBACKDROP;
        dwAttribute.pvData = &policy;
        dwAttribute.cbData = (uint)Marshal.SizeOf(policy);
        try
        {
            return WindowCompositionNativeApi2.NtUserSetWindowCompositionAttribute(hWnd, &dwAttribute);
        }
        catch (TypeLoadException)
        {
            return false;
        }
    }
}
