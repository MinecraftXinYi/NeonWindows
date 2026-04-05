using NeonWindows.ABI.ApplicationModel;
using NeonWindows.ABI.System;
using System;

namespace NeonWindows.ApplicationModel;

/// <summary>
/// 用于检索与 Windows 应用模型相关联的信息。
/// </summary>
public static class Win32AppModel
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
                uint length = uint.MinValue;
                return AppModelApi.GetCurrentPackageFamilyName(ref length, null) != AppModelApi.APPMODEL_ERROR_NO_PACKAGE;
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
                    return WinUserImrsivProcApi.IsImmersiveProcess(ProcessThreadsApi.GetCurrentProcess());
                }
                catch (TypeLoadException)
                {
                    return true;
                }
            }
        }
    }
}
