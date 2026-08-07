using System;

namespace NeonWindows.ABI.ApplicationModel;

[Flags]
public enum ASTA_TEST_MODE_FLAGS
{
    NONE = 0x0,
    RO_INIT_SINGLETHREADED_CREATES_ASTAS = 0x1,
    GIT_LIFETIME_EXTENSION_ENABLED = 0x2,
    ROINITIALIZEASTA_ALLOWED = 0x4,
}
