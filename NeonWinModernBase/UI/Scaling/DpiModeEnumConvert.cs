using NeonWindows.ABI.UI.Scaling;
using System;

namespace NeonWindows.UI.Scaling;

internal static class DpiModeEnumConvert
{
    internal static DpiAwarenessMode? FromDpiAwarenessContext(DPI_AWARENESS_CONTEXT value)
    {
        if (value.IsNull) return null;
        if (value == DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_UNAWARE) return DpiAwarenessMode.Unaware;
        if (value == DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_UNAWARE_MIXED) return DpiAwarenessMode.Unaware;
        if (value == DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_SYSTEM_AWARE) return DpiAwarenessMode.System;
        if (value == DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_SYSTEM_AWARE_MIXED) return DpiAwarenessMode.System;
        if (value == DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE) return DpiAwarenessMode.PerMonitor;
        if (value == DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_MIXED) return DpiAwarenessMode.PerMonitor;
        if (value == DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2) return DpiAwarenessMode.PerMonitorV2;
        if (value == DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2_MIXED) return DpiAwarenessMode.PerMonitorV2;
        if (value == DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED) return DpiAwarenessMode.UnawareGdiScaled;
        if (value == DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED_MIXED) return DpiAwarenessMode.UnawareGdiScaled;
        try
        {
            if (DpiAwarenessContextApi.AreDpiAwarenessContextsEqual(value, DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_UNAWARE)) return DpiAwarenessMode.Unaware;
            if (DpiAwarenessContextApi.AreDpiAwarenessContextsEqual(value, DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_SYSTEM_AWARE)) return DpiAwarenessMode.System;
            if (DpiAwarenessContextApi.AreDpiAwarenessContextsEqual(value, DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE)) return DpiAwarenessMode.PerMonitor;
            if (DpiAwarenessContextApi.AreDpiAwarenessContextsEqual(value, DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2)) return DpiAwarenessMode.PerMonitorV2;
            if (DpiAwarenessContextApi.AreDpiAwarenessContextsEqual(value, DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED)) return DpiAwarenessMode.UnawareGdiScaled;
            return DpiAwarenessContextApi.IsValidDpiAwarenessContext(value) ? ReservedDpiModeEnum : null;
        }
        catch (TypeLoadException)
        {
            return ReservedDpiModeEnum;
        }
    }

    internal static DpiAwarenessMode? FromProcessDpiAwarenessEnum(PROCESS_DPI_AWARENESS value) => value switch
    {
        PROCESS_DPI_AWARENESS.PROCESS_DPI_UNAWARE => DpiAwarenessMode.Unaware,
        PROCESS_DPI_AWARENESS.PROCESS_SYSTEM_DPI_AWARE => DpiAwarenessMode.System,
        PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE => DpiAwarenessMode.PerMonitor,
        _ => null
    };

    internal static DPI_AWARENESS_CONTEXT ToCommonDpiAwarenessContext(DpiAwarenessMode value) => value switch
    {
        DpiAwarenessMode.Unaware => DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_UNAWARE,
        DpiAwarenessMode.System => DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_SYSTEM_AWARE,
        DpiAwarenessMode.PerMonitor => DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE,
        DpiAwarenessMode.PerMonitorV2 => DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2,
        DpiAwarenessMode.UnawareGdiScaled => DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED,
        _ => DPI_AWARENESS_CONTEXT.Null
    };

    internal static DPI_AWARENESS_CONTEXT ToMixedDpiAwarenessContext(DpiAwarenessMode value) => value switch
    {
        DpiAwarenessMode.Unaware => DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_UNAWARE_MIXED,
        DpiAwarenessMode.System => DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_SYSTEM_AWARE_MIXED,
        DpiAwarenessMode.PerMonitor => DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_MIXED,
        DpiAwarenessMode.PerMonitorV2 => DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2_MIXED,
        DpiAwarenessMode.UnawareGdiScaled => DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED_MIXED,
        _ => DPI_AWARENESS_CONTEXT.Null
    };

    internal static PROCESS_DPI_AWARENESS? ToProcessDpiAwarenessEnum(DpiAwarenessMode value) => value switch
    {
        DpiAwarenessMode.Unaware => PROCESS_DPI_AWARENESS.PROCESS_DPI_UNAWARE,
        DpiAwarenessMode.System => PROCESS_DPI_AWARENESS.PROCESS_SYSTEM_DPI_AWARE,
        DpiAwarenessMode.PerMonitor => PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE,
        _ => null
    };

    internal const DpiAwarenessMode ReservedDpiModeEnum = (DpiAwarenessMode)byte.MaxValue;
}
