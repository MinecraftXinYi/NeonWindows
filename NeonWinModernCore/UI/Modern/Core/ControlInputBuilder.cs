using NeonWindows.ABI.UI.Modern.Core;
using Windows.UI.Core;
using WinRT;

namespace NeonWindows.UI.Modern.Core;

public static class ControlInputBuilder
{
    public static CoreComponentInputSource CreateCoreComponentInputSource()
    {
        ExceptionHelpers.ThrowExceptionForHR(CoreUIControlInputApi.CreateControlInput(typeof(ICoreInputSourceBase).GUID, out nint pCoreComponentInputSource));
        return CoreComponentInputSource.FromAbi(pCoreComponentInputSource);
    }

    public static CoreComponentInputSource CreateCoreComponentInputSource(this CoreWindow coreWindow)
    {
        nint pCoreWindow = MarshalInspectable<CoreWindow>.FromManaged(coreWindow);
        int hr = CoreUIControlInputApi.CreateControlInputEx(pCoreWindow, typeof(ICoreInputSourceBase).GUID, out nint pCoreComponentInputSource);
        MarshalInspectable<CoreWindow>.DisposeAbi(pCoreWindow);
        ExceptionHelpers.ThrowExceptionForHR(hr);
        return CoreComponentInputSource.FromAbi(pCoreComponentInputSource);
    }
}
