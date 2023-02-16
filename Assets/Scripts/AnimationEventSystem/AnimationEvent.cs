using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace AnimationEventSystem
{
	// Token: 0x02000E35 RID: 3637
	[Serializable]
	public class AnimationEvent
	{
		// Token: 0x04005802 RID: 22530
		public const float MAX_EVENT_TIME = 1f;

		// Token: 0x04005803 RID: 22531
		public AnimationEventParameter Parameter;

		// Token: 0x04005804 RID: 22532
		[SerializeField]
		private string _functionName;

		// Token: 0x04005805 RID: 22533
		[SerializeField]
		private int _functionNameHash;

		// Token: 0x04005806 RID: 22534
		public bool Enabled = true;

		// Token: 0x04005807 RID: 22535
		[SerializeField]
		private float _time;

		// Token: 0x04005808 RID: 22536
		public List<EventCondition> EventConditions;
	}
}
