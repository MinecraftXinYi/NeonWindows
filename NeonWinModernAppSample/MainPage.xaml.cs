using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace NeonWinModernAppSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a <see cref="Frame">.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavView.SelectedItem = NavView.MenuItems[0];
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            string? tag = args.SelectedItemContainer.Tag?.ToString();
            if ((!string.IsNullOrEmpty(tag)) && App.AppPages.TryGetValue(tag, out Type? targetPageType))
            {
                Type currentPageType = rootFrame.CurrentSourcePageType;
                if (targetPageType is not null && currentPageType != targetPageType) rootFrame.Navigate(targetPageType, null, new DrillInNavigationTransitionInfo());
            }
            else
            {
                if (args.IsSettingsSelected)
                {
                    ContentDialog1 contentDialog = new();
                    try
                    {
                        _ = contentDialog.ShowAsync();
                    } catch (Exception)
                    {
                        contentDialog.XamlRoot = XamlRoot;
                        _ = contentDialog.ShowAsync();
                    }
                }
            }
        }
    }
}
