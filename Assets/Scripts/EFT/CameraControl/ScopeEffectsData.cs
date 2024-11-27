using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace EFT.CameraControl
{
	// Token: 0x02002BC8 RID: 11208
	public class ScopeEffectsData : MonoBehaviour
	{
		public bool ChromaticAberration;
		public int ChromaticAberrationAniso;
		public float ChromaticAberrationShift;
		[Space]
		public bool BloomOptimized;
		public float BloomOptimizedIntensity;
		public float BloomOptimizedThreshold;
		public float BloomOptimizedBlurSize;
		[Space]
		public bool FastVignette;
		public bool UltimateBloom;
		public bool Fisheye;
		[Space]
		public bool Tonemapping;
		public float White;
		public float AdaptionSpeed;
		public float ExposureAdjustment;
		public float MiddleGrey;
		public Tonemapping.AdaptiveTexSize AdaptiveTextureSize;
		public Tonemapping.TonemapperType Type;
	}
}
