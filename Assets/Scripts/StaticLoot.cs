using System;
using UnityEngine;

// Token: 0x020005DE RID: 1502
public class StaticLoot : MonoBehaviour
{
	// Token: 0x170005E6 RID: 1510
	// (get) Token: 0x060028BA RID: 10426 RVA: 0x000B8446 File Offset: 0x000B6646
	public string Id
	{
		get
		{
			return this._id;
		}
	}

	// Token: 0x04002332 RID: 9010
	[SerializeField]
	private string _id;
}
