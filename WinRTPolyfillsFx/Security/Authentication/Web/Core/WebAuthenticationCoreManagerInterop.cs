using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Security.Authentication.Web.Core;
using Windows.Security.Credentials;
using Windows.Win32.System.WinRT;

namespace NeonWindows.Security.Authentication.Web.Core;

public unsafe static class WebAuthenticationCoreManagerInterop
{
    public static IAsyncOperation<WebTokenRequestResult> RequestTokenForWindowAsync(nint appWindow, WebTokenRequest request)
    {
        Guid iid = typeof(IAsyncOperation<WebTokenRequestResult>).GUID;
        return (IAsyncOperation<WebTokenRequestResult>)webAuthenticationCoreManagerInterop.RequestTokenForWindowAsync(new(appWindow), (IInspectable)(object)request, &iid);
    }

    public static IAsyncOperation<WebTokenRequestResult> RequestTokenWithWebAccountForWindowAsync(nint appWindow, WebTokenRequest request, WebAccount webAccount)
    {
        Guid iid = typeof(IAsyncOperation<WebTokenRequestResult>).GUID;
        return (IAsyncOperation<WebTokenRequestResult>)webAuthenticationCoreManagerInterop.RequestTokenWithWebAccountForWindowAsync(new(appWindow), (IInspectable)(object)request, (IInspectable)(object)webAccount, &iid);
    }

    private static IWebAuthenticationCoreManagerInterop webAuthenticationCoreManagerInterop = (IWebAuthenticationCoreManagerInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(WebAuthenticationCoreManager));
}
