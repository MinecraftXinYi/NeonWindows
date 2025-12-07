using System.Runtime.InteropServices;

namespace NeonWindows.ABI.ApplicationModel;

public static class WinUserImmersiveProcessApi
{
    /// <summary>
    /// 确定进程是否属于 Windows 应用商店应用。
    /// </summary>
    /// <param name="hProcess">目标进程句柄。</param>
    /// <returns>如果该函数成功，则返回值为非零值。 如果函数失败，则返回值为零。 要获得更多的错误信息，请调用 GetLastError。</returns>
    [DllImport(Win32DllName.User32, ExactSpelling = true, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsImmersiveProcess(nint hProcess);
}
