using NeonWindows.ApplicationModel;
using NeonWindows.ApplicationModel.Modern.Core;
using NeonWindows.UI.Modern.Desktop.Core;
using NeonWindows.UI.Modern.Xaml.Hosting;
using NeonWindows.UI.Windowing;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

public unsafe class DesktopXamlWindow : CoreUIHostWindow
{
    protected readonly DesktopWindowXamlSource windowXamlSource;

    public UIElement Content
    {
        get => windowXamlSource.Content;
        set => windowXamlSource.Content = value;
    }

    public override CoreWindow CoreWindow { get; }

    public override CoreApplicationView CoreApplicationView { get; }

    public static DesktopXamlWindow? Current => _current;

    [ThreadStatic]
    private static DesktopXamlWindow? _current;

    public static Task<DesktopXamlWindow> CreateOnNewThread()
    {
        TaskCompletionSource<DesktopXamlWindow> taskCompletionSource = new();
        Thread wndThread = STAThreadingModel.CreateSTAThread(() =>
        {
            DesktopXamlWindow window = new();
            taskCompletionSource.SetResult(window);
            window.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
        });
        wndThread.Start();
        return taskCompletionSource.Task;
    }

    public DesktopXamlWindow(UIElement content) : this()
        => Content = content;

    public DesktopXamlWindow()
    {
        if (_current != null) throw new NotSupportedException();
        windowXamlSource = new();
        CoreWindow = CoreWindow.GetForCurrentThread();
        InitializeCoreUIFramework();
        InitializeWin32CoreWindow();
        SetCoreWindowParent(true);
        SetCoreWindowRect();
        CoreApplicationView = CoreApplication2.CreateNonImmersiveView();
        SetXamlSourceParent(true);
        InitializeXamlSourceWin32Window();
        SetXamlSourceRect();
        _current = this;
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        SetXamlSourceVisible();
    }

    protected override void OnResizeBegin(EventArgs e)
    {
        base.OnResizeBegin(e);
        SetXamlSourceParent();
    }

    protected override void OnClientSizeChanged(EventArgs e)
    {
        base.OnClientSizeChanged(e);
        SetXamlSourceRect();
    }

    public override bool PreProcessMessage(ref Message msg)
    {
        XamlSourcePreTranslateMessage(msg);
        return base.PreProcessMessage(ref msg);
    }

    protected bool InitializeXamlSourceWin32Window()
    {
        if (windowXamlSource is not null)
        {
            XamlSourceWin32Window = new Win32Window(windowXamlSource.GetWindowHandle());
            return true;
        }
        return false;
    }

    protected IWin32Window? XamlSourceWin32Window { get; private set; }

    protected void SetXamlSourceParent(bool initialize = false)
    {
        if (initialize) windowXamlSource?.AttachToWindow(Handle);
        else
        {
            if (XamlSourceWin32Window is null) return;
            if (!XamlSourceWin32Window.IsParent(this)) XamlSourceWin32Window.SetParent(this);
        }
    }

    protected void SetXamlSourceRect()
    {
        XamlSourceWin32Window?.SetRectangle(new(default, ClientSize));
    }

    protected void SetXamlSourceVisible()
    {
        XamlSourceWin32Window?.ShowAsync(false);
    }

    protected void XamlSourcePreTranslateMessage(Message message)
    {
        windowXamlSource?.PreTranslateMessage(&message);
    }
}
