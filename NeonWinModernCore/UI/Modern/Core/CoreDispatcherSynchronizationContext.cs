using System.Threading;
using Windows.UI.Core;

namespace NeonWindows.UI.Modern.Core;

/// <summary>
/// 适用于 <see cref="CoreDispatcher"/> 的 <see cref="SynchronizationContext"/> 。
/// </summary>
/// <param name="dispatcher">用于初始化该 <see cref="SynchronizationContext"/> 实例的 <see cref="CoreDispatcher"/> 。</param>
public sealed class CoreDispatcherSynchronizationContext(CoreDispatcher dispatcher) : SynchronizationContext
{
    /// <summary>
    /// 该 <see cref="SynchronizationContext"/> 实例使用的 <see cref="CoreDispatcher"/> 。
    /// </summary>
    public CoreDispatcher Dispatcher { get; } = dispatcher;

    public override void Post(SendOrPostCallback d, object? state)
        => _ = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => d?.Invoke(state));

    public override void Send(SendOrPostCallback d, object? state)
        => _ = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => d?.Invoke(state));
}
