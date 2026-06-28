using NeonWindows.UI.Windowing.Core;
using System.Windows.Forms;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Windowing;

public class Win32Window : IWin32Window
{
    protected readonly NativeWindow2 native = new();

    public Win32Window()
    {
        CreateNativeWindow(GetDefaultCreateParams());
        InitializeCallbacks();
    }

    public Win32Window(CreateParams createParams)
    {
        CreateNativeWindow(createParams);
        InitializeCallbacks();
    }

    public void Show(bool activate = true)
    {
        SHOW_WINDOW_CMD cmd = activate ? SHOW_WINDOW_CMD.SW_SHOW : SHOW_WINDOW_CMD.SW_SHOWNA;
        this.ShowWindow((int)cmd);
    }

    public void Activate()
        => this.ActivateWindow();

    public nint Handle => native.Handle;

    private void CreateNativeWindow(CreateParams createParams)
    {
        OnCreate();
        native.CreateHandle(createParams);
        SetWindowStyle(Handle);
        OnCreated(Handle);
    }

    protected virtual void OnCreate() { }

    protected virtual void SetWindowStyle(nint hWnd)
    {
        HWND hwnd = new(hWnd);
        PInvoke.SetWindowLong(hwnd, WINDOW_LONG_PTR_INDEX.GWL_STYLE, (int)(WINDOW_STYLE.WS_OVERLAPPEDWINDOW | WINDOW_STYLE.WS_SIZEBOX));
        PInvoke.SetWindowLong(hwnd, WINDOW_LONG_PTR_INDEX.GWL_EXSTYLE, (int)(WINDOW_EX_STYLE.WS_EX_APPWINDOW | WINDOW_EX_STYLE.WS_EX_OVERLAPPEDWINDOW));
        this.SetWindowRect(new(), (uint)(SET_WINDOW_POS_FLAGS.SWP_FRAMECHANGED | SET_WINDOW_POS_FLAGS.SWP_NOACTIVATE | SET_WINDOW_POS_FLAGS.SWP_NOMOVE | SET_WINDOW_POS_FLAGS.SWP_NOSIZE));
    }

    protected virtual void OnCreated(nint hWnd) { }

    protected virtual CreateParams GetDefaultCreateParams()
    {
        return new()
        {
            Caption = "Win32 Window",
            Width = 800,
            Height = 600
        };
    }

    private void InitializeCallbacks()
    {
        native.OnWndProc += WndProcEntry;
        OnCallBacksInitialized();
    }

    protected virtual void OnCallBacksInitialized() { }

    private void WndProcEntry(object? sender, WndProcEventArgs e)
    {
        if (sender == null || sender != native) return;
        OnWndProc.Invoke(this, e);
        if (!e.Handled)
        {
            e.Handled = true;
            WndProc(ref e.Message);
        }
    }

    public event EventHandler<WndProcEventArgs> OnWndProc = delegate { };

    protected virtual void WndProc(ref Message m)
    {
        native.DefWndProc(ref m);
    }
}
