using System.Reflection;
using System.Windows.Forms;

namespace NeonWindows.UI.Scaling;

public static class WinFormsDpiAwareness
{
    public static void SetDpiAwarenessForNativeWindow(NativeWindow nativeWindow, DpiAwarenessMode mode)
    {
        FieldInfo fieldInfo = GetFieldInfo_DpiContext_NativeWindow(out _, out FieldInfo[] fieldTypeStatics);
        fieldInfo.SetValue(nativeWindow, fieldTypeStatics[((int)mode) + 1].GetValue(null));
    }

    internal static FieldInfo GetFieldInfo_DpiContext_NativeWindow(out Type fieldType, out FieldInfo[] fieldTypeStatics)
    {
        FieldInfo fieldInfo = typeof(NativeWindow).GetField(ReflectionHelpers.PropertyBackingFieldName("DpiAwarenessContext"), BindingFlags.Instance | BindingFlags.NonPublic)!;
        fieldType = fieldInfo.FieldType;
        fieldTypeStatics = fieldType.GetFields(BindingFlags.Static | BindingFlags.NonPublic);
        return fieldInfo;
    }
}
