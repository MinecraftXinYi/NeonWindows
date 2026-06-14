using NeonWindows.ABI.UI.Scaling;

namespace NWBDpiApiTest;

/// <summary>
/// 提供与用户界面缩放相关联的系统信息。
/// </summary>
public static class ScaleInfo
{
    /// <summary>
    /// 系统 DPI 值。
    /// </summary>
    public static uint SystemDpi
        => DpiInfoApi.GetDpiForSystem();

    /// <summary>
    /// 系统 DPI 值 (忽略 DPI 感知模式)。
    /// </summary>
    public static uint SystemDpiDirect
        => DpiInfoApi.GetDpiFromDpiAwarenessContext(DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_SYSTEM_AWARE);

    /// <summary>
    /// 获取指定窗口的 DPI 值。
    /// </summary>
    /// <param name="hWnd">检索其 DPI 的窗口句柄。</param>
    /// <returns>指定窗口的 DPI 值。</returns>
    public static uint WindowDpi(nint hWnd)
        => DpiInfoApi.GetDpiForWindow(hWnd);

    /// <summary>
    /// 将 DPI 值转换为缩放比例系数。
    /// </summary>
    /// <param name="dpi">要转换的 DPI 值。</param>
    /// <returns>缩放比例系数。</returns>
    public static float DpiToScaleFactor(uint dpi)
        => (float)dpi / DpiInfoApi.USER_DEFAULT_SCREEN_DPI;
}
