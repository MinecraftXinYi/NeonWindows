using System.Collections.Generic;
using Windows.Win32;
using Windows.Win32.Foundation;

namespace NeonWindows.UI.Windowing.Core;

public unsafe static class WndProcManager
{
    internal static void AddProcDelegate(nint hWnd, WndProcDelegate windowDelegate)
        => WndProcTable.Add(hWnd, windowDelegate);

    internal static void RemoveProcDelegate(nint hWnd)
        => WndProcTable.Remove(hWnd);

    public static nint WndProcPtr => (nint)WndProcEntry;

    internal static delegate* unmanaged[Stdcall]<HWND, uint, WPARAM, LPARAM, LRESULT> WndProcEntry
        => (delegate* unmanaged[Stdcall]<HWND, uint, WPARAM, LPARAM, LRESULT>)(delegate* managed<HWND, uint, WPARAM, LPARAM, LRESULT>)&WndProc;

    private static readonly Dictionary<nint, WndProcDelegate> WndProcTable = new();

    private static LRESULT WndProc(HWND hWnd, uint uMsg, WPARAM wParam, LPARAM lParam)
    {
        try
        {
            return (LRESULT)WndProcTable[hWnd].Invoke(hWnd, uMsg, wParam, lParam);
        }
        catch (KeyNotFoundException)
        {
            return PInvoke.DefWindowProc(hWnd, uMsg, wParam, lParam);
        }
    }
}
