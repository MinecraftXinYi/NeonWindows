using NeonWindows.ABI.UI.Messaging;
using NeonWindows.ApplicationModel;
using NeonWindows.UI.Composition;
using NeonWindows.UI.Content;
using NeonWindows.UI.Modern.Core;
using NeonWindows.UI.Modern.Xaml.Hosting;
using NeonWindows.UI.Scaling;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

public partial class DesktopXamlWindow : Form
{
    private readonly DesktopWindowXamlSource windowXamlSource;

    private readonly CoreWindow coreWindow;

    public DesktopXamlWindow()
    {
        windowXamlSource = new();
        windowXamlSource.AttachToWindow(Handle);
        coreWindow = CoreWindow.GetForCurrentThread();
        ContentWindowAdjustToHostWindow(true);
        CoreInitialize();
    }

    public static Task<DesktopXamlWindow> CreateOnDedicatedThread()
    {
        TaskCompletionSource<DesktopXamlWindow> taskCompletionSource = new();
        Thread thread = STAThreadingModel.CreateSTAThread(() =>
        {
            DesktopXamlWindow window = new();
            taskCompletionSource.SetResult(window);
            window.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
        });
        thread.Start();
        return taskCompletionSource.Task;
    }

    public UIElement Content
    {
        get => windowXamlSource.Content;
        set => windowXamlSource.Content = value;
    }

    public CoreDispatcher Dispatcher => coreWindow.Dispatcher;

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

    protected override void OnHandleDestroyed(EventArgs e)
    {
        windowXamlSource.Dispose();
        Dispatcher.StopProcessEvents();
        base.OnHandleDestroyed(e);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        ContentWindowAdjustToHostWindow();
        base.OnClientSizeChanged(e);
    }

    protected override bool ProcessKeyMessage(ref Message m)
    {
        ContentWindowProcessMessage(m.Msg, m.WParam, m.LParam);
        return base.ProcessKeyMessage(ref m);
    }

    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case (int)WM.WM_ACTIVATE:
                ContentWindowProcessMessage(m.Msg, m.WParam, m.LParam, false);
                break;
            default:
                break;
        }
        base.WndProc(ref m);
    }

    private void ContentWindowAdjustToHostWindow(bool prepare = false)
    {
        if (coreWindow == null) return;
        nint hWndCoreWindow = coreWindow.GetWindowHandle();
        if (prepare) ContentWindow.PrepareClientOnlyContentWindow(hWndCoreWindow);
        ContentWindow.SetRootContentWindow(hWndCoreWindow, Handle);
        ContentWindow.SetRootContentWindow(windowXamlSource.GetWindowHandle(), Handle, hWndCoreWindow);
    }

    private void CoreInitialize()
    {
        CoreUITextInputPatch.FixTextInputBehavioursForCoreWindow(coreWindow);
        BackdropComposition.EnableHostBackdropBrush(Handle);
    }

    private void ContentWindowProcessMessage(int Msg, nint wParam, nint lParam, bool coreOnly = true)
    {
        if (coreWindow == null) return;
        WindowMessageApi.PostMessageW(coreWindow.GetWindowHandle(), (uint)Msg, (nuint)wParam, lParam);
        if (!coreOnly) WindowMessageApi.PostMessageW(windowXamlSource.GetWindowHandle(), (uint)Msg, (nuint)wParam, lParam);
    }
}
