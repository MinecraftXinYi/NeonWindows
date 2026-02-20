using System;
using System.Reflection;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace NeonWindows.UI.Modern.Xaml;

public static class XamlAppActivation
{
    private static readonly MethodInfo OnActivatedMethod = typeof(Application).GetMethod("OnActivated", new Type[] { typeof(IActivatedEventArgs) });

    public static void InvokeActivationMethod(this Application app, IActivatedEventArgs args)
        => OnActivatedMethod.Invoke(app, new object[] { args });
}
