using Windows.Win32.System.Threading;

namespace NeonWindows.ABI;

internal unsafe struct PEB
{
    internal _Reserved1_e__FixedBuffer Reserved1;

    public byte BeingDebugged;

    internal _Reserved2_e__FixedBuffer Reserved2;

    internal _Reserved3_e__FixedBuffer Reserved3;

    internal PEB_LDR_DATA* Ldr;

    internal RTL_USER_PROCESS_PARAMETERS* ProcessParameters;

    internal _Reserved4_e__FixedBuffer Reserved4;

    public void* AtlThunkSListPtr;

    internal void* Reserved5;

    internal uint Reserved6;

    internal void* Reserved7;

    internal uint Reserved8;

    public uint AtlThunkSListPtr32;

    internal _Reserved9_e__FixedBuffer Reserved9;

    internal _Reserved10_e__FixedBuffer Reserved10;

    internal delegate* unmanaged[Stdcall]<void> PostProcessInitRoutine;

    internal _Reserved11_e__FixedBuffer Reserved11;

    internal _Reserved12_e__FixedBuffer Reserved12;

    public uint SessionId;

    internal partial struct _Reserved1_e__FixedBuffer
    {
        public byte e0;
        public byte e1;
    }

    internal partial struct _Reserved2_e__FixedBuffer
    {
        public byte e0;
    }

    internal unsafe partial struct _Reserved3_e__FixedBuffer
    {
        public void* e0;
        public void* e1;
    }

    internal unsafe partial struct _Reserved4_e__FixedBuffer
    {
        public void* e0;
        public void* e1;
        public void* e2;
    }

    internal unsafe partial struct _Reserved9_e__FixedBuffer
    {
        public void* e0;
        public void* e1;
        public void* e2;
        public void* e3;
        public void* e4;
        public void* e5;
        public void* e6;
        public void* e7;
        public void* e8;
        public void* e9;
        public void* e10;
        public void* e11;
        public void* e12;
        public void* e13;
        public void* e14;
        public void* e15;
        public void* e16;
        public void* e17;
        public void* e18;
        public void* e19;
        public void* e20;
        public void* e21;
        public void* e22;
        public void* e23;
        public void* e24;
        public void* e25;
        public void* e26;
        public void* e27;
        public void* e28;
        public void* e29;
        public void* e30;
        public void* e31;
        public void* e32;
        public void* e33;
        public void* e34;
        public void* e35;
        public void* e36;
        public void* e37;
        public void* e38;
        public void* e39;
        public void* e40;
        public void* e41;
        public void* e42;
        public void* e43;
        public void* e44;
    }

    internal partial struct _Reserved10_e__FixedBuffer
    {
        public byte e0;
        public byte e1;
        public byte e2;
        public byte e3;
        public byte e4;
        public byte e5;
        public byte e6;
        public byte e7;
        public byte e8;
        public byte e9;
        public byte e10;
        public byte e11;
        public byte e12;
        public byte e13;
        public byte e14;
        public byte e15;
        public byte e16;
        public byte e17;
        public byte e18;
        public byte e19;
        public byte e20;
        public byte e21;
        public byte e22;
        public byte e23;
        public byte e24;
        public byte e25;
        public byte e26;
        public byte e27;
        public byte e28;
        public byte e29;
        public byte e30;
        public byte e31;
        public byte e32;
        public byte e33;
        public byte e34;
        public byte e35;
        public byte e36;
        public byte e37;
        public byte e38;
        public byte e39;
        public byte e40;
        public byte e41;
        public byte e42;
        public byte e43;
        public byte e44;
        public byte e45;
        public byte e46;
        public byte e47;
        public byte e48;
        public byte e49;
        public byte e50;
        public byte e51;
        public byte e52;
        public byte e53;
        public byte e54;
        public byte e55;
        public byte e56;
        public byte e57;
        public byte e58;
        public byte e59;
        public byte e60;
        public byte e61;
        public byte e62;
        public byte e63;
        public byte e64;
        public byte e65;
        public byte e66;
        public byte e67;
        public byte e68;
        public byte e69;
        public byte e70;
        public byte e71;
        public byte e72;
        public byte e73;
        public byte e74;
        public byte e75;
        public byte e76;
        public byte e77;
        public byte e78;
        public byte e79;
        public byte e80;
        public byte e81;
        public byte e82;
        public byte e83;
        public byte e84;
        public byte e85;
        public byte e86;
        public byte e87;
        public byte e88;
        public byte e89;
        public byte e90;
        public byte e91;
        public byte e92;
        public byte e93;
        public byte e94;
        public byte e95;
    }

    internal partial struct _Reserved11_e__FixedBuffer
    {
        public byte e0;
        public byte e1;
        public byte e2;
        public byte e3;
        public byte e4;
        public byte e5;
        public byte e6;
        public byte e7;
        public byte e8;
        public byte e9;
        public byte e10;
        public byte e11;
        public byte e12;
        public byte e13;
        public byte e14;
        public byte e15;
        public byte e16;
        public byte e17;
        public byte e18;
        public byte e19;
        public byte e20;
        public byte e21;
        public byte e22;
        public byte e23;
        public byte e24;
        public byte e25;
        public byte e26;
        public byte e27;
        public byte e28;
        public byte e29;
        public byte e30;
        public byte e31;
        public byte e32;
        public byte e33;
        public byte e34;
        public byte e35;
        public byte e36;
        public byte e37;
        public byte e38;
        public byte e39;
        public byte e40;
        public byte e41;
        public byte e42;
        public byte e43;
        public byte e44;
        public byte e45;
        public byte e46;
        public byte e47;
        public byte e48;
        public byte e49;
        public byte e50;
        public byte e51;
        public byte e52;
        public byte e53;
        public byte e54;
        public byte e55;
        public byte e56;
        public byte e57;
        public byte e58;
        public byte e59;
        public byte e60;
        public byte e61;
        public byte e62;
        public byte e63;
        public byte e64;
        public byte e65;
        public byte e66;
        public byte e67;
        public byte e68;
        public byte e69;
        public byte e70;
        public byte e71;
        public byte e72;
        public byte e73;
        public byte e74;
        public byte e75;
        public byte e76;
        public byte e77;
        public byte e78;
        public byte e79;
        public byte e80;
        public byte e81;
        public byte e82;
        public byte e83;
        public byte e84;
        public byte e85;
        public byte e86;
        public byte e87;
        public byte e88;
        public byte e89;
        public byte e90;
        public byte e91;
        public byte e92;
        public byte e93;
        public byte e94;
        public byte e95;
        public byte e96;
        public byte e97;
        public byte e98;
        public byte e99;
        public byte e100;
        public byte e101;
        public byte e102;
        public byte e103;
        public byte e104;
        public byte e105;
        public byte e106;
        public byte e107;
        public byte e108;
        public byte e109;
        public byte e110;
        public byte e111;
        public byte e112;
        public byte e113;
        public byte e114;
        public byte e115;
        public byte e116;
        public byte e117;
        public byte e118;
        public byte e119;
        public byte e120;
        public byte e121;
        public byte e122;
        public byte e123;
        public byte e124;
        public byte e125;
        public byte e126;
        public byte e127;
    }

    internal unsafe partial struct _Reserved12_e__FixedBuffer
    {
        public void* e0;
    }
}
