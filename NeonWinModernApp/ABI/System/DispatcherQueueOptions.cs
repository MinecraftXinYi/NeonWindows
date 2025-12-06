using System.Runtime.InteropServices;

namespace NeonWindows.ABI.System;

/// <summary>
/// 表示有关新 DispatcherQueueController 的线程关联和 COM 单元类型的选项。
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct DispatcherQueueOptions
{
    /// <summary>
    /// 此 DispatcherQueueOptions 结构的大小。
    /// </summary>
    public uint dwSize;

    /// <summary>
    /// 新 DispatcherQueueController 的线程相关性。
    /// </summary>
    public DISPATCHERQUEUE_THREAD_TYPE threadType;

    /// <summary>
    /// 指定是将新线程上的 COM 单元初始化为应用程序单线程单元 (ASTA) 还是单线程单元 (STA) 。
    /// 仅当 threadType 为 <see cref="DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_DEDICATED"/> 时，此字段才相关。
    /// threadType 为 <see cref="DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_CURRENT"/> 时使用 <see cref="DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_NONE"/>。
    /// </summary>
    public DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType;
}
