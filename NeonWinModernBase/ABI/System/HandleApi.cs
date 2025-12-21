using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.System;

internal static class HandleApi
{
    /// <summary>
    /// 关闭打开的对象句柄。
    /// </summary>
    /// <param name="hObject">打开对象的有效句柄。</param>
    /// <returns>如果该函数成功，则返回值为非零值。 如果函数失败，则返回值为零。 要获得更多的错误信息，请调用 GetLastError。</returns>
    internal static bool CloseHandle(nint hObject)
    {
        try
        {
            [DllImport(Win32DllName.KernelBase, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern int CloseHandle(nint hObject);
            return CloseHandle(hObject) != 0;
        }
        catch (TypeLoadException)
        {
            [DllImport(Win32DllName.Kernel32, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern int CloseHandle(nint hObject);
            return CloseHandle(hObject) != 0;
        }
    }
}
