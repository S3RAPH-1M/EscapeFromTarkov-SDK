using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace EFT
{
	// Token: 0x0200126B RID: 4715
	public class KnifeCollider : MonoBehaviour
	{
		// Token: 0x04006A7D RID: 27261
		public BoxCollider Collider;

		// Token: 0x04006A7E RID: 27262
		public Vector3 CastDirection;

		// Token: 0x04006A7F RID: 27263
		public RaycastHit[] hits = new RaycastHit[2];

		// Token: 0x04006A81 RID: 27265
		public float MaxDistance = 1f;

		// Token: 0x04006A83 RID: 27267
		internal Player player_0;

		// Token: 0x04006A84 RID: 27268
		public int _hitMask;

		// Token: 0x04006A85 RID: 27269
		public int _spiritMask;

		// Token: 0x04006A86 RID: 27270
		private Collider[] collider_0 = new Collider[16];

		// Token: 0x04006A87 RID: 27271
		private bool bool_0;

		// Token: 0x04006A88 RID: 27272
		private Vector3 vector3_0;

		// Token: 0x04006A89 RID: 27273
		private Vector3 vector3_1;

		// Token: 0x04006A8A RID: 27274
		private Quaternion quaternion_0;

		// Token: 0x04006A8B RID: 27275
		private HashSet<Player> hashSet_0 = new HashSet<Player>();

		// Token: 0x04006A8C RID: 27276
		private Vector3 vector3_2 = Vector3.one;

		// Token: 0x04006A8D RID: 27277
		[Header("Server setting")]
		[SerializeField]
		private float _weaponRootExtension = 0.7f;
	}
}
