using NeonWindows.ABI.UI.Modern.Core;
using System.Runtime.InteropServices;
using Windows.UI.Core;
using WinRT;

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
        => InitializeTextInputProducerForConsumer(coreWindow.As<ITextInputConsumer>());

    internal static nint InitializeTextInputProducerForConsumer(ITextInputConsumer textInputConsumer)
    {
        nint pTextInputConsumer = textInputConsumer.GetAbi();
        int hr = CoreUITextInputApi.PrivateCreateTextInputProducer(pTextInputConsumer, out nint pTextInputProducer);
        Marshal.Release(pTextInputConsumer);
        ExceptionHelpers.ThrowExceptionForHR(hr);
        hr = textInputConsumer.SetTextInputProducer(pTextInputProducer);
        Marshal.Release(pTextInputProducer);
        ExceptionHelpers.ThrowExceptionForHR(hr);
        return pTextInputProducer;
    }
}
