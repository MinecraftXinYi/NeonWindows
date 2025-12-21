using System;

namespace NeonWindows.ABI.System;

[Flags]
internal enum PROCESS_ACCESS_RIGHTS : uint
{
    /// <summary>
    /// 需要使用 ReadProcessMemory 读取进程中的内存。
    /// </summary>
    PROCESS_VM_READ = 0x00000010,

    /// <summary>
    /// 检索有关进程的某些信息（例如其令牌、退出代码和优先级类）所必需的。
    /// </summary>
    PROCESS_QUERY_INFORMATION = 0x00000400,

    /// <summary>
    /// 检索有关进程的某些信息是必需的。 PROCESS_QUERY_LIMITED_INFORMATION 自动授予具有 PROCESS_QUERY_INFORMATION 访问权限的句柄。
    /// </summary>
    PROCESS_QUERY_LIMITED_INFORMATION = 0x00001000,
}
