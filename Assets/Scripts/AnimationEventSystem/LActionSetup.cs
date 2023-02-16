using System;
using UnityEngine;

namespace AnimationEventSystem
{
	// Token: 0x02000E47 RID: 3655
	[Serializable]
	public class LActionSetup
	{
		// Token: 0x04005841 RID: 22593
		public float StartThreshold = 0.9f;

		// Token: 0x04005842 RID: 22594
		public AnimationCurve LayerWeight;

		// Token: 0x04005843 RID: 22595
		[SerializeField]
		private int _stateHash;
	}
}
