using System;
using UnityEngine;

namespace EFT.CameraControl
{
	// Token: 0x02002A54 RID: 10836
	public class ScopeCameraData : MonoBehaviour
	{
		
		// Token: 0x0400D85E RID: 55390
		[Space]
		public float FieldOfView;

		// Token: 0x0400D85F RID: 55391
		[Space]
		public float NearClipPlane;

		// Token: 0x0400D860 RID: 55392
		public float FarClipPlane;

		// Token: 0x0400D861 RID: 55393
		[Space]
		public bool OpticCullingMask;

		// Token: 0x0400D862 RID: 55394
		public float OpticCullingMaskScale;

		// Token: 0x0400D863 RID: 55395
		public bool CameraLodBiasController;

		// Token: 0x0400D864 RID: 55396
		public float LodBiasFactor;
	}
}
