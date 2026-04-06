// See https://aka.ms/new-console-template for more information
using NeonWindows.UI;
using NeonWindows.UI.Windowing;
using System.Drawing;

Console.WriteLine("Hello, World!");
Window window = new(new()
{
    Border = WindowBorder.Resizable,
    Position = Point.Empty,
    Size = new Size(800, 600),
    State = WindowState.Normal,
    CursorMode = CursorMode.Normal,
    Title = "Test",
    UpdateFrequency = null,
});
window.Show();
Window.Run();
