using NeonWindows.ABI.System;
using System.Runtime.InteropServices;
using Windows.System;
using WinRT;

namespace NeonWindows.System;

public static class DispatcherQueueBuilder
{
    public static DispatcherQueue CreateDispatcherQueueForCurrentThread(out DispatcherQueueController controller)
    {
        DispatcherQueueOptions options = new()
        {
            threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_CURRENT,
            apartmentType = DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_NONE
        };
        return CreateDispatcherQueueInternal(options, out controller);
    }

    public static DispatcherQueue CreateDispatcherQueueOnDedicatedSTAThread(out DispatcherQueueController controller)
    {
        DispatcherQueueOptions options = new()
        {
            threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_DEDICATED,
            apartmentType = DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_STA
        };
        return CreateDispatcherQueueInternal(options, out controller);
    }

    public static DispatcherQueue CreateDispatcherQueueForCurrentThread2()
    {
        DispatcherQueueApi2.CreateDispatcherQueueForCurrentThread(out nint pDispatcherQueue);
        return DispatcherQueue.FromAbi(pDispatcherQueue);
    }

    private static DispatcherQueue CreateDispatcherQueueInternal(DispatcherQueueOptions options, out DispatcherQueueController controller)
    {
        options.dwSize = (uint)Marshal.SizeOf(options);
        ExceptionHelpers.ThrowExceptionForHR(DispatcherQueueApi.CreateDispatcherQueueController(options, out nint pDispatcherQueueController));
        controller = DispatcherQueueController.FromAbi(pDispatcherQueueController);
        return controller.DispatcherQueue;
    }
}
