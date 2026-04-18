using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.ApplicationModel;

public unsafe static class AppModelApi
{
    /// <summary>
    /// 获取调用进程的包系列名称。
    /// </summary>
    /// <param name="packageFamilyNameLength">输入时， packageFamilyName 缓冲区的大小（以字符为单位），包括 null 终止符。 输出时，返回的包系列名称的大小（以字符为单位），包括 null 终止符。</param>
    /// <param name="packageFamilyName">包系列名称。</param>
    /// <returns>如果该函数成功，则返回 ERROR_SUCCESS。 否则，该函数将返回错误代码。</returns>
    public static long GetCurrentPackageFamilyName(uint* packageFamilyNameLength, char* packageFamilyName)
    {
        try
        {
            [DllImport(Win32DllName.KernelBase, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern long GetCurrentPackageFamilyName(uint* packageFamilyNameLength, char* packageFamilyName);
            return GetCurrentPackageFamilyName(packageFamilyNameLength, packageFamilyName);
        }
        catch (TypeLoadException)
        {
            [DllImport(Win32DllName.Kernel32, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern long GetCurrentPackageFamilyName(uint* packageFamilyNameLength, char* packageFamilyName);
            return GetCurrentPackageFamilyName(packageFamilyNameLength, packageFamilyName);
        }
    }

    public const long APPMODEL_ERROR_NO_PACKAGE = 15700L;
}
