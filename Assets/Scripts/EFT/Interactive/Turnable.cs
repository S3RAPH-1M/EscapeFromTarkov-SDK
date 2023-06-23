using System;
using EFT.Ballistics;
using EFT.NetworkPackets;
using UnityEngine;

namespace EFT.Interactive
{
	// Token: 0x02002247 RID: 8775
	public abstract class Turnable : MonoBehaviour
	{
		// Token: 0x0400AE03 RID: 44547
		public string Id;

		// Token: 0x0400AE04 RID: 44548
		public int NetId;

		// Token: 0x0400AE05 RID: 44549
		public Turnable.EState LampState;

		// Token: 0x0400AE06 RID: 44550
		public BallisticCollider BallisticCollider;

		// Token: 0x02002248 RID: 8776
		public enum EState
		{
			// Token: 0x0400AE08 RID: 44552
			TurningOn,
			// Token: 0x0400AE09 RID: 44553
			TurningOff,
			// Token: 0x0400AE0A RID: 44554
			On,
			// Token: 0x0400AE0B RID: 44555
			Off,
			// Token: 0x0400AE0C RID: 44556
			Destroyed,
			// Token: 0x0400AE0D RID: 44557
			ConstantFlickering,
			// Token: 0x0400AE0E RID: 44558
			SmoothOff
		}
	}
}