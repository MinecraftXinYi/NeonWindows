using System.Windows.Forms;

namespace NeonWindows.UI.Windowing;

public class NativeWindow2 : NativeWindow
{
    protected override void WndProc(ref Message m)
    {
        WndProcEventArgs e = new(ref m);
        OnWndProc.Invoke(this, e);
        if (!e.Handled) base.WndProc(ref m);
    }

    public event EventHandler<WndProcEventArgs> OnWndProc = delegate { };
}
