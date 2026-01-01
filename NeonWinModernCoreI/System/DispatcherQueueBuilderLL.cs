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
    public static nint CreateDispatcherQueueForCurrentThread()
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
    /// 在专用线程上创建 DispatcherQueue。
    /// </summary>
    /// <param name="apartmentType">DispatcherQueueController COM 单元类型。</param>
    /// <returns>创建的 DispatcherQueueController 对象的指针。</returns>
    /// <exception cref="PlatformNotSupportedException"></exception>
    public static nint CreateDispatcherQueueOnDedicatedThread(DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType)
    {
        try
        {
            DispatcherQueueOptions options = new()
            {
                threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_DEDICATED,
                apartmentType = apartmentType,
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
