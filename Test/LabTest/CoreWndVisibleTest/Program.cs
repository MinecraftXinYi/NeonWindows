using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace CoreWndVisibleTest
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            AllocConsole();
            Application.Start((p) => new App());
        }

        [DllImport("KernelBase.dll")]
        private static extern int AllocConsole();
    }
}
