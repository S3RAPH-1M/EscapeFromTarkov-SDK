using System;

namespace EFT.Interactive
{
    // Token: 0x02001E28 RID: 7720
    [Flags]
    public enum EDoorState : byte
    {
        // Token: 0x04009BD9 RID: 39897
        Locked = 1,
        // Token: 0x04009BDA RID: 39898
        Shut = 2,
        // Token: 0x04009BDB RID: 39899
        Open = 4,
        // Token: 0x04009BDC RID: 39900
        Interacting = 8,
        // Token: 0x04009BDD RID: 39901
        Breaching = 16
    }
}