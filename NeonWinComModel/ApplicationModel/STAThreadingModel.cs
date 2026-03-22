using System.Threading;

namespace NeonWindows.ApplicationModel;

/// <summary>
/// 提供 Windows STA 线程模型相关功能。
/// </summary>
public static class STAThreadingModel
{
    /// <summary>
    /// 检索当前线程是否为 STA 模型线程。
    /// </summary>
    public static bool IsSTAThread
    {
        get => Thread.CurrentThread.GetApartmentState() == ApartmentState.STA;
    }

    /// <summary>
    /// 新建一个 STA 模型线程。
    /// </summary>
    /// <param name="start">表示开始执行此线程时要调用的方法的 <see cref="ThreadStart"/> 委托。</param>
    /// <returns>创建的 STA 模型线程。</returns>
    public static Thread CreateSTAThread(ThreadStart start)
    {
        Thread thread = new(start);
        thread.SetApartmentState(ApartmentState.STA);
        return thread;
    }

    /// <summary>
    /// 新建一个 STA 模型线程，指定允许对象在线程启动时传递给线程的委托。
    /// </summary>
    /// <param name="start">一个委托，它表示此线程开始执行时要调用的方法。</param>
    /// <returns>创建的 STA 模型线程。</returns>
    public static Thread CreateSTAThread(ParameterizedThreadStart start)
    {
        Thread thread = new(start);
        thread.SetApartmentState(ApartmentState.STA);
        return thread;
    }
}
