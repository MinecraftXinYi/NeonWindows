using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NeonWindows.ABI.UI.Scaling;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace NWBDpiApiTestUwp
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            DPI_AWARENESS_CONTEXT d0 = ThreadDpiContextApi.GetThreadDpiAwarenessContext();
            infoblock1.Text = $"Current thread dpi awareness context: {(long)d0}";
        }

        private void SetButton_Click(object sender, RoutedEventArgs e)
        {
            ThreadDpiContextApi.SetThreadDpiAwarenessContext(DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE);
        }
    }
}
