namespace NeonWindows.ABI.UI.Composition;

/// <summary>
/// Specifies options used by the <see cref="WindowCompositionAttribData"/> structure.
/// </summary>
public enum WindowCompositionAttrib
{
    WCA_UNDEFINED,

    /// <summary>
    /// DWMWA_NCRENDERING_ENABLED
    /// </summary>
    WCA_NCRENDERING_ENABLED,

    /// <summary>
    /// DWMWA_NCRENDERING_POLICY
    /// </summary>
    WCA_NCRENDERING_POLICY,

    /// <summary>
    /// DWMWA_TRANSITIONS_FORCEDISABLED
    /// </summary>
    WCA_TRANSITIONS_FORCEDISABLED,

    /// <summary>
    /// DWMWA_ALLOW_NCPAINT
    /// </summary>
    WCA_ALLOW_NCPAINT,

    /// <summary>
    /// DWMWA_CAPTION_BUTTON_BOUNDS
    /// </summary>
    WCA_CAPTION_BUTTON_BOUNDS,

    /// <summary>
    /// DWMWA_NONCLIENT_RTL_LAYOUT
    /// </summary>
    WCA_NONCLIENT_RTL_LAYOUT,

    /// <summary>
    /// DWMWA_FORCE_ICONIC_REPRESENTATION
    /// </summary>
    WCA_FORCE_ICONIC_REPRESENTATION,

    /// <summary>
    /// DWMWA_EXTENDED_FRAME_BOUNDS
    /// </summary>
    WCA_EXTENDED_FRAME_BOUNDS,

    /// <summary>
    /// DWMWA_HAS_ICONIC_BITMAP
    /// </summary>
    WCA_HAS_ICONIC_BITMAP,

    WCA_THEME_ATTRIBUTES,

    WCA_NCRENDERING_EXILED,

    WCA_NCADORNMENTINFO,

    /// <summary>
    /// DWMWA_EXCLUDED_FROM_PEEK
    /// </summary>
    WCA_EXCLUDED_FROM_LIVEPREVIEW,

    WCA_VIDEO_OVERLAY_ACTIVE,

    WCA_FORCE_ACTIVEWINDOW_APPEARANCE,

    /// <summary>
    /// DWMWA_DISALLOW_PEEK
    /// </summary>
    WCA_DISALLOW_PEEK,

    /// <summary>
    /// DWMWA_CLOAK
    /// </summary>
    WCA_CLOAK,

    /// <summary>
    /// DWMWA_CLOAKED
    /// </summary>
    WCA_CLOAKED,

    /// <summary>
    /// 修改窗口强调模式，pvData 指向 ACCENT_POLICY 结构。
    /// </summary>
    WCA_ACCENT_POLICY,

    /// <summary>
    /// DWMWA_FREEZE_REPRESENTATION
    /// </summary>
    WCA_FREEZE_REPRESENTATION,

    WCA_EVER_UNCLOAKED,

    WCA_VISUAL_OWNER,

    WCA_HOLOGRAPHIC,

    /// <summary>
    /// 防止桌面复制API捕捉窗口，pvData 指向 BOOL 类型的值。
    /// </summary>
    WCA_EXCLUDED_FROM_DDA,

    /// <summary>
    /// DWMWA_PASSIVE_UPDATE_MODE
    /// </summary>
    WCA_PASSIVEUPDATEMODE,

    /// <summary>
    /// DWMWA_USE_IMMERSIVE_DARK_MODE
    /// </summary>
    WCA_USEDARKMODECOLORS,

    /// <summary>
    /// DWMWA_WINDOW_CORNER_PREFERENCE
    /// </summary>
    WCA_MINIMIZE_ANIMATION,

    WCA_MAXIMIZE_ANIMATION,

    WCA_DISABLE_MOVESIZE_FEEDBACK,

    /// <summary>
    /// DWMWA_SYSTEM_BACKDROP_TYPE
    /// </summary>
    WCA_SYSTEM_BACKDROP_TYPE,

    WCA_SET_TAGGED_WINDOW_RECT,

    WCA_CLEAR_TAGGED_WINDOW_RECT,

    WCA_LAST
}
