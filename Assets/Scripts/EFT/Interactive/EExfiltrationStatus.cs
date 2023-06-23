using System;

namespace EFT.Interactive
{
    // Token: 0x020021CE RID: 8654
    public enum EExfiltrationStatus : byte
    {
        // Token: 0x0400AB9F RID: 43935
        NotPresent = 1,
        // Token: 0x0400ABA0 RID: 43936
        UncompleteRequirements,
        // Token: 0x0400ABA1 RID: 43937
        Countdown,
        // Token: 0x0400ABA2 RID: 43938
        RegularMode,
        // Token: 0x0400ABA3 RID: 43939
        Pending,
        // Token: 0x0400ABA4 RID: 43940
        AwaitsManualActivation
    }
}