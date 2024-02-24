using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020009E9 RID: 2537
public class FlareForEffects : OnRenderObjectConnector
{
	// Token: 0x04003D81 RID: 15745
	public MultiFlare MultiFlareObject;

	// Token: 0x04003D82 RID: 15746
	private FlareForEffects.Class501[] class501_0;

	// Token: 0x04003D83 RID: 15747
	private static readonly LinkedList<FlareForEffects.Class502> linkedList_0;

	// Token: 0x04003D84 RID: 15748
	private Material material_0;

	// Token: 0x04003D85 RID: 15749
	private Material material_1;

	// Token: 0x04003D86 RID: 15750
	private float float_0;

	// Token: 0x04003D87 RID: 15751
	private float float_1;

	// Token: 0x04003D88 RID: 15752
	private static readonly int int_0;

	// Token: 0x020009EA RID: 2538
	private class Class501
	{
		// Token: 0x06003FE4 RID: 16356 RVA: 0x00002050 File Offset: 0x00000250
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Class501()
		{
			throw null;
		}

		// Token: 0x04003D89 RID: 15753
		public Mesh ScreenMesh;

		// Token: 0x04003D8A RID: 15754
		public Mesh ShitMesh;
	}

	// Token: 0x020009EB RID: 2539
	private class Class502
	{
		// Token: 0x06003FE5 RID: 16357 RVA: 0x00002050 File Offset: 0x00000250
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Class502(Vector3 pos, int flareID, float time)
		{
			throw null;
		}

		// Token: 0x06003FE6 RID: 16358 RVA: 0x00002050 File Offset: 0x00000250
		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool Process(float delta)
		{
			throw null;
		}

		// Token: 0x04003D8B RID: 15755
		public int FlareID;

		// Token: 0x04003D8C RID: 15756
		public Vector3 Position;

		// Token: 0x04003D8D RID: 15757
		private float float_0;

		// Token: 0x04003D8E RID: 15758
		public float Energy;
	}
}
