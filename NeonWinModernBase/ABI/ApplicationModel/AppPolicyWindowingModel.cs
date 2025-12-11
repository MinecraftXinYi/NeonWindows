namespace NeonWindows.ABI.ApplicationModel;

/// <summary>
/// 指示进程是使用基于 CoreWindow 的窗口模型，还是使用基于 HWND 的窗口模型。
/// </summary>
public enum AppPolicyWindowingModel
{
    /// <summary>
    /// 指示进程没有窗口化模型。
    /// </summary>
    None,

    /// <summary>
    /// 指示进程的窗口化模型是基于 CoreWindow 的。
    /// </summary>
    Universal,

    /// <summary>
    /// 指示进程的窗口化模型是基于 HWND 的。
    /// </summary>
    ClassicDesktop,

    /// <summary>
    /// 指示进程的窗口化模型是基于 Silverlight 的，并且不提供窗口状态更改的通知。
    /// </summary>
    ClassicPhone
}
