using NeonWindows.ABI.UI.Modern.Core;
using Windows.UI.Core;
using WinRT;

namespace NeonWindows.UI.Modern.Core;

public static class CoreInputBuilder
{
    public static CoreComponentInputSource CreateCoreComponentInputSource2(CoreInputDeviceTypes inputDeviceTypes)
        => CoreComponentInputSource.FromAbi(CreateCoreInputInternal(COREINPUT_TYPE.CI_COMPONENT_INPUT, inputDeviceTypes));

    public static CoreComponentInputSource CreateCoreComponentInputSource2(this CoreWindow coreWindow, CoreInputDeviceTypes inputDeviceTypes)
        => CoreComponentInputSource.FromAbi(CreateCoreInputInternal2(coreWindow, COREINPUT_TYPE.CI_COMPONENT_INPUT, inputDeviceTypes));

    public static CoreIndependentInputSource CreateCoreIndependentInputSource(CoreInputDeviceTypes inputDeviceTypes)
        => CoreIndependentInputSource.FromAbi(CreateCoreInputInternal(COREINPUT_TYPE.CI_INDEPENDENT_INPUT, inputDeviceTypes));

    public static CoreIndependentInputSource CreateCoreIndependentInputSource(this CoreWindow coreWindow, CoreInputDeviceTypes inputDeviceTypes)
        => CoreIndependentInputSource.FromAbi(CreateCoreInputInternal2(coreWindow, COREINPUT_TYPE.CI_INDEPENDENT_INPUT, inputDeviceTypes));

    public static ICoreInputSourceBase CreateCoreInputWithWindowHandle(nint hWnd)
    {
        ExceptionHelpers.ThrowExceptionForHR(CoreUICoreInputApi.PrivateCreateCoreInputWithHwnd(hWnd, typeof(ICoreInputSourceBase).GUID, out nint ppv));
        return MarshalInterface<ICoreInputSourceBase>.FromAbi(ppv);
    }

    private static nint CreateCoreInputInternal(COREINPUT_TYPE type, CoreInputDeviceTypes inputDeviceTypes)
    {
        COREINPUT_POINTER_TYPE pointerTypes = (COREINPUT_POINTER_TYPE)inputDeviceTypes;
        ExceptionHelpers.ThrowExceptionForHR(CoreUICoreInputApi.PrivateCreateCoreInput(type, pointerTypes, COREINPUT_FLAGS.CIF_NONE, typeof(ICoreInputSourceBase).GUID, out nint ppv));
        return ppv;
    }

    private static nint CreateCoreInputInternal2(CoreWindow coreWindow, COREINPUT_TYPE type, CoreInputDeviceTypes inputDeviceTypes)
    {
        COREINPUT_POINTER_TYPE pointerTypes = (COREINPUT_POINTER_TYPE)inputDeviceTypes;
        nint pCoreWindow = MarshalInspectable<CoreWindow>.FromManaged(coreWindow);
        int hr = CoreUICoreInputApi.PrivateCreateCoreInputEx(type, pointerTypes, pCoreWindow, COREINPUT_FLAGS.CIF_NONE, typeof(ICoreInputSourceBase).GUID, out nint ppv);
        MarshalInspectable<CoreWindow>.DisposeAbi(pCoreWindow);
        ExceptionHelpers.ThrowExceptionForHR(hr);
        return ppv;
    }
}
