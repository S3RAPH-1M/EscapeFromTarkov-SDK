using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace AnimationEventSystem
{
	// Token: 0x02000E48 RID: 3656
	[CreateAssetMenu]
	public class AnimatorControllerStaticData : ScriptableObject
	{
		// Token: 0x04005844 RID: 22596
		[SerializeField]
		private List<EventsCollection> _stateHashToEventsCollection;

        // Token: 0x04005845 RID: 22597
        [SerializeField]
		private List<LActionSetup> _stateHashToLActionSetups;


#if UNITY_EDITOR
        private void OnValidate()
        {
            foreach (var eventCollection in _stateHashToEventsCollection)
            {
                eventCollection.OnValidate();
            }
        }
#endif
	}
}
