using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.ApplicationSettings;
using Windows.Win32;
using Windows.Win32.System.WinRT;

namespace NeonWindows.UI.ApplicationSettings;

public static class AccountsSettingsPaneInterop
{
    public static AccountsSettingsPane GetForWindow(nint appWindow)
        => (AccountsSettingsPane)accountsSettingsPaneInterop.GetForWindow(new(appWindow), IID_IAccountsSettingsPane);

    public static IAsyncAction ShowManageAccountsForWindowAsync(nint appWindow)
        => (IAsyncAction)accountsSettingsPaneInterop.ShowManageAccountsForWindowAsync(new(appWindow), typeof(IAsyncAction).GUID);

    public static IAsyncAction ShowAddAccountForWindowAsync(nint appWindow)
        => (IAsyncAction)accountsSettingsPaneInterop.ShowAddAccountForWindowAsync(new(appWindow), typeof(IAsyncAction).GUID);

    internal static readonly Guid IID_IAccountsSettingsPane = new(2179634220u, 20233, 17414, 165, 56, 131, 141, 155, 20, 183, 230);

    private static IAccountsSettingsPaneInterop accountsSettingsPaneInterop = (IAccountsSettingsPaneInterop)WindowsRuntimeMarshal.GetActivationFactory(typeof(AccountsSettingsPane));
}
