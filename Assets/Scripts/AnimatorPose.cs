using System;
using UnityEngine;

// Token: 0x020006DD RID: 1757
[CreateAssetMenu]
public class AnimatorPose : ScriptableObject
{
	// Token: 0x040026E0 RID: 9952
	public Vector3 Position;

	// Token: 0x040026E1 RID: 9953
	public Vector3 Rotation;

	// Token: 0x040026E2 RID: 9954
	public Vector3 CameraRotation;

	// Token: 0x040026E3 RID: 9955
	public Vector3 CameraPosition;

	// Token: 0x040026E4 RID: 9956
	public AnimationCurve Blend;
}
