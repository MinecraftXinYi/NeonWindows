using NeonWindows.ABI.UI.Scaling;
using System;

namespace NeonWindows.UI.Scaling;

/// <summary>
/// 提供进程级别的应用程序 DPI 感知管理功能。
/// </summary>
public static class AppDpiAwareness
{
    /// <summary>
    /// 当前进程的 DPI 感知模式。
    /// </summary>
    public static DpiAwarenessMode CurrentProcessDpiAwarenessMode
    {
        get
        {
            try
            {
                return GetDpiAwarenessModeForProcess(default)!.Value;
            }
            catch (Exception)
            {
                try
                {
                    return ClassicDpiAwarenessApi.IsProcessDPIAware() ? DpiAwarenessMode.System : DpiAwarenessMode.Unaware;
                }
                catch (TypeLoadException)
                {
                    return DpiAwarenessMode.Unaware;
                }
            }
        }
    }

    /// <summary>
    /// 获取指定进程的 DPI 感知模式。
    /// </summary>
    /// <param name="hProcess">检索其 DPI 感知模式的进程句柄。</param>
    /// <returns>指定进程的 DPI 感知模式。若发生错误，则返回 null 。</returns>
    /// <exception cref="PlatformNotSupportedException"></exception>
    public static DpiAwarenessMode? GetDpiAwarenessModeForProcess(nint hProcess)
    {
        try
        {
            return DpiModeEnumConvert.FromDpiAwarenessContext(ProcessDpiContextApi.NtUserGetProcessDpiAwarenessContext(hProcess));
        }
        catch (TypeLoadException)
        {
            try
            {
                try
                {
                    if (ProcessDpiAwarenessApi.GetProcessDpiAwareness(hProcess, out PROCESS_DPI_AWARENESS dpiAwareness) == 0x00000000)
                        return DpiModeEnumConvert.FromProcessDpiAwarenessEnum(dpiAwareness);
                }
                catch (TypeLoadException)
                {
                    if (ProcessDpiAwarenessApi2.GetProcessDpiAwarenessInternal(hProcess, out PROCESS_DPI_AWARENESS dpiAwareness))
                        return DpiModeEnumConvert.FromProcessDpiAwarenessEnum(dpiAwareness);
                }
                return null;
            }
            catch (TypeLoadException)
            {
                throw new PlatformNotSupportedException();
            }
        }
    }

    /// <summary>
    /// 设置当前进程的 DPI 感知模式。
    /// </summary>
    /// <param name="mode">要设置的 DPI 感知模式。</param>
    /// <returns>指示操作是否成功。</returns>
    /// <exception cref="ArgumentException"></exception>
    public static bool SetCurrentProcessDpiAwarenessMode(DpiAwarenessMode mode)
    {
        try
        {
            DPI_AWARENESS_CONTEXT dpiContext = DpiModeEnumConvert.ToCommonDpiAwarenessContext(mode);
            if (dpiContext.IsNull) throw new ArgumentException();
            return ProcessDpiContextApi.SetProcessDpiAwarenessContext(dpiContext);
        }
        catch (TypeLoadException)
        {
            try
            {
                PROCESS_DPI_AWARENESS? dpiAwareness = DpiModeEnumConvert.ToProcessDpiAwarenessEnum(mode);
                if (!dpiAwareness.HasValue) return false;
                try
                {
                    return ProcessDpiAwarenessApi.SetProcessDpiAwareness(dpiAwareness.Value) == 0x00000000;
                }
                catch (TypeLoadException)
                {
                    return ProcessDpiAwarenessApi2.SetProcessDpiAwarenessInternal(dpiAwareness.Value);
                }
            }
            catch (TypeLoadException)
            {
                if (mode == DpiAwarenessMode.Unaware) return true;
                try
                {
                    if (mode != DpiAwarenessMode.System) return false;
                    return ClassicDpiAwarenessApi.SetProcessDPIAware();
                }
                catch (TypeLoadException)
                {
                    return false;
                }
            }
        }
    }

    /// <summary>
    /// 确定指定的 DPI 感知模式是否有效且受当前系统支持。
    /// </summary>
    /// <param name="mode">要确定它是否受支持的 DPI 感知模式。</param>
    /// <returns>指示它是否受支持。</returns>
    public static bool IsDPIAwarenessModeSupported(DpiAwarenessMode mode)
    {
        try
        {
            DPI_AWARENESS_CONTEXT dpiContext = DpiModeEnumConvert.ToCommonDpiAwarenessContext(mode);
            if (dpiContext.IsNull) return false;
            return DpiAwarenessContextApi.IsValidDpiAwarenessContext(dpiContext);
        }
        catch (TypeLoadException)
        {
            try
            {
                try
                {
                    _ = ProcessDpiAwarenessApi.GetProcessDpiAwareness(default, out _);
                }
                catch (TypeLoadException)
                {
                    _ = ProcessDpiAwarenessApi2.GetProcessDpiAwarenessInternal(default, out _);
                }
                return DpiModeEnumConvert.ToProcessDpiAwarenessEnum(mode).HasValue;
            }
            catch (TypeLoadException)
            {
                try
                {
                    _ = ClassicDpiAwarenessApi.IsProcessDPIAware();
                    return mode == DpiAwarenessMode.Unaware || mode == DpiAwarenessMode.System;
                }
                catch (TypeLoadException)
                {
                    return mode == DpiAwarenessMode.Unaware;
                }
            }
        }
    }
}
