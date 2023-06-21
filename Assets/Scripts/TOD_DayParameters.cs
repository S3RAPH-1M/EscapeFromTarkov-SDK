using System;
using UnityEngine;

// Token: 0x020000AD RID: 173
[Serializable]
public class TOD_DayParameters
{
	// Token: 0x04000389 RID: 905
	[Tooltip("Intensity of the light source.")]
	public float LightIntensity = 1f;

	// Token: 0x0400038A RID: 906
	[Tooltip("Opacity of the shadows dropped by the light source.")]
	public float ShadowStrength = 1f;

	// Token: 0x0400038B RID: 907
	[Tooltip("Brightness multiplier of the color gradients at day.")]
	[Range(0f, 1f)]
	public float ColorMultiplier = 1f;

	// Token: 0x0400038C RID: 908
	[Tooltip("Brightness multiplier of the ambient light at day.")]
	[Range(0f, 1f)]
	public float AmbientMultiplier = 1f;

	// Token: 0x0400038D RID: 909
	[Tooltip("Brightness multiplier of the reflection probe at day.")]
	[Range(0f, 1f)]
	public float ReflectionMultiplier = 1f;
}
