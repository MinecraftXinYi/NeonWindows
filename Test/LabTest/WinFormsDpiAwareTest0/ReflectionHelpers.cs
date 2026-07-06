namespace WinFormsDpiAwareTest0;

internal static class ReflectionHelpers
{
    internal static string PropertyBackingFieldName(string propertyName)
        => $"<{propertyName}>k__BackingField";
}
