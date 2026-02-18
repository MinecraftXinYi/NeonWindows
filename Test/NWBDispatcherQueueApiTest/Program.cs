// See https://aka.ms/new-console-template for more information
using NeonWindows.ABI.System;
using System.Runtime.InteropServices;
using Windows.System;

Console.WriteLine("Hello, World!");
Console.ReadKey();
Thread thread = new(() =>
{
    Console.WriteLine("Testing native api GetDispatcherQueueForCurrentThread...");
    DispatcherQueueApi2.GetDispatcherQueueForCurrentThread(out nint pDispatcherQueue);
    Console.WriteLine($"HRESULT: {Marshal.GetHRForLastWin32Error()}");
    Console.WriteLine($"Return value: {pDispatcherQueue}");
    Console.ReadKey();
    Console.WriteLine("Testing native api CreateDispatcherQueueForCurrentThread...");
    DispatcherQueueApi2.CreateDispatcherQueueForCurrentThread(out pDispatcherQueue);
    Console.WriteLine($"HRESULT: {Marshal.GetHRForLastWin32Error()}");
    Console.WriteLine($"Return value: {pDispatcherQueue}");
    Console.ReadKey();
    Console.WriteLine("Testing native api GetDispatcherQueueForCurrentThread...x2");
    DispatcherQueueApi2.GetDispatcherQueueForCurrentThread(out pDispatcherQueue);
    Console.WriteLine($"HRESULT: {Marshal.GetHRForLastWin32Error()}");
    Console.WriteLine($"Return value: {pDispatcherQueue}");
    Console.ReadKey();
    Console.WriteLine("Testing native api CreateDispatcherQueueForCurrentThread...x2");
    DispatcherQueueApi2.CreateDispatcherQueueForCurrentThread(out pDispatcherQueue);
    Console.WriteLine($"HRESULT: {Marshal.GetHRForLastWin32Error()}");
    Console.WriteLine($"Return value: {pDispatcherQueue}");
    Console.ReadKey();
    DispatcherQueue dispatcherQueue = DispatcherQueue.FromAbi(pDispatcherQueue);
    Console.WriteLine($"DispatcherQueue Object: {dispatcherQueue}");
    Console.ReadKey();
});
thread.SetApartmentState(ApartmentState.STA);
thread.Start();
thread.Join();
