namespace NeonWindows.UI.Scaling;

/// <summary>
/// 指定可应用于应用程序的不同 DPI 感知模式。
/// </summary>
public enum DpiAwarenessMode
{
    /// <summary>
    /// 应用程序窗口不会随着 DPI 更改而缩放，始终假定缩放比例为 100%。
    /// </summary>
    Unaware,

    /// <summary>
    /// 此窗口会查询一次主监视器的 DPI，并将其用于所有监视器上的应用程序。
    /// </summary>
    System,

    /// <summary>
    /// 此窗口会在创建 DPI 时对其进行检查，并在 DPI 更改时调整缩放比例。
    /// </summary>
    PerMonitor,

    /// <summary>
    /// 类似于 PerMonitor，但启用了子窗口 DPI 更改通知、comctl32 控件的改进缩放和对话框缩放。
    /// </summary>
    PerMonitorV2,

    /// <summary>
    /// 类似于 Unaware，但提高了基于 GDI/GDI+ 的内容的质量。
    /// </summary>
    UnawareGdiScaled
}
