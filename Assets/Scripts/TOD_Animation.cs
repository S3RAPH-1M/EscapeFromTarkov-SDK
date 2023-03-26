using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000096 RID: 150
public class TOD_Animation : MonoBehaviour
{
	// Token: 0x040002F6 RID: 758
	[Tooltip("Wind direction in degrees.")]
	public float WindDegrees;

	// Token: 0x040002F7 RID: 759
	[Tooltip("Speed of the wind that is acting on the clouds.")]
	public float WindSpeed = 1f;

	// Token: 0x040002F8 RID: 760
	[Tooltip("Adjust the cloud coordinates when the sky dome moves.")]
	public bool WorldSpaceCloudUV = true;

	// Token: 0x040002F9 RID: 761
	[Tooltip("Randomize the cloud coordinates at startup.")]
	public bool RandomInitialCloudUV = true;

	// Token: 0x040002FA RID: 762
	[CompilerGenerated]
	private Vector4 vector4_0;

	// Token: 0x040002FB RID: 763
	public Vector2 CloudPosition;

	// Token: 0x040002FC RID: 764
	private TOD_Sky tod_Sky_0;
}
