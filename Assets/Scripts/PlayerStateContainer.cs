using System;
using System.Runtime.CompilerServices;
using EFT;
using UnityEngine;

public class PlayerStateContainer : StateMachineBehaviour
{
	// Token: 0x0400295D RID: 10589
	public bool IsDefaultState;

	// Token: 0x0400295E RID: 10590
	public EPlayerState Name;

	// Token: 0x0400295F RID: 10591
	public EStateType Type;

	// Token: 0x04002960 RID: 10592
	public EMovementDirection AdditionalDirectionInfo;

	// Token: 0x04002961 RID: 10593
	public float RotationSpeedClamp = 99f;

	// Token: 0x04002962 RID: 10594
	public float StateSensitivity = 1f;

	// Token: 0x04002963 RID: 10595
	public bool CanInteract;

	// Token: 0x04002964 RID: 10596
	public bool DisableRootMotion;

	// Token: 0x04002965 RID: 10597
	public bool CreateUniqueMovementStateObject;

	// Token: 0x04002966 RID: 10598
	public float AnimationAuthority;

	// Token: 0x04002967 RID: 10599
	public float AuthoritySpeed = 4f;

	// Token: 0x04002968 RID: 10600
	public AnimationCurve SmoothLerpAnimCurve;

	// Token: 0x04002969 RID: 10601
	[HideInInspector]
	public string StateFullName;

	// Token: 0x0400296A RID: 10602
	[HideInInspector]
	public int StateFullNameHash;

	// Token: 0x0400296B RID: 10603
	[HideInInspector]
	public float StateLength;

	// Token: 0x0400296C RID: 10604
	public AnimatorPose FirstPersonPose;
}
