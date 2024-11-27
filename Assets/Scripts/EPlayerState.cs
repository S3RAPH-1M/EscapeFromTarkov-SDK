using System;

// Token: 0x020006EB RID: 1771
public enum EPlayerState : byte
{
	// Token: 0x040027A0 RID: 10144
	None,
	// Token: 0x040027A1 RID: 10145
	Idle,
	// Token: 0x040027A2 RID: 10146
	ProneIdle,
	// Token: 0x040027A3 RID: 10147
	ProneMove,
	// Token: 0x040027A4 RID: 10148
	Run,
	// Token: 0x040027A5 RID: 10149
	Sprint,
	// Token: 0x040027A6 RID: 10150
	Jump,
	// Token: 0x040027A7 RID: 10151
	FallDown,
	// Token: 0x040027A8 RID: 10152
	Transition,
	// Token: 0x040027A9 RID: 10153
	BreachDoor,
	// Token: 0x040027AA RID: 10154
	Loot,
	// Token: 0x040027AB RID: 10155
	Pickup,
	// Token: 0x040027AC RID: 10156
	Open,
	// Token: 0x040027AD RID: 10157
	Close,
	// Token: 0x040027AE RID: 10158
	Unlock,
	// Token: 0x040027AF RID: 10159
	Sidestep,
	// Token: 0x040027B0 RID: 10160
	DoorInteraction,
	// Token: 0x040027B1 RID: 10161
	Approach,
	// Token: 0x040027B2 RID: 10162
	Prone2Stand,
	// Token: 0x040027B3 RID: 10163
	Transit2Prone,
	// Token: 0x040027B4 RID: 10164
	Plant,
	// Token: 0x040027B5 RID: 10165
	Stationary,
	// Token: 0x040027B6 RID: 10166
	Roll,
	// Token: 0x040027B7 RID: 10167
	JumpLanding,
	// Token: 0x040027B8 RID: 10168
	ClimbOver,
	// Token: 0x040027B9 RID: 10169
	ClimbUp,
	// Token: 0x040027BA RID: 10170
	VaultingFallDown,
	// Token: 0x040027BB RID: 10171
	VaultingLanding,
	// Token: 0x040027BC RID: 10172
	BlindFire
}
