using System.Runtime.InteropServices;
using WinRT;

namespace NeonWindows.ABI.ApplicationModel.Modern.Core;

[Guid(WinRTCoreAppComGuid.IID_ICoreApplicationPrivate2)]
public partial interface ICoreApplicationPrivate2
{
    internal void GetIids(out ulong iidCount, out nint iids);

    internal void GetRuntimeClassName(out nint className);

    internal void GetTrustLevel(out TrustLevel trustLevel);
}
