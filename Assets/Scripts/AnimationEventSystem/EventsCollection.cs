using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationEventSystem
{
	// Token: 0x02000E46 RID: 3654
	[Serializable]
	public class EventsCollection
	{
		// Token: 0x06005754 RID: 22356 RVA: 0x001B153C File Offset: 0x001AF73C
		public EventsCollection(IEnumerable<AnimationEvent> animationEvents)
		{
			this._animationEvents = new List<AnimationEvent>(animationEvents);
		}

		// Token: 0x17000B49 RID: 2889
		// (get) Token: 0x06005755 RID: 22357 RVA: 0x001B1550 File Offset: 0x001AF750
		public List<AnimationEvent> AnimationEvents
		{
			get
			{
				return this._animationEvents;
			}
		}

		// Token: 0x06005756 RID: 22358 RVA: 0x001B1558 File Offset: 0x001AF758
		private static void smethod_0(EventsCollection eventsCollection)
		{
			float max = 0.9899901f;
			List<AnimationEvent> animationEvents = eventsCollection._animationEvents;
			for (int i = 0; i < animationEvents.Count; i++)
			{
				AnimationEvent animationEvent = animationEvents[i];
				float num = Mathf.Clamp(animationEvent.Time, 0f, max);
				if (Math.Abs(num - animationEvent.Time) >= 1E-45f)
				{
					animationEvent.Time = num;
				}
			}
		}

		// Token: 0x04005840 RID: 22592
		[SerializeField]
		private List<AnimationEvent> _animationEvents;
	}
}
