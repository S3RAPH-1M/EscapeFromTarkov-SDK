using System;
using UnityEngine;

namespace EFT.CameraControl
{
	// Token: 0x02002BCD RID: 11213
	[ExecuteAlways]
	public class OpticSight : MonoBehaviour
	{
		private static readonly int int_0 = Shader.PropertyToID("_SwitchToSight");
		public Renderer LensRenderer;
		public Transform ScopeTransform;
		[SerializeField]
		public float DistanceToCamera;
		[SerializeField]
		public ScopeData ScopeData;
		[SerializeField]
		[Tooltip("ALARM! Consumes a lot of CPU!")]
		public bool IsThermalSightAvailableAt45Degrees;
	}
}
