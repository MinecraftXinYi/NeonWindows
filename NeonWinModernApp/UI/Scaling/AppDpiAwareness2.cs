using NeonWindows.ABI.UI.Scaling;
using System;

namespace NeonWindows.UI.Scaling;

/// <summary>
/// 提供线程级别的应用程序 DPI 感知管理功能。
/// </summary>
public static class AppDpiAwareness2
{
    /// <summary>
    /// 获取或设置当前线程的 DPI 感知模式。
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="PlatformNotSupportedException"></exception>
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
        set
        {
            try
            {
                DPI_AWARENESS_CONTEXT dpiContext = DpiModeEnumConvert.ToDpiAwarenessContext(value);
                if (dpiContext.IsNull) throw new ArgumentException();
                if (ThreadDpiContextApi.SetThreadDpiAwarenessContext(dpiContext).IsNull) throw new PlatformNotSupportedException();
            }
            catch (TypeLoadException)
            {
                throw new PlatformNotSupportedException();
            }
        }
    }

    /// <summary>
    /// 尝试设置当前线程的 DPI 感知模式。
    /// </summary>
    /// <param name="mode">要设置的 DPI 感知模式。</param>
    /// <returns>指示操作是否成功。</returns>
    public static bool TrySetCurrentThreadDpiAwarenessMode(DpiAwarenessMode mode)
    {
        try
        {
            CurrentThreadDpiAwarenessMode = mode;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
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
                return DpiAwarenessContextApi.IsValidDpiAwarenessContext(ThreadDpiContextApi.GetThreadDpiAwarenessContext());
            }
            catch (TypeLoadException)
            {
                return false;
            }
        }
    }
}
