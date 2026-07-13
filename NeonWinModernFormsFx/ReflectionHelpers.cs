namespace NeonWindows;

internal static class ReflectionHelpers
{
    internal static string PropertyBackingFieldName(string propertyName)
        => $"<{propertyName}>k__BackingField";
}
