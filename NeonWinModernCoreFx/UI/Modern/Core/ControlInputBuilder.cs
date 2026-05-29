using NeonWindows.ABI.UI.Modern.Core;
using NeonWindows.WinRT;
using System.Runtime.InteropServices;
using Windows.UI.Core;

namespace NeonWindows.UI.Modern.Core;

public static class ControlInputBuilder
{
    public static CoreComponentInputSource CreateCoreComponentInputSource()
    {
        Marshal.ThrowExceptionForHR(CoreUIControlInputApi.CreateControlInput(typeof(ICoreInputSourceBase).GUID, out nint pCoreComponentInputSource));
        return (CoreComponentInputSource)Marshal.GetObjectForIUnknown(pCoreComponentInputSource);
    }

    public static CoreComponentInputSource CreateCoreComponentInputSource(this CoreWindow coreWindow)
    {
        nint pCoreWindow = MarshalInspectable<CoreWindow>.FromManaged(coreWindow);
        int hr = CoreUIControlInputApi.CreateControlInputEx(pCoreWindow, typeof(ICoreInputSourceBase).GUID, out nint pCoreComponentInputSource);
        Marshal.Release(pCoreWindow);
        Marshal.ThrowExceptionForHR(hr);
        return (CoreComponentInputSource)Marshal.GetObjectForIUnknown(pCoreComponentInputSource);
    }
}
