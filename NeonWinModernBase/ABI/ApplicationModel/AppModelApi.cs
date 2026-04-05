using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NeonWindows.ABI.ApplicationModel;

public static class AppModelApi
{
    /// <summary>
    /// 获取调用进程的包系列名称。
    /// </summary>
    /// <param name="packageFamilyNameLength">输入时， packageFamilyName 缓冲区的大小（以字符为单位），包括 null 终止符。 输出时，返回的包系列名称的大小（以字符为单位），包括 null 终止符。</param>
    /// <param name="packageFamilyName">包系列名称。</param>
    /// <returns>如果该函数成功，则返回 ERROR_SUCCESS。 否则，该函数将返回错误代码。</returns>
    public static long GetCurrentPackageFamilyName(ref uint packageFamilyNameLength, StringBuilder? packageFamilyName)
    {
        try
        {
            [DllImport(Win32DllName.KernelBase, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern long GetCurrentPackageFamilyName(ref uint packageFamilyNameLength, StringBuilder? packageFamilyName);
            return GetCurrentPackageFamilyName(ref packageFamilyNameLength, packageFamilyName);
        }
        catch (TypeLoadException)
        {
            [DllImport(Win32DllName.Kernel32, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern long GetCurrentPackageFamilyName(ref uint packageFamilyNameLength, StringBuilder? packageFamilyName);
            return GetCurrentPackageFamilyName(ref packageFamilyNameLength, packageFamilyName);
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
