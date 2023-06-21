using System;
using UnityEngine;

// Token: 0x020000B3 RID: 179
[Serializable]
public class TOD_LightParameters
{
	// Token: 0x040003AD RID: 941
	[Tooltip("Refresh interval of the light source position in seconds.")]
	public float UpdateInterval;

	// Token: 0x040003AE RID: 942
	[Tooltip("Controls how low the light source is allowed to go.\n = -1 light source can go as low as it wants.\n = 0 light source will never go below the horizon.\n = +1 light source will never leave zenith.")]
	public float MinimumHeight;
}
