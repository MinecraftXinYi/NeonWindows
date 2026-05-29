using NeonWindows.ABI.UI.Modern.Core;
using NeonWindows.WinRT;
using System.Runtime.InteropServices;
using Windows.UI.Core;

namespace NeonWindows.UI.Modern.Core;

public static class CoreInputBuilder
{
    public static CoreComponentInputSource CreateCoreComponentInputSource2(CoreInputDeviceTypes inputDeviceTypes)
        => (CoreComponentInputSource)Marshal.GetObjectForIUnknown(CreateCoreInputInternal(COREINPUT_TYPE.CI_COMPONENT_INPUT, inputDeviceTypes));

    public static CoreComponentInputSource CreateCoreComponentInputSource2(this CoreWindow coreWindow, CoreInputDeviceTypes inputDeviceTypes)
        => (CoreComponentInputSource)Marshal.GetObjectForIUnknown(CreateCoreInputInternal2(coreWindow, COREINPUT_TYPE.CI_COMPONENT_INPUT, inputDeviceTypes));

    public static CoreIndependentInputSource CreateCoreIndependentInputSource(CoreInputDeviceTypes inputDeviceTypes)
        => (CoreIndependentInputSource)Marshal.GetObjectForIUnknown(CreateCoreInputInternal(COREINPUT_TYPE.CI_INDEPENDENT_INPUT, inputDeviceTypes));

    public static CoreIndependentInputSource CreateCoreIndependentInputSource(this CoreWindow coreWindow, CoreInputDeviceTypes inputDeviceTypes)
        => (CoreIndependentInputSource)Marshal.GetObjectForIUnknown(CreateCoreInputInternal2(coreWindow, COREINPUT_TYPE.CI_INDEPENDENT_INPUT, inputDeviceTypes));

    public static ICoreInputSourceBase CreateCoreInputWithWindowHandle(nint hWnd)
    {
        Marshal.ThrowExceptionForHR(CoreUICoreInputApi.PrivateCreateCoreInputWithHwnd(hWnd, typeof(ICoreInputSourceBase).GUID, out nint ppv));
        return (ICoreInputSourceBase)Marshal.GetObjectForIUnknown(ppv);
    }

    internal static nint CreateCoreInputInternal(COREINPUT_TYPE type, CoreInputDeviceTypes inputDeviceTypes)
    {
        COREINPUT_POINTER_TYPE pointerTypes = (COREINPUT_POINTER_TYPE)inputDeviceTypes;
        Marshal.ThrowExceptionForHR(CoreUICoreInputApi.PrivateCreateCoreInput(type, pointerTypes, COREINPUT_FLAGS.CIF_NONE, typeof(ICoreInputSourceBase).GUID, out nint ppv));
        return ppv;
    }

    internal static nint CreateCoreInputInternal2(CoreWindow coreWindow, COREINPUT_TYPE type, CoreInputDeviceTypes inputDeviceTypes)
    {
        COREINPUT_POINTER_TYPE pointerTypes = (COREINPUT_POINTER_TYPE)inputDeviceTypes;
        nint pCoreWindow = MarshalInspectable<CoreWindow>.FromManaged(coreWindow);
        int hr = CoreUICoreInputApi.PrivateCreateCoreInputEx(type, pointerTypes, pCoreWindow, COREINPUT_FLAGS.CIF_NONE, typeof(ICoreInputSourceBase).GUID, out nint ppv);
        Marshal.Release(pCoreWindow);
        Marshal.ThrowExceptionForHR(hr);
        return ppv;
    }
}
