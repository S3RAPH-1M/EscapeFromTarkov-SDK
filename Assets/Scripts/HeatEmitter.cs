using System;
using UnityEngine;

// Token: 0x02000954 RID: 2388
public class HeatEmitter : MonoBehaviour
{
	// Token: 0x04003957 RID: 14679
	public Vector3 Bounds = new Vector3(1f, 1f, 1f);

	// Token: 0x04003958 RID: 14680
	public Vector3 Center;

	// Token: 0x04003959 RID: 14681
	public Vector2 LifetimeDelta = new Vector2(1f, 2f);

	// Token: 0x0400395A RID: 14682
	public Vector2 Size = new Vector2(1f, 2f);

	// Token: 0x0400395B RID: 14683
	public float IrradiationRate = 0.016f;

	// Token: 0x0400395C RID: 14684
	public float HeatIncreasePerShot = 0.006f;

	// Token: 0x0400395D RID: 14685
	public AnimationCurve CountByHeat = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 10f),
		new Keyframe(1f, 10f)
	});

	// Token: 0x0400395E RID: 14686
	public AnimationCurve LifeTimeByHeat = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0.15f),
		new Keyframe(1f, 0.3f)
	});

	// Token: 0x0400395F RID: 14687
	public float _heat = 1f;

	// Token: 0x04003962 RID: 14690
	public float VelocityFactor = 10f;
}
