using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.Windows.ApplicationModel.DynamicDependency;
using NeonWindows.ApplicationModel;
using System;
using System.Threading;
using WinRT;

namespace NWBUxThemeApiTest;

internal static class Program
{
    internal static void Main(string[] args)
    {
        ComWrappersSupport.InitializeComWrappers();
        if (!Win32AppModel.IsRunningAsAppX)
        {
            PackageVersion packageVersion;
            packageVersion.Major = 8000;
            packageVersion.Minor = 731;
            packageVersion.Build = 1000;
            packageVersion.Revision = 0;
            if (!Bootstrap.TryInitialize(0x00010008, "", packageVersion, Bootstrap.InitializeOptions.OnNoMatch_ShowUI, out int hr))
                Environment.Exit(hr);
        }
        Application.Start((p) =>
        {
            SynchronizationContext context = new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread());
            new App();
        });
    }
}
