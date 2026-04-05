using NeonWindows.ABI.System;
using System.Runtime.InteropServices;
using Windows.System;

namespace NeonWindows.System;

/// <summary>
/// 提供创建并初始化 <see cref="DispatcherQueue"/> 实例的功能。
/// </summary>
public static class DispatcherQueueFactory
{
    /// <summary>
    /// 在当前线程上创建并初始化 <see cref="DispatcherQueue"/> 实例。
    /// </summary>
    /// <param name="controller">创建的 <see cref="DispatcherQueueController"/> 实例。</param>
    /// <returns>创建的 <see cref="DispatcherQueue"/> 实例。</returns>
    public static DispatcherQueue CreateDispatcherQueueForCurrentThread(out DispatcherQueueController controller)
    {
        DispatcherQueueOptions options = new()
        {
            threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_CURRENT,
            apartmentType = DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_NONE
        };
        return CreateDispatcherQueueInternal(options, out controller);
    }

    /// <summary>
    /// 在专用 STA 模型线程上创建 <see cref="DispatcherQueue"/> 实例。
    /// </summary>
    /// <param name="controller">创建的 <see cref="DispatcherQueueController"/> 实例。</param>
    /// <returns>创建的 <see cref="DispatcherQueue"/> 实例。</returns>
    public static DispatcherQueue CreateDispatcherQueueOnDedicatedSTAThread(out DispatcherQueueController controller)
    {
        DispatcherQueueOptions options = new()
        {
            threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_DEDICATED,
            apartmentType = DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_STA
        };
        return CreateDispatcherQueueInternal(options, out controller);
    }

    /// <summary>
    /// 在当前线程上创建并初始化 <see cref="DispatcherQueue"/> 实例。
    /// </summary>
    /// <returns>创建的 <see cref="DispatcherQueue"/> 实例。</returns>
    public static DispatcherQueue CreateDispatcherQueueForCurrentThread2()
    {
        DispatcherQueueApi2.CreateDispatcherQueueForCurrentThread(out nint pDispatcherQueue);
        return (DispatcherQueue)Marshal.GetObjectForIUnknown(pDispatcherQueue);
    }

    private static DispatcherQueue CreateDispatcherQueueInternal(DispatcherQueueOptions options, out DispatcherQueueController controller)
    {
        options.dwSize = (uint)Marshal.SizeOf(options);
        Marshal.ThrowExceptionForHR(DispatcherQueueApi.CreateDispatcherQueueController(options, out nint pDispatcherQueueController));
        controller = (DispatcherQueueController)Marshal.GetObjectForIUnknown(pDispatcherQueueController);
        return controller.DispatcherQueue;
    }
}
