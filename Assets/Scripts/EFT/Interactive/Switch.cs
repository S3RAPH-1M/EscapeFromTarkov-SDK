using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace EFT.Interactive
{
	// Token: 0x0200223F RID: 8767
	public class Switch : WorldInteractiveObject
	{
		// Token: 0x0400ADD8 RID: 44504
		[Header("-------------  Switch -----------")]
		public bool DontAnimateRotation;

		// Token: 0x0400ADD9 RID: 44505
		public string ContextMenuTip;

		// Token: 0x0400ADDA RID: 44506
		public float Delay;

		// Token: 0x0400ADDB RID: 44507
		[Header("Exfiltration Zone")]
		public ExfiltrationPoint ExfiltrationPoint;

		// Token: 0x0400ADDC RID: 44508
		public EExfiltrationStatus TargetStatus;

		// Token: 0x0400ADDD RID: 44509
		public EExfiltrationStatus[] ConditionStatus;

		// Token: 0x0400ADDE RID: 44510
		public string ExtractionZoneTip;

		// Token: 0x0400ADDF RID: 44511
		[Header("Other Switches")]
		public Switch.SwitchAndOperation[] NextSwitches;

		// Token: 0x0400ADE0 RID: 44512
		public Switch PreviousSwitch;

		// Token: 0x0400ADE1 RID: 44513
		[Header("Door")]
		public Door Door;

		// Token: 0x0400ADE2 RID: 44514
		public EInteractionType Interaction;

		// Token: 0x0400ADE3 RID: 44515
		[Header("Lamps")]
		public LampController[] Lamps;

		// Token: 0x0400ADE4 RID: 44516
		[Header("Curve is played 1.5x faster. Consider!")]
		public AnimationCurve CustomProgressCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x0400ADE5 RID: 44517
		public Vector3 ShutPosition;

		// Token: 0x0400ADE6 RID: 44518
		public Vector3 OpenPosition;

		// Token: 0x02002240 RID: 8768
		[Serializable]
		public class SwitchAndOperation
		{
			// Token: 0x0400ADE7 RID: 44519
			public Switch Switch;

			// Token: 0x0400ADE8 RID: 44520
			public EInteractionType Operation;
		}
	}
}