using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI;

internal static class ProcessThreadsApi
{
    /// <summary>
    /// 检索当前进程的伪句柄。
    /// </summary>
    /// <returns>返回值是当前进程的伪句柄。</returns>
    internal static nint GetCurrentProcess()
    {
        try
        {
            [DllImport(Win32DllName.KernelBase, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern nint GetCurrentProcess();
            return GetCurrentProcess();
        }
        catch (TypeLoadException)
        {
            [DllImport(Win32DllName.Kernel32, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern nint GetCurrentProcess();
            return GetCurrentProcess();
        }
    }

    /// <summary>
    /// 检索伪句柄，该句柄可以用作引用与进程关联的 访问令牌 的简写方式。
    /// </summary>
    /// <returns>伪句柄，可以将其用作引用与进程关联的 访问令牌 的简写方式。</returns>
    internal static nint GetCurrentProcessToken()
        => -4;
}
