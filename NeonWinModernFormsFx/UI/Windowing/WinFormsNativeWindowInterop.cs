using System;
using System.Reflection;
using System.Windows.Forms;

namespace NeonWindows.UI.Windowing;

public static class WinFormsNativeWindowInterop
{
    public static NativeWindow GetNativeWindowForControl(Control control)
    {
        FieldInfo fieldInfo = GetFieldInfo_NativeWindow_WinFormsControl(out _);
        return (NativeWindow)fieldInfo.GetValue(control);
    }

    internal static FieldInfo GetFieldInfo_NativeWindow_WinFormsControl(out Type fieldType)
    {
        FieldInfo fieldInfo = typeof(Control).GetField("window", BindingFlags.Instance | BindingFlags.NonPublic);
        fieldType = fieldInfo.FieldType;
        return fieldInfo;
    }
}
