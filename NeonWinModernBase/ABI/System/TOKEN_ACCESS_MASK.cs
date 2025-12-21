using System;

namespace NeonWindows.ABI.System;

[Flags]
internal enum TOKEN_ACCESS_MASK : uint
{
    /// <summary>
    /// 查询访问令牌所必需的。
    /// </summary>
    TOKEN_QUERY = 0x00000008,

    /// <summary>
    /// 合并 STANDARD_RIGHTS_READ 和 TOKEN_QUERY。
    /// </summary>
    TOKEN_READ = 0x00020008,
}
