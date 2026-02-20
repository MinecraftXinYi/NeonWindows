using NeonWindows.ABI.ApplicationModel.Modern.Core;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;

namespace NeonWindows.ApplicationModel.Modern.Core;

/// <summary>
/// 提供 <see cref="CoreApplication"/> 与传统 Win32 应用模型的互操作功能。
/// </summary>
public static class CoreApplicationWin32
{
    /// <summary>
    /// 在当前线程上创建非沉浸式 <see cref="CoreApplicationView"/> 。
    /// </summary>
    /// <returns>创建的 <see cref="CoreApplicationView"/> 。</returns>
    public static CoreApplicationView CreateNotImmersiveView()
    {
        ICoreApplicationPrivate2 coreApplicationPrivate2 = (ICoreApplicationPrivate2)WindowsRuntimeMarshal.GetActivationFactory(typeof(CoreApplication));
        Marshal.ThrowExceptionForHR(coreApplicationPrivate2.CreateNonImmersiveView(out nint pCoreApplicationView));
        return (CoreApplicationView)Marshal.GetObjectForIUnknown(pCoreApplicationView);
    }
}
