using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

namespace EFT.Interactive
{
	// Token: 0x02002201 RID: 8705
	public class Door : WorldInteractiveObject
	{
		// Token: 0x0400AC7F RID: 44159
		public bool IsBroken;

		// Token: 0x0400AC80 RID: 44160
		public bool CanBeBreached = true;

		// Token: 0x0400AC81 RID: 44161
		public bool CanInteractWithBreach = true;

		// Token: 0x0400AC82 RID: 44162
		[Space(10f)]
		public AnimationCurve KickCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f, 1f, 1f),
			new Keyframe(0.5f, 1f, 1f, 1f)
		});

		// Token: 0x0400AC83 RID: 44163
		public ParticleSystem HitEffect;

		// Token: 0x0400AC84 RID: 44164
		public AudioClip HitClip;

		// Token: 0x0400AC85 RID: 44165
		public AudioClip BreachSound;
	}
}