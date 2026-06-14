using NeonWindows.ABI.UI.Messaging;
using NeonWindows.ABI.UI.Windowing;
using NeonWindows.ApplicationModel;
using NeonWindows.UI.Content;
using NeonWindows.UI.Modern.Core;
using NeonWindows.UI.Modern.Xaml.Hosting;
using System;
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
        ContentWindow.PrepareContentWindow(coreWindow.GetWindowHandle());
        SetContentWindow();
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

    protected override void OnActivated(EventArgs e)
    {
        //WindowDisplayApi.ShowWindowAsync(coreWindow.GetWindowHandle(), WindowDisplayApi.SW_SHOW);
        base.OnActivated(e);
    }

    protected override void OnClientSizeChanged(EventArgs e)
    {
        SetContentWindow();
        base.OnClientSizeChanged(e);
    }

    protected override bool ProcessKeyMessage(ref Message m)
    {
        WindowMessageApi.PostMessageW(coreWindow.GetWindowHandle(), (uint)m.Msg, m.WParam, m.LParam);
        return base.ProcessKeyMessage(ref m);
    }

    private void SetContentWindow()
    {
        nint hWndCoreWindow = coreWindow.GetWindowHandle();
        ContentWindow.SetFullContentWindow(hWndCoreWindow, Handle);
        ContentWindow.SetFullContentWindow(windowXamlSource.GetWindowHandle(), Handle, hWndCoreWindow);
    }
}
