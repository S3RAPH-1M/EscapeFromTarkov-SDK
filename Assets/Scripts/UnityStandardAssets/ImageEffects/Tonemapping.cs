using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace UnityStandardAssets.ImageEffects
{
	// Token: 0x0200003C RID: 60
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Color Adjustments/Tonemapping")]
	public class Tonemapping : PostEffectsBase
	{
		// Token: 0x04000248 RID: 584
		public Tonemapping.TonemapperType type = Tonemapping.TonemapperType.Photographic;

		// Token: 0x04000249 RID: 585
		public Tonemapping.AdaptiveTexSize adaptiveTextureSize = Tonemapping.AdaptiveTexSize.Square256;

		// Token: 0x0400024A RID: 586
		public AnimationCurve remapCurve;

		// Token: 0x0400024B RID: 587
		private Texture2D curveTex;

		// Token: 0x0400024C RID: 588
		public float exposureAdjustment = 1.5f;

		// Token: 0x0400024D RID: 589
		public float middleGrey = 0.4f;

		// Token: 0x0400024E RID: 590
		public float white = 2f;

		// Token: 0x0400024F RID: 591
		public float adaptionSpeed = 1.5f;

		// Token: 0x04000250 RID: 592
		public Shader tonemapper;

		// Token: 0x04000251 RID: 593
		public bool validRenderTextureFormat = true;

		// Token: 0x04000252 RID: 594
		private Material tonemapMaterial;

		// Token: 0x04000253 RID: 595
		private RenderTexture rt;

		// Token: 0x04000254 RID: 596
		private RenderTextureFormat rtFormat = RuntimeUtilities.defaultHDRRenderTextureFormat;

		// Token: 0x04000255 RID: 597
		private static readonly int _rangeScale = Shader.PropertyToID("_RangeScale");

		// Token: 0x04000256 RID: 598
		private static readonly int _curve = Shader.PropertyToID("_Curve");

		// Token: 0x04000257 RID: 599
		private static readonly int _exposureAdjustment = Shader.PropertyToID("_ExposureAdjustment");

		// Token: 0x04000258 RID: 600
		private static readonly int _adaptionSpeed = Shader.PropertyToID("_AdaptionSpeed");

		// Token: 0x04000259 RID: 601
		private static readonly int _hdrParams = Shader.PropertyToID("_HdrParams");

		// Token: 0x0400025A RID: 602
		private static readonly int _smallTex = Shader.PropertyToID("_SmallTex");

		// Token: 0x020000CF RID: 207
		public enum TonemapperType
		{
			// Token: 0x04000638 RID: 1592
			SimpleReinhard,
			// Token: 0x04000639 RID: 1593
			UserCurve,
			// Token: 0x0400063A RID: 1594
			Hable,
			// Token: 0x0400063B RID: 1595
			Photographic,
			// Token: 0x0400063C RID: 1596
			OptimizedHejiDawson,
			// Token: 0x0400063D RID: 1597
			AdaptiveReinhard,
			// Token: 0x0400063E RID: 1598
			AdaptiveReinhardAutoWhite
		}

		// Token: 0x020000D0 RID: 208
		public enum AdaptiveTexSize
		{
			// Token: 0x04000640 RID: 1600
			Square16 = 16,
			// Token: 0x04000641 RID: 1601
			Square32 = 32,
			// Token: 0x04000642 RID: 1602
			Square64 = 64,
			// Token: 0x04000643 RID: 1603
			Square128 = 128,
			// Token: 0x04000644 RID: 1604
			Square256 = 256,
			// Token: 0x04000645 RID: 1605
			Square512 = 512,
			// Token: 0x04000646 RID: 1606
			Square1024 = 1024
		}
	}
}
