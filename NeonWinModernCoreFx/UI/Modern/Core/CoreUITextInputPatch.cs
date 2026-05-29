using NeonWindows.ABI.UI.Modern.Core;
using System.Runtime.InteropServices;
using Windows.UI.Core;

namespace NeonWindows.UI.Modern.Core;

/// <summary>
/// 提供针对传统 Win32 应用模型上的 <see cref="CoreWindow"/> 文本输入问题的修补方案。
/// </summary>
public static class CoreUITextInputPatch
{
    /// <summary>
    /// 修复指定 <see cref="CoreWindow"/> 的文本输入响应问题。
    /// </summary>
    /// <param name="coreWindow">需要修补的 <see cref="CoreWindow"/> 。</param>
    /// <returns>用于修补的内部 COM 接口指针。</returns>
    public static nint FixTextInputBehavioursForCoreWindow(CoreWindow coreWindow)
        => InitializeTextInputProducerForConsumer((ITextInputConsumer)(object)coreWindow);

    internal static nint InitializeTextInputProducerForConsumer(ITextInputConsumer textInputConsumer)
    {
        nint pTextInputConsumer = textInputConsumer.ToUnmanaged();
        int hr = CoreUITextInputApi.PrivateCreateTextInputProducer(pTextInputConsumer, out nint pTextInputProducer);
        Marshal.Release(pTextInputConsumer);
        Marshal.ThrowExceptionForHR(hr);
        hr = textInputConsumer.SetTextInputProducer(pTextInputProducer);
        Marshal.Release(pTextInputProducer);
        Marshal.ThrowExceptionForHR(hr);
        return pTextInputProducer;
    }
}
