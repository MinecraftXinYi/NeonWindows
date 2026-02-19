using System;
using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Modern.Core;

public static class CoreUICoreInputApi
{
    [DllImport(WinRTDllName.WindowsUI, EntryPoint = "#1600", ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern int PrivateCreateCoreInput(COREINPUT_TYPE InputType, COREINPUT_POINTER_TYPE PointerTypes, COREINPUT_FLAGS Flags, Guid riid, out nint ppv);

    [DllImport(WinRTDllName.WindowsUI, EntryPoint = "#1602", ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern int PrivateCreateCoreInputEx(COREINPUT_TYPE InputType, COREINPUT_POINTER_TYPE PointerTypes, nint pCoreWindow, COREINPUT_FLAGS Flags, Guid riid, out nint ppv);

    [DllImport(WinRTDllName.WindowsUI, EntryPoint = "#1604", ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern int PrivateCreateCoreInputWithHwnd(nint hwnd, Guid riid, out nint ppv);
}
