using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.ApplicationSettings;
using Windows.Win32.System.WinRT;

namespace NeonWindows.UI.ApplicationSettings;

public unsafe static class AccountsSettingsPaneInterop
{
    public static AccountsSettingsPane GetForWindow(nint appWindow)
    {
        Guid iid = IID_IAccountsSettingsPane;
        return (AccountsSettingsPane)accountsSettingsPaneInterop.GetForWindow(new(appWindow), &iid);
    }

    public static IAsyncAction ShowManageAccountsForWindowAsync(nint appWindow)
    {
        Guid iid = typeof(IAsyncAction).GUID;
        return (IAsyncAction)accountsSettingsPaneInterop.ShowManageAccountsForWindowAsync(new(appWindow), &iid);
    }

    public static IAsyncAction ShowAddAccountForWindowAsync(nint appWindow)
    {
        Guid iid = typeof(IAsyncAction).GUID;
        return (IAsyncAction)accountsSettingsPaneInterop.ShowAddAccountForWindowAsync(new(appWindow), &iid);
    }

    internal static readonly Guid IID_IAccountsSettingsPane = new(2179634220u, 20233, 17414, 165, 56, 131, 141, 155, 20, 183, 230);

    private static IAccountsSettingsPaneInterop accountsSettingsPaneInterop = (IAccountsSettingsPaneInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(AccountsSettingsPane));
}
