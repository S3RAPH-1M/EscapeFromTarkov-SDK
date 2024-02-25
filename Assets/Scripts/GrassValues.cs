using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020009AE RID: 2478
[Serializable]
public class GrassValues
{
	// Token: 0x04003B84 RID: 15236
	public float AngleInRads;

	// Token: 0x04003B85 RID: 15237
	public float TailLength;

	// Token: 0x04003B86 RID: 15238
	[Range(0.01f, 16f)]
	public float Radius;

	// Token: 0x04003B87 RID: 15239
	[Range(0.01f, 16f)]
	public float PressedRadius;

	// Token: 0x04003B88 RID: 15240
	public float ReturnTime;
}
