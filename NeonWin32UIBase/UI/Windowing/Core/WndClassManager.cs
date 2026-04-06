using System;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Gdi;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Windowing.Core;

public unsafe static class WndClassManager
{
    public static string RegisterWndClassForType<T>(WndClassStyleInfo styleInfo, nint wndProcPtr, string? menuName = null)
    {
        string generatedClassName = $"{typeof(T).GUID}-{random.Next()}";
        fixed (char* lpszClassName = generatedClassName)
        fixed (char* lpszMenuName = menuName)
        {
            WNDCLASSEXW wndClassEx = new()
            {
                lpszClassName = lpszClassName,
                cbSize = (uint)Marshal.SizeOf<WNDCLASSEXW>(),
                style = WNDCLASS_STYLES.CS_OWNDC,
                lpfnWndProc = (delegate* unmanaged[Stdcall]<HWND, uint, WPARAM, LPARAM, LRESULT>)wndProcPtr,
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = PInvoke.GetModuleHandle((char*)null),
                hIcon = (HICON)styleInfo.Icon,
                hIconSm = (HICON)styleInfo.SmallIcon,
                hCursor = (HCURSOR)styleInfo.Cursor,
                hbrBackground = (HBRUSH)styleInfo.BackgroundBrush,
                lpszMenuName = lpszMenuName,
            };

            if (PInvoke.RegisterClassEx(&wndClassEx) is 0)
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        }
        return generatedClassName;
    }

    public static void UnregisterWndClass(string className)
    {
        if (!PInvoke.UnregisterClass(className))
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
    }

    private static readonly Random random = new();
}
