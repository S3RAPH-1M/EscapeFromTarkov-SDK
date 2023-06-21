using System;
using UnityEngine;

// Token: 0x020000AE RID: 174
[Serializable]
public class TOD_NightParameters
{
	// Token: 0x04000393 RID: 915
	[Tooltip("Intensity of the light source at night.")]
	public float LightIntensity = 0.1f;

	// Token: 0x04000394 RID: 916
	[Tooltip("Opacity of the shadows dropped by the light source at night.")]
	public float ShadowStrength = 1f;

	// Token: 0x04000395 RID: 917
	[Range(0f, 1f)]
	[Tooltip("Brightness multiplier of the color gradients at night.")]
	public float ColorMultiplier = 1f;

	// Token: 0x04000396 RID: 918
	[Range(0f, 1f)]
	[Tooltip("Brightness multiplier of the ambient light at night.")]
	public float AmbientMultiplier = 1f;

	// Token: 0x04000397 RID: 919
	[Tooltip("Brightness multiplier of the reflection probe at night.")]
	[Range(0f, 1f)]
	public float ReflectionMultiplier = 1f;
}
