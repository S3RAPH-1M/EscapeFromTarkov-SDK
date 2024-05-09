using System;

[Flags]
public enum ETagStatus
{
	// Token: 0x04002A7A RID: 10874
	Unaware = 1,
	// Token: 0x04002A7B RID: 10875
	Aware = 2,
	// Token: 0x04002A7C RID: 10876
	Combat = 4,
	// Token: 0x04002A7D RID: 10877
	Solo = 8,
	// Token: 0x04002A7E RID: 10878
	Coop = 16,
	// Token: 0x04002A7F RID: 10879
	Bear = 32,
	// Token: 0x04002A80 RID: 10880
	Usec = 64,
	// Token: 0x04002A81 RID: 10881
	Scav = 128,
	// Token: 0x04002A82 RID: 10882
	TargetSolo = 256,
	// Token: 0x04002A83 RID: 10883
	TargetMultiple = 512,
	// Token: 0x04002A84 RID: 10884
	Healthy = 1024,
	// Token: 0x04002A85 RID: 10885
	Injured = 2048,
	// Token: 0x04002A86 RID: 10886
	BadlyInjured = 4096,
	// Token: 0x04002A87 RID: 10887
	Dying = 8192,
	// Token: 0x04002A88 RID: 10888
	Birdeye = 16384,
	// Token: 0x04002A89 RID: 10889
	Knight = 32768,
	// Token: 0x04002A8A RID: 10890
	BigPipe = 65536
}
