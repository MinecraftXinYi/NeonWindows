using System;

namespace NeonWindows.ABI;

internal static class RoInterfaceIDs
{
    internal static readonly Guid
        IID_ICoreDragDropManager = new(2102842180u, 33892, 20399, 170, 73, 55, 234, 110, 45, 123, 209),
        IID_IDataTransferManager = new(2781539995u, 34568, 18897, 141, 54, 103, 210, 90, 141, 160, 12),
        IID_IPlayToManager = new(4117373038u, 7031, 17135, 143, 13, 185, 73, 248, 217, 178, 96),
        IID_IPrintManager = new(4280981140u, 35993, 17661, 174, 74, 25, 217, 170, 154, 15, 10),
        IID_ISystemMediaTransportControls = new(2583314420u, 5954, 17062, 144, 46, 8, 125, 65, 249, 101, 236);
}
