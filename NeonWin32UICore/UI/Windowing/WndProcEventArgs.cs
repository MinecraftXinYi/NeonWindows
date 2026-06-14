using System.Windows.Forms;

namespace NeonWindows.UI.Windowing;

public class WndProcEventArgs : EventArgs
{
    public WndProcEventArgs(ref Message m)
        => Message = m;

    public Message Message;

    public bool Handled { get; set; } = false;
}
