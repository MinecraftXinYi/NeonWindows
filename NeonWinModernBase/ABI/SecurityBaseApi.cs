using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI;

internal static class SecurityBaseApi
{
    /// <summary>
    /// GetTokenInformation 函数检索有关访问令牌的指定类型的信息。 调用进程必须具有适当的访问权限才能获取信息。
    /// </summary>
    /// <param name="TokenHandle">从中检索信息的访问令牌的句柄。 如果 TokenInformationClass 指定 TokenSource，则句柄必须具有TOKEN_QUERY_SOURCE访问权限。 对于所有其他 TokenInformationClass 值，句柄必须具有TOKEN_QUERY访问权限。</param>
    /// <param name="TokenInformationClass">指定 TOKEN_INFORMATION_CLASS 枚举类型的值，以标识函数检索的信息类型。 检查 TokenIsAppContainer 并使其返回 0 的任何调用方还应验证调用方令牌是否不是标识级别模拟令牌。 如果当前令牌不是应用容器，而是标识级别令牌，则应返回 AccessDenied。</param>
    /// <param name="TokenInformation">指向函数用请求的信息填充的缓冲区的指针。 放入此缓冲区中的结构取决于 TokenInformationClass 参数指定的信息类型。</param>
    /// <param name="TokenInformationLength">指定 TokenInformation 参数指向的缓冲区的大小（以字节为单位）。 如果 TokenInformation 为 NULL，则此参数必须为零。</param>
    /// <param name="ReturnLength">指向变量的指针，该变量接收 TokenInformation 参数指向的缓冲区所需的字节数。 如果此值大于 TokenInformationLength 参数中指定的值，则函数将失败，并且不会在缓冲区中存储任何数据。</param>
    /// <returns>如果该函数成功，则返回值为非零值。 如果函数失败，则返回值为零。 要获得更多的错误信息，请调用 GetLastError。</returns>
    internal unsafe static bool GetTokenInformation(nint TokenHandle, uint TokenInformationClass, void* TokenInformation, uint TokenInformationLength, out uint ReturnLength)
    {
        try
        {
            [DllImport(Win32DllName.KernelBase, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern int GetTokenInformation(nint TokenHandle, uint TokenInformationClass, void* TokenInformation, uint TokenInformationLength, out uint ReturnLength);
            int retval = GetTokenInformation(TokenHandle, TokenInformationClass, TokenInformation, TokenInformationLength, out ReturnLength);
            return retval != 0;
        }
        catch (TypeLoadException)
        {
            [DllImport(Win32DllName.Advapi32, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern int GetTokenInformation(nint TokenHandle, uint TokenInformationClass, void* TokenInformation, uint TokenInformationLength, out uint ReturnLength);
            int retval = GetTokenInformation(TokenHandle, TokenInformationClass, TokenInformation, TokenInformationLength, out ReturnLength);
            return retval != 0;
        }
    }

    internal const uint TOKEN_INFORMATION_CLASS_TokenIsAppContainer = 29;
}
