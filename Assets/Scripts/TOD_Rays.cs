using System;
using UnityEngine;

// Token: 0x020000B7 RID: 183
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Time of Day/Camera God Rays")]
[ExecuteInEditMode]
public class TOD_Rays : TOD_ImageEffect
{
	// Token: 0x040003B8 RID: 952
	public Shader GodRayShader;

	// Token: 0x040003B9 RID: 953
	public Shader ScreenClearShader;

	// Token: 0x040003BA RID: 954
	public TOD_Rays.ResolutionType Resolution = TOD_Rays.ResolutionType.Normal;

	// Token: 0x040003BB RID: 955
	public TOD_Rays.BlendModeType BlendMode;

	// Token: 0x040003BC RID: 956
	public int BlurIterations = 2;

	// Token: 0x040003BD RID: 957
	public float BlurRadius = 2f;

	// Token: 0x040003BE RID: 958
	public float Intensity = 1f;

	// Token: 0x040003BF RID: 959
	public float MaxRadius = 0.5f;

	// Token: 0x040003C0 RID: 960
	public bool UseDepthTexture = true;

	// Token: 0x040003C1 RID: 961
	private Material material_0;

	// Token: 0x040003C2 RID: 962
	private Material material_1;

	// Token: 0x040003C3 RID: 963
	private static readonly int int_1 = Shader.PropertyToID("_BlurRadius4");

	// Token: 0x040003C4 RID: 964
	private static readonly int int_2 = Shader.PropertyToID("_LightPosition");

	// Token: 0x040003C5 RID: 965
	private static readonly int int_3 = Shader.PropertyToID("_LightColor");

	// Token: 0x040003C6 RID: 966
	private static readonly int int_4 = Shader.PropertyToID("_ColorBuffer");

	// Token: 0x040003C7 RID: 967
	private const int int_5 = 2;

	// Token: 0x040003C8 RID: 968
	private const int int_6 = 3;

	// Token: 0x040003C9 RID: 969
	private const int int_7 = 1;

	// Token: 0x040003CA RID: 970
	private const int int_8 = 0;

	// Token: 0x040003CB RID: 971
	private const int int_9 = 4;

	// Token: 0x020000B8 RID: 184
	public enum ResolutionType
	{
		// Token: 0x040003CD RID: 973
		Low,
		// Token: 0x040003CE RID: 974
		Normal,
		// Token: 0x040003CF RID: 975
		High
	}

	// Token: 0x020000B9 RID: 185
	public enum BlendModeType
	{
		// Token: 0x040003D1 RID: 977
		Screen,
		// Token: 0x040003D2 RID: 978
		Add
	}
}
