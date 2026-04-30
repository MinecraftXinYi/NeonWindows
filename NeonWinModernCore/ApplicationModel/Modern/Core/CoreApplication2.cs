using NeonWindows.ABI.ApplicationModel.Modern.Core;
using Windows.ApplicationModel.Core;
using WinRT;

namespace NeonWindows.ApplicationModel.Modern.Core;

/// <summary>
/// 提供 <see cref="CoreApplication"/> 与传统 Win32 应用模型的互操作功能。
/// </summary>
public static class CoreApplication2
{
    /// <summary>
    /// 在当前线程上创建非沉浸式 <see cref="CoreApplicationView"/> 。
    /// </summary>
    /// <returns>创建的 <see cref="CoreApplicationView"/> 。</returns>
    public static CoreApplicationView CreateNonImmersiveView()
    {
        ICoreApplicationPrivate2 coreApplicationPrivate2 = CoreApplication.As<ICoreApplicationPrivate2>();
        ExceptionHelpers.ThrowExceptionForHR(coreApplicationPrivate2.CreateNonImmersiveView(out nint pCoreApplicationView));
        return CoreApplicationView.FromAbi(pCoreApplicationView);
    }
}
