using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using EFT;
using EFT.Ballistics;
using UnityEngine;

namespace Systems.Effects
{
	// Token: 0x02000B3A RID: 2874
	public class EffectsCommutator : MonoBehaviour
	{
		// Token: 0x040047FB RID: 18427
		[SerializeField]
		private Vector2 _minMaxBleedingSpawnDelta;

		// Token: 0x040047FC RID: 18428
		private Effects.Effect[] effect_0;

		// Token: 0x040047FD RID: 18429
		private List<Vector3> list_0;

		// Token: 0x040047FF RID: 18431
		private const int int_0 = 3;

		// Token: 0x04004800 RID: 18432
		private const int int_1 = 4;
	}
}
