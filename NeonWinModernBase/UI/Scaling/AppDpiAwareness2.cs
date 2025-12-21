using NeonWindows.ABI.System;
using NeonWindows.ABI.UI.Scaling;
using NeonWindows.ABI.UI.Windowing;
using System;

namespace NeonWindows.UI.Scaling;

/// <summary>
/// 提供线程与窗口级别的应用程序 DPI 感知管理功能。
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
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="PlatformNotSupportedException"></exception>
    public static void SetCurrentThreadDpiAwarenessMode(DpiAwarenessMode mode)
    {
        try
        {
            DPI_AWARENESS_CONTEXT dpiContext = DpiModeEnumConvert.ToCommonDpiAwarenessContext(mode);
            if (dpiContext.IsNull) throw new ArgumentException();
            if (ThreadDpiContextApi.SetThreadDpiAwarenessContext(dpiContext).IsNull) throw new PlatformNotSupportedException();
        }
        catch (TypeLoadException)
        {
            throw new PlatformNotSupportedException();
        }
    }

    /// <summary>
    /// 获取指定窗口的 DPI 感知模式。
    /// </summary>
    /// <param name="hWnd">检索其 DPI 感知模式的窗口句柄。</param>
    /// <returns>指定窗口的 DPI 感知模式。</returns>
    /// <exception cref="PlatformNotSupportedException"></exception>
    public static DpiAwarenessMode? GetDpiAwarenessModeForWindow(nint hWnd)
    {
        try
        {
            return DpiModeEnumConvert.FromDpiAwarenessContext(WindowDpiContextApi.GetWindowDpiAwarenessContext(hWnd));
        }
        catch (TypeLoadException)
        {
            uint pid;
            try
            {
                if (WindowProcessThreadApi.GetWindowThreadProcessId(hWnd, out pid) == 0) return null;
            }
            catch (TypeLoadException)
            {
                throw new PlatformNotSupportedException();
            }
            nint hProcess = ProcessThreadsApi.OpenProcess(PROCESS_ACCESS_RIGHTS.PROCESS_QUERY_INFORMATION | PROCESS_ACCESS_RIGHTS.PROCESS_VM_READ, false, pid);
            if (hProcess == default) return null;
            try
            {
                DpiAwarenessMode? dpiMode = AppDpiAwareness.GetDpiAwarenessModeForProcess(hProcess);
                HandleApi.CloseHandle(hProcess);
                return dpiMode;
            }
            catch (PlatformNotSupportedException e)
            {
                HandleApi.CloseHandle(hProcess);
                throw e;
            }
        }
    }

    /// <summary>
    /// 设置当前进程的 DPI 感知模式，并提供更多功能。
    /// </summary>
    /// <param name="mode">要设置的 DPI 感知模式。</param>
    /// <param name="enforced">如果此项为 <see cref="true"/>，则将忽略通过此前的 API 调用或在应用程序清单设置的进程的默认 DPI 感知模式。</param>
    /// <param name="applyToThread">指示是否将该 DPI 感知模式设置到当前线程。</param>
    /// <returns>指示操作是否成功。</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="PlatformNotSupportedException"></exception>
    public static bool SetCurrentProcessDpiAwarenessModeEx(DpiAwarenessMode mode, bool enforced = false, bool applyToThread = true)
    {
        try
        {
            DPI_AWARENESS_CONTEXT mixedContext = DpiModeEnumConvert.ToMixedDpiAwarenessContext(mode);
            if (mixedContext.IsNull) throw new ArgumentException();
            if (!ProcessDpiContextApi.NtUserSetProcessDpiAwarenessContext(mixedContext, enforced)) return false;
            if (applyToThread) ThreadDpiContextApi.SetThreadDpiAwarenessContext(mixedContext);
            return true;
        }
        catch (TypeLoadException)
        {
            throw new PlatformNotSupportedException();
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
                _ = ThreadDpiContextApi.SetThreadDpiAwarenessContext(DPI_AWARENESS_CONTEXT.Null);
                return !ThreadDpiContextApi.GetThreadDpiAwarenessContext().IsNull;
            }
            catch (TypeLoadException)
            {
                return false;
            }
        }
    }
}
