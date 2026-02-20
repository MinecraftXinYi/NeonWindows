using NeonWindows.ABI.UI.Modern.Core;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Core;

namespace NeonWindows.UI.Modern.Core;

/// <summary>
/// 提供创建并初始化 <see cref="CoreDispatcher"/> 的功能。
/// </summary>
public static class CoreDispatcherBuilder
{
    /// <summary>
    /// 获取或创建与当前线程相关联的 <see cref="CoreDispatcher"/> 。
    /// </summary>
    /// <returns>与当前线程相关联的 <see cref="CoreDispatcher"/> 。</returns>
    public static CoreDispatcher GetOrCreateDispatcherForCurrentThread()
    {
        IActivationFactory refInternalCoreDispatcherStatic = WindowsRuntimeMarshal.GetActivationFactory(typeof(CoreDispatcher));
        IInternalCoreDispatcherStatic internalCoreDispatcherStatic = (IInternalCoreDispatcherStatic)refInternalCoreDispatcherStatic;
        int hr = internalCoreDispatcherStatic.GetOrCreateForCurrentThread(out nint pDispatcher);
        Marshal.ReleaseComObject(refInternalCoreDispatcherStatic);
        Marshal.ThrowExceptionForHR(hr);
        return (CoreDispatcher)Marshal.GetObjectForIUnknown(pDispatcher);
    }
}
