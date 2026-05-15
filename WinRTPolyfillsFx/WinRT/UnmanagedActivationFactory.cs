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
        nint hStrTypeName = WindowsRuntimeMarshal.StringToHString(typeName);
        int hr = RoApi.RoGetActivationFactory(hStrTypeName, ref iid_IActivationFactory, out nint factoryRef);
        WindowsRuntimeMarshal.FreeHString(hStrTypeName);
        Marshal.ThrowExceptionForHR(hr);
        return (IActivationFactory)Marshal.GetObjectForIUnknown(factoryRef);
    }

    public static nint Get(string typeName, Guid iid)
    {
        nint hStrTypeName = WindowsRuntimeMarshal.StringToHString(typeName);
        int hr = RoApi.RoGetActivationFactory(hStrTypeName, ref iid, out nint objRef);
        WindowsRuntimeMarshal.FreeHString(hStrTypeName);
        Marshal.ThrowExceptionForHR(hr);
        return objRef;
    }
}
