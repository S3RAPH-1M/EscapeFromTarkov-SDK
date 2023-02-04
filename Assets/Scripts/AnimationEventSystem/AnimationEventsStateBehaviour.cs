using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace AnimationEventSystem
{
	// Token: 0x02000E45 RID: 3653
	public class AnimationEventsStateBehaviour : StateMachineBehaviour
	{
		public AnimationEventsContainer EventsContainer;

		// Token: 0x04005838 RID: 22584
		public string FullName;

		// Token: 0x04005839 RID: 22585
		public int FullNameHash;

		// Token: 0x0400583A RID: 22586
		public AnimatorControllerStaticData EventsData;

		// Token: 0x0400583B RID: 22587
		public int EventsListId = -1;
	}
}
