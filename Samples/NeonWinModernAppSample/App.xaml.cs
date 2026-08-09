using NeonWindows.ApplicationModel;
using NeonWindows.UI.Modern.Desktop;
using NeonWindows.UI.Modern.Xaml.Desktop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Navigation;

namespace NeonWinModernAppSample
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default <see cref="Application"/> class.
    /// </summary>
    public sealed partial class App : Application
    {
        public bool IsUWP { get; }

        /// <summary>
        /// Initializes the singleton application object. This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App(bool isUWP)
        {
            InitializeComponent();
            IsUWP = isUWP;

            if (IsUWP) Suspending += OnSuspending;
        }

        /// <inheritdoc/>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Debug.WriteLine("OnLunched method invoked.");

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active.
            if (Window.Current.Content is not Frame rootFrame)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;

                if (IsUWP)
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if ((!IsUWP) || e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page, configuring
                    // the new page by passing required information as a navigation parameter.
                    rootFrame.Navigate(typeof(MainPage), e?.Arguments);
                }

                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails.
        /// </summary>
        /// <param name="sender">The Frame which failed navigation.</param>
        /// <param name="e">Details about the navigation failure.</param>
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception($"Failed to load page '{e.SourcePageType.FullName}'.");
        }

        /// <summary>
        /// Invoked when application execution is being suspended. Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            SuspendingDeferral deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        internal static readonly Dictionary<string, Type> AppPages = new()
        {
            { "Home", typeof(HomePage) },
            { "Windowing", typeof(WindowingPage) },
        };

        internal static Thread CreateCoreAppViewWindow()
        {
            Thread thread = STAThreadingModel.CreateSTAThread(() =>
            {
                CoreAppViewWindow window = new(new FrameworkView());
                Window.Current.Content = new MainPage();
                window.Show();
                window.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
            });
            thread.Start();
            return thread;
        }

        internal static Thread CreateDesktopXamlWindow()
        {
            Thread thread = STAThreadingModel.CreateSTAThread(() =>
            {
                WindowsXamlManager xamlManager = WindowsXamlManager.InitializeForCurrentThread();
                DesktopXamlWindow window = new(new MainPage());
                window.Show();
                window.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
                xamlManager.Dispose();
            });
            thread.Start();
            return thread;
        }

        internal static CoreApplicationView CreateCoreAppView()
        {
            CoreApplicationView view = CoreApplication.CreateNewView();
            int viewId = default;
            _ = view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Window.Current.Content = new MainPage();
                Window.Current.Activate();
                viewId = ApplicationView.GetForCurrentView().Id;
            });
            _ = ApplicationViewSwitcher.TryShowAsStandaloneAsync(viewId);
            return view;
        }
    }
}
