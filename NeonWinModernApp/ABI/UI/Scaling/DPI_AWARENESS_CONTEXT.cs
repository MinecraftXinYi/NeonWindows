using System.Diagnostics;

namespace NeonWindows.ABI.UI.Scaling;

/// <summary>
/// 标识窗口的感知上下文。
/// </summary>
[DebuggerDisplay("{Value}")]
public readonly struct DPI_AWARENESS_CONTEXT
{
    public readonly nint Value;

    public DPI_AWARENESS_CONTEXT(nint value) => this.Value = value;

    public static readonly DPI_AWARENESS_CONTEXT Null = default;

    public bool IsNull => Value == default;

    public override int GetHashCode() => unchecked((int)this.Value);

    public override string ToString() => $"0x{(nuint)this.Value:x}";

    public static implicit operator nint(DPI_AWARENESS_CONTEXT value) => value.Value;

    public static explicit operator DPI_AWARENESS_CONTEXT(nint value) => new(value);

    /// <summary>
    /// DPI 不知道。 此窗口不缩放 DPI 更改，并且始终假定其比例系数为 100% （96 DPI）。 系统将在任何其他 DPI 设置上自动缩放它。
    /// </summary>
    public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_UNAWARE = new(-1);

    /// <summary>
    /// DPI 不知道。 此窗口不缩放 DPI 更改，并且始终假定其比例系数为 100% （96 DPI）。 系统将在任何其他 DPI 设置上自动缩放它。
    /// </summary>
    public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_UNAWARE_MIXED = new(24592);

    /// <summary>
    /// 系统 DPI 感知。 此窗口不会缩放 DPI 更改。 它将查询 DPI 一次，并在进程的生存期内使用该值。 如果 DPI 发生更改，该过程将不会调整为新的 DPI 值。 当 DPI 从系统值发生更改时，系统会自动纵向扩展或缩减它。
    /// </summary>
    public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_SYSTEM_AWARE = new(-2);

    /// <summary>
    /// 系统 DPI 感知。 此窗口不会缩放 DPI 更改。 它将查询 DPI 一次，并在进程的生存期内使用该值。 如果 DPI 发生更改，该过程将不会调整为新的 DPI 值。 当 DPI 从系统值发生更改时，系统会自动纵向扩展或缩减它。
    /// </summary>
    public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_SYSTEM_AWARE_MIXED = new(30737);

    /// <summary>
    /// 每个监视器 DPI 感知。 此窗口在创建 DPI 时检查 DPI，并在 DPI 发生更改时调整比例因子。 系统不会自动缩放这些进程。
    /// </summary>
    public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE = new(-3);

    /// <summary>
    /// 每个监视器 DPI 感知。 此窗口在创建 DPI 时检查 DPI，并在 DPI 发生更改时调整比例因子。 系统不会自动缩放这些进程。
    /// </summary>
    public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_MIXED = new(18);

    /// <summary>
    /// 也称为 Per Monitor v2。 与原始按监视器 DPI 感知模式的提升，使应用程序能够基于每个顶级窗口访问与 DPI 相关的新缩放行为。
    /// 每个监视器 v2 在 Windows 10 的创意者更新（也称为版本 1703）中提供，在早期版本的操作系统上不可用。
    /// </summary>
    public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = new(-4);

    /// <summary>
    /// 也称为 Per Monitor v2。 与原始按监视器 DPI 感知模式的提升，使应用程序能够基于每个顶级窗口访问与 DPI 相关的新缩放行为。
    /// 每个监视器 v2 在 Windows 10 的创意者更新（也称为版本 1703）中提供，在早期版本的操作系统上不可用。
    /// </summary>
    public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2_MIXED = new(34);

    /// <summary>
    /// DPI 不知道基于 GDI 的内容的质量。 此模式的行为类似于DPI_AWARENESS_CONTEXT_UNAWARE，但也使系统能够在窗口显示在高 DPI 监视器上时自动提高文本和其他基于 GDI 的基元的呈现质量。
    /// DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED是在 2018 年 10 月 Windows 10 更新（也称为版本 1809）中引入的。
    /// </summary>
    public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED = new(-5);

    /// <summary>
    /// DPI 不知道基于 GDI 的内容的质量。 此模式的行为类似于DPI_AWARENESS_CONTEXT_UNAWARE，但也使系统能够在窗口显示在高 DPI 监视器上时自动提高文本和其他基于 GDI 的基元的呈现质量。
    /// DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED是在 2018 年 10 月 Windows 10 更新（也称为版本 1809）中引入的。
    /// </summary>
    public static readonly DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED_MIXED = new(1073766416);
}
