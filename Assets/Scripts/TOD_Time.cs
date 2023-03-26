using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020000BD RID: 189
public class TOD_Time : MonoBehaviour
{
	// Token: 0x04000461 RID: 1121
	public bool LockCurrentTime;

	// Token: 0x04000463 RID: 1123
	[Tooltip("Length of one day in minutes.")]
	public float DayLengthInMinutes = 30f;

	// Token: 0x04000464 RID: 1124
	[Tooltip("Set the date to the current device date on start.")]
	public bool UseDeviceDate;

	// Token: 0x04000465 RID: 1125
	[Tooltip("Set the time to the current device time on start.")]
	public bool UseDeviceTime;

	// Token: 0x04000466 RID: 1126
	[Tooltip("Apply the time curve when progressing time.")]
	public bool UseTimeCurve;

	// Token: 0x04000467 RID: 1127
	[Tooltip("Time progression curve.")]
	public AnimationCurve TimeCurve = AnimationCurve.Linear(0f, 0f, 24f, 24f);

	// Token: 0x04000468 RID: 1128
	[CompilerGenerated]
	private Action action_0;

	// Token: 0x04000469 RID: 1129
	[CompilerGenerated]
	private Action action_1;

	// Token: 0x0400046A RID: 1130
	[CompilerGenerated]
	private Action action_2;

	// Token: 0x0400046B RID: 1131
	[CompilerGenerated]
	private Action action_3;

	// Token: 0x0400046C RID: 1132
	[CompilerGenerated]
	private Action action_4;

	// Token: 0x0400046D RID: 1133
	private TOD_Sky tod_Sky_0;

	// Token: 0x0400046E RID: 1134
	private AnimationCurve animationCurve_0;

	// Token: 0x0400046F RID: 1135
	private AnimationCurve animationCurve_1;

	// Token: 0x04000470 RID: 1136
	private DateTime dateTime_0;

	// Token: 0x04000471 RID: 1137
	private const string string_0 = "d";
}
