using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x0200002B RID: 43
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Displacement/Fisheye")]
	public class Fisheye : PostEffectsBase
	{	
		// Token: 0x040001B5 RID: 437
		public float strengthX = 0.05f;

		// Token: 0x040001B6 RID: 438
		public float strengthY = 0.05f;

		// Token: 0x040001B7 RID: 439
		public Shader fishEyeShader;

		// Token: 0x040001B8 RID: 440
		private Material fisheyeMaterial;
	}
}
