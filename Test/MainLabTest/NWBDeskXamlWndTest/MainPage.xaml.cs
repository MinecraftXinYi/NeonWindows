using System;
using Windows.UI.Xaml.Controls;

namespace NWBDeskXamlWndTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a <see cref="Frame">.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ContentDialog1 dialog1 = new();
            try
            {
                _ = dialog1.ShowAsync();
            }
            catch (ArgumentException)
            {
                dialog1.XamlRoot = XamlRoot;
                _ = dialog1.ShowAsync();
            }
        }
    }
}
