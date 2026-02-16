using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace NeonWindows.UI.Modern.Xaml;

public static class XamlAppActivation
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "OnActivated")]
    private static extern void OnActivatedMethod(Application app, IActivatedEventArgs args);

    public static void InvokeActivationMethod(this Application app, IActivatedEventArgs args)
        => OnActivatedMethod(app, args);
}
