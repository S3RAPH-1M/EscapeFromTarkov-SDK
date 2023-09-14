using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EFT.Visual
{
	// Token: 0x020017E5 RID: 6117
	public class GunShadowDisabler : MonoBehaviour
	{
		// Token: 0x0400870B RID: 34571
		[SerializeField]
		private List<Light> Lights;

		// Token: 0x0400870C RID: 34572
		private CommandBuffer commandBuffer_0;

		// Token: 0x0400870D RID: 34573
		private CommandBuffer commandBuffer_1;

		// Token: 0x0400870E RID: 34574
		private static readonly int int_0 = Shader.PropertyToID("_HideGunShadow");
	}
}
