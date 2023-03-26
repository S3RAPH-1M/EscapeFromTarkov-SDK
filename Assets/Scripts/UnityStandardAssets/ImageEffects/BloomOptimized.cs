using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x0200001E RID: 30
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Bloom and Glow/Bloom (Optimized)")]
	public class BloomOptimized : PostEffectsBase
	{
		// Token: 0x040000EA RID: 234
		[Range(0f, 1.5f)]
		public float threshold = 0.25f;

		// Token: 0x040000EB RID: 235
		[Range(0f, 2.5f)]
		public float intensity = 0.75f;

		// Token: 0x040000EC RID: 236
		[Range(0.25f, 5.5f)]
		public float blurSize = 1f;

		// Token: 0x040000ED RID: 237
		private BloomOptimized.Resolution resolution;

		// Token: 0x040000EE RID: 238
		[Range(1f, 4f)]
		public int blurIterations = 1;

		// Token: 0x040000EF RID: 239
		public BloomOptimized.BlurType blurType;

		// Token: 0x040000F0 RID: 240
		public Shader fastBloomShader;

		// Token: 0x040000F1 RID: 241
		private Material fastBloomMaterial;

		// Token: 0x040000F2 RID: 242
		private bool isSupport;

		// Token: 0x020000BD RID: 189
		public enum Resolution
		{
			// Token: 0x040005F2 RID: 1522
			Low,
			// Token: 0x040005F3 RID: 1523
			High
		}

		// Token: 0x020000BE RID: 190
		public enum BlurType
		{
			// Token: 0x040005F5 RID: 1525
			Standard,
			// Token: 0x040005F6 RID: 1526
			Sgx
		}
	}
}
