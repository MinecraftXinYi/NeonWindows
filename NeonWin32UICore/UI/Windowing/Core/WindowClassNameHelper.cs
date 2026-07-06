using System;

namespace NeonWindows.UI.Windowing.Core;

public static class WindowClassNameHelper
{
    public static string CreateWindowClassNameByManagedClass<T>(bool useGuid = false)
    {
        string baseStr = useGuid ? typeof(T).GUID.ToString() : typeof(T).FullName;
        string conjectionStr = useGuid ? "-" : "_";
        return baseStr + conjectionStr + random.Next().ToString();
    }

    private static readonly Random random = new();
}
