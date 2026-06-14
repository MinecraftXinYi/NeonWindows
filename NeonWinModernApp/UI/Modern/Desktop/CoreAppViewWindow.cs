using NeonWindows.ABI.UI.Messaging;
using NeonWindows.ApplicationModel;
using NeonWindows.ApplicationModel.Modern.Core;
using NeonWindows.UI.Composition;
using NeonWindows.UI.Content;
using NeonWindows.UI.Modern.Core;
using NeonWindows.UI.Scaling;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace NeonWindows.UI.Modern.Desktop;

public partial class CoreAppViewWindow : Form
{
    public CoreWindow CoreWindow { get; }

    public CoreApplicationView CoreApplicationView { get; }

    public CoreDispatcher Dispatcher => CoreWindow.Dispatcher;

    public CoreAppViewWindow()
    {
        CoreWindow = CoreWindowFactory.CreateImmersiveHostedCoreWindow(string.Empty, new(), Handle);
        CoreWindowAdjustToHostWindow(true);
        CoreInitialize();
        CoreApplicationView = CoreApplication2.CreateNonImmersiveView();
    }

    public CoreAppViewWindow(IFrameworkView frameworkView) : this()
    {
        frameworkView.Initialize(CoreApplicationView);
        frameworkView.SetWindow(CoreWindow);
    }

    public CoreAppViewWindow(IFrameworkViewSource frameworkViewSource) : this(frameworkViewSource.CreateView()) { }

    public static Task<CoreAppViewWindow> CreateOnDedicatedThread()
    {
        TaskCompletionSource<CoreAppViewWindow> taskCompletionSource = new();
        Thread thread = STAThreadingModel.CreateSTAThread(() =>
        {
            CoreAppViewWindow window = new();
            taskCompletionSource.SetResult(window);
            window.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
        });
        thread.Start();
        return taskCompletionSource.Task;
    }

    protected override void CreateHandle()
    {
        ModernDpiAwareness.SetThreadPerMonitorDpiAware(out _);
        Debug.WriteLine(AppDpiAwareness2.CurrentThreadDpiAwarenessMode);
        base.CreateHandle();
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        Debug.WriteLine(AppDpiAwareness2.CurrentThreadDpiAwarenessMode);
        base.OnHandleCreated(e);
    }

    //protected override void OnResizeEnd(EventArgs e)
    //{
    //    CoreWindowAdjustToHostWindow();
    //    base.OnResizeEnd(e);
    //}

    protected override void OnSizeChanged(EventArgs e)
    {
        CoreWindowAdjustToHostWindow();
        base.OnClientSizeChanged(e);
    }

    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case (int)WM.WM_ACTIVATE:
                CoreWindowProcessMessage(m.Msg, m.WParam, m.LParam);
                break;
            default:
                break;
        }
        base.WndProc(ref m);
    }

    private void CoreWindowAdjustToHostWindow(bool prepare = false)
    {
        if (CoreWindow == null) return;
        nint hWndCoreWindow = CoreWindow.GetWindowHandle();
        if (prepare) ContentWindow.PrepareClientOnlyContentWindow(hWndCoreWindow);
        ContentWindow.SetRootContentWindow(hWndCoreWindow, Handle);
    }

    private void CoreInitialize()
    {
        CoreUITextInputPatch.FixTextInputBehavioursForCoreWindow(CoreWindow);
        BackdropComposition.EnableHostBackdropBrush(Handle);
        BackdropComposition.EnableHostBackdropBrush(CoreWindow.GetWindowHandle());
    }

    private void CoreWindowProcessMessage(int Msg, nint wParam, nint lParam)
    {
        if (CoreWindow == null) return;
        WindowMessageApi.PostMessageW(CoreWindow.GetWindowHandle(), (uint)Msg, (nuint)wParam, lParam);
    }
}
