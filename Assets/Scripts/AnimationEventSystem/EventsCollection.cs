using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationEventSystem
{
	// Token: 0x02000E46 RID: 3654
	[Serializable]
	public class EventsCollection
	{
		
		// Token: 0x04005840 RID: 22592
		[SerializeField]
		private List<AnimationEvent> _animationEvents;

#if UNITY_EDITOR
        public void OnValidate()
        {
            foreach (var animationEvent in _animationEvents)
            {
                animationEvent.UpdateHash();
            }
        }
#endif
    }
}
