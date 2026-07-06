using NeonWindows.UI.Input;
using NeonWindows.UI.Windowing.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Windowing;

public unsafe class Window : IWin32Window
{
    public nint Handle { get; }

    public Window()
    {
        RegisterWindowClass();
        Handle = CreateNativeWindow();
        Load();
    }

    private static void RegisterWindowClass()
    {
        if (nativeWindowClass.Register() == default)
        {
            int hr = Marshal.GetHRForLastWin32Error();
            if (NativeWindowClass.Get(nativeWindowClass.Name) == null) Marshal.ThrowExceptionForHR(hr);
        }
    }

    private static readonly NativeWindowClass nativeWindowClass = new()
    {
        Name = WindowClassNameHelper.CreateWindowClassNameByManagedClass<Window>(),
        Style = (uint)(WNDCLASS_STYLES.CS_GLOBALCLASS | WNDCLASS_STYLES.CS_OWNDC),
        CursorHandle = Cursor.Standard._handle,
        WndProc_Native = (delegate* unmanaged[Stdcall]<nint, uint, nuint, nint, nint>)(delegate* managed<nint, uint, nuint, nint, nint>)&GlobalWndProc
    };

    private nint CreateNativeWindow()
    {
        nint hWnd = CreateHandle();
        if (!NativeWindowTest.IsWindow(hWnd)) Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        OnHandleCreated(EventArgs.Empty);
        return hWnd;
    }

    protected virtual nint CreateHandle()
        => NativeWindowBuild.CreateWindow(nativeWindowClass.Name, string.Empty, (uint)WINDOW_STYLE.WS_OVERLAPPEDWINDOW, (uint)WINDOW_EX_STYLE.WS_EX_APPWINDOW, new());

    private void Load()
    {
        AddThreadWndProc();
    }

    private void Unload()
    {
        RemoveThreadWndProc();
    }

    private void AddThreadWndProc()
        => threadWndProcs.Add(Handle, WndProc);

    private void RemoveThreadWndProc()
        => threadWndProcs.Remove(Handle);

    protected static nint GlobalWndProc(nint hWnd, uint Msg, nuint wParam, nint lParam)
    {
        if (threadWndProcs.TryGetValue(hWnd, out WndProcDelegate wndProc)) return wndProc(hWnd, Msg, wParam, lParam);
        return WindowProc.DefaultWindowProc(hWnd, Msg, wParam, lParam);
    }

    private static readonly Dictionary<nint, WndProcDelegate> threadWndProcs = [];

    protected virtual nint WndProc(nint hWnd, uint Msg, nuint wParam, nint lParam)
    {
        if (IsNotThisHandle(hWnd)) return WindowProc.DefaultWindowProc(hWnd, Msg, wParam, lParam);
        switch (Msg)
        {
            case PInvoke.WM_ACTIVATE:
                return WmActivation(wParam);
            case PInvoke.WM_MOVE:
            case PInvoke.WM_MOVING:
            case PInvoke.WM_SIZE:
            case PInvoke.WM_SIZING:
                return WmRectChange(hWnd, Msg, wParam, lParam);
            case PInvoke.WM_CLOSE:
                return WmClose(hWnd, Msg);
            case PInvoke.WM_DESTROY:
                return WmDestroy(hWnd, Msg);
            default:
                return WindowProc.DefaultWindowProc(hWnd, Msg, wParam, lParam);
        }
    }

    private bool IsNotThisHandle(nint hWnd)
        => hWnd != Handle;

    private nint WmActivation(nuint wParam)
    {
        if (wParam.LOWORD != PInvoke.WA_INACTIVE) OnActivated(EventArgs.Empty);
        else OnDeactivated(EventArgs.Empty);
        return default;
    }

    private nint WmRectChange(nint hWnd, uint Msg, nuint wParam, nint lParam)
    {
        if (IsNotThisHandle(hWnd)) return default;
        switch (Msg)
        {
            case PInvoke.WM_ENTERSIZEMOVE:
                OnResizeMoveBegin(EventArgs.Empty);
                break;
            case PInvoke.WM_EXITSIZEMOVE:
                OnResizeMoveEnd(EventArgs.Empty);
                break;
            case PInvoke.WM_MOVING:
            case PInvoke.WM_SIZING:
                WindowChangingEventArgs e1 = new(lParam);
                OnChanging(e1);
                if (e1.Cancel) return default;
                break;
            case PInvoke.WM_MOVE:
                WindowMovedEventArgs e2 = new(lParam.LOWORD, lParam.HIWORD);
                OnMoved(e2);
                break;
            case PInvoke.WM_SIZE:
                WindowResizedEventArgs e3 = new(lParam.LOWORD, lParam.HIWORD);
                OnResized(e3);
                break;
            default:
                break;
        }
        return WindowProc.DefaultWindowProc(hWnd, Msg, wParam, lParam);
    }

    private nint WmClose(nint hWnd, uint msg)
    {
        if (IsNotThisHandle(hWnd) || msg != PInvoke.WM_CLOSE) return default;
        WindowClosingEventArgs e = new();
        OnClosing(e);
        if (!e.Cancel) ThreadWindowInterop.DestroyWindow(Handle);
        return default;
    }

    private nint WmDestroy(nint hWnd, uint msg)
    {
        if (IsNotThisHandle(hWnd) || msg != PInvoke.WM_DESTROY) return default;
        OnDestroying(EventArgs.Empty);
        Unload();
        return default;
    }

    protected virtual void OnHandleCreated(EventArgs e)
        => HandleCreated?.Invoke(this, e);

    protected virtual void OnActivated(EventArgs e)
        => Activated?.Invoke(this, e);

    protected virtual void OnResizeMoveBegin(EventArgs e)
        => ResizeMoveBegin?.Invoke(this, e);

    protected virtual void OnResizeMoveEnd(EventArgs e)
        => ResizeMoveEnd?.Invoke(this, e);

    protected virtual void OnChanging(WindowChangingEventArgs e)
        => Changing?.Invoke(this, e);

    protected virtual void OnMoved(WindowMovedEventArgs e)
        => Moved?.Invoke(this, e);

    protected virtual void OnResized(WindowResizedEventArgs e)
        => Resized?.Invoke(this, e);

    protected virtual void OnDeactivated(EventArgs e)
        => Deactivated?.Invoke(this, e);

    protected virtual void OnClosing(WindowClosingEventArgs e)
        => Closing?.Invoke(this, e);

    protected virtual void OnDestroying(EventArgs e)
        => Destroying?.Invoke(this, e);

    public event EventHandler? HandleCreated;

    public event EventHandler? Activated;

    public event EventHandler? Deactivated;

    public event EventHandler? ResizeMoveBegin;

    public event EventHandler? ResizeMoveEnd;

    public event EventHandler<WindowChangingEventArgs>? Changing;

    public event EventHandler<WindowMovedEventArgs>? Moved;

    public event EventHandler<WindowResizedEventArgs>? Resized;

    public event EventHandler<WindowClosingEventArgs>? Closing;

    public event EventHandler? Destroying;

}
