using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

// Token: 0x02000204 RID: 516
[Serializable]
public class TriangleData
{
	// Token: 0x04000AD3 RID: 2771
	[SerializeField]
	public int Id;

	// Token: 0x04000AD4 RID: 2772
	public float CenterX;

	// Token: 0x04000AD5 RID: 2773
	public float CenterY;

	// Token: 0x04000AD6 RID: 2774
	public float CenterZ;

	// Token: 0x04000AD7 RID: 2775
	public int[] Ids;

	// Token: 0x04000AD8 RID: 2776
	public float[] Dists;

	// Token: 0x04000AD9 RID: 2777
	public int[] Closest;

	// Token: 0x04000ADA RID: 2778
	public int PointAIndex;

	// Token: 0x04000ADB RID: 2779
	public int PointBIndex;

	// Token: 0x04000ADC RID: 2780
	public int PointCIndex;

	// Token: 0x04000ADD RID: 2781
	private Dictionary<int, float> _distances = new Dictionary<int, float>();
}