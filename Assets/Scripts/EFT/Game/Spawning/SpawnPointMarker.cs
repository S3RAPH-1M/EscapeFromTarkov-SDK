using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace EFT.Game.Spawning
{
	// Token: 0x02001BB9 RID: 7097
	[ExecuteInEditMode]
	public sealed class SpawnPointMarker : MonoBehaviour
	{
		// Token: 0x04008FA9 RID: 36777
		public Color Color = new Color(0f, 1f, 0f, 1f);

		// Token: 0x04008FAA RID: 36778
		[SerializeField]
		private SpawnPoint _spawnPoint;

		// Token: 0x04008FAB RID: 36779
		[SerializeField]
		private Collider _collider;

		// Token: 0x04008FAC RID: 36780
		private string string_0;

	}
}
