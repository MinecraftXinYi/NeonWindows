using System;
using System.Runtime.InteropServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NeonWinModernAppSampleFx;

public sealed partial class MainPage : Page
{
    public string FrameworkDescription => RuntimeInformation.FrameworkDescription;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        ContentDialog1 contentDialog = new();
        await contentDialog.ShowAsync();
    }
}
