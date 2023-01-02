using System;
using UnityEngine;

// Token: 0x020005A1 RID: 1441
public class ThrowableSettings : MonoBehaviour
{
	// Token: 0x0400214A RID: 8522
	[SerializeField]
	public Vector3 Offset;

	// Token: 0x0400214B RID: 8523
	[SerializeField]
	[Header("Threshold sqrMagnitude")]
	public float VelocityTreshold = 0.005f;
}
