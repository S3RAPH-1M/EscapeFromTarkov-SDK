using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationEventSystem
{
	// Token: 0x02000E39 RID: 3641
	[Serializable]
	public class AnimationEventsContainer 
	{
		public enum EUpdateType
		{
			// Token: 0x0400581E RID: 22558
			OnEnter,
			// Token: 0x0400581F RID: 22559
			OnUpdate,
			// Token: 0x04005820 RID: 22560
			OnExit
		}
	}
}
