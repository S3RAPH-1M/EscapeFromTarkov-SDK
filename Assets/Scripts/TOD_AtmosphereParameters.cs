using System;
using UnityEngine;

// Token: 0x020000AC RID: 172
[Serializable]
public class TOD_AtmosphereParameters
{
	// Token: 0x0400037D RID: 893	
	[Tooltip("Intensity of the atmospheric Rayleigh scattering.")]
	public float RayleighMultiplier = 1f;

	// Token: 0x0400037E RID: 894
	[Tooltip("Intensity of the atmospheric Mie scattering.")]	
	public float MieMultiplier = 1f;

	// Token: 0x0400037F RID: 895
	[Tooltip("Overall brightness of the atmosphere.")]	
	public float Brightness = 1.5f;

	// Token: 0x04000380 RID: 896
	[Tooltip("Scattering brightness of the atmosphere.")]
	
	public float ScatteringBrightness = 1.5f;
	// Token: 0x04000381 RID: 897
	[Tooltip("Overall contrast of the atmosphere.")]
	public float Contrast = 1.5f;

	// Token: 0x04000382 RID: 898
	[Tooltip("Directionality factor that determines the size of the glow around the sun.")]
	public float Directionality = 0.7f;

	// Token: 0x04000383 RID: 899
	[Tooltip("Density of the fog covering the sky.")]
	public float Fogginess;
}
