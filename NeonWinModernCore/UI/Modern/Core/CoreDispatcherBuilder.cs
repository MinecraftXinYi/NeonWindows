using NeonWindows.ABI.UI.Modern.Core;
using Windows.UI.Core;
using WinRT;

namespace NeonWindows.UI.Modern.Core;

public static class CoreDispatcherBuilder
{
    public static CoreDispatcher GetOrCreateCoreDispatcherForCurrentThread()
    {
        using IObjectReference refInternalCoreDispatcherStatic = ActivationFactory.Get(typeof(CoreDispatcher).FullName);
        {
            IInternalCoreDispatcherStatic internalCoreDispatcherStatic = refInternalCoreDispatcherStatic.AsInterface<IInternalCoreDispatcherStatic>();
            ExceptionHelpers.ThrowExceptionForHR(internalCoreDispatcherStatic.GetOrCreateForCurrentThread(out nint pDispatcher));
            return CoreDispatcher.FromAbi(pDispatcher);
        }
    }
}
