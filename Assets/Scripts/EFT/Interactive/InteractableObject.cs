using System;
using EFT.AssetsManager;
using UnityEngine;

namespace EFT.Interactive
{
	// Token: 0x0200220B RID: 8715
	public abstract class InteractableObject : MonoBehaviour
	{
		// Token: 0x17001BBF RID: 7103
		// (get) Token: 0x0600C399 RID: 50073 RVA: 0x0034017F File Offset: 0x0033E37F
		public Vector3 WorldInteractionDirection
		{
			get
			{
				return -base.transform.TransformDirection(this.InteractionDirection);
			}
		}

		// Token: 0x0600C39C RID: 50076 RVA: 0x003401C4 File Offset: 0x0033E3C4
		public virtual void OnDrawGizmosSelected()
		{
			if (this.InteractionDirection.sqrMagnitude > 0f)
			{
				Vector3 worldInteractionDirection = this.WorldInteractionDirection;
				Debug.DrawLine(base.transform.position - worldInteractionDirection, base.transform.position, Color.magenta, Time.deltaTime);
			}
		}

		// Token: 0x0400AC9F RID: 44191
		public ESpecificInteractionContext specificInteractionContext;

		// Token: 0x0400ACA0 RID: 44192
		private float float_0;

		// Token: 0x0400ACA1 RID: 44193
		public float InteractionDot;

		// Token: 0x0400ACA2 RID: 44194
		public Vector3 InteractionDirection;
	}
}