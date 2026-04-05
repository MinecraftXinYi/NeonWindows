using NeonWindows.ABI.ApplicationModel;
using NeonWindows.ABI.System;
using System;

namespace NeonWindows.ApplicationModel;

/// <summary>
/// 用于检索与 Windows 应用模型相关联的信息。
/// </summary>
public unsafe static class Win32AppModel
{
    /// <summary>
    /// 指示当前应用是否正以 AppX 形式运行。
    /// </summary>
    public static bool IsRunningAsAppX
    {
        get
        {
            try
            {
                uint length = sbyte.MaxValue + 1;
                char* buffer = stackalloc char[(int)length];
                return AppModelApi.GetCurrentPackageFamilyName(ref length, (nint)buffer) != AppModelApi.APPMODEL_ERROR_NO_PACKAGE;
            }
            catch (TypeLoadException)
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 指示当前应用是否作为 UWP App 运行。
    /// </summary>
    public static bool IsRunningAsUwp
    {
        get
        {
            if (!IsRunningAsAppX) return false;
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
