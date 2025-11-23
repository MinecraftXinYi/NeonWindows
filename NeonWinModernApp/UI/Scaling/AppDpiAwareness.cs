using NeonWindows.ABI;
using NeonWindows.ABI.UI.Scaling;
using System;
using System.Runtime.InteropServices;

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
                return GetDpiAwarenessModeForProcess(0)!.Value;
            }
            catch (PlatformNotSupportedException)
            {
                return DpiModeEnumConvert.FromBool(ClassicDpiAwarenessApi.IsProcessDPIAware());
            }
        }
    }

    /// <summary>
    /// 获取指定进程的 DPI 感知模式。
    /// </summary>
    /// <param name="hProcess">检索其 DPI 感知模式的进程句柄。</param>
    /// <returns>指定进程的 DPI 感知模式。</returns>
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
                    int hr = ProcessDpiAwarenessApi.GetProcessDpiAwareness(hProcess, out PROCESS_DPI_AWARENESS dpiAwareness);
                    return hr == CommonHR.S_OK ? DpiModeEnumConvert.FromProcessDpiAwarenessEnum(dpiAwareness) : null;
                }
                catch (TypeLoadException)
                {
                    if (ProcessDpiAwarenessApi2.GetProcessDpiAwarenessInternal(hProcess, out PROCESS_DPI_AWARENESS dpiAwareness))
                        return DpiModeEnumConvert.FromProcessDpiAwarenessEnum(dpiAwareness);
                    else return null;
                }
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
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="PlatformNotSupportedException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static void SetCurrentProcessDpiAwarenessMode(DpiAwarenessMode mode)
    {
        try
        {
            DPI_AWARENESS_CONTEXT dpiContext = DpiModeEnumConvert.ToDpiAwarenessContext(mode);
            if (dpiContext.IsNull) throw new ArgumentException();
            if (!ProcessDpiContextApi.SetProcessDpiAwarenessContext(dpiContext))
            {
                int hr = Marshal.GetHRForLastWin32Error();
                throw hr switch
                {
                    CommonHR.E_INVALIDARG => new PlatformNotSupportedException(),
                    CommonHR.E_ACCESSDENIED => new InvalidOperationException(),
                    _ => Marshal.GetExceptionForHR(hr)
                };
            }
        }
        catch (TypeLoadException)
        {
            try
            {
                PROCESS_DPI_AWARENESS? dpiAwareness = DpiModeEnumConvert.ToProcessDpiAwarenessEnum(mode);
                if (!dpiAwareness.HasValue) throw new PlatformNotSupportedException();
                try
                {
                    int hr = ProcessDpiAwarenessApi.SetProcessDpiAwareness(dpiAwareness.Value);
                    if (hr != CommonHR.S_OK)
                        throw hr switch
                        {
                            CommonHR.E_ACCESSDENIED => new InvalidOperationException(),
                            _ => Marshal.GetExceptionForHR(hr)
                        };
                }
                catch (TypeLoadException)
                {
                    if (!ProcessDpiAwarenessApi2.SetProcessDpiAwarenessInternal(dpiAwareness.Value))
                    {
                        int hr = Marshal.GetHRForLastWin32Error();
                        throw hr switch
                        {
                            CommonHR.E_ACCESSDENIED => new InvalidOperationException(),
                            _ => Marshal.GetExceptionForHR(hr)
                        };
                    }
                }
            }
            catch (TypeLoadException)
            {
                if (mode == DpiAwarenessMode.Unaware) return;
                try
                {
                    if (mode != DpiAwarenessMode.System) throw new PlatformNotSupportedException();
                    if (!ClassicDpiAwarenessApi.SetProcessDPIAware()) throw new InvalidOperationException();
                }
                catch (TypeLoadException)
                {
                    throw new PlatformNotSupportedException();
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
            DPI_AWARENESS_CONTEXT dpiContext = DpiModeEnumConvert.ToDpiAwarenessContext(mode);
            if (dpiContext.IsNull) return false;
            return DpiAwarenessContextApi.IsValidDpiAwarenessContext(dpiContext);
        }
        catch (TypeLoadException)
        {
            try
            {
                _ = ProcessDpiAwarenessApi.GetProcessDpiAwareness(0, out _);
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
