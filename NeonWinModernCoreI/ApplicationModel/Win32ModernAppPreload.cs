using NeonWindows.ABI;
using NeonWindows.ABI.ApplicationModel;
using System;
using System.Collections.Generic;

namespace NeonWindows.ApplicationModel;

public class Win32ModernAppPreload : IDisposable
{
    internal static readonly string[] preloadDlls = new string[] { WinRTDllName.TWinApiAppCore, WinRTDllName.ThreadPoolWinRT };

    internal readonly List<nint> dllHandles = new();

    public Win32ModernAppPreload()
    {
        foreach (string dllName in preloadDlls) dllHandles.Add(LibLoaderApi.LoadLibraryExW(dllName, default, default));
    }

    public void Dispose()
    {
        foreach (nint dllHandle in dllHandles) LibLoaderApi.FreeLibrary(dllHandle);
        GC.SuppressFinalize(this);
    }
}
