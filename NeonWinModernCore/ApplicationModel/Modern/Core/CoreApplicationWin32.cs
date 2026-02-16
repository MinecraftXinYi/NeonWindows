using NeonWindows.ABI.ApplicationModel.Modern.Core;
using Windows.ApplicationModel.Core;
using WinRT;

namespace NeonWindows.ApplicationModel.Modern.Core;

public static class CoreApplicationWin32
{
    public static CoreApplicationView CreateNotImmersiveView()
    {
        ICoreApplicationPrivate2 coreApplicationPrivate2 = CoreApplication.As<ICoreApplicationPrivate2>();
        ExceptionHelpers.ThrowExceptionForHR(coreApplicationPrivate2.CreateNonImmersiveView(out nint pCoreApplicationView));
        return CoreApplicationView.FromAbi(pCoreApplicationView);
    }
}
