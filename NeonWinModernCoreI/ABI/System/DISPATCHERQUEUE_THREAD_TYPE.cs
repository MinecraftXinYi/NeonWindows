namespace NeonWindows.ABI.System;

/// <summary>
/// 定义常量，这些常量指定有关新 DispatcherQueueController 线程关联的选项。
/// </summary>
public enum DISPATCHERQUEUE_THREAD_TYPE
{
    /// <summary>
    /// 指定将在专用线程上创建 DispatcherQueueController 的 DispatcherQueue。
    /// </summary>
    DQTYPE_THREAD_DEDICATED = 1,

    /// <summary>
    /// 指定将在调用方线程上创建 DispatcherQueueController 的 DispatcherQueue。
    /// </summary>
    DQTYPE_THREAD_CURRENT = 2
}
