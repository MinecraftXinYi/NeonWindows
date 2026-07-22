using NeonWindows.ABI.UI.Scaling;
using System;

namespace NeonWindows.UI.Scaling;

/// <summary>
/// 提供线程级别的应用程序 DPI 感知管理功能。
/// </summary>
public static class AppDpiAwareness2
{
    /// <summary>
    /// 当前线程的 DPI 感知模式。
    /// </summary>
    public static DpiAwarenessMode CurrentThreadDpiAwarenessMode
    {
        get
        {
            try
            {
                return DpiModeEnumConvert.FromDpiAwarenessContext(ThreadDpiContextApi.GetThreadDpiAwarenessContext())!.Value;
            }
            catch (Exception)
            {
                return AppDpiAwareness.CurrentProcessDpiAwarenessMode;
            }
        }
    }

    /// <summary>
    /// 设置当前线程的 DPI 感知模式。
    /// </summary>
    /// <param name="mode">要设置的 DPI 感知模式。</param>
    /// <returns>指示操作是否成功。</returns>
    /// <exception cref="ArgumentException"></exception>
    public static bool SetCurrentThreadDpiAwarenessMode(DpiAwarenessMode mode)
    {
        DPI_AWARENESS_CONTEXT dpiContext = DpiModeEnumConvert.ToCommonDpiAwarenessContext(mode);
        if (dpiContext.IsNull) throw new ArgumentException();
        try
        {
            return !ThreadDpiContextApi.SetThreadDpiAwarenessContext(dpiContext).IsNull;
        }
        catch (TypeLoadException)
        {
            return false;
        }
    }

    /// <summary>
    /// 设置当前进程的默认 DPI 感知模式，并提供更多功能。
    /// </summary>
    /// <param name="mode">要设置的 DPI 感知模式。</param>
    /// <param name="enforced">如果此项为 <see cref="true"/>，则将忽略通过此前的 API 调用或在应用程序清单设置的进程的默认 DPI 感知模式。</param>
    /// <param name="applyToThread">指示是否将该 DPI 感知模式设置到当前线程。</param>
    /// <returns>指示操作是否成功。</returns>
    /// <exception cref="ArgumentException"></exception>
    public static bool SetCurrentProcessDpiAwarenessModeEx(DpiAwarenessMode mode, bool enforced = false, bool applyToThread = true)
    {
        DPI_AWARENESS_CONTEXT mixedContext = DpiModeEnumConvert.ToMixedDpiAwarenessContext(mode);
        if (mixedContext.IsNull) throw new ArgumentException();
        try
        {
            if (!ProcessDpiContextApi.NtUserSetProcessDpiAwarenessContext((ulong)mixedContext.Value, Convert.ToByte(enforced))) return false;
        }
        catch (TypeLoadException)
        {
            return AppDpiAwareness.SetCurrentProcessDpiAwarenessMode(mode);
        }
        if (applyToThread)
        {
            try
            {
                ThreadDpiContextApi.SetThreadDpiAwarenessContext(mixedContext);
            }
            catch (TypeLoadException) { }
        }
        return true;
    }

    /// <summary>
    /// 确定当前的操作系统平台是否支持线程级 DPI 感知模型。
    /// </summary>
    public static bool IsThreadBasedDpiAwarenessSupported
    {
        get
        {
            try
            {
                return !ThreadDpiContextApi.GetThreadDpiAwarenessContext().IsNull;
            }
            catch (TypeLoadException)
            {
                return false;
            }
        }
    }
}
