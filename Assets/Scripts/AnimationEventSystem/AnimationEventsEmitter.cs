using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationEventSystem
{
	// Token: 0x02000EF6 RID: 3830
	public class AnimationEventsEmitter
	{
		// Token: 0x140000E1 RID: 225
		// (add) Token: 0x06005D80 RID: 23936 RVA: 0x001C7634 File Offset: 0x001C5834
		// (remove) Token: 0x06005D81 RID: 23937 RVA: 0x001C766C File Offset: 0x001C586C
		public event Action<int, AnimationEventParameter> OnEventAction;

		// Token: 0x17000C36 RID: 3126
		// (get) Token: 0x06005D82 RID: 23938 RVA: 0x001C76A1 File Offset: 0x001C58A1
		public AnimationEventsSequenceData EventsSequenceData
		{
			get
			{
				return this._eventsSequenceData;
			}
		}


		// Token: 0x04005BD9 RID: 23513
		private AnimationEventsEmitter.EEmitType _emitType;	

		// Token: 0x04005BDC RID: 23516
		private AnimationEventsSequenceData _eventsSequenceData = new AnimationEventsSequenceData();


		// Token: 0x02000EF8 RID: 3832
		public enum EEmitType
		{
			// Token: 0x04005BE1 RID: 23521
			EmitOnAnimatorUpdate,
			// Token: 0x04005BE2 RID: 23522
			EmitOnDemand
		}

	}
}
