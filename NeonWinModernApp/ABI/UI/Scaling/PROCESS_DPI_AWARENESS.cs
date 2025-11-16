namespace NeonWindows.ABI.UI.Scaling;

/// <summary>
/// 标识每英寸点数 (dpi) 感知值。 DPI 感知指示应用程序为 DPI 执行的缩放工作量与系统完成的缩放量。
/// </summary>
public enum PROCESS_DPI_AWARENESS
{
    /// <summary>
    /// DPI 不知道。 此应用不会缩放 DPI 更改，并且始终假定其比例系数为 100% (96 DPI) 。 系统将在任何其他 DPI 设置上自动缩放它。
    /// </summary>
    PROCESS_DPI_UNAWARE,

    /// <summary>
    /// 系统 DPI 感知。 此应用不会缩放 DPI 更改。 它将查询 DPI 一次，并在应用的生存期内使用该值。 如果 DPI 发生更改，应用将不会调整为新的 DPI 值。 当 DPI 与系统值发生更改时，系统会自动纵向扩展或缩减它。
    /// </summary>
    PROCESS_SYSTEM_DPI_AWARE,

    /// <summary>
    /// 按监视器 DPI 感知。 此应用在创建 DPI 时检查 DPI，并在 DPI 发生更改时调整比例系数。 系统不会自动缩放这些应用程序。
    /// </summary>
    PROCESS_PER_MONITOR_DPI_AWARE
}
