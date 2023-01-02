using System;

namespace EFT
{
	// Token: 0x02000FC4 RID: 4036
	[Flags]
	public enum EDamageType
	{
		// Token: 0x04005DB7 RID: 23991
		Undefined = 1,
		// Token: 0x04005DB8 RID: 23992
		Fall = 2,
		// Token: 0x04005DB9 RID: 23993
		Explosion = 4,
		// Token: 0x04005DBA RID: 23994
		Barbed = 8,
		// Token: 0x04005DBB RID: 23995
		Flame = 16,
		// Token: 0x04005DBC RID: 23996
		GrenadeFragment = 32,
		// Token: 0x04005DBD RID: 23997
		Impact = 64,
		// Token: 0x04005DBE RID: 23998
		Existence = 128,
		// Token: 0x04005DBF RID: 23999
		Medicine = 256,
		// Token: 0x04005DC0 RID: 24000
		Bullet = 512,
		// Token: 0x04005DC1 RID: 24001
		Melee = 1024,
		// Token: 0x04005DC2 RID: 24002
		Landmine = 2048,
		// Token: 0x04005DC3 RID: 24003
		Sniper = 4096,
		// Token: 0x04005DC4 RID: 24004
		Blunt = 8192,
		// Token: 0x04005DC5 RID: 24005
		LightBleeding = 16384,
		// Token: 0x04005DC6 RID: 24006
		HeavyBleeding = 32768,
		// Token: 0x04005DC7 RID: 24007
		Dehydration = 65536,
		// Token: 0x04005DC8 RID: 24008
		Exhaustion = 131072,
		// Token: 0x04005DC9 RID: 24009
		RadExposure = 262144,
		// Token: 0x04005DCA RID: 24010
		Stimulator = 524288,
		// Token: 0x04005DCB RID: 24011
		Poison = 1048576
	}
}
