using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.ApplicationModel;

internal static class LibLoaderApi
{
    /// <summary>
    /// 将指定的模块加载到调用进程的地址空间中。 指定的模块可能会导致加载其他模块。
    /// </summary>
    /// <param name="lpLibFileName">一个字符串，指定要加载的模块的文件名。 此名称与存储在库模块本身中的名称无关，如模块定义 （.def） 文件中的 LIBRARY 关键字所指定。</param>
    /// <param name="hFile">此参数保留供将来使用。 它必须 NULL。</param>
    /// <param name="dwFlags">加载模块时要执行的操作。 如果未指定任何标志，则此函数的行为与 LoadLibrary 函数的行为相同。</param>
    /// <returns>如果函数成功，则返回值是已加载模块的句柄。 如果函数失败，则返回值 NULL。 若要获取扩展的错误信息，请调用 GetLastError。</returns>
    internal static nint LoadLibraryExW(string lpLibFileName, nint hFile, uint dwFlags)
    {
        try
        {
            [DllImport(Win32DllName.KernelBase, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern nint LoadLibraryExW([MarshalAs(UnmanagedType.LPWStr)] string lpLibFileName, nint hFile, uint dwFlags);
            return LoadLibraryExW(lpLibFileName, hFile, dwFlags);
        }
        catch (TypeLoadException)
        {
            [DllImport(Win32DllName.Kernel32, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern nint LoadLibraryExW([MarshalAs(UnmanagedType.LPWStr)] string lpLibFileName, nint hFile, uint dwFlags);
            return LoadLibraryExW(lpLibFileName, hFile, dwFlags);
        }
    }

    /// <summary>
    /// 释放加载的动态链接库 (DLL) 模块，并在必要时递减其引用计数。 当引用计数达到零时，模块将从调用进程的地址空间中卸载，句柄不再有效。
    /// </summary>
    /// <param name="hLibModule">已加载的库模块的句柄。 LoadLibrary、LoadLibraryEx、GetModuleHandle 或 GetModuleHandleEx 函数返回此句柄。</param>
    /// <returns>如果该函数成功，则返回值为非零值。 如果函数失败，则返回值为零。 若要获得更多的错误信息，请调用 GetLastError 函数。</returns>
    internal static bool FreeLibrary(nint hLibModule)
    {
        try
        {
            [DllImport(Win32DllName.KernelBase, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern int FreeLibrary(nint hLibModule);
            return FreeLibrary(hLibModule) != 0;
        }
        catch (TypeLoadException)
        {
            [DllImport(Win32DllName.Kernel32, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern int FreeLibrary(nint hLibModule);
            return FreeLibrary(hLibModule) != 0;
        }
    }
}
