using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;

namespace WinFormsPreMsgTest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Form form1 = new Form1(), form2 = new();
            int wndlong = PInvoke.GetWindowLong(new(form2.Handle), WINDOW_LONG_PTR_INDEX.GWL_STYLE);
            wndlong = wndlong | (int)WINDOW_STYLE.WS_CHILDWINDOW;
            PInvoke.SetWindowLong(new(form2.Handle), WINDOW_LONG_PTR_INDEX.GWL_STYLE, wndlong);
            PInvoke.SetParent(new(form2.Handle), new(form1.Handle));
            form2.Show();
            Application.Run(form1);
        }
    }
}
