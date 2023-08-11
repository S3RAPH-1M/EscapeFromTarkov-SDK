using System;
using System.Collections.Generic;

namespace AnimationEventSystem
{
	// Token: 0x02000EFA RID: 3834
	public class AnimationEventsSequenceData
	{

		// Token: 0x04005BE7 RID: 23527
		private const int MAX_QUEUE_SIZE = 15;

		// Token: 0x04005BE8 RID: 23528
		public readonly Queue<AnimationEventsSequenceData.GStruct108> AnimationEventsDebugQueue = new Queue<AnimationEventsSequenceData.GStruct108>(15);

		// Token: 0x02000EFB RID: 3835
		public readonly struct GStruct108
		{
			// Token: 0x06005D94 RID: 23956 RVA: 0x001C7BF9 File Offset: 0x001C5DF9
			public GStruct108(string eventName, int stateHash, bool condsPassed)
			{
				this.EventName = eventName;
				this.StateNameShortHash = stateHash;
				this.ConditionPassed = condsPassed;
			}

			// Token: 0x04005BE9 RID: 23529
			public readonly string EventName;

			// Token: 0x04005BEA RID: 23530
			public readonly int StateNameShortHash;

			// Token: 0x04005BEB RID: 23531
			public readonly bool ConditionPassed;
		}
	}
}
