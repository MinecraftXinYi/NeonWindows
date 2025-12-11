using NeonWindows.ABI;
using NeonWindows.ABI.ApplicationModel;
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
                    return false;
                }
            }
        }
    }

    /// <summary>
    /// 指示当前进程是否在 AppContainer 环境中运行。
    /// </summary>
    public unsafe static bool IsAppContainer
    {
        get
        {
            uint isAppContainer = 0;
            SecurityBaseApi.GetTokenInformation(ProcessThreadsApi.GetCurrentProcessToken(), SecurityBaseApi.TOKEN_INFORMATION_CLASS_TokenIsAppContainer,
                &isAppContainer, sizeof(uint), out _);
            return isAppContainer != 0;
        }
    }
}
