using System;
using UnityEngine;

// Token: 0x0200099F RID: 2463
[RequireComponent(typeof(Light))]
public class MuzzleLight : MonoBehaviour
{
	public Vector2 Range = new Vector2(6f, 12f);

	// Token: 0x04003BC0 RID: 15296
	public Light[] Lights;

	// Token: 0x04003BC1 RID: 15297
	public AnimationCurve LightIntensityCurve = AnimationCurve.Linear(0f, 1f, 0.5f, 0f);
}
