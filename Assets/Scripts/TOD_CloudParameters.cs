using System;
using UnityEngine;

// Token: 0x020000B2 RID: 178
[Serializable]
public class TOD_CloudParameters
{
	// Token: 0x040003A6 RID: 934
	[Tooltip("Density of the clouds.")]
	public float Density = 1f;

	// Token: 0x040003A7 RID: 935
	[Tooltip("Sharpness of the clouds.")]
	public float Sharpness = 3f;

	// Token: 0x040003A8 RID: 936
	[Tooltip("Brightness of the clouds.")]
	public float Brightness = 1f;

	// Token: 0x040003A9 RID: 937
	[Tooltip("Number of billboard clouds to instantiate at start.\nBillboard clouds are not visible in edit mode.")]
	public int Billboards;

	// Token: 0x040003AA RID: 938
	[Tooltip("Opacity of the cloud shadows.")]
	public float ShadowStrength;

	// Token: 0x040003AB RID: 939
	[Tooltip("Scale of the first cloud layer.")]
	public Vector2 Scale1 = new Vector2(3f, 3f);

	// Token: 0x040003AC RID: 940
	[Tooltip("Scale of the second cloud layer.")]
	public Vector2 Scale2 = new Vector2(7f, 7f);
}
