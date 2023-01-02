using System;
using System.Runtime.CompilerServices;
using System.Threading;
using EFT.NetworkPackets;
using UnityEngine;

namespace EFT.Ballistics
{
	// Token: 0x02001CDC RID: 7388
	public class BallisticCollider : BaseBallistic
	{
		// Token: 0x04009524 RID: 38180
		public const int OLD_PRESET_ID = -900;

		// Token: 0x04009525 RID: 38181
		[HideInInspector]
		[SerializeField]
		private int _presetId = -900;

		// Token: 0x04009526 RID: 38182
		public int NetId;

		// Token: 0x04009527 RID: 38183
		public EHitType HitType;

		// Token: 0x04009528 RID: 38184
		[SerializeField]
		private MaterialType _typeOfMaterial;

		// Token: 0x04009529 RID: 38185
		[CompilerGenerated]
		private Action<DamageInfo> action_0;

		// Token: 0x0400952A RID: 38186
		public float PenetrationLevel;

		// Token: 0x0400952B RID: 38187
		[Range(0f, 1f)]
		public float PenetrationChance;

		// Token: 0x0400952C RID: 38188
		[Range(0f, 1f)]
		public float RicochetChance;

		// Token: 0x0400952D RID: 38189
		[Range(0f, 1f)]
		public float FragmentationChance;

		// Token: 0x0400952E RID: 38190
		[Range(0f, 1f)]
		public float TrajectoryDeviationChance;

		// Token: 0x0400952F RID: 38191
		[Range(0f, 1f)]
		public float TrajectoryDeviation;
	}
}
