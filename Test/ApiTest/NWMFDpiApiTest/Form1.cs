using NeonWindows.UI.Scaling;
using NeonWindows.UI.Windowing;

namespace NWMFDpiApiTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void CreateHandle()
        {
            WinFormsDpiAwareness.SetDpiAwarenessForNativeWindow(WinFormsNativeWindowInterop.GetNativeWindowForControl(this), DpiAwarenessMode.PerMonitorV2);
            base.CreateHandle();
        }
    }
}
