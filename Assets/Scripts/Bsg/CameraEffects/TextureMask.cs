using System;
using System.Collections.Generic;
using UnityEngine;

namespace BSG.CameraEffects
{
	// Token: 0x02000AF5 RID: 2805
	[RequireComponent(typeof(Camera))]
	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TextureMask")]
	public class TextureMask : MonoBehaviour
	{
		// Token: 0x04004669 RID: 18025
		private const string string_0 = "_STRETCH";

		// Token: 0x0400466A RID: 18026
		public Shader Shader;

		// Token: 0x0400466B RID: 18027
		public Color Color;

		// Token: 0x0400466C RID: 18028
		public Texture Mask;

		// Token: 0x0400466D RID: 18029
		public bool Stretch;

		// Token: 0x0400466E RID: 18030
		public float Size = 1f;

		// Token: 0x04004670 RID: 18032
		private Material material_0;

		// Token: 0x04004671 RID: 18033
		private Camera camera_0;

		// Token: 0x04004673 RID: 18035
		private static readonly int int_0 = Shader.PropertyToID("_Color");

		// Token: 0x04004674 RID: 18036
		private static readonly int int_1 = Shader.PropertyToID("_Mask");

		// Token: 0x04004675 RID: 18037
		private static readonly int int_2 = Shader.PropertyToID("_InvMaskSize");

		// Token: 0x04004676 RID: 18038
		private static readonly int int_3 = Shader.PropertyToID("_InvAspect");

		// Token: 0x04004677 RID: 18039
		private static readonly int int_4 = Shader.PropertyToID("_CameraAspect");
	}
}
