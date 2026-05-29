using NeonWindows.ABI;
using NeonWindows.ABI.ApplicationModel;
using System;

namespace NeonWindows.ApplicationModel;

/// <summary>
/// 提供应用程序兼容性设置相关功能。
/// </summary>
public unsafe static class WinAppCompatHelper
{
    /// <summary>
    /// 修改当前进程的 OSMaxVersionTested 属性以兼容一些系统功能 (比如: UWP XAML Islands) 。
    /// </summary>
    /// <param name="newValue">要写入的新数据。</param>
    /// <returns>指示操作是否成功。</returns>
    public static bool TrySetOSMaxVersionTestedForCurrentProcess(ulong newValue)
    {
        try
        {
            APPCOMPAT_EXE_DATA* exeData = AppCompatDataMarshal.GetAppCompatExeData(RtlProcEnvApi.RtlGetCurrentPeb());
            if (exeData is null) return false;
            SWITCH_CONTEXT* scData = &exeData->SwitchContext;
            SWITCH_CONTEXT_DATA* data = &scData->Data;
            data->OsMaxVersionTested = newValue;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Windows 10, version 2004
    /// </summary>
    public const ulong RecommendedOSMaxVersionTested_1 = 0x000a00004a610000;
}
