using NeonWindows.ABI;
using NeonWindows.ABI.ApplicationModel;

namespace NeonWindows.ApplicationModel;

public unsafe static class WinAppCompatHelper
{
    public static bool TrySetOsMaxVersionTestedForCurrentProcess(ulong newValue = 0x000a00004a610000)
    {
        try
        {
            APPCOMPAT_EXE_DATA* exeData = AppCompatDataMarshal.GetAppCompatExeDataRaw(RtlProcEnvApi.RtlGetCurrentPeb());
            if (exeData is null) return false;
            SWITCH_CONTEXT* scData = &exeData->SwitchContext;
            SWITCH_CONTEXT_DATA* data = &scData->Data;
            data->OsMaxVersionTested = newValue; // Windows 10 2004, build 19041
            return true;
        }
        catch
        {
            return false;
        }
    }
}
