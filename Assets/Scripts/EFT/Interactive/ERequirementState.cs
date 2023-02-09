using System;

namespace EFT.Interactive
{
    // Token: 0x020021D7 RID: 8663
    public enum ERequirementState
    {
        // Token: 0x0400ABD0 RID: 43984
        None,
        // Token: 0x0400ABD1 RID: 43985
        Empty,
        // Token: 0x0400ABD2 RID: 43986
        TransferItem,
        // Token: 0x0400ABD3 RID: 43987
        WorldEvent,
        // Token: 0x0400ABD4 RID: 43988
        NotEmpty,
        // Token: 0x0400ABD5 RID: 43989
        HasItem,
        // Token: 0x0400ABD6 RID: 43990
        WearsItem,
        // Token: 0x0400ABD7 RID: 43991
        EmptyOrSize,
        // Token: 0x0400ABD8 RID: 43992
        SkillLevel,
        // Token: 0x0400ABD9 RID: 43993
        Reference,
        // Token: 0x0400ABDA RID: 43994
        ScavCooperation,
        // Token: 0x0400ABDB RID: 43995
        Train,
        // Token: 0x0400ABDC RID: 43996
        Timer
    }
}