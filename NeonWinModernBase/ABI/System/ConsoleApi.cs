using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.System;

public static class ConsoleApi
{
    /// <summary>
    /// 将调用进程附加到指定进程的控制台作为客户端应用程序。
    /// </summary>
    /// <param name="dwProcessId">要使用的控制台的进程标识符。</param>
    /// <returns>如果该函数成功，则返回值为非零值。 如果函数失败，则返回值为零。 要获得更多的错误信息，请调用 GetLastError。</returns>
    public static bool AttachConsole(uint dwProcessId)
    {
        try
        {
            [DllImport(Win32DllName.KernelBase, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern int AttachConsole(uint dwProcessId);
            return AttachConsole(dwProcessId) != 0;
        }
        catch (TypeLoadException)
        {
            [DllImport(Win32DllName.Kernel32, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern int AttachConsole(uint dwProcessId);
            return AttachConsole(dwProcessId) != 0;
        }
    }

    /// <summary>
    /// 使用当前进程的父级的控制台。
    /// </summary>
    public const uint ATTACH_PARENT_PROCESS = unchecked((uint)-1);

    /// <summary>
    /// 为调用进程分配一个新的控制台。
    /// </summary>
    /// <returns>如果该函数成功，则返回值为非零值。 如果函数失败，则返回值为零。 若要获取扩展的错误信息，请调用 GetLastError。</returns>
    public static bool AllocConsole()
    {
        try
        {
            [DllImport(Win32DllName.KernelBase, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern int AllocConsole();
            return AllocConsole() != 0;
        }
        catch (TypeLoadException)
        {
            [DllImport(Win32DllName.Kernel32, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern int AllocConsole();
            return AllocConsole() != 0;
        }
    }

    /// <summary>
    /// 从其控制台分离调用进程。
    /// </summary>
    /// <returns>如果该函数成功，则返回值为非零值。 如果函数失败，则返回值为零。 要获得更多的错误信息，请调用 GetLastError。</returns>
    public static bool FreeConsole()
    {
        try
        {
            [DllImport(Win32DllName.KernelBase, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern int FreeConsole();
            return FreeConsole() != 0;
        }
        catch (TypeLoadException)
        {
            [DllImport(Win32DllName.Kernel32, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern int FreeConsole();
            return FreeConsole() != 0;
        }
    }
}
