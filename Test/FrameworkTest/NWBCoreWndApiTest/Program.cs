// See https://aka.ms/new-console-template for more information
using NeonWindows.ABI.UI.Modern.Core;
using Windows.UI.Core;
using WinRT;

ComWrappersSupport.InitializeComWrappers();
Console.WriteLine("Hello, World!");
int hr;
Console.ReadKey();
Console.WriteLine("Trying to create CoreWindow...");
hr = CoreUICoreWindowApi.PrivateCreateCoreWindow(WINDOW_TYPE.NOT_IMMERSIVE, null!, 0, 0, 0, 0, 0, 0, typeof(ICoreWindow).GUID, out nint pCoreWnd);
Console.WriteLine($"HResult: {hr}");
CoreWindow coreWindow = CoreWindow.FromAbi(pCoreWnd);
Console.WriteLine($"CoreWindow Object: {coreWindow}");
Console.ReadKey();
Console.WriteLine("Trying to create CoreWindow...x2");
hr = CoreUICoreWindowApi.PrivateCreateCoreWindow(WINDOW_TYPE.NOT_IMMERSIVE, string.Empty, 0, 0, 0, 0, 0, 0, typeof(ICoreWindow).GUID, out pCoreWnd);
Console.WriteLine($"HResult: {hr}");
coreWindow = CoreWindow.FromAbi(pCoreWnd);
Console.WriteLine($"CoreWindow Object: {coreWindow}");
Console.ReadKey();
