using System;
using UnityEngine;

// Token: 0x0200059D RID: 1437
public class GrenadeSettings : ThrowableSettings
{

	// Token: 0x0400213B RID: 8507
	public GrenadeSettings.CollisionSounds CollisionSound;

	// Token: 0x0400213C RID: 8508
	public Transform Skoba;

	// Token: 0x0200059E RID: 1438
	public enum CollisionSounds
	{
		// Token: 0x0400213E RID: 8510
		frag,
		// Token: 0x0400213F RID: 8511
		smoke,
		// Token: 0x04002140 RID: 8512
		stun,
		// Token: 0x04002141 RID: 8513
		smokeM18,
		// Token: 0x04002142 RID: 8514
		stunM7920
	}
}
