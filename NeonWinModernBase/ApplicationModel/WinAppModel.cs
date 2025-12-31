using NeonWindows.ABI.ApplicationModel;
using NeonWindows.ABI.System;
using System;

namespace NeonWindows.ApplicationModel;

/// <summary>
/// 用于检索与 Windows 应用模型相关联的信息。
/// </summary>
public static class WinAppModel
{
    /// <summary>
    /// 指示当前进程是否属于 APPX 应用。
    /// </summary>
    public static bool IsAPPX
    {
        get
        {
            try
            {
                uint length = 0;
                return AppModelApi.GetCurrentPackageFullName(ref length, null) != AppModelApi.APPMODEL_ERROR_NO_PACKAGE;
            }
            catch (TypeLoadException)
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 指示当前进程是否属于 UWP 应用。
    /// </summary>
    public static bool IsUWP
    {
        get
        {
            if (!IsAPPX) return false;
            try
            {
                AppModelApi.AppPolicyGetWindowingModel(ProcessThreadsApi.GetCurrentProcessToken(), out AppPolicyWindowingModel windowingModel);
                return windowingModel == AppPolicyWindowingModel.Universal;
            }
            catch (TypeLoadException)
            {
                try
                {
                    return WinUserImmersiveProcessApi.IsImmersiveProcess(ProcessThreadsApi.GetCurrentProcess());
                }
                catch (TypeLoadException)
                {
                    return true;
                }
            }
        }
    }

    /// <summary>
    /// 检索指定进程是否属于 APPX 应用。
    /// </summary>
    /// <param name="hProcess">要检索的进程句柄。</param>
    /// <returns>指示进程是否属于 APPX 应用。</returns>
    public static bool IsProcessAPPX(nint hProcess)
    {
        if (hProcess == default) return false;
        try
        {
            uint length = 0;
            return AppModelApi.GetPackageFullName(hProcess, ref length, null) != AppModelApi.APPMODEL_ERROR_NO_PACKAGE;
        }
        catch (TypeLoadException)
        {
            return false;
        }
    }

    /// <summary>
    /// 检索指定进程是否属于 UWP 应用。
    /// </summary>
    /// <param name="hProcess">要检索的进程句柄。</param>
    /// <returns>指示进程是否属于 UWP 应用。</returns>
    public static bool IsProcessUWP(nint hProcess)
    {
        if (!IsProcessAPPX(hProcess)) return false;
        if (!ProcessThreadsApi.OpenProcessToken(hProcess, ProcessThreadsApi.TOKEN_READ, out nint hToken)) return false;
        try
        {
            AppModelApi.AppPolicyGetWindowingModel(hToken, out AppPolicyWindowingModel windowingModel);
            HandleApi.CloseHandle(hToken);
            return windowingModel == AppPolicyWindowingModel.Universal;
        }
        catch (TypeLoadException)
        {
            HandleApi.CloseHandle(hToken);
            try
            {
                return WinUserImmersiveProcessApi.IsImmersiveProcess(hProcess);
            }
            catch (TypeLoadException)
            {
                return true;
            }
        }
    }
}
