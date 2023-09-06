using System;
using System.Runtime.CompilerServices;
using EFT.InventoryLogic;
using UnityEngine;

namespace EFT.Visual
{
	// Token: 0x02001752 RID: 5970
	public class FoldableStockView : MonoBehaviour
	{
		// Token: 0x04008351 RID: 33617
		[SerializeField]
		private FoldableStockView.BonePosition[] _bonePositions;

		// Token: 0x04008352 RID: 33618
		private FoldableComponent foldableComponent_0;

		// Token: 0x04008353 RID: 33619
		private Action action_0;

		// Token: 0x02001753 RID: 5971
		[Serializable]
		public class BonePosition
		{
			// Token: 0x04008354 RID: 33620
			public string BoneName;

			// Token: 0x04008355 RID: 33621
			public Transform Bone;

			// Token: 0x04008356 RID: 33622
			public Quaternion FoldedRotation;

			// Token: 0x04008357 RID: 33623
			public Quaternion UnfoldedRotation;
		}
	}
}
