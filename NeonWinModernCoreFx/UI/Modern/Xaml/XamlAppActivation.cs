using System.Reflection;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace NeonWindows.UI.Modern.Xaml;

public static class XamlAppActivation
{
    private static readonly MethodInfo OnActivatedMethod = typeof(Application).GetMethod("OnActivated", BindingFlags.Instance | BindingFlags.NonPublic);

    private static readonly MethodInfo OnLaunchedMethod = typeof(Application).GetMethod("OnLaunched", BindingFlags.Instance | BindingFlags.NonPublic);

    public static void InvokeOnActivatedMethod(this Application app, IActivatedEventArgs args)
        => OnActivatedMethod.Invoke(app, new object[] { args });

    public static void InvokeOnLaunchedMethod(this Application app, LaunchActivatedEventArgs args)
        => OnLaunchedMethod.Invoke(app, new object[] { args });
}
