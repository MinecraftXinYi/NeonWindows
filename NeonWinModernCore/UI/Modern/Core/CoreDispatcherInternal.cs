using NeonWindows.ABI.UI.Modern.Core;
using Windows.System;
using Windows.UI.Core;
using WinRT;

namespace NeonWindows.UI.Modern.Core;

/// <summary>
/// 用于访问 <see cref="CoreDispatcher"/> 的内部功能。
/// </summary>
public static class CoreDispatcherInternal
{
    /// <summary>
    /// 获取 <see cref="CoreDispatcher"/> 内部的 <see cref="DispatcherQueue"/> 实例。
    /// </summary>
    /// <param name="dispatcher">要操作的 <see cref="CoreDispatcher"/> 实例。</param>
    /// <returns>获取到的 <see cref="DispatcherQueue"/> 实例。</returns>
    public static DispatcherQueue GetDispatcherQueue(this CoreDispatcher dispatcher)
    {
        ExceptionHelpers.ThrowExceptionForHR(dispatcher.As<IInternalDispatcher2>().GetDispatcherQueue(out nint pDispatcherQueue));
        return DispatcherQueue.FromAbi(pDispatcherQueue);
    }
}
