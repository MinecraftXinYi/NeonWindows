using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Xaml.Hosting;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

public abstract class WindowsXamlHostBase : ContainerControl
{
    protected readonly DesktopWindowXamlSource windowXamlSource = null!;

    public WindowsXamlHostBase()
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
        SetControlStyle();
    }

    protected void SetControlStyle()
    {
        SetStyle(ControlStyles.ContainerControl, true);
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    }
}
