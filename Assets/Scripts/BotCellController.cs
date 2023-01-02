using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using EFT.Interactive;
using UnityEngine;

// Token: 0x020001E1 RID: 481
public class BotCellController : MonoBehaviour
{
	// Token: 0x04000A26 RID: 2598
	public float CellDrawLevel = 10f;

	// Token: 0x04000A27 RID: 2599
	public float Dimention = 10f;

	// Token: 0x04000A28 RID: 2600
	[HideInInspector]
	public AICellData Data;

	// Token: 0x04000A29 RID: 2601
	private NavMeshDoorLink[] navMeshDoorLink_0;

	// Token: 0x020001E2 RID: 482
	[CompilerGenerated]
	private sealed class Class113
	{
		public Vector3 pos;
	}
}
