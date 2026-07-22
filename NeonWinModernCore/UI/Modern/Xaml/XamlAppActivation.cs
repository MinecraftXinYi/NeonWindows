using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace NeonWindows.UI.Modern.Xaml;

public static class XamlAppActivation
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "OnActivated")]
    private static extern void OnActivatedMethod(Application app, IActivatedEventArgs args);

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "OnLaunched")]
    private static extern void OnLaunchedMethod(Application app, LaunchActivatedEventArgs args);

    public static void InvokeOnActivatedMethod(this Application app, IActivatedEventArgs args)
        => OnActivatedMethod(app, args);

    public static void InvokeOnLaunchedMethod(this Application app, LaunchActivatedEventArgs args)
        => OnLaunchedMethod(app, args);
}
