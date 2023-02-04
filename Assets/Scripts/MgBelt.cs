using System;
using System.Collections.Generic;
using BezierSplineTools;
using UnityEngine;

// Token: 0x02000808 RID: 2056
public class MgBelt : MonoBehaviour
{
	// Token: 0x04003000 RID: 12288
	public Rigidbody[] KeyElemetns;

	// Token: 0x04003001 RID: 12289
	public Collider[] KeyElementsColliders;

	// Token: 0x04003002 RID: 12290
	public List<Transform> Links = new List<Transform>();

	// Token: 0x04003003 RID: 12291
	public float WaveAmplitude;

	// Token: 0x04003004 RID: 12292
	public AnimationCurve AmplitudeCurve;

	// Token: 0x04003005 RID: 12293
	public AnimationCurve WeightCurve;

}
