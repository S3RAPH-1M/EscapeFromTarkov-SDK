using System;
using UnityEngine;

// Token: 0x0200062C RID: 1580
public static class WeaponAnimationSpeedControllerClass
{
	// Token: 0x06002964 RID: 10596 RVA: 0x000BF364 File Offset: 0x000BD564
	public static string ParameterHashToName(int hash)
	{
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_ACTIVE)
		{
			return "Active";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_ADDAMMOINCHAMBER)
		{
			return "AddAmmoInChamber";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_ADDAMMOINMAG)
		{
			return "AddAmmoInMag";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_ALTFIRE)
		{
			return "AltFire";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_ARM)
		{
			return "Arm";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_ARMED)
		{
			return "Armed";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_BOLTACTIONRELOAD)
		{
			return "BoltActionReload";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_BOLTCATCH)
		{
			return "BoltCatch";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_CANRELOAD)
		{
			return "CanReload";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_DELAMMOCHAMBER)
		{
			return "DelAmmoChamber";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_DELAMMOFROMMAG)
		{
			return "DelAmmoFromMag";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_DISARM)
		{
			return "Disarm";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_DISCHARGE)
		{
			return "Discharge";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_FASTHIDE)
		{
			return "FastHide";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_FIRE)
		{
			return "Fire";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_GRIP)
		{
			return "Grip";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_HVAT)
		{
			return "Hvat";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_IDLE)
		{
			return "Idle";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_INCOMPATIBLEAMMO)
		{
			return "IncompatibleAmmo";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_INVENTORY)
		{
			return "Inventory";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_ISEXTERNALMAG)
		{
			return "IsExternalMag";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_LAUNCHERREADY)
		{
			return "LauncherReady";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_LOADONE)
		{
			return "LoadOne";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_MAGFULL)
		{
			return "MagFull";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_MAGIN)
		{
			return "MagIn";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_MAGINWEAPON)
		{
			return "MagInWeapon";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_MAGOUT)
		{
			return "MagOut";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_MAGSWAP)
		{
			return "MagSwap";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_MODSET)
		{
			return "ModSet";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_OFFBOLTCATCH)
		{
			return "OffBoltCatch";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_ONBOLTCATCH)
		{
			return "OnBoltCatch";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_PATROL)
		{
			return "Patrol";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_QUICKFIRE)
		{
			return "QuickFire";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_SETFIREMODE0)
		{
			return "SetFiremode0";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_SETFIREMODE1)
		{
			return "SetFiremode1";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_SHELLEJECT)
		{
			return "ShellEject";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_STOCKFOLDED)
		{
			return "StockFolded";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_USELEFTHAND)
		{
			return "UseLeftHand";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_RECHAMBER)
		{
			return "Rechamber";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_MALFUNCTIONREPAIR)
		{
			return "MalfunctionRepair";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_MISFIRESLIDE_UNKNOWN)
		{
			return "MisfireSlideUnknown";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_ROLLCYLINDER)
		{
			return "RollCylinder";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_MASTERINGRELOADABORTED)
		{
			return "MasteringReloadAborted";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_DOUBLEACTION)
		{
			return "DoubleActionFireModeFloat";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_AIM_ANGLE)
		{
			return "Aim_angle";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_AMMOINCHAMBER)
		{
			return "AmmoInChamber";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_AMMOINMAG)
		{
			return "AmmoInMag";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_AMMOCOUNTFORREMOVE)
		{
			return "AmmoCountForRemove";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_CHARACTERID)
		{
			return "CharacterID";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_DEFLECTED)
		{
			return "Deflected";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_EMPTYLINKSCOUNT)
		{
			return "EmptyLinksCount";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_FIREMODE)
		{
			return "FireMode";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_GESTUREINDEX)
		{
			return "GestureIndex";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_GRIPWEIGHT)
		{
			return "GripWeight";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_IDLEPOSITION)
		{
			return "IdlePosition";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_IDLEVAR)
		{
			return "IdleVar";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_LAUNCHERID)
		{
			return "LauncherID";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_LEFTHANDPROGRESS)
		{
			return "LeftHandProgress";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_RADIOCOMMAND)
		{
			return "RadioCommand";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_RELTYPENEW)
		{
			return "RelTypeNew";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_RELTYPEOLD)
		{
			return "RelTypeOld";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_SHELLSINWEAPON)
		{
			return "ShellsInWeapon";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_SHOULDERREACH)
		{
			return "ShoulderReach";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_SPEEDDRAW)
		{
			return "SpeedDraw";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_SPEEDFIX)
		{
			return "SpeedFix";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_SPEEDRELOAD)
		{
			return "SpeedReload";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_STOCKANIMATIONINDEX)
		{
			return "StockAnimationIndex";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_SWINGSPEED)
		{
			return "SwingSpeed";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_THIRDPERSON)
		{
			return "ThirdPerson";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_UNDERMOD)
		{
			return "UnderMod";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_USETIMEMULTIPLIER)
		{
			return "UseTimeMultiplier";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_WEAPONLEVEL)
		{
			return "WeaponLevel";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_CAMORAINDEX)
		{
			return "CamoraIndex";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_CAMORAINDEXFORLOADAMMO)
		{
			return "CamoraIndexForLoadAmmo";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_CAMORAINDEXWITHSHELLFORREMOVE)
		{
			return "CamoraIndexWithShellForRemove";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_CAMORAINDEXFORUNLOADAMMO)
		{
			return "CamoraIndexForRemoveAmmo";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_CAMORAFIREINDEX)
		{
			return "CamoraFireIndex";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_CHAMBERINDEX)
		{
			return "ChamberIndex";
		}
		if (hash == WeaponAnimationSpeedControllerClass.FLOAT_CHAMBERINDEX_WITH_SHELL)
		{
			return "ChamberIndexWithShell";
		}
		if (hash == WeaponAnimationSpeedControllerClass.INT_ANIMATIONVARIANT)
		{
			return "AnimationVariant";
		}
		if (hash == WeaponAnimationSpeedControllerClass.INT_FIREVAR)
		{
			return "FireVar";
		}
		if (hash == WeaponAnimationSpeedControllerClass.INT_GRENADEALTFIRE)
		{
			return "GrenadeAltFire";
		}
		if (hash == WeaponAnimationSpeedControllerClass.INT_GRENADEFIRE)
		{
			return "GrenadeFire";
		}
		if (hash == WeaponAnimationSpeedControllerClass.INT_LACTIONINDEX)
		{
			return "LActionIndex";
		}
		if (hash == WeaponAnimationSpeedControllerClass.INT_PLAYERSTATE)
		{
			return "PlayerState";
		}
		if (hash == WeaponAnimationSpeedControllerClass.INT_THIRDACTION)
		{
			return "ThirdAction";
		}
		if (hash == WeaponAnimationSpeedControllerClass.INT_MALFUNCTION)
		{
			return "Malfunction";
		}
		if (hash == WeaponAnimationSpeedControllerClass.INT_MALFTYPE)
		{
			return "MalfType";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_BUTTERFINGERS)
		{
			return "Butterfingers";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_CHECKAMMO)
		{
			return "CheckAmmo";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_CHECKCHAMBER)
		{
			return "CheckChamber";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_FIREMODECHECK)
		{
			return "FiremodeCheck";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_FIREMODESWITCH)
		{
			return "FiremodeSwitch";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_HAMMERARMED)
		{
			return "HammerArmed";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_FIRINGBULLET)
		{
			return "FiringBullet";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_GESTURE)
		{
			return "Gesture";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_GOMELE)
		{
			return "GoMele";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_HANDREADY)
		{
			return "HandReady";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_IDLETIME)
		{
			return "IdleTime";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_LOOK)
		{
			return "Look";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_MAGINFROMINV)
		{
			return "MagInFromInv";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_MAGOUTFROMINV)
		{
			return "MagOutFromInv";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_MAGSWAPEND)
		{
			return "MagSwapEnd";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_MODSWITCH)
		{
			return "ModSwitch";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_RADIO)
		{
			return "Radio";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_RELOAD)
		{
			return "Reload";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_RELOADFAST)
		{
			return "ReloadFast";
		}
		if (hash == WeaponAnimationSpeedControllerClass.TRIGGER_STOCKSWITCH)
		{
			return "StockSwitch";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_FIREMODE_SPRINT)
		{
			return "FiremodeSprint";
		}
		if (hash == WeaponAnimationSpeedControllerClass.BOOL_SPRINT)
		{
			return "Sprint";
		}
		return "undefined";
	}

	// Token: 0x04002389 RID: 9097
	public static readonly int BOOL_ACTIVE = Animator.StringToHash("Active");

	// Token: 0x0400238A RID: 9098
	public static readonly int BOOL_ADDAMMOINCHAMBER = Animator.StringToHash("AddAmmoInChamber");

	// Token: 0x0400238B RID: 9099
	public static readonly int BOOL_ADDAMMOINMAG = Animator.StringToHash("AddAmmoInMag");

	// Token: 0x0400238C RID: 9100
	public static readonly int BOOL_ALTFIRE = Animator.StringToHash("AltFire");

	// Token: 0x0400238D RID: 9101
	public static readonly int BOOL_ARM = Animator.StringToHash("Arm");

	// Token: 0x0400238E RID: 9102
	public static readonly int BOOL_ARMED = Animator.StringToHash("Armed");

	// Token: 0x0400238F RID: 9103
	public static readonly int BOOL_BOLTACTIONRELOAD = Animator.StringToHash("BoltActionReload");

	// Token: 0x04002390 RID: 9104
	public static readonly int BOOL_BOLTCATCH = Animator.StringToHash("BoltCatch");

	// Token: 0x04002391 RID: 9105
	public static readonly int BOOL_CANRELOAD = Animator.StringToHash("CanReload");

	// Token: 0x04002392 RID: 9106
	public static readonly int BOOL_DELAMMOCHAMBER = Animator.StringToHash("DelAmmoChamber");

	// Token: 0x04002393 RID: 9107
	public static readonly int BOOL_DELAMMOFROMMAG = Animator.StringToHash("DelAmmoFromMag");

	// Token: 0x04002394 RID: 9108
	public static readonly int BOOL_DISARM = Animator.StringToHash("Disarm");

	// Token: 0x04002395 RID: 9109
	public static readonly int BOOL_DISCHARGE = Animator.StringToHash("Discharge");

	// Token: 0x04002396 RID: 9110
	public static readonly int BOOL_FASTHIDE = Animator.StringToHash("FastHide");

	// Token: 0x04002397 RID: 9111
	public static readonly int BOOL_FIRE = Animator.StringToHash("Fire");

	// Token: 0x04002398 RID: 9112
	public static readonly int BOOL_SPRINT = Animator.StringToHash("Sprint");

	// Token: 0x04002399 RID: 9113
	public static readonly int BOOL_GRIP = Animator.StringToHash("Grip");

	// Token: 0x0400239A RID: 9114
	public static readonly int BOOL_HVAT = Animator.StringToHash("Hvat");

	// Token: 0x0400239B RID: 9115
	public static readonly int BOOL_IDLE = Animator.StringToHash("Idle");

	// Token: 0x0400239C RID: 9116
	public static readonly int BOOL_INCOMPATIBLEAMMO = Animator.StringToHash("IncompatibleAmmo");

	// Token: 0x0400239D RID: 9117
	public static readonly int BOOL_INVENTORY = Animator.StringToHash("Inventory");

	// Token: 0x0400239E RID: 9118
	public static readonly int BOOL_ISEXTERNALMAG = Animator.StringToHash("IsExternalMag");

	// Token: 0x0400239F RID: 9119
	public static readonly int BOOL_LAUNCHERREADY = Animator.StringToHash("LauncherReady");

	// Token: 0x040023A0 RID: 9120
	public static readonly int BOOL_LOADONE = Animator.StringToHash("LoadOne");

	// Token: 0x040023A1 RID: 9121
	public static readonly int BOOL_MAGFULL = Animator.StringToHash("MagFull");

	// Token: 0x040023A2 RID: 9122
	public static readonly int BOOL_MAGIN = Animator.StringToHash("MagIn");

	// Token: 0x040023A3 RID: 9123
	public static readonly int BOOL_MAGINWEAPON = Animator.StringToHash("MagInWeapon");

	// Token: 0x040023A4 RID: 9124
	public static readonly int FLOAT_MAGINWEAPONFLOAT = Animator.StringToHash("MagInWeaponFloat");

	// Token: 0x040023A5 RID: 9125
	public static readonly int BOOL_MAGOUT = Animator.StringToHash("MagOut");

	// Token: 0x040023A6 RID: 9126
	public static readonly int BOOL_MAGSWAP = Animator.StringToHash("MagSwap");

	// Token: 0x040023A7 RID: 9127
	public static readonly int BOOL_MODSET = Animator.StringToHash("ModSet");

	// Token: 0x040023A8 RID: 9128
	public static readonly int BOOL_OFFBOLTCATCH = Animator.StringToHash("OffBoltCatch");

	// Token: 0x040023A9 RID: 9129
	public static readonly int BOOL_ONBOLTCATCH = Animator.StringToHash("OnBoltCatch");

	// Token: 0x040023AA RID: 9130
	public static readonly int BOOL_PATROL = Animator.StringToHash("Patrol");

	// Token: 0x040023AB RID: 9131
	public static readonly int BOOL_QUICKFIRE = Animator.StringToHash("QuickFire");

	// Token: 0x040023AC RID: 9132
	public static readonly int BOOL_SETFIREMODE0 = Animator.StringToHash("SetFiremode0");

	// Token: 0x040023AD RID: 9133
	public static readonly int BOOL_SETFIREMODE1 = Animator.StringToHash("SetFiremode1");

	// Token: 0x040023AE RID: 9134
	public static readonly int BOOL_SHELLEJECT = Animator.StringToHash("ShellEject");

	// Token: 0x040023AF RID: 9135
	public static readonly int BOOL_STOCKFOLDED = Animator.StringToHash("StockFolded");

	// Token: 0x040023B0 RID: 9136
	public static readonly int BOOL_USELEFTHAND = Animator.StringToHash("UseLeftHand");

	// Token: 0x040023B1 RID: 9137
	public static readonly int BOOL_RECHAMBER = Animator.StringToHash("Rechamber");

	// Token: 0x040023B2 RID: 9138
	public static readonly int BOOL_MALFUNCTIONREPAIR = Animator.StringToHash("MalfunctionRepair");

	// Token: 0x040023B3 RID: 9139
	public static readonly int BOOL_MISFIRESLIDE_UNKNOWN = Animator.StringToHash("MisfireSlideUnknown");

	// Token: 0x040023B4 RID: 9140
	public static readonly int BOOL_ROLLCYLINDER = Animator.StringToHash("RollCylinder");

	// Token: 0x040023B5 RID: 9141
	public static readonly int BOOL_ROLLTOZEROCAMORA = Animator.StringToHash("RollToZeroCamora");

	// Token: 0x040023B6 RID: 9142
	public static readonly int BOOL_MASTERINGRELOADABORTED = Animator.StringToHash("MasteringReloadAborted");

	// Token: 0x040023B7 RID: 9143
	public static readonly int BOOL_FIREMODE_SPRINT = Animator.StringToHash("FiremodeSprint");

	// Token: 0x040023B8 RID: 9144
	public static readonly int FLOAT_DOUBLEACTION = Animator.StringToHash("DoubleActionFireModeFloat");

	// Token: 0x040023B9 RID: 9145
	public static readonly int FLOAT_AIM_ANGLE = Animator.StringToHash("Aim_angle");

	// Token: 0x040023BA RID: 9146
	public static readonly int FLOAT_AMMOINCHAMBER = Animator.StringToHash("AmmoInChamber");

	// Token: 0x040023BB RID: 9147
	public static readonly int FLOAT_AMMOINMAG = Animator.StringToHash("AmmoInMag");

	// Token: 0x040023BC RID: 9148
	public static readonly int FLOAT_AMMOCOUNTFORREMOVE = Animator.StringToHash("AmmoCountForRemove");

	// Token: 0x040023BD RID: 9149
	public static readonly int FLOAT_CHARACTERID = Animator.StringToHash("CharacterID");

	// Token: 0x040023BE RID: 9150
	public static readonly int FLOAT_DEFLECTED = Animator.StringToHash("Deflected");

	// Token: 0x040023BF RID: 9151
	public static readonly int FLOAT_EMPTYLINKSCOUNT = Animator.StringToHash("EmptyLinksCount");

	// Token: 0x040023C0 RID: 9152
	public static readonly int FLOAT_FIREMODE = Animator.StringToHash("FireMode");

	// Token: 0x040023C1 RID: 9153
	public static readonly int FLOAT_GESTUREINDEX = Animator.StringToHash("GestureIndex");

	// Token: 0x040023C2 RID: 9154
	public static readonly int FLOAT_GRIPWEIGHT = Animator.StringToHash("GripWeight");

	// Token: 0x040023C3 RID: 9155
	public static readonly int FLOAT_IDLEPOSITION = Animator.StringToHash("IdlePosition");

	// Token: 0x040023C4 RID: 9156
	public static readonly int FLOAT_IDLEVAR = Animator.StringToHash("IdleVar");

	// Token: 0x040023C5 RID: 9157
	public static readonly int FLOAT_LAUNCHERID = Animator.StringToHash("LauncherID");

	// Token: 0x040023C6 RID: 9158
	public static readonly int FLOAT_LEFTHANDPROGRESS = Animator.StringToHash("LeftHandProgress");

	// Token: 0x040023C7 RID: 9159
	public static readonly int FLOAT_RADIOCOMMAND = Animator.StringToHash("RadioCommand");

	// Token: 0x040023C8 RID: 9160
	public static readonly int FLOAT_RELTYPENEW = Animator.StringToHash("RelTypeNew");

	// Token: 0x040023C9 RID: 9161
	public static readonly int FLOAT_RELTYPEOLD = Animator.StringToHash("RelTypeOld");

	// Token: 0x040023CA RID: 9162
	public static readonly int FLOAT_SHELLSINWEAPON = Animator.StringToHash("ShellsInWeapon");

	// Token: 0x040023CB RID: 9163
	public static readonly int FLOAT_SHOULDERREACH = Animator.StringToHash("ShoulderReach");

	// Token: 0x040023CC RID: 9164
	public static readonly int FLOAT_SPEEDDRAW = Animator.StringToHash("SpeedDraw");

	// Token: 0x040023CD RID: 9165
	public static readonly int FLOAT_SPEEDFIX = Animator.StringToHash("SpeedFix");

	// Token: 0x040023CE RID: 9166
	public static readonly int FLOAT_SPEEDRELOAD = Animator.StringToHash("SpeedReload");

	// Token: 0x040023CF RID: 9167
	public static readonly int FLOAT_STOCKANIMATIONINDEX = Animator.StringToHash("StockAnimationIndex");

	// Token: 0x040023D0 RID: 9168
	public static readonly int FLOAT_SWINGSPEED = Animator.StringToHash("SwingSpeed");

	// Token: 0x040023D1 RID: 9169
	public static readonly int FLOAT_THIRDPERSON = Animator.StringToHash("ThirdPerson");

	// Token: 0x040023D2 RID: 9170
	public static readonly int FLOAT_UNDERMOD = Animator.StringToHash("UnderMod");

	// Token: 0x040023D3 RID: 9171
	public static readonly int FLOAT_USETIMEMULTIPLIER = Animator.StringToHash("UseTimeMultiplier");

	// Token: 0x040023D4 RID: 9172
	public static readonly int FLOAT_WEAPONLEVEL = Animator.StringToHash("WeaponLevel");

	// Token: 0x040023D5 RID: 9173
	public static readonly int FLOAT_CHAMBERINDEX = Animator.StringToHash("ChamberIndex");

	// Token: 0x040023D6 RID: 9174
	public static readonly int FLOAT_CHAMBERINDEX_WITH_SHELL = Animator.StringToHash("ChamberIndexWithShell");

	// Token: 0x040023D7 RID: 9175
	public static readonly int FLOAT_CAMORAINDEX = Animator.StringToHash("CamoraIndex");

	// Token: 0x040023D8 RID: 9176
	public static readonly int FLOAT_CAMORAINDEXFORLOADAMMO = Animator.StringToHash("CamoraIndexForLoadAmmo");

	// Token: 0x040023D9 RID: 9177
	public static readonly int FLOAT_CAMORAINDEXWITHSHELLFORREMOVE = Animator.StringToHash("CamoraIndexWithShellForRemove");

	// Token: 0x040023DA RID: 9178
	public static readonly int FLOAT_CAMORAINDEXFORUNLOADAMMO = Animator.StringToHash("CamoraIndexForRemoveAmmo");

	// Token: 0x040023DB RID: 9179
	public static readonly int FLOAT_CAMORAFIREINDEX = Animator.StringToHash("CamoraFireIndex");

	// Token: 0x040023DC RID: 9180
	public static readonly int FLOAT_SIGHTINGRANGE = Animator.StringToHash("SightingRange");

	// Token: 0x040023DD RID: 9181
	public static readonly int FLOAT_ANIMATION_MOD_ID_FLOAT = Animator.StringToHash("UniqueAnimationModIdFloat");

	// Token: 0x040023DE RID: 9182
	public static readonly int INT_ANIMATIONVARIANT = Animator.StringToHash("AnimationVariant");

	// Token: 0x040023DF RID: 9183
	public static readonly int INT_FIREVAR = Animator.StringToHash("FireVar");

	// Token: 0x040023E0 RID: 9184
	public static readonly int INT_GRENADEALTFIRE = Animator.StringToHash("GrenadeAltFire");

	// Token: 0x040023E1 RID: 9185
	public static readonly int INT_GRENADEFIRE = Animator.StringToHash("GrenadeFire");

	// Token: 0x040023E2 RID: 9186
	public static readonly int INT_LACTIONINDEX = Animator.StringToHash("LActionIndex");

	// Token: 0x040023E3 RID: 9187
	public static readonly int INT_PLAYERSTATE = Animator.StringToHash("PlayerState");

	// Token: 0x040023E4 RID: 9188
	public static readonly int INT_THIRDACTION = Animator.StringToHash("ThirdAction");

	// Token: 0x040023E5 RID: 9189
	public static readonly int INT_MALFUNCTION = Animator.StringToHash("Malfunction");

	// Token: 0x040023E6 RID: 9190
	public static readonly int INT_MALFTYPE = Animator.StringToHash("MalfType");

	// Token: 0x040023E7 RID: 9191
	public static readonly int INT_MOD_ANIMATION_ID = Animator.StringToHash("UniqueAnimationModId");

	// Token: 0x040023E8 RID: 9192
	public static readonly int TRIGGER_BUTTERFINGERS = Animator.StringToHash("Butterfingers");

	// Token: 0x040023E9 RID: 9193
	public static readonly int TRIGGER_CHECKAMMO = Animator.StringToHash("CheckAmmo");

	// Token: 0x040023EA RID: 9194
	public static readonly int TRIGGER_CHECKCHAMBER = Animator.StringToHash("CheckChamber");

	// Token: 0x040023EB RID: 9195
	public static readonly int TRIGGER_FIREMODECHECK = Animator.StringToHash("FiremodeCheck");

	// Token: 0x040023EC RID: 9196
	public static readonly int TRIGGER_FIREMODESWITCH = Animator.StringToHash("FiremodeSwitch");

	// Token: 0x040023ED RID: 9197
	public static readonly int TRIGGER_HAMMERARMED = Animator.StringToHash("HammerArmed");

	// Token: 0x040023EE RID: 9198
	public static readonly int TRIGGER_FIRINGBULLET = Animator.StringToHash("FiringBullet");

	// Token: 0x040023EF RID: 9199
	public static readonly int TRIGGER_GESTURE = Animator.StringToHash("Gesture");

	// Token: 0x040023F0 RID: 9200
	public static readonly int TRIGGER_GOMELE = Animator.StringToHash("GoMele");

	// Token: 0x040023F1 RID: 9201
	public static readonly int TRIGGER_HANDREADY = Animator.StringToHash("HandReady");

	// Token: 0x040023F2 RID: 9202
	public static readonly int TRIGGER_IDLETIME = Animator.StringToHash("IdleTime");

	// Token: 0x040023F3 RID: 9203
	public static readonly int TRIGGER_LOOK = Animator.StringToHash("Look");

	// Token: 0x040023F4 RID: 9204
	public static readonly int TRIGGER_MAGINFROMINV = Animator.StringToHash("MagInFromInv");

	// Token: 0x040023F5 RID: 9205
	public static readonly int TRIGGER_MAGOUTFROMINV = Animator.StringToHash("MagOutFromInv");

	// Token: 0x040023F6 RID: 9206
	public static readonly int TRIGGER_MAGSWAPEND = Animator.StringToHash("MagSwapEnd");

	// Token: 0x040023F7 RID: 9207
	public static readonly int TRIGGER_MODSWITCH = Animator.StringToHash("ModSwitch");

	// Token: 0x040023F8 RID: 9208
	public static readonly int TRIGGER_RADIO = Animator.StringToHash("Radio");

	// Token: 0x040023F9 RID: 9209
	public static readonly int TRIGGER_RELOAD = Animator.StringToHash("Reload");

	// Token: 0x040023FA RID: 9210
	public static readonly int TRIGGER_RELOADFAST = Animator.StringToHash("ReloadFast");

	// Token: 0x040023FB RID: 9211
	public static readonly int TRIGGER_STOCKSWITCH = Animator.StringToHash("StockSwitch");

	// Token: 0x040023FC RID: 9212
	public static readonly int FLOAT_IS_AIMING = Animator.StringToHash("IsAimingFloat");

	// Token: 0x040023FD RID: 9213
	public static readonly int FLOAT_PREV_AIMING_STATE = Animator.StringToHash("PrevIsAimingFloatState");

	// Token: 0x040023FE RID: 9214
	public static readonly int TRIGGER_AIMING_IN = Animator.StringToHash("AimingIn");

	// Token: 0x040023FF RID: 9215
	public static readonly int TRIGGER_AIMING_OUT = Animator.StringToHash("AimingOut");
}
