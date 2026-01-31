using NeonWindows.ABI.System;
using System;
using System.Runtime.InteropServices;

namespace NeonWindows.System;

/// <summary>
/// Low-Level DispatcherQueueBuilder
/// </summary>
public static class DispatcherQueueBuilderLL
{
    /// <summary>
    /// 在当前线程上创建 DispatcherQueue。
    /// </summary>
    /// <returns>创建的 DispatcherQueueController 对象的指针。</returns>
    /// <exception cref="PlatformNotSupportedException"></exception>
    public static nint CreateDispatcherQueueOnCurrentThread()
    {
        try
        {
            DispatcherQueueOptions options = new()
            {
                threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_CURRENT,
                apartmentType = DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_NONE,
                dwSize = (uint)Marshal.SizeOf<DispatcherQueueOptions>()
            };
            int hr = DispatcherQueueApi.CreateDispatcherQueueController(options, out nint pDispatcherQueueController);
            if (hr != 0x00000000) Marshal.ThrowExceptionForHR(hr);
            return pDispatcherQueueController;
        }
        catch (TypeLoadException)
        {
            throw new PlatformNotSupportedException();
        }
    }

    /// <summary>
    /// 在 STA 单元类型的专用线程上创建 DispatcherQueue。
    /// </summary>
    /// <returns>创建的 DispatcherQueueController 对象的指针。</returns>
    /// <exception cref="PlatformNotSupportedException"></exception>
    public static nint CreateDispatcherQueueOnDedicatedSTAThread()
    {
        try
        {
            DispatcherQueueOptions options = new()
            {
                threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_DEDICATED,
                apartmentType = DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_STA,
                dwSize = (uint)Marshal.SizeOf<DispatcherQueueOptions>()
            };
            int hr = DispatcherQueueApi.CreateDispatcherQueueController(options, out nint pDispatcherQueueController);
            if (hr != 0x00000000) Marshal.ThrowExceptionForHR(hr);
            return pDispatcherQueueController;
        }
        catch (TypeLoadException)
        {
            throw new PlatformNotSupportedException();
        }
    }
}
