using System;
using UnityEngine;

// Token: 0x020001E0 RID: 480
[Serializable]
public class AICellData
{
	// Token: 0x04000A20 RID: 2592
	[SerializeField]
	public AICell[] List;

	// Token: 0x04000A21 RID: 2593
	public float CellSize;

	// Token: 0x04000A22 RID: 2594
	public float StartX;

	// Token: 0x04000A23 RID: 2595
	public float StartZ;

	// Token: 0x04000A24 RID: 2596
	public int MaxIx;

	// Token: 0x04000A25 RID: 2597
	public int MaxIz;
}
