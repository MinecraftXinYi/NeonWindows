using NeonWindows.ABI.System;

namespace NeonWindows.System;

/// <summary>
/// 管理 Win32 应用程序的控制台。
/// </summary>
public static class Win32Console
{
    /// <summary>
    /// 将当前进程附加到控制台。
    /// </summary>
    /// <param name="detachExisting">指示是否先将当前进程从已有控制台中分离。</param>
    /// <returns>指示操作是否成功。</returns>
    public static bool AttachToConsole(bool detachExisting = false)
    {
        if (detachExisting) ConsoleApi.FreeConsole();
        if (!ConsoleApi.AttachConsole(ConsoleApi.ATTACH_PARENT_PROCESS)) return ConsoleApi.AllocConsole();
        return true;
    }

    /// <summary>
    /// 将当前进程附加到指定进程的控制台。
    /// </summary>
    /// <param name="pid">要使用的控制台的进程标识符。</param>
    /// <param name="detachExisting">指示是否先将当前进程从已有控制台中分离。</param>
    /// <returns>指示操作是否成功。</returns>
    public static bool AttachToProcessConsole(uint pid, bool detachExisting = false)
    {
        if (detachExisting) ConsoleApi.FreeConsole();
        return ConsoleApi.AttachConsole(pid);
    }

    /// <summary>
    /// 从控制台分离当前进程。
    /// </summary>
    /// <returns>指示操作是否成功。</returns>
    public static bool DetachFromConsole()
        => ConsoleApi.FreeConsole();
}
