// See https://aka.ms/new-console-template for more information
using NeonWindows.UI.Windowing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

Console.WriteLine("Hello, World!");
Test();
Console.ReadKey();
Win32Window window = new();
window.Show();
Application.Run();

unsafe static void Test()
{
    Message m = new();
    Console.WriteLine((nint)Unsafe.AsPointer<Message>(ref m));
    WndProcEventArgs e = new(ref m);
    Console.WriteLine((nint)Unsafe.AsPointer<Message>(ref e.Message));
}
