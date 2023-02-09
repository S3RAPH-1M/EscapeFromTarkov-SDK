using System;

namespace EFT.Game.Spawning
{
	// Token: 0x02001BBD RID: 7101
	public struct SpawnPointParams
	{
		// Token: 0x04008FB2 RID: 36786
		public string Id;
		
		public ClassVector3 Position;

		// Token: 0x04008FB4 RID: 36788
		public float Rotation;

		// Token: 0x04008FB5 RID: 36789
		public EPlayerSideMask Sides;

		// Token: 0x04008FB6 RID: 36790
		public ESpawnCategoryMask Categories;

		// Token: 0x04008FB7 RID: 36791
		public string Infiltration;

		// Token: 0x04008FB8 RID: 36792
		public string BotZoneName;

		// Token: 0x04008FB9 RID: 36793
		public float DelayToCanSpawnSec;

		// Token: 0x04008FBA RID: 36794
		public ISpawnColliderParams ColliderParams;
	}
}
