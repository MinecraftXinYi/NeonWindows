namespace NeonWindows.ABI.System;

/// <summary>
/// 定义常量，这些常量指定新 DispatcherQueueController COM 单元类型的选项。
/// </summary>
public enum DISPATCHERQUEUE_THREAD_APARTMENTTYPE
{
    /// <summary>
    /// 未指定 COM 线程单元类型。
    /// </summary>
    DQTAT_COM_NONE,

    /// <summary>
    /// 指定应用程序单线程单元 (ASTA) COM 线程单元。
    /// </summary>
    DQTAT_COM_ASTA,

    /// <summary>
    /// 指定单线程单元 (STA) COM 线程单元。
    /// </summary>
    DQTAT_COM_STA
}
