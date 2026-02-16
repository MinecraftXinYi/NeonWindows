using NeonWindows.ABI.UI.Modern.Core;
using System.Runtime.InteropServices;
using Windows.UI.Core;
using WinRT;

namespace NeonWindows.UI.Modern.Core;

public static class CoreUITextInputPatch
{
    public static void FixTextInputBehavioursForCoreWindow(CoreWindow coreWindow)
    {
        ITextInputConsumer textInputConsumer = coreWindow.As<ITextInputConsumer>();
        if (!ComWrappers.TryGetComInstance(textInputConsumer, out nint pTextInputConsumer)) throw new COMException();
        int hr = CoreUITextInputApi.PrivateCreateTextInputProducer(pTextInputConsumer, out nint pTextInputProducer);
        Marshal.Release(pTextInputConsumer);
        ExceptionHelpers.ThrowExceptionForHR(hr);
        hr = textInputConsumer.SetTextInputProducer(pTextInputProducer);
        Marshal.Release(pTextInputProducer);
        ExceptionHelpers.ThrowExceptionForHR(hr);
    }
}
