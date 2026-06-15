using NeonWindows.UI.Windowing.Core;
using System.Windows.Forms;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Windowing;

public class NativeWindow2 : NativeWindow
{
    public void Show(bool activate = true)
    {
        SHOW_WINDOW_CMD cmd = activate ? SHOW_WINDOW_CMD.SW_SHOW : SHOW_WINDOW_CMD.SW_SHOWNA;
        this.ShowWindow((int)cmd);
    }

    public void Activate()
        => this.ActivateWindow();

    protected override void WndProc(ref Message m)
    {
        WndProcEventArgs e = new(ref m);
        OnWndProc.Invoke(this, e);
        if (!e.Handled) base.WndProc(ref m);
    }

    public event EventHandler<WndProcEventArgs> OnWndProc = delegate { };
}
