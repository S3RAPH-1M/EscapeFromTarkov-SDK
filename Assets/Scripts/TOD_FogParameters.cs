using System;
using UnityEngine;

// Token: 0x020000B4 RID: 180
[Serializable]
public class TOD_FogParameters
{
	// Token: 0x040003AF RID: 943
	[Tooltip("Fog color mode.")]
	public TOD_FogType Mode = TOD_FogType.Color;

	// Token: 0x040003B0 RID: 944
	[Tooltip("Fog color sampling height.\n = 0 fog is atmosphere color at horizon.\n = 1 fog is atmosphere color at zenith.")]
	public float HeightBias;
}
