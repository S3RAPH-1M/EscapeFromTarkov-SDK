using System;
using UnityEngine;

// Token: 0x020000BB RID: 187
[AddComponentMenu("Time of Day/Camera Scattering")]
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class TOD_Scattering : TOD_ImageEffect
{
	// Token: 0x04000410 RID: 1040
	public bool Lighten;

	// Token: 0x04000411 RID: 1041
	public bool FromLevelSettings = true;

	// Token: 0x04000412 RID: 1042
	public Shader ScatteringShader;

	// Token: 0x04000413 RID: 1043
	public Texture2D DitheringTexture;

	// Token: 0x04000414 RID: 1044
	[Range(0f, 0.2f)]
	public float GlobalDensity = 0.001f;

	// Token: 0x04000415 RID: 1045
	[Range(0f, 1f)]
	public float HeightFalloff = 0.001f;

	// Token: 0x04000416 RID: 1046
	[Range(0.95f, 1f)]
	public float SunrizeGlow = 0.95f;

	// Token: 0x04000417 RID: 1047
	public float ZeroLevel;

	// Token: 0x04000418 RID: 1048
	private Material material_0;

	// Token: 0x04000419 RID: 1049
	private static readonly int int_1 = Shader.PropertyToID("_FrustumCornersWS");

	// Token: 0x0400041A RID: 1050
	private static readonly int int_2 = Shader.PropertyToID("_DitheringTexture");

	// Token: 0x0400041B RID: 1051
	private static readonly int int_3 = Shader.PropertyToID("_Density");

	// Token: 0x0400041C RID: 1052
	private static readonly int int_4 = Shader.PropertyToID("_SunrizeGlow");
}
