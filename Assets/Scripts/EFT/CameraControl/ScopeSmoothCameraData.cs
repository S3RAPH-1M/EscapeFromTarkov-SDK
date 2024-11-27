using System;
using System.Runtime.CompilerServices;
using EFT.InventoryLogic;
using UnityEngine;

namespace EFT.CameraControl
{
	// Token: 0x02002BCB RID: 11211
	[RequireComponent(typeof(ScopeZoomHandler))]
	public class ScopeSmoothCameraData : MonoBehaviour
	{
		public ScopeZoomHandler ScopeZoomHandler { get; set; }
		[CompilerGenerated]
		private ScopeZoomHandler scopeZoomHandler_0;
		[Space]
		public Vector3 MinMaxFieldOfView;
		public AnimationCurve FieldOfViewCurve;
		public AnimationCurve ReticleBlendCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
		public float ZoomSensitivity;
		public float AdjustableOpticSensitivity;
		[Space]
		public float NearClipPlane;
		public float FarClipPlane;
		[Space]
		public bool OpticCullingMask;
		public float OpticCullingMaskScale;
		public bool CameraLodBiasController;
		public float LodBiasFactor;
		private bool bool_0;
		private Vector3 vector3_0;
		private float float_0;
		private float float_1;
		private float float_2;
	}
}
