using NeonWindows.ABI;
using Windows.Win32.System.Threading;

namespace NeonWindows.ApplicationModel;

public unsafe static class AppCompactInfoUtils
{
    public static SWITCH_CONTEXT_DATA* GetSwitchContextDataForCurrentProcess()
        => GetSwitchContextData(NtProcThreadInfoApi.RtlGetCurrentPeb());

    public static SWITCH_CONTEXT_DATA* GetSwitchContextData(nint pPeb)
        => &AppCompactInfoUtils.GetSwitchContext(AppCompactInfoUtils.GetAppCompatExeData(pPeb))->Data;

    internal static APPCOMPAT_EXE_DATA* GetAppCompatExeData(nint pPeb)
        => *(APPCOMPAT_EXE_DATA**)(pPeb + OffsetOfAppCompatShimData);

    internal static nint OffsetOfAppCompatShimData
    {
        get
        {
            PEB peb;
            return (nint)((byte*)&peb.SessionId - (byte*)&peb) + sizeof(void*) + (2 * sizeof(ulong));
        }
    }

    internal static SWITCH_CONTEXT* GetSwitchContext(APPCOMPAT_EXE_DATA* pShim)
    {
        nint _switchContextOffset = (nint)((byte*)&pShim->SwitchContext - (byte*)pShim);
        return (SWITCH_CONTEXT*)((byte*)pShim + _switchContextOffset);
    }
}
