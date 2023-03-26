using System;
using UnityEngine;

// Token: 0x0200009A RID: 154
[AddComponentMenu("Time of Day/Camera Main Script")]
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class TOD_Camera : MonoBehaviour
{
	// Token: 0x04000301 RID: 769
	public TOD_Sky sky;

	// Token: 0x04000302 RID: 770
	public bool DomePosToCamera = true;

	// Token: 0x04000303 RID: 771
	public Vector3 DomePosOffset = Vector3.zero;

	// Token: 0x04000304 RID: 772
	public bool DomeScaleToFarClip = true;

	// Token: 0x04000305 RID: 773
	public float DomeScaleFactor = 0.95f;

	// Token: 0x04000306 RID: 774
	private Camera camera_0;

	// Token: 0x04000307 RID: 775
	private Transform transform_0;
}
