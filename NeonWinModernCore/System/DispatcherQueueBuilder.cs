using NeonWindows.ABI.System;
using System.Runtime.InteropServices;
using Windows.System;
using WinRT;

namespace NeonWindows.System;

public static class DispatcherQueueBuilder
{
    public static DispatcherQueueController CreateDispatcherQueueForCurrentThread()
    {
        DispatcherQueueOptions options = new()
        {
            threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_CURRENT,
            apartmentType = DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_NONE
        };
        options.dwSize = (uint)Marshal.SizeOf(options);
        ExceptionHelpers.ThrowExceptionForHR(DispatcherQueueApi.CreateDispatcherQueueController(options, out nint pDispatcherQueueController));
        return DispatcherQueueController.FromAbi(pDispatcherQueueController);
    }

    public static DispatcherQueueController CreateDispatcherQueueOnDedicatedSTAThread()
    {
        DispatcherQueueOptions options = new()
        {
            threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_DEDICATED,
            apartmentType = DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_STA
        };
        options.dwSize = (uint)Marshal.SizeOf(options);
        ExceptionHelpers.ThrowExceptionForHR(DispatcherQueueApi.CreateDispatcherQueueController(options, out nint pDispatcherQueueController));
        return DispatcherQueueController.FromAbi(pDispatcherQueueController);
    }
}
