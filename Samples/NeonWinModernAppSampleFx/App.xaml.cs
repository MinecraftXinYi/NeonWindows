using Windows.UI.Xaml;

namespace NeonWinModernAppSampleFx;

sealed partial class App : Application
{
    public App()
    {
        this.InitializeComponent();
    }

    public void Close()
    {
        this.Exit();
    }
}
