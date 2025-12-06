using System.Runtime.InteropServices;

namespace NeonWindows.ABI.System;

public static class DispatcherQueueApi
{
    /// <summary>
    /// 创建 DispatcherQueueController。 使用创建的 DispatcherQueueController 创建和管理 DispatcherQueue 的生存期，以在调度程序队列的线程上按优先级顺序运行排队任务。
    /// </summary>
    /// <param name="options">创建的 DispatcherQueueController 的线程关联和 COM 单元类型。</param>
    /// <param name="dispatcherQueueController">创建的调度程序队列控制器。</param>
    /// <returns>成功 S_OK; 否则为失败代码。</returns>
    [DllImport(Win32DllName.CoreMessaging, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern int CreateDispatcherQueueController(DispatcherQueueOptions options, out nint dispatcherQueueController);
}
