using System;
using UnityEngine;

namespace EFT.Game.Spawning
{
	// Token: 0x02001BB2 RID: 7090
	[Serializable]
	public class SpawnPoint
	{
		// Token: 0x04008F95 RID: 36757
		public string Id;

		// Token: 0x04008F96 RID: 36758
		public string Name;

		// Token: 0x04008F97 RID: 36759
		public Vector3 Position;

		// Token: 0x04008F98 RID: 36760
		public Quaternion Rotation;

		// Token: 0x04008F99 RID: 36761
		public EPlayerSideMask Sides;

		// Token: 0x04008F9A RID: 36762
		public ESpawnCategoryMask Categories;

		// Token: 0x04008F9B RID: 36763
		public string Infiltration;

		// Token: 0x04008F9C RID: 36764
		public BotZone BotZone;

		// Token: 0x04008F9D RID: 36765
		public float DelayToCanSpawnSec = 4f;
	}
}
