using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

namespace EFT.Interactive
{
	// Token: 0x020021F8 RID: 8696
	public abstract class BorderZone : MonoBehaviour
	{
		// Token: 0x0400AC3D RID: 44093
		protected const float DEEPENING_UPDATE_FREQUENCY = 1f;

		// Token: 0x0400AC3E RID: 44094
		[SerializeField]
		private BoxCollider Collider;

		// Token: 0x0400AC3F RID: 44095
		[SerializeField]
		protected Vector3 _extents;

		// Token: 0x0400AC40 RID: 44096
		[SerializeField]
		protected Vector4 _triggerZoneSettings = new Vector4(1f, 1f, 1f, 1f);
	}
}