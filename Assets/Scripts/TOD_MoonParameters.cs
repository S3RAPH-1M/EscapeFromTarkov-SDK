using System;
using UnityEngine;

// Token: 0x020000B0 RID: 176
[Serializable]
public class TOD_MoonParameters
{
	// Token: 0x0400039D RID: 925
	[Tooltip("Size of the moon mesh in degrees.")]
	public float MeshSize = 1f;

	// Token: 0x0400039E RID: 926
	[Tooltip("Brightness of the moon mesh.")]
	public float MeshBrightness = 2f;

	// Token: 0x0400039F RID: 927
	[Tooltip("Contrast of the moon mesh.")]
	public float MeshContrast = 1f;

	// Token: 0x040003A0 RID: 928
	[Tooltip("Color of the moon halo.\nInterpolates from left (day) to right (night).")]
	public Gradient HaloColor = new Gradient
	{
		alphaKeys = new GradientAlphaKey[]
		{
			new GradientAlphaKey(1f, 0f),
			new GradientAlphaKey(1f, 1f)
		},
		colorKeys = new GradientColorKey[]
		{
			new GradientColorKey(new Color32(25, 40, 65, byte.MaxValue), 0f),
			new GradientColorKey(new Color32(25, 40, 65, byte.MaxValue), 1f)
		}
	};

	// Token: 0x040003A1 RID: 929
	[Tooltip("Size of the moon halo.")]
	public float HaloSize = 0.1f;

	// Token: 0x040003A2 RID: 930
	[Tooltip("Type of the moon position calculation.")]
	public TOD_MoonPositionType Position = TOD_MoonPositionType.Realistic;
}
