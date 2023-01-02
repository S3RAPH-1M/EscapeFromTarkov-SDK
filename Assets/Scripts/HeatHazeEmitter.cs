using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000955 RID: 2389
public class HeatHazeEmitter : MonoBehaviour
{
	// Token: 0x04003963 RID: 14691
	public Vector3 Bounds = new Vector3(1f, 1f, 1f);

	// Token: 0x04003964 RID: 14692
	public Vector3 Center;

	public Vector2 LifetimeDelta = new Vector2(1f, 2f);

	public Vector2 Size = new Vector2(1f, 2f);

	// Token: 0x04003967 RID: 14695
	public int Count = 5;

	// Token: 0x04003968 RID: 14696
	public float VelocityFactor = 10f;

	// Token: 0x04003969 RID: 14697
	public float Angle = 0.04f;

	// Token: 0x0400396A RID: 14698
	public float DelayInSec = 0.1f;

	// Token: 0x0400396B RID: 14699
	[HideInInspector]
	public float Chance = 1f;
}
