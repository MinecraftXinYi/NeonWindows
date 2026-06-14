using System.Windows.Forms;

namespace NeonWindows.UI.Windowing;

public class Win32Window : IWin32Window
{
    protected readonly NativeWindow2 native = new();

    public Win32Window()
    {
        CreateNativeWindow();
        InitializeCallbacks();
    }

    public Win32Window(nint hWnd)
    {
        GetNativeWindow(hWnd);
        InitializeCallbacks();
    }

    public nint Handle => native.Handle;

    private void CreateNativeWindow()
    {
        OnCreate();
        native.CreateHandle(GetCreateParams());
        OnCreated();
    }

    private void GetNativeWindow(nint hWnd)
    {
        OnGet();
        native.AssignHandle(hWnd);
        OnGot();
    }

    protected virtual void OnCreate() { }

    protected virtual void OnCreated() { }

    protected virtual void OnGet() { }

    protected virtual void OnGot() { }

    protected virtual CreateParams GetCreateParams()
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
