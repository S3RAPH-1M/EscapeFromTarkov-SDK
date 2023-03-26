using System;
using UnityEngine;

// Token: 0x020000B5 RID: 181
[Serializable]
public class TOD_AmbientParameters
{
	// Token: 0x040003B1 RID: 945
	[Tooltip("Ambient light mode.")]
	public TOD_AmbientType Mode = TOD_AmbientType.Color;

	// Token: 0x040003B2 RID: 946
	[Tooltip("Refresh interval of the ambient light probe in seconds.")]
	public float UpdateInterval = 1f;
}
