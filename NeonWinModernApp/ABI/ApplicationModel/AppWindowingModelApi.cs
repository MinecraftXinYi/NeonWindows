using System.Runtime.InteropServices;

namespace NeonWindows.ABI.ApplicationModel;

public static class AppWindowingModelApi
{
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
