using System;
using AnimationEventSystem;
using UnityEngine;

// Token: 0x02000818 RID: 2072
public class LActionState : StateMachineBehaviour
{
	// Token: 0x170007B4 RID: 1972
	// (get) Token: 0x0600351D RID: 13597 RVA: 0x000EEA2E File Offset: 0x000ECC2E
	public LActionSetup Setup
	{
		get
		{
			return this.StaticData.GetLActionSetupById(this.LActionSetupId);
		}
	}
	// Token: 0x0400304C RID: 12364
	public AnimatorControllerStaticData StaticData;

	// Token: 0x0400304D RID: 12365
	public int LActionSetupId = -1;
}
