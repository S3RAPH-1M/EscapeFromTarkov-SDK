using System;

namespace EFT.Game.Spawning
{
	// Token: 0x02001BA2 RID: 7074
	[Flags]
	public enum ESpawnCategoryMask
	{
		// Token: 0x0400A941 RID: 43329
		None = 0,
		// Token: 0x0400A942 RID: 43330
		Player = 1,
		// Token: 0x0400A943 RID: 43331
		Bot = 2,
		// Token: 0x0400A944 RID: 43332
		Boss = 4,
		// Token: 0x0400A945 RID: 43333
		Coop = 8,
		// Token: 0x0400A946 RID: 43334
		Group = 16,
		// Token: 0x0400A947 RID: 43335
		Opposite = 32,
		// Token: 0x0400A948 RID: 43336
		All = 7
	}
}
