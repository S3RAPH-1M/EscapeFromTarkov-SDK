using System;
using BSG.CameraEffects;
using EFT.PostEffects;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace EFT.CameraControl
{
	// Token: 0x02001A51 RID: 6737
	public class OpticSight : MonoBehaviour
	{

		// Token: 0x040090C5 RID: 37061
		public Renderer LensRenderer;

		// Token: 0x040090C6 RID: 37062
		public Transform ScopeTransform;

		// Token: 0x040090C7 RID: 37063
		[SerializeField]
		public float DistanceToCamera;

		// Token: 0x040090C8 RID: 37064
		[SerializeField]
		public Camera TemplateCamera;

		// Token: 0x040090C9 RID: 37065
		[SerializeField]
		public OpticCullingMask OpticCullingMask;

		// Token: 0x040090CA RID: 37066
		[SerializeField]
		public ChromaticAberration ChromaticAberration;

		// Token: 0x040090CB RID: 37067
		[SerializeField]
		public BloomOptimized BloomOptimized;

		// Token: 0x040090CC RID: 37068
		[SerializeField]
		public ThermalVision ThermalVision;

		// Token: 0x040090CD RID: 37069
		[SerializeField]
		public CC_FastVignette FastVignette;

		// Token: 0x040090CE RID: 37070
		[SerializeField]
		public UltimateBloom UltimateBloom;

		// Token: 0x040090CF RID: 37071
		[SerializeField]
		public Tonemapping Tonemapping;

		// Token: 0x040090D0 RID: 37072
		[SerializeField]
		public NightVision NightVision;

		// Token: 0x040090D1 RID: 37073
		[SerializeField]
		public Fisheye Fisheye;

		// Token: 0x040090D2 RID: 37074
		[SerializeField]
		public CameraLodBiasController CameraLodBiasController;

		// Token: 0x040090D3 RID: 37075
		[SerializeField]
		[Tooltip("ALARM! Consumes a lot of CPU!")]
		public bool IsThermalSightAvailableAt45Degrees;

		// Token: 0x040090D4 RID: 37076
		private readonly int int_0 = Shader.PropertyToID("_SwitchToSight");

		// Token: 0x02001A52 RID: 6738
		public struct GStruct218
		{
			// Token: 0x040090D5 RID: 37077
			public OpticSight OpticSight;

			// Token: 0x040090D6 RID: 37078
			public bool IsEnabled;
		}
	}
}
