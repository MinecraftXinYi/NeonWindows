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
using NeonWindows.UI.Scaling;
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
            this.Loaded += PageLoaded;
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            LoadMain();
        }

        private void LoadMain()
        {
            Load1();
            Load2();
        }

        private void Load1()
        {
            infoblock1.Text = $"CurrentProcessDpiAwarenessMode: {AppDpiAwareness.CurrentProcessDpiAwarenessMode}";
            infoblock2.Text = $"CurrentThreadDpiAwarenessMode: {AppDpiAwareness2.CurrentThreadDpiAwarenessMode}";
            infoblock3.Text = $"IsThreadBasedDpiAwarenessSupported: {AppDpiAwareness2.IsThreadBasedDpiAwarenessSupported}";
        }

        private void Load2()
        {
            bool callapi1;
            try
            {
                callapi1 = !ThreadDpiContextApi.GetThreadDpiAwarenessContext().IsNull;
            }
            catch (TypeLoadException)
            {
                callapi1 = false;
            }
            bool callapi2;
            try
            {
                _ = ThreadDpiContextApi.SetThreadDpiAwarenessContext(DPI_AWARENESS_CONTEXT.Null);
                callapi2 = true;
            }
            catch (TypeLoadException)
            {
                callapi2 = false;
            }
            bool callapi3;
            try
            {
                _ = ProcessDpiContextApi.SetProcessDpiAwarenessContext(DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);
                callapi3 = true;
            }
            catch (TypeLoadException)
            {
                callapi3 = false;
            }
            bool callapi4;
            try
            {
                callapi4 = DpiAwarenessContextApi.AreDpiAwarenessContextsEqual(DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE, DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE);
            }
            catch (TypeLoadException)
            {
                callapi4 = false;
            }
            bool callapi5;
            try
            {
                callapi5 = DpiAwarenessContextApi.IsValidDpiAwarenessContext(DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_UNAWARE);
            }
            catch (TypeLoadException)
            {
                callapi5 = false;
            }
            infoblock6.Text = $"GetThreadDpiAwarenessContext: {callapi1}";
            infoblock7.Text = $"SetThreadDpiAwarenessContext: {callapi2}";
            infoblock8.Text = $"SetProcessDpiAwarenessContext: {callapi3}";
            infoblock9.Text = $"AreDpiAwarenessContextsEqual: {callapi4}";
            infoblock10.Text = $"IsValidDpiAwarenessContext: {callapi5}";
        }
    }
}
