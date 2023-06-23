using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public sealed class MultiFlareLight : MonoBehaviour
{
	// Token: 0x06003CCB RID: 15563 RVA: 0x0012169A File Offset: 0x0011F89A
	private void OnDrawGizmos()
	{
		Gizmos.DrawIcon(base.transform.position, "flareGismo.png", true);
	}

	// Token: 0x04003B6B RID: 15211
	public MultiFlare Parent;

	// Token: 0x04003B6C RID: 15212
	public bool TrackPosition;

	// Token: 0x04003B6D RID: 15213
	public Light LightObject;

	// Token: 0x04003B6E RID: 15214
	public float Scale = 1f;

	// Token: 0x04003B6F RID: 15215
	public Vector3 CheckFadeOffset;

	// Token: 0x04003B70 RID: 15216
	public float Alpha = 1f;

	// Token: 0x04003B71 RID: 15217
	public Color Color = Color.white;

	// Token: 0x04003B72 RID: 15218
	public MultiFlareLight.Flare[] Flares;

	// Token: 0x02000996 RID: 2454
	[Serializable]
	public sealed class Flare
	{
		// Token: 0x04003B82 RID: 15234
		public int TextureId;

		// Token: 0x04003B83 RID: 15235
		public MultiFlare.EFlareType Type;

		// Token: 0x04003B84 RID: 15236
		public Vector2 Scale;

		// Token: 0x04003B85 RID: 15237
		public float Alpha;

		// Token: 0x04003B86 RID: 15238
		public float CenterShift = 1f;

		// Token: 0x04003B87 RID: 15239
		public float MinDist;

		// Token: 0x04003B88 RID: 15240
		public float MaxDist;

		// Token: 0x04003B89 RID: 15241
		public float MinScale;

		// Token: 0x04003B8A RID: 15242
		public float MaxScale;

		// Token: 0x04003B8B RID: 15243
		public float MinAlpha;

		// Token: 0x04003B8C RID: 15244
		public float MaxAlpha;

		// Token: 0x04003B8D RID: 15245
		public float SvWidth;

		// Token: 0x04003B8E RID: 15246
		public float SvShift;

		// Token: 0x04003B8F RID: 15247
		public MultiFlare.ERotationType RotType;

		// Token: 0x04003B90 RID: 15248
		public Color Color;
	}
}