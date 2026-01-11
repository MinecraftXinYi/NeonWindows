using NeonWindows.ABI.UI.Composition;
using NeonWindows.ABI.UI.UxTheme;
using System;
using System.Runtime.InteropServices;

namespace NeonWindows.UI.Immersive;

/// <summary>
/// 提供应用程序沉浸式主题管理功能。
/// </summary>
public static class ImmersiveAppTheme
{
    /// <summary>
    /// 设置是否启用窗口上下文菜单深色模式。
    /// </summary>
    public static bool UseDarkModeForWindowContextMenu
    {
        set
        {
            try
            {
                UXThemeAppModeApi.SetPreferredAppMode(value ? PreferredAppMode.ForceDark : PreferredAppMode.Default);
                UXThemeAppModeApi.FlushMenuThemes();
            }
            catch (TypeLoadException) { }
        }
    }

    /// <summary>
    /// 检索指定窗口是否启用沉浸式深色模式。
    /// </summary>
    /// <param name="hWnd">要检索的窗口。</param>
    /// <param name="enabled">指示是否开启沉浸式深色模式。</param>
    /// <returns>指示操作是否成功。</returns>
    public unsafe static bool GetImmersiveDarkModeForWindow(nint hWnd, out bool enabled)
    {
        int useDarkMode = 0;
        WindowCompositionAttribData dwAttribute;
        dwAttribute.Attrib = WindowCompositionAttrib.WCA_USEDARKMODECOLORS;
        dwAttribute.pvData = &useDarkMode;
        dwAttribute.cbData = (uint)Marshal.SizeOf(useDarkMode);
        try
        {
            bool retval = WindowCompositionNativeApi2.NtUserGetWindowCompositionAttribute(hWnd, &dwAttribute);
            enabled = useDarkMode != 0;
            return retval;
        }
        catch (TypeLoadException)
        {
            enabled = false;
            return false;
        }
    }

    /// <summary>
    /// 为指定窗口启用或禁用沉浸式深色模式。
    /// </summary>
    /// <param name="hWnd">要设置的窗口。</param>
    /// <param name="enabled">指示是否开启沉浸式深色模式。</param>
    /// <returns>指示操作是否成功。</returns>
    public unsafe static bool SetImmersiveDarkModeForWindow(nint hWnd, bool enabled)
    {
        int useDarkMode = enabled ? 1 : 0;
        WindowCompositionAttribData dwAttribute;
        dwAttribute.Attrib = WindowCompositionAttrib.WCA_USEDARKMODECOLORS;
        dwAttribute.pvData = &useDarkMode;
        dwAttribute.cbData = (uint)Marshal.SizeOf(useDarkMode);
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
