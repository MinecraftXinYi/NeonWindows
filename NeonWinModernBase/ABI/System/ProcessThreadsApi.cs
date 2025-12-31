using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.System;

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
    /// 检索伪句柄，该句柄可以用作引用与进程关联的访问令牌的简写方式。
    /// </summary>
    /// <returns>伪句柄，可以将其用作引用与进程关联的访问令牌的简写方式。</returns>
    internal static nint GetCurrentProcessToken()
        => -4;

    /// <summary>
    /// OpenProcessToken 函数打开与进程关联的访问令牌。
    /// </summary>
    /// <param name="ProcessHandle">打开访问令牌的进程句柄。 进程必须具有 PROCESS_QUERY_LIMITED_INFORMATION 访问权限。 有关详细信息，请参阅进程安全性和访问权限。</param>
    /// <param name="DesiredAccess">指定访问掩码，该掩码指定访问令牌的请求访问类型。 </param>
    /// <param name="TokenHandle">指向句柄的指针，该句柄标识函数返回时新打开的访问令牌。</param>
    /// <returns>如果该函数成功，则返回值为非零值。 如果函数失败，则返回值为零。 要获得更多的错误信息，请调用 GetLastError。</returns>
    internal static bool OpenProcessToken(nint ProcessHandle, uint DesiredAccess, out nint TokenHandle)
    {
        try
        {
            [DllImport(Win32DllName.KernelBase, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern int OpenProcessToken(nint ProcessHandle, uint DesiredAccess, out nint TokenHandle);
            return OpenProcessToken(ProcessHandle, DesiredAccess, out TokenHandle) != 0;
        }
        catch (TypeLoadException)
        {
            [DllImport(Win32DllName.Advapi32, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern int OpenProcessToken(nint ProcessHandle, uint DesiredAccess, out nint TokenHandle);
            return OpenProcessToken(ProcessHandle, DesiredAccess, out TokenHandle) != 0;
        }
    }

    /// <summary>
    /// 合并 STANDARD_RIGHTS_READ 和 TOKEN_QUERY。
    /// </summary>
    internal const uint TOKEN_READ = 0x00020008;
}
