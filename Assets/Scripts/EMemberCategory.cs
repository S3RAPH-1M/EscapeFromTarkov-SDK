using System;

// Token: 0x02000754 RID: 1876
[Flags]
public enum EMemberCategory
{
	// Token: 0x04002AC6 RID: 10950
	Default = 0,
	// Token: 0x04002AC7 RID: 10951
	Developer = 1,
	// Token: 0x04002AC8 RID: 10952
	UniqueId = 2,
	// Token: 0x04002AC9 RID: 10953
	Trader = 4,
	// Token: 0x04002ACA RID: 10954
	Group = 8,
	// Token: 0x04002ACB RID: 10955
	System = 16,
	// Token: 0x04002ACC RID: 10956
	ChatModerator = 32,
	// Token: 0x04002ACD RID: 10957
	ChatModeratorWithPermanentBan = 64,
	// Token: 0x04002ACE RID: 10958
	UnitTest = 128,
	// Token: 0x04002ACF RID: 10959
	Sherpa = 256,
	// Token: 0x04002AD0 RID: 10960
	Emissary = 512
}
