using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Windowing;

internal unsafe static class WindowProcessThreadApi
{
    internal static uint GetWindowThreadProcessId(nint hWnd, out uint dwProcessId)
    {
        fixed (uint* lpdwProcessId = &dwProcessId)
        {
            return GetWindowThreadProcessId(hWnd, lpdwProcessId);
        }
    }

    /// <summary>
    /// 检索创建指定窗口的线程的标识符，以及创建该窗口的进程（可选）的标识符。
    /// </summary>
    /// <param name="hWnd">窗口的句柄。</param>
    /// <param name="lpdwProcessId">指向接收进程标识符的变量的指针。 如果此参数不为 NULL，则 GetWindowThreadProcessId 会将进程的标识符复制到变量;否则，它不会。 如果函数失败，则变量的值保持不变。</param>
    /// <returns>如果函数成功，则返回值是创建窗口的线程的标识符。 如果窗口句柄无效，则返回值为零。</returns>
    [DllImport(Win32DllName.User32, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static extern uint GetWindowThreadProcessId(nint hWnd, uint* lpdwProcessId);
}
