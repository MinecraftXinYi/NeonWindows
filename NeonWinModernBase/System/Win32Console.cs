using NeonWindows.ABI.System;

namespace NeonWindows.System;

/// <summary>
/// 管理应用程序的 Windows 控制台。
/// </summary>
public static class Win32Console
{
    /// <summary>
    /// 为当前进程分配控制台。
    /// </summary>
    /// <returns>指示操作是否成功。</returns>
    public static bool Initialize()
    {
        if (!ConsoleApi.AttachConsole(ConsoleApi.ATTACH_PARENT_PROCESS))
            return ConsoleApi.AllocConsole();
        return true;
    }

    /// <summary>
    /// 为当前进程分配控制台。
    /// </summary>
    /// <param name="pid">要使用的控制台的进程标识符。</param>
    /// <returns>指示操作是否成功。</returns>
    public static bool Initialize(uint pid)
        => ConsoleApi.AttachConsole(pid);

    /// <summary>
    /// 从控制台分离当前进程。
    /// </summary>
    /// <returns>指示操作是否成功。</returns>
    public static bool Unload()
        => ConsoleApi.FreeConsole();
}
