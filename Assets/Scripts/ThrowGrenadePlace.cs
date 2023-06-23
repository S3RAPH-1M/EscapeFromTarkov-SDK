using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using EFT.Interactive;
using UnityEngine;

// Token: 0x0200045B RID: 1115
public class ThrowGrenadePlace : MonoBehaviour
{
	public float GrenadeMass = 0.6f;

	// Token: 0x04001B3C RID: 6972
	public float GrenadeForce = 11f;

	// Token: 0x04001B3D RID: 6973
	public Transform From;

	// Token: 0x04001B3E RID: 6974
	public Transform Target;

	// Token: 0x04001B3F RID: 6975
	public float AngleForThrow = 45f;

	// Token: 0x04001B40 RID: 6976
	public float ThrowForce = 45f;

	// Token: 0x04001B41 RID: 6977
	public Door Door;

	// Token: 0x04001B42 RID: 6978
	public bool IsOk;

	// Token: 0x04001B43 RID: 6979
	public Vector3 DoorPos;

	// Token: 0x04001B44 RID: 6980
	public bool HaveDoor;
}