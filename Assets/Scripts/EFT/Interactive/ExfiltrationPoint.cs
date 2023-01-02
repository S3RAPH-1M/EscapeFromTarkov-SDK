using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using EFT.InventoryLogic;
using UnityEngine;

namespace EFT.Interactive
{
	// Token: 0x02001C0B RID: 7179
	public class ExfiltrationPoint : MonoBehaviour
	{
		// (get) Token: 0x0600A346 RID: 41798 RVA: 0x002BFBE1 File Offset: 0x002BDDE1
		public string Description { get; } = "ExfiltrationPoint";

		// Token: 0x04009120 RID: 37152
		public Collider ExtendedCollider;

		// Token: 0x04009122 RID: 37154
		private string string_0 = "";

		// Token: 0x04009123 RID: 37155
		private readonly List<string> list_0 = new List<string>();

		// Token: 0x04009124 RID: 37156

		// Token: 0x04009125 RID: 37157
		[CompilerGenerated]
		private readonly string string_1;

		// Token: 0x04009126 RID: 37158
		public float ExfiltrationStartTime;

		// Token: 0x04009128 RID: 37160
		[SerializeField]
		private GameObject _root;

		// Token: 0x04009129 RID: 37161
		[NonSerialized]
		public List<string> QueuedPlayers = new List<string>();

		// Token: 0x0400912A RID: 37162
		// Token: 0x0400912B RID: 37163
		// Token: 0x0400912C RID: 37164
		[CompilerGenerated]
		private Action<ExfiltrationPoint, Player> action_1;

		// Token: 0x0400912D RID: 37165
		[CompilerGenerated]
		private Action<ExfiltrationPoint, Player> action_2;

		// Token: 0x0400912E RID: 37166
		public string[] EligibleEntryPoints = new string[0];

		// Token: 0x04009130 RID: 37168
		public bool Reusable;

		// Token: 0x04009131 RID: 37169
		private BoxCollider boxCollider_0;

		// Token: 0x04009132 RID: 37170
		private Coroutine coroutine_0;

		// Token: 0x04009133 RID: 37171
		private Coroutine coroutine_1;

		// Token: 0x04009134 RID: 37172
		private bool bool_0;

		public string profileId;
	}
}
