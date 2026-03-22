using NeonWindows.ABI.UI.Modern.Core;
using Windows.UI.Core;
using WinRT;

namespace NeonWindows.UI.Modern.Core;

/// <summary>
/// 提供创建并初始化 <see cref="CoreDispatcher"/> 的功能。
/// </summary>
public static class CoreDispatcherBuilder
{
    /// <summary>
    /// 获取或创建与当前线程相关联的 <see cref="CoreDispatcher"/> 。
    /// </summary>
    /// <returns>与当前线程相关联的 <see cref="CoreDispatcher"/> 。</returns>
    public static CoreDispatcher GetOrCreateDispatcherForCurrentThread()
    {
        IInternalCoreDispatcherStatic internalCoreDispatcherStatic = ActivationFactoryForCoreDispatcher.AsInterface<IInternalCoreDispatcherStatic>();
        ExceptionHelpers.ThrowExceptionForHR(internalCoreDispatcherStatic.GetOrCreateForCurrentThread(out nint pDispatcher));
        return CoreDispatcher.FromAbi(pDispatcher);
    }

    private static IObjectReference ActivationFactoryForCoreDispatcher
        => ActivationFactory.Get(typeof(CoreDispatcher).FullName);
}
