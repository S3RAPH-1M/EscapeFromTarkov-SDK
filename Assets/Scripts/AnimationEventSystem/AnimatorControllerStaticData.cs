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
		// Token: 0x0600575A RID: 22362 RVA: 0x001B1601 File Offset: 0x001AF801
		[CanBeNull]
		public List<AnimationEvent> GetEventsByIndex(int index)
		{
			if (this.IsValidListIndex(index))
			{
				return this._stateHashToEventsCollection[index].AnimationEvents;
			}
			Debug.LogErrorFormat("Invalid index for {0}", new object[]
			{
				index
			});
			return null;
		}

		// Token: 0x0600575B RID: 22363 RVA: 0x001B1638 File Offset: 0x001AF838
		public LActionSetup GetLActionSetupById(int lActionSetupId)
		{
			return this._stateHashToLActionSetups[lActionSetupId];
		}

		// Token: 0x0600575C RID: 22364 RVA: 0x001B1646 File Offset: 0x001AF846
		public bool IsValidListIndex(int index)
		{
			return index >= 0 && index < this._stateHashToEventsCollection.Count;
		}

		// Token: 0x04005844 RID: 22596
		[SerializeField]
		private List<EventsCollection> _stateHashToEventsCollection;

		// Token: 0x04005845 RID: 22597
		[SerializeField]
		private List<LActionSetup> _stateHashToLActionSetups;
	}
}
