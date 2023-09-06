using System;
using System.Collections;
using UnityEngine;

namespace EFT
{
	// Token: 0x0200137C RID: 4988
	public class BeltDetachablePart : MonoBehaviour
	{
		// Token: 0x04006FFD RID: 28669
		[SerializeField]
		private Rigidbody _rigidbody;

		// Token: 0x04006FFE RID: 28670
		[SerializeField]
		private EAmmoBeltSpawnDirection _spawnDirection;

		// Token: 0x04006FFF RID: 28671
		[SerializeField]
		private float _beltLifetime = 3f;

		// Token: 0x04007000 RID: 28672
		[SerializeField]
		private float _forceInSpawn = 2f;

		// Token: 0x04007001 RID: 28673
		private IEnumerator ienumerator_0;

		// Token: 0x04007002 RID: 28674
		private bool bool_0;
	}
}
