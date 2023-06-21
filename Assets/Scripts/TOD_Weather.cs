using System;
using UnityEngine;

// Token: 0x020000BF RID: 191
public class TOD_Weather : MonoBehaviour
{
	// Token: 0x04000472 RID: 1138
	[Tooltip("Time to fade from one weather type to the other.")]
	public float FadeTime = 10f;

	// Token: 0x04000473 RID: 1139
	[Tooltip("Currently selected cloud type.")]
	public TOD_CloudType Clouds;

	// Token: 0x04000474 RID: 1140
	[Tooltip("Currently selected weather type.")]
	public TOD_WeatherType Weather;

	// Token: 0x04000475 RID: 1141
	private float float_0;

	// Token: 0x04000476 RID: 1142
	private float float_1;

	// Token: 0x04000477 RID: 1143
	private float float_2;

	// Token: 0x04000478 RID: 1144
	private float float_3;

	// Token: 0x04000479 RID: 1145
	private float float_4;

	// Token: 0x0400047A RID: 1146
	private float float_5;

	// Token: 0x0400047B RID: 1147
	private float float_6;

	// Token: 0x0400047C RID: 1148
	private TOD_Sky tod_Sky_0;
}
