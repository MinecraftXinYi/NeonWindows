namespace NeonWindows.ABI.UI.Composition;

public enum AccentState
{
    /// <summary>
    /// 禁用渲染效果。
    /// </summary>
    DISABLED,

    /// <summary>
    /// 类似于纯色 (GradientColor 字段)，且四边框均被着色。
    /// </summary>
    ENABLE_GRADIENT,

    /// <summary>
    /// 类似于纯色 (使用系统主题的颜色而非 GradientColor)，且四边框均被着色。
    /// </summary>
    ENABLE_TRANSPARENTGRADIENT,

    /// <summary>
    /// 透明的模糊效果，不使用 GradientColor。
    /// </summary>
    ENABLE_BLURBEHIND,

    /// <summary>
    /// 1803+，亚克力效果，支持与一个半透明的颜色 (GradientColor 字段) 叠加。
    /// </summary>
    ENABLE_ACRYLICBLURBEHIND,

    /// <summary>
    /// 1809+，允许非 UWP 窗口使用 HostBackdropBrush，仅使用 AccentState 字段。
    /// DwmSWA 将 DWMWA_USE_HOSTBACKDROPBRUSH 转发到 ACCENT_ENABLE_HOSTBACKDROP。
    /// </summary>
    ENABLE_HOSTBACKDROP,

    INVALID_STATE
}
