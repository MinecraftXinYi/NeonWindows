using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Security.Credentials.UI;
using Windows.Win32.System.WinRT;

namespace NeonWindows.Security.Credentials.UI;

public unsafe static class UserConsentVerifierInterop
{
    public static IAsyncOperation<UserConsentVerificationResult> RequestVerificationForWindowAsync(nint appWindow, string message)
    {
        Guid iid = typeof(IAsyncOperation<UserConsentVerificationResult>).GUID;
        nint hstrMsg = WindowsRuntimeMarshal.StringToHString(message);
        try
        {
            return (IAsyncOperation<UserConsentVerificationResult>)userConsentVerifierInterop.RequestVerificationForWindowAsync(new(appWindow), new(hstrMsg), &iid);
        }
        finally
        {
            WindowsRuntimeMarshal.FreeHString(hstrMsg);
        }
    }

    private static IUserConsentVerifierInterop userConsentVerifierInterop = (IUserConsentVerifierInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(UserConsentVerifier));
}
