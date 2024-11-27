using System;
using UnityEngine;

namespace EFT
{
	// Token: 0x020015C0 RID: 5568
	public abstract class BaseMovementState
	{

		// Token: 0x04007E8E RID: 32398
		public EStateType Type;

		// Token: 0x04007E8F RID: 32399
		public EPlayerState Name;

		// Token: 0x04007E90 RID: 32400
		public string AnimatorStateName;

		// Token: 0x04007E91 RID: 32401
		public int AnimatorStateHash;

		// Token: 0x04007E92 RID: 32402
		public float AnimationAuthority;

		// Token: 0x04007E93 RID: 32403
		public float AuthoritySpeed = 4f;

		// Token: 0x04007E94 RID: 32404
		public float StateLength;

		// Token: 0x04007E95 RID: 32405
		public float StateSensitivity = 1f;

		// Token: 0x04007E96 RID: 32406
		public EMovementDirection AdditionalDirectionInfo;

		// Token: 0x04007E97 RID: 32407
		public AnimationCurve SmoothLerpAnimCurve;

		// Token: 0x04007E98 RID: 32408
		public float RotationSpeedClamp = 99f;
	}
}
