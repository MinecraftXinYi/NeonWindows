namespace NeonWindows.ABI.ApplicationModel;

public unsafe static class AppCompatDataMarshal
{
    public static APPCOMPAT_EXE_DATA* GetAppCompatExeData(void* peb)
    {
        int padding = sizeof(void*) - sizeof(uint);
        PEB peb0;
        //0x00000000000002d8
        nint offsetOfAppCompatDataPtr = (nint)((byte*)&peb0.SessionId - (byte*)&peb0) + sizeof(uint) + padding + (2 * sizeof(ulong));
        //                                                 + SessionId    + Padding + (AppCompatFlags + AppCompatFlagsUser)
        return *(APPCOMPAT_EXE_DATA**)((nint)peb + offsetOfAppCompatDataPtr);
    }
}
