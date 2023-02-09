using System;
using UnityEngine;
using UnityEngine.Networking;

namespace EFT.SynchronizableObjects
{
	// Token: 0x02001B35 RID: 6965
	public class SynchronizableObject : MonoBehaviour
	{
		// Token: 0x0400951A RID: 38170
		public SynchronizableObjectType Type;

		// Token: 0x0400951B RID: 38171
		public int ObjectId;

		// Token: 0x0400951C RID: 38172
		public int UniqueId;

		// Token: 0x0400951D RID: 38173
		public bool IsActive;

		// Token: 0x0400951E RID: 38174
		public bool IsInited;

		// Token: 0x0400951F RID: 38175
		public bool IsStatic;
	}
}