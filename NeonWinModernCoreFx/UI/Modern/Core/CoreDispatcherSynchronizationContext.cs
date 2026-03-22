using System.Threading;
using Windows.UI.Core;

namespace NeonWindows.UI.Modern.Core;

/// <summary>
/// 适用于 <see cref="CoreDispatcher"/> 的 <see cref="SynchronizationContext"/> 。
/// </summary>
public sealed class CoreDispatcherSynchronizationContext : SynchronizationContext
{
    /// <param name="dispatcher">用于初始化该 <see cref="SynchronizationContext"/> 实例的 <see cref="CoreDispatcher"/> 。</param>
    public CoreDispatcherSynchronizationContext(CoreDispatcher dispatcher)
        => Dispatcher = dispatcher;

    /// <summary>
    /// 该 <see cref="SynchronizationContext"/> 实例使用的 <see cref="CoreDispatcher"/> 。
    /// </summary>
    public CoreDispatcher Dispatcher { get; }

    public override void Post(SendOrPostCallback d, object? state)
        => _ = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => d?.Invoke(state));

    public override void Send(SendOrPostCallback d, object? state)
        => _ = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => d?.Invoke(state));
}
