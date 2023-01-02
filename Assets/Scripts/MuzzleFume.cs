using System;
using UnityEngine;

// Token: 0x02000999 RID: 2457
public class MuzzleFume : MuzzleEffect
{
	// Token: 0x04003B98 RID: 15256
	public float StartPos;

	// Token: 0x04003B99 RID: 15257
	public float EmitterRadius;

	// Token: 0x04003B9A RID: 15258
	public float ConusSize = 1f;

	// Token: 0x04003B9B RID: 15259
	public AnimationCurve Sizes = AnimationCurve.Linear(0f, 1f, 1f, 1f);

	// Token: 0x04003B9C RID: 15260
	public AnimationCurve Speeds = AnimationCurve.Linear(0f, 1f, 1f, 1f);

	// Token: 0x04003B9D RID: 15261
	public AnimationCurve LifeTimes = AnimationCurve.Linear(0f, 1f, 1f, 1f);

	// Token: 0x04003B9E RID: 15262
	public float SizesRnd = 0.5f;

	// Token: 0x04003B9F RID: 15263
	public float Size = 1f;

	// Token: 0x04003BA0 RID: 15264
	public float Speed = 1f;

	// Token: 0x04003BA1 RID: 15265
	public float LifeTime = 1f;

	// Token: 0x04003BA2 RID: 15266
	public Gradient Color;

	// Token: 0x04003BA3 RID: 15267
	public int CountMin = 1;

	// Token: 0x04003BA4 RID: 15268
	public int CountRange = 3;

}
