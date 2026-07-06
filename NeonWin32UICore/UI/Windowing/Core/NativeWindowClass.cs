using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace NeonWindows.UI.Windowing.Core;

public unsafe class NativeWindowClass
{
    internal WNDCLASSEXW Field;

    public NativeWindowClass() : this(PInvoke.GetModuleHandle(default)) { }

    public NativeWindowClass(nint instanceHandle)
    {
        Field.cbSize = (uint)Marshal.SizeOf<WNDCLASSEXW>();
        InstanceHandle = instanceHandle;
    }

    internal NativeWindowClass(WNDCLASSEXW native)
        => Field = native;

    public static NativeWindowClass? Get(string name)
        => Get(PInvoke.GetModuleHandle(default), name);

    public static NativeWindowClass? Get(nint instanceHandle, string name)
    {
        if (!PInvoke.GetClassInfoEx(new(instanceHandle), name, out WNDCLASSEXW native)) return null;
        return new(native);
    }

    public string Name
    {
        get => Field.lpszClassName.ToString();
        set
        {
            fixed (char* pValue = value) Field.lpszClassName = new(pValue);
        }
    }

    public uint Style
    {
        get => (uint)Field.style;
        set => Field.style = (WNDCLASS_STYLES)value;
    }

    public nint WndProc
    {
        get => (nint)Field.lpfnWndProc;
        set => Field.lpfnWndProc = (delegate* unmanaged[Stdcall]<HWND, uint, WPARAM, LPARAM, LRESULT>)value;
    }

    public delegate* unmanaged[Stdcall]<nint, uint, nuint, nint, nint> WndProc_Native
    {
        get => (delegate* unmanaged[Stdcall]<nint, uint, nuint, nint, nint>)Field.lpfnWndProc;
        set => Field.lpfnWndProc = (delegate* unmanaged[Stdcall]<HWND, uint, WPARAM, LPARAM, LRESULT>)value;
    }

    public int ExtraClassSize
    {
        get => Field.cbClsExtra;
        set => Field.cbClsExtra = value;
    }

    public int ExtraWindowSize
    {
        get => Field.cbWndExtra;
        set => Field.cbWndExtra = value;
    }

    public nint InstanceHandle
    {
        get => Field.hInstance;
        set => Field.hInstance = new(value);
    }

    public nint IconHandle
    {
        get => Field.hIcon;
        set => Field.hIcon = new(value);
    }

    public nint SmallIconHandle
    {
        get => Field.hIconSm;
        set => Field.hIconSm = new(value);
    }

    public nint CursorHandle
    {
        get => Field.hCursor;
        set => Field.hCursor = new(value);
    }

    public nint BackgroundBrushHandle
    {
        get => Field.hbrBackground;
        set => Field.hbrBackground = new(value);
    }

    public string MenuName
    {
        get => Field.lpszMenuName.ToString();
        set
        {
            fixed (char* pValue = value) Field.lpszMenuName = new(pValue);
        }
    }

    public ushort Register()
        => PInvoke.RegisterClassEx(Field);
}
