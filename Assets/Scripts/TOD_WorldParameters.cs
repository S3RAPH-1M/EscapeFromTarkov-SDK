using System;
using UnityEngine;

// Token: 0x020000AB RID: 171
[Serializable]
public class TOD_WorldParameters
{
	// Token: 0x0400037A RID: 890
	[Range(-90f, 90f)]
	[Tooltip("Latitude of the current location in degrees.")]
	public float Latitude;

	// Token: 0x0400037B RID: 891
	[Range(-180f, 180f)]
	[Tooltip("Longitude of the current location in degrees.")]
	public float Longitude;

	// Token: 0x0400037C RID: 892
	[Tooltip("UTC/GMT time zone of the current location in hours.")]
	[Range(-14f, 14f)]
	public float UTC;
}
