using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020009E2 RID: 2530
[ExecuteInEditMode]
public class MuzzleSmoke : MonoBehaviour
{
	// Token: 0x04003D6A RID: 15722
	public Material Material;

	// Token: 0x04003D6B RID: 15723
	public float SmokeEnd = 10f;

	// Token: 0x04003D6C RID: 15724
	public float BrakeDistance = 0.1f;

	// Token: 0x04003D6D RID: 15725
	[Space(8f)]
	public float DragValue = 0.98f;

	// Token: 0x04003D6E RID: 15726
	public float Gravity = -2f;

	// Token: 0x04003D6F RID: 15727
	public float SmokeVelocity = 0.1f;

	// Token: 0x04003D70 RID: 15728
	[Space(8f)]
	public float TurbulenceDensity = 0.1f;

	// Token: 0x04003D71 RID: 15729
	public float TurbulenceIntensity = 0.5f;

	// Token: 0x04003D72 RID: 15730
	[Space(8f)]
	public float SmokeDiffusionBySmokeVelocity;

	// Token: 0x04003D73 RID: 15731
	[Header("Driven By Muzzle Speed")]
	public float MuzzleSpeedMultiplier;

	// Token: 0x04003D74 RID: 15732
	public AnimationCurve SpeedTurbulenceDensity = AnimationCurve.Linear(0f, 0f, 30f, 6f);

	// Token: 0x04003D75 RID: 15733
	public AnimationCurve SpeedTurbulenceStrength = AnimationCurve.Linear(0f, 0f, 30f, 80f);

	// Token: 0x04003D76 RID: 15734
	public AnimationCurve SpeedSmokeStrength = AnimationCurve.Linear(0f, 1f, 20f, 0.1f);

	// Token: 0x04003D77 RID: 15735
	public AnimationCurve SpeedStartDiffusion = AnimationCurve.Linear(0f, 1f, 20f, 0.1f);

	// Token: 0x04003D78 RID: 15736
	[Header("Driven By Time")]
	public AnimationCurve Smoke = AnimationCurve.EaseInOut(0.1f, 0.2f, 3f, 0f);

	// Token: 0x04003D79 RID: 15737
	public float SmokeStrength = 1f;

	// Token: 0x04003D7A RID: 15738
	public float SmokeLength = 1f;

	// Token: 0x04003D7B RID: 15739
	public float SmokeLengthRandomness;

	// Token: 0x04003D7C RID: 15740
	public float SmokeIncreasingByShot = 0.4f;

	// Token: 0x04003D7D RID: 15741
	public float ShotFactorDropTime = 0.5f;
}
