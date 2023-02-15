using System;
using UnityEngine;

namespace AnimationEventSystem
{
	// Token: 0x02000E47 RID: 3655
	[Serializable]
	public class LActionSetup
	{
		// Token: 0x06005757 RID: 22359 RVA: 0x001B15BB File Offset: 0x001AF7BB
		public LActionSetup(AnimationCurve animationCurve, float startThreshold)
		{
			this.LayerWeight = ((animationCurve == null) ? new AnimationCurve() : new AnimationCurve(animationCurve.keys));
			this.StartThreshold = startThreshold;
		}

		// Token: 0x17000B4A RID: 2890
		// (get) Token: 0x06005758 RID: 22360 RVA: 0x001B15F0 File Offset: 0x001AF7F0
		// (set) Token: 0x06005759 RID: 22361 RVA: 0x001B15F8 File Offset: 0x001AF7F8
		public int StateHash
		{
			get
			{
				return this._stateHash;
			}
			set
			{
				this._stateHash = value;
			}
		}

		// Token: 0x04005841 RID: 22593
		public float StartThreshold = 0.9f;

		// Token: 0x04005842 RID: 22594
		public AnimationCurve LayerWeight;

		// Token: 0x04005843 RID: 22595
		[SerializeField]
		private int _stateHash;
	}
}
