using System.Windows.Forms;
using Windows.System;
using Windows.UI.Core;

namespace NeonWindows.UI.Modern.Desktop.Core;

public abstract class CoreUIHostWindow : Form
{
    public abstract CoreDispatcher Dispatcher { get; }

    public abstract DispatcherQueue DispatcherQueue { get; }
}
