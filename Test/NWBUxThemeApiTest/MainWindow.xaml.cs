using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using NeonWindows.ABI.UI.UxTheme;
using NeonWindows.UI.Immersive;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NWBUxThemeApiTest
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            PreferredAppMode retv = UXThemeAppModeApi.SetPreferredAppMode(PreferredAppMode.Default);
            UXThemeAppModeApi.FlushMenuThemes();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ImmersiveAppTheme.UseDarkModeForWindowContextMenu = true;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            ImmersiveAppTheme.UseDarkModeForWindowContextMenu = false;
        }
    }
}
