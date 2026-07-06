using NeonWindows.UI.Messaging;
using NeonWindows.UI.Windowing;
using System.Drawing;

Console.WriteLine("Hello, World!");
Size size = new(800, 600);
Window window1 = new()
{
    Title = "Window1"
}, window2 = new()
{
    Title = "Window2"
};
Thread thread = new(() =>
{
    Window window3 = new()
    {
        Title = "Window3"
    };
    window3.Resize(size);
    window3.Show();
    window3.Activated += Activated;
    window3.Deactivated += Deactivated;
    window3.Closing += Closing;
    window3.Destroying += Destroying;
    MessageProc.Run();
});
window1.Resize(size);
window2.Resize(size);
window1.Show();
window2.Show();
window1.Activated += Activated;
window2.Activated += Activated;
window1.Deactivated += Deactivated;
window2.Deactivated += Deactivated;
window1.Closing += Closing;
window2.Closing += Closing;
window1.Destroying += Destroying;
window2.Destroying += Destroying;
thread.Start();
MessageProc.Run();

static void Activated(object? sender, EventArgs e)
{
    Console.WriteLine($"{((Window)sender!).Title} activated.");
}

static void Deactivated(object? sender, EventArgs e)
{
    Console.WriteLine($"{((Window)sender!).Title} deactivated.");
}

static void Closing(object? sender, EventArgs e)
{
    Console.WriteLine($"{((Window)sender!).Title} closed.");
}

static void Destroying(object? sender, EventArgs e)
{
    Console.WriteLine($"{((Window)sender!).Title} destroyed.");
}
