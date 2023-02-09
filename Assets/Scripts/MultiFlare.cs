using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

// Token: 0x02000990 RID: 2448
[ExecuteInEditMode]
public sealed class MultiFlare : MonoBehaviour
{
	// Token: 0x04003B49 RID: 15177
	public ProFlareAtlas Atlas;

	// Token: 0x04003B4A RID: 15178
	public Material NormalMat;

	// Token: 0x04003B4B RID: 15179
	public Material ShitMat;

	// Token: 0x04003B4C RID: 15180
	public LayerMask LayerMask;

	// Token: 0x04003B4D RID: 15181
	public Space Space;

	// Token: 0x04003B4E RID: 15182
	public int StartCapacity = 4;

	// Token: 0x04003B51 RID: 15185
	private List<Vector4> list_1;

	// Token: 0x04003B52 RID: 15186
	private List<Vector3> list_2;

	// Token: 0x04003B53 RID: 15187
	private List<Vector2> list_3;

	// Token: 0x04003B54 RID: 15188
	private List<Vector2> list_4;

	// Token: 0x04003B55 RID: 15189
	private List<Vector2> list_5;

	// Token: 0x04003B56 RID: 15190
	private List<Vector2> list_6;

	// Token: 0x04003B57 RID: 15191
	private List<int> list_7;

	// Token: 0x04003B5A RID: 15194
	private int int_0 = -1;

	// Token: 0x04003B5B RID: 15195
	private Bounds bounds_0;

	// Token: 0x02000991 RID: 2449
	public enum EFlareType
	{
		// Token: 0x04003B5D RID: 15197
		Normal,
		// Token: 0x04003B5E RID: 15198
		OffScreen,
		// Token: 0x04003B5F RID: 15199
		Shit
	}

	// Token: 0x02000992 RID: 2450
	public enum ERotationType
	{
		// Token: 0x04003B61 RID: 15201
		None,
		// Token: 0x04003B62 RID: 15202
		Normal,
		// Token: 0x04003B63 RID: 15203
		Inverse
	}
}