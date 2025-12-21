using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NeonWindows.ABI.ApplicationModel;

public static class AppModelApi
{
    /// <summary>
    /// 获取调用进程的包全名。
    /// </summary>
    /// <param name="packageFullNameLength">输入时， packageFullName 缓冲区的大小（以字符为单位）。 输出时，返回包全名的大小（以字符为单位），包括 null 终止符。</param>
    /// <param name="packageFullName">包全名。</param>
    /// <returns>如果函数成功，则返回 ERROR_SUCCESS。 否则，函数将返回错误代码。</returns>
    public static long GetCurrentPackageFullName(ref uint packageFullNameLength, StringBuilder? packageFullName)
    {
        try
        {
            [DllImport(Win32DllName.KernelBase, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern long GetCurrentPackageFullName(ref uint packageFullNameLength, StringBuilder? packageFullName);
            return GetCurrentPackageFullName(ref packageFullNameLength, packageFullName);
        }
        catch (TypeLoadException)
        {
            [DllImport(Win32DllName.Kernel32, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern long GetCurrentPackageFullName(ref uint packageFullNameLength, StringBuilder? packageFullName);
            return GetCurrentPackageFullName(ref packageFullNameLength, packageFullName);
        }
    }

    /// <summary>
    /// 获取指定进程的包全名。
    /// </summary>
    /// <param name="hProcess">具有 PROCESS_QUERY_INFORMATION 或 PROCESS_QUERY_LIMITED_INFORMATION 访问权限的进程句柄。 有关详细信息，请参阅进程安全性和访问权限。</param>
    /// <param name="packageFullNameLength">输入时， packageFullName 缓冲区的大小（以字符为单位）。 输出时，返回包全名的大小（以字符为单位），包括 null 终止符。</param>
    /// <param name="packageFullName">包全名。</param>
    /// <returns>如果函数成功，则返回 ERROR_SUCCESS。 否则，函数将返回错误代码。</returns>
    public static long GetPackageFullName(nint hProcess, ref uint packageFullNameLength, StringBuilder? packageFullName)
    {
        try
        {
            [DllImport(Win32DllName.KernelBase, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern long GetPackageFullName(nint hProcess, ref uint packageFullNameLength, StringBuilder? packageFullName);
            return GetPackageFullName(hProcess, ref packageFullNameLength, packageFullName);
        }
        catch (TypeLoadException)
        {
            [DllImport(Win32DllName.Kernel32, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern long GetPackageFullName(nint hProcess, ref uint packageFullNameLength, StringBuilder? packageFullName);
            return GetPackageFullName(hProcess, ref packageFullNameLength, packageFullName);
        }
    }

    public const long APPMODEL_ERROR_NO_PACKAGE = 15700L;

    /// <summary>
    /// 检索一个值，该值指示进程是使用基于 CoreWindow 的窗口模型还是基于 HWND 的窗口模型。 可以用来决定如何注册窗口状态更改通知 (大小更改、可见性更改等) 。
    /// </summary>
    /// <param name="processToken">标识进程的访问令牌的句柄。</param>
    /// <param name="policy">指向 <see cref="AppPolicyWindowingModel"/> 枚举类型的变量的指针。 当函数成功返回时，变量包含一个枚举常量值，该值指示所标识进程的窗口化模型。</param>
    /// <returns>如果函数成功，该函数将返回 ERROR_SUCCESS 。</returns>
    [DllImport(Win32DllName.ApiMsWinAppModelRuntimeL112, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern long AppPolicyGetWindowingModel(nint processToken, out AppPolicyWindowingModel policy);
}
