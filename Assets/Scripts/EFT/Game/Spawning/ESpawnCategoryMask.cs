using System;

namespace EFT.Game.Spawning
{
	// Token: 0x02001BA2 RID: 7074
	[Flags]
	public enum ESpawnCategoryMask
	{
		// Token: 0x04008F84 RID: 36740
		None = 0,
		// Token: 0x04008F85 RID: 36741
		Player = 1,
		// Token: 0x04008F86 RID: 36742
		Bot = 2,
		// Token: 0x04008F87 RID: 36743
		Boss = 4,
		// Token: 0x04008F88 RID: 36744
		All = 7
	}
}
