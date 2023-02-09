using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using EFT.Interactive;
using UnityEngine;

// Token: 0x020001E1 RID: 481
public class BotCellController : MonoBehaviour
{
	private void OnDrawGizmosSelected()
	{
		for (int i = 0; i < this.Data.MaxIx + 1; i++)
		{
			for (int j = 0; j < this.Data.MaxIz + 1; j++)
			{
				Vector3 vector = new Vector3(this.Data.StartX + this.Data.CellSize * (float)i, this.CellDrawLevel, this.Data.StartZ + this.Data.CellSize * (float)j);
				Vector3 to = vector + new Vector3(this.Data.CellSize, 0f, 0f);
				Vector3 to2 = vector + new Vector3(0f, 0f, this.Data.CellSize);
				vector += new Vector3(this.Data.CellSize / 2f, 0f, this.Data.CellSize / 2f);
				Gizmos.color = Color.green;
				if (j != this.Data.MaxIz)
				{
					Gizmos.DrawLine(vector, to2);
				}
				if (i != this.Data.MaxIx)
				{
					Gizmos.DrawLine(vector, to);
				}
			}
		}
	}
	
	// Token: 0x04000A26 RID: 2598
	public float CellDrawLevel = 10f;

	// Token: 0x04000A27 RID: 2599
	public float Dimention = 10f;

	public AICellData Data;
}
