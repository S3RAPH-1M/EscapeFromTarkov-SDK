using System;
using UnityEngine;

// Token: 0x020000AA RID: 170
[Serializable]
public class TOD_CycleParameters
{
	// Token: 0x04000376 RID: 886
	[Tooltip("Current hour of the day.")]
	[Range(0f, 24f)]
	public float Hour = 12f;

	// Token: 0x04000377 RID: 887
	[Tooltip("Current day of the month.")]
	[Range(0f, 31f)]
	public int Day = 15;

	// Token: 0x04000378 RID: 888
	[Range(0f, 11f)]
	[Tooltip("Current month of the year.")]
	public int Month = 6;

	// Token: 0x04000379 RID: 889
	[Tooltip("Current year.")]
	public int Year = 2000;
}
