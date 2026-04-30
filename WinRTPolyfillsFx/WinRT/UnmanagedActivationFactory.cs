using NeonWindows.ABI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace NeonWindows.WinRT;

public static class UnmanagedActivationFactory
{
    public static IActivationFactory Get(string typeName)
    {
        Guid iid_IActivationFactory = typeof(IActivationFactory).GUID;
        Marshal.ThrowExceptionForHR(RoApi.RoGetActivationFactory(typeName, ref iid_IActivationFactory, out nint factoryRef));
        return (IActivationFactory)Marshal.GetObjectForIUnknown(factoryRef);
    }

    public static nint Get(string typeName, Guid iid)
    {
        Marshal.ThrowExceptionForHR(RoApi.RoGetActivationFactory(typeName, ref iid, out nint objRef));
        return objRef;
    }
}
