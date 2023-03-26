using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace EFT.PostEffects
{
	// Token: 0x020016E3 RID: 5859
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Camera))]
	public class OpticCullingMask : MonoBehaviour
	{
		// Token: 0x04008138 RID: 33080
		[SerializeField]
		private Shader _cullingMaskShader;

		// Token: 0x04008139 RID: 33081
		[SerializeField]
		[Range(0f, 2f)]
		public float _maskScale = 1f;

		// Token: 0x0400813A RID: 33082
		private static Mesh mesh_0;

		// Token: 0x0400813B RID: 33083
		private static readonly Matrix4x4 matrix4x4_0 = Matrix4x4.identity;

		// Token: 0x0400813C RID: 33084
		private Camera camera_0;

		// Token: 0x0400813D RID: 33085
		private Material material_0;

		// Token: 0x0400813E RID: 33086
		private CameraEvent cameraEvent_0 = CameraEvent.BeforeGBuffer;

		// Token: 0x0400813F RID: 33087
		private CommandBuffer commandBuffer_0;

		// Token: 0x04008140 RID: 33088
		private int int_0;
	}
}
