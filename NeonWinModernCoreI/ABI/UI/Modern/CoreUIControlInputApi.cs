using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Modern;

public unsafe static class CoreUIControlInputApi
{
    /// <summary>
    /// 在调用者的 UI 线程中创建 CoreComponentInputSource 对象。
    /// </summary>
    /// <param name="riid">对象的接口 ID。 必须设置为 ICoreInputSourceBase 的 UUID，即 CoreComponentInputSource 的默认接口。</param>
    /// <param name="ppv">用于接收 CoreComponentInputSource 对象的指针。</param>
    /// <returns>如果此函数成功，它将返回 S_OK。 否则，它将返回 HRESULT 错误代码。</returns>
    [DllImport(WinRTDllName.WindowsUI, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern int CreateControlInput(Guid riid, nint* ppv);

    /// <summary>
    /// 在工作线程或 UI 线程中创建 CoreComponentInputSource 对象。
    /// </summary>
    /// <param name="pCoreWindow">指向将附加 CoreComponentInputSource 对象的父 CoreWindow 的指针。 此参数不能为 NULL。</param>
    /// <param name="riid">对象的接口 ID。 必须设置为 ICoreInputSourceBase 的 UUID，即 CoreComponentInputSource 的默认接口。</param>
    /// <param name="ppv">用于接收 CoreComponentInputSource 对象的指针。</param>
    /// <returns>如果此函数成功，它将返回 S_OK。 否则，它将返回 HRESULT 错误代码。</returns>
    [DllImport(WinRTDllName.WindowsUI, ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern int CreateControlInputEx(nint pCoreWindow, Guid riid, nint* ppv);
}
