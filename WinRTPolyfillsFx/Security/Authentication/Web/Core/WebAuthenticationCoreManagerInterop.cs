using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Security.Authentication.Web.Core;
using Windows.Security.Credentials;
using Windows.Win32;
using Windows.Win32.System.WinRT;

namespace NeonWindows.Security.Authentication.Web.Core;

public static class WebAuthenticationCoreManagerInterop
{
    public static IAsyncOperation<WebTokenRequestResult> RequestTokenForWindowAsync(nint appWindow, WebTokenRequest request)
        => (IAsyncOperation<WebTokenRequestResult>)webAuthenticationCoreManagerInterop.RequestTokenForWindowAsync(new(appWindow), (IInspectable)(object)request, typeof(IAsyncOperation<WebTokenRequestResult>).GUID);

    public static IAsyncOperation<WebTokenRequestResult> RequestTokenWithWebAccountForWindowAsync(nint appWindow, WebTokenRequest request, WebAccount webAccount)
        => (IAsyncOperation<WebTokenRequestResult>)webAuthenticationCoreManagerInterop.RequestTokenWithWebAccountForWindowAsync(new(appWindow), (IInspectable)(object)request, (IInspectable)(object)webAccount, typeof(IAsyncOperation<WebTokenRequestResult>).GUID);

    private static IWebAuthenticationCoreManagerInterop webAuthenticationCoreManagerInterop = (IWebAuthenticationCoreManagerInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(WebAuthenticationCoreManager));
}
