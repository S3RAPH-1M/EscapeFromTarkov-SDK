using System;
using UnityEngine;

// Token: 0x020005E2 RID: 1506
public static class WeaponAnimationSpeedControllerClass
{
	// Token: 0x0600274D RID: 10061 RVA: 0x000B4A0C File Offset: 0x000B2C0C
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

	// Token: 0x040021ED RID: 8685
	public static readonly int BOOL_ACTIVE = Animator.StringToHash("Active");

	// Token: 0x040021EE RID: 8686
	public static readonly int BOOL_ADDAMMOINCHAMBER = Animator.StringToHash("AddAmmoInChamber");

	// Token: 0x040021EF RID: 8687
	public static readonly int BOOL_ADDAMMOINMAG = Animator.StringToHash("AddAmmoInMag");

	// Token: 0x040021F0 RID: 8688
	public static readonly int BOOL_ALTFIRE = Animator.StringToHash("AltFire");

	// Token: 0x040021F1 RID: 8689
	public static readonly int BOOL_ARM = Animator.StringToHash("Arm");

	// Token: 0x040021F2 RID: 8690
	public static readonly int BOOL_ARMED = Animator.StringToHash("Armed");

	// Token: 0x040021F3 RID: 8691
	public static readonly int BOOL_BOLTACTIONRELOAD = Animator.StringToHash("BoltActionReload");

	// Token: 0x040021F4 RID: 8692
	public static readonly int BOOL_BOLTCATCH = Animator.StringToHash("BoltCatch");

	// Token: 0x040021F5 RID: 8693
	public static readonly int BOOL_CANRELOAD = Animator.StringToHash("CanReload");

	// Token: 0x040021F6 RID: 8694
	public static readonly int BOOL_DELAMMOCHAMBER = Animator.StringToHash("DelAmmoChamber");

	// Token: 0x040021F7 RID: 8695
	public static readonly int BOOL_DELAMMOFROMMAG = Animator.StringToHash("DelAmmoFromMag");

	// Token: 0x040021F8 RID: 8696
	public static readonly int BOOL_DISARM = Animator.StringToHash("Disarm");

	// Token: 0x040021F9 RID: 8697
	public static readonly int BOOL_DISCHARGE = Animator.StringToHash("Discharge");

	// Token: 0x040021FA RID: 8698
	public static readonly int BOOL_FASTHIDE = Animator.StringToHash("FastHide");

	// Token: 0x040021FB RID: 8699
	public static readonly int BOOL_FIRE = Animator.StringToHash("Fire");

	// Token: 0x040021FC RID: 8700
	public static readonly int BOOL_SPRINT = Animator.StringToHash("Sprint");

	// Token: 0x040021FD RID: 8701
	public static readonly int BOOL_GRIP = Animator.StringToHash("Grip");

	// Token: 0x040021FE RID: 8702
	public static readonly int BOOL_HVAT = Animator.StringToHash("Hvat");

	// Token: 0x040021FF RID: 8703
	public static readonly int BOOL_IDLE = Animator.StringToHash("Idle");

	// Token: 0x04002200 RID: 8704
	public static readonly int BOOL_INCOMPATIBLEAMMO = Animator.StringToHash("IncompatibleAmmo");

	// Token: 0x04002201 RID: 8705
	public static readonly int BOOL_INVENTORY = Animator.StringToHash("Inventory");

	// Token: 0x04002202 RID: 8706
	public static readonly int BOOL_ISEXTERNALMAG = Animator.StringToHash("IsExternalMag");

	// Token: 0x04002203 RID: 8707
	public static readonly int BOOL_LAUNCHERREADY = Animator.StringToHash("LauncherReady");

	// Token: 0x04002204 RID: 8708
	public static readonly int BOOL_LOADONE = Animator.StringToHash("LoadOne");

	// Token: 0x04002205 RID: 8709
	public static readonly int BOOL_MAGFULL = Animator.StringToHash("MagFull");

	// Token: 0x04002206 RID: 8710
	public static readonly int BOOL_MAGIN = Animator.StringToHash("MagIn");

	// Token: 0x04002207 RID: 8711
	public static readonly int BOOL_MAGINWEAPON = Animator.StringToHash("MagInWeapon");

	// Token: 0x04002208 RID: 8712
	public static readonly int BOOL_MAGOUT = Animator.StringToHash("MagOut");

	// Token: 0x04002209 RID: 8713
	public static readonly int BOOL_MAGSWAP = Animator.StringToHash("MagSwap");

	// Token: 0x0400220A RID: 8714
	public static readonly int BOOL_MODSET = Animator.StringToHash("ModSet");

	// Token: 0x0400220B RID: 8715
	public static readonly int BOOL_OFFBOLTCATCH = Animator.StringToHash("OffBoltCatch");

	// Token: 0x0400220C RID: 8716
	public static readonly int BOOL_ONBOLTCATCH = Animator.StringToHash("OnBoltCatch");

	// Token: 0x0400220D RID: 8717
	public static readonly int BOOL_PATROL = Animator.StringToHash("Patrol");

	// Token: 0x0400220E RID: 8718
	public static readonly int BOOL_QUICKFIRE = Animator.StringToHash("QuickFire");

	// Token: 0x0400220F RID: 8719
	public static readonly int BOOL_SETFIREMODE0 = Animator.StringToHash("SetFiremode0");

	// Token: 0x04002210 RID: 8720
	public static readonly int BOOL_SETFIREMODE1 = Animator.StringToHash("SetFiremode1");

	// Token: 0x04002211 RID: 8721
	public static readonly int BOOL_SHELLEJECT = Animator.StringToHash("ShellEject");

	// Token: 0x04002212 RID: 8722
	public static readonly int BOOL_STOCKFOLDED = Animator.StringToHash("StockFolded");

	// Token: 0x04002213 RID: 8723
	public static readonly int BOOL_USELEFTHAND = Animator.StringToHash("UseLeftHand");

	// Token: 0x04002214 RID: 8724
	public static readonly int BOOL_RECHAMBER = Animator.StringToHash("Rechamber");

	// Token: 0x04002215 RID: 8725
	public static readonly int BOOL_MALFUNCTIONREPAIR = Animator.StringToHash("MalfunctionRepair");

	// Token: 0x04002216 RID: 8726
	public static readonly int BOOL_MISFIRESLIDE_UNKNOWN = Animator.StringToHash("MisfireSlideUnknown");

	// Token: 0x04002217 RID: 8727
	public static readonly int BOOL_ROLLCYLINDER = Animator.StringToHash("RollCylinder");

	// Token: 0x04002218 RID: 8728
	public static readonly int BOOL_ROLLTOZEROCAMORA = Animator.StringToHash("RollToZeroCamora");

	// Token: 0x04002219 RID: 8729
	public static readonly int BOOL_MASTERINGRELOADABORTED = Animator.StringToHash("MasteringReloadAborted");

	// Token: 0x0400221A RID: 8730
	public static readonly int BOOL_FIREMODE_SPRINT = Animator.StringToHash("FiremodeSprint");

	// Token: 0x0400221B RID: 8731
	public static readonly int FLOAT_DOUBLEACTION = Animator.StringToHash("DoubleActionFireModeFloat");

	// Token: 0x0400221C RID: 8732
	public static readonly int FLOAT_AIM_ANGLE = Animator.StringToHash("Aim_angle");

	// Token: 0x0400221D RID: 8733
	public static readonly int FLOAT_AMMOINCHAMBER = Animator.StringToHash("AmmoInChamber");

	// Token: 0x0400221E RID: 8734
	public static readonly int FLOAT_AMMOINMAG = Animator.StringToHash("AmmoInMag");

	// Token: 0x0400221F RID: 8735
	public static readonly int FLOAT_AMMOCOUNTFORREMOVE = Animator.StringToHash("AmmoCountForRemove");

	// Token: 0x04002220 RID: 8736
	public static readonly int FLOAT_CHARACTERID = Animator.StringToHash("CharacterID");

	// Token: 0x04002221 RID: 8737
	public static readonly int FLOAT_DEFLECTED = Animator.StringToHash("Deflected");

	// Token: 0x04002222 RID: 8738
	public static readonly int FLOAT_EMPTYLINKSCOUNT = Animator.StringToHash("EmptyLinksCount");

	// Token: 0x04002223 RID: 8739
	public static readonly int FLOAT_FIREMODE = Animator.StringToHash("FireMode");

	// Token: 0x04002224 RID: 8740
	public static readonly int FLOAT_GESTUREINDEX = Animator.StringToHash("GestureIndex");

	// Token: 0x04002225 RID: 8741
	public static readonly int FLOAT_GRIPWEIGHT = Animator.StringToHash("GripWeight");

	// Token: 0x04002226 RID: 8742
	public static readonly int FLOAT_IDLEPOSITION = Animator.StringToHash("IdlePosition");

	// Token: 0x04002227 RID: 8743
	public static readonly int FLOAT_IDLEVAR = Animator.StringToHash("IdleVar");

	// Token: 0x04002228 RID: 8744
	public static readonly int FLOAT_LAUNCHERID = Animator.StringToHash("LauncherID");

	// Token: 0x04002229 RID: 8745
	public static readonly int FLOAT_LEFTHANDPROGRESS = Animator.StringToHash("LeftHandProgress");

	// Token: 0x0400222A RID: 8746
	public static readonly int FLOAT_RADIOCOMMAND = Animator.StringToHash("RadioCommand");

	// Token: 0x0400222B RID: 8747
	public static readonly int FLOAT_RELTYPENEW = Animator.StringToHash("RelTypeNew");

	// Token: 0x0400222C RID: 8748
	public static readonly int FLOAT_RELTYPEOLD = Animator.StringToHash("RelTypeOld");

	// Token: 0x0400222D RID: 8749
	public static readonly int FLOAT_SHELLSINWEAPON = Animator.StringToHash("ShellsInWeapon");

	// Token: 0x0400222E RID: 8750
	public static readonly int FLOAT_SHOULDERREACH = Animator.StringToHash("ShoulderReach");

	// Token: 0x0400222F RID: 8751
	public static readonly int FLOAT_SPEEDDRAW = Animator.StringToHash("SpeedDraw");

	// Token: 0x04002230 RID: 8752
	public static readonly int FLOAT_SPEEDFIX = Animator.StringToHash("SpeedFix");

	// Token: 0x04002231 RID: 8753
	public static readonly int FLOAT_SPEEDRELOAD = Animator.StringToHash("SpeedReload");

	// Token: 0x04002232 RID: 8754
	public static readonly int FLOAT_STOCKANIMATIONINDEX = Animator.StringToHash("StockAnimationIndex");

	// Token: 0x04002233 RID: 8755
	public static readonly int FLOAT_SWINGSPEED = Animator.StringToHash("SwingSpeed");

	// Token: 0x04002234 RID: 8756
	public static readonly int FLOAT_THIRDPERSON = Animator.StringToHash("ThirdPerson");

	// Token: 0x04002235 RID: 8757
	public static readonly int FLOAT_UNDERMOD = Animator.StringToHash("UnderMod");

	// Token: 0x04002236 RID: 8758
	public static readonly int FLOAT_USETIMEMULTIPLIER = Animator.StringToHash("UseTimeMultiplier");

	// Token: 0x04002237 RID: 8759
	public static readonly int FLOAT_WEAPONLEVEL = Animator.StringToHash("WeaponLevel");

	// Token: 0x04002238 RID: 8760
	public static readonly int FLOAT_CHAMBERINDEX = Animator.StringToHash("ChamberIndex");

	// Token: 0x04002239 RID: 8761
	public static readonly int FLOAT_CHAMBERINDEX_WITH_SHELL = Animator.StringToHash("ChamberIndexWithShell");

	// Token: 0x0400223A RID: 8762
	public static readonly int FLOAT_CAMORAINDEX = Animator.StringToHash("CamoraIndex");

	// Token: 0x0400223B RID: 8763
	public static readonly int FLOAT_CAMORAINDEXFORLOADAMMO = Animator.StringToHash("CamoraIndexForLoadAmmo");

	// Token: 0x0400223C RID: 8764
	public static readonly int FLOAT_CAMORAINDEXWITHSHELLFORREMOVE = Animator.StringToHash("CamoraIndexWithShellForRemove");

	// Token: 0x0400223D RID: 8765
	public static readonly int FLOAT_CAMORAINDEXFORUNLOADAMMO = Animator.StringToHash("CamoraIndexForRemoveAmmo");

	// Token: 0x0400223E RID: 8766
	public static readonly int FLOAT_CAMORAFIREINDEX = Animator.StringToHash("CamoraFireIndex");

	// Token: 0x0400223F RID: 8767
	public static readonly int FLOAT_SIGHTINGRANGE = Animator.StringToHash("SightingRange");

	// Token: 0x04002240 RID: 8768
	public static readonly int INT_ANIMATIONVARIANT = Animator.StringToHash("AnimationVariant");

	// Token: 0x04002241 RID: 8769
	public static readonly int INT_FIREVAR = Animator.StringToHash("FireVar");

	// Token: 0x04002242 RID: 8770
	public static readonly int INT_GRENADEALTFIRE = Animator.StringToHash("GrenadeAltFire");

	// Token: 0x04002243 RID: 8771
	public static readonly int INT_GRENADEFIRE = Animator.StringToHash("GrenadeFire");

	// Token: 0x04002244 RID: 8772
	public static readonly int INT_LACTIONINDEX = Animator.StringToHash("LActionIndex");

	// Token: 0x04002245 RID: 8773
	public static readonly int INT_PLAYERSTATE = Animator.StringToHash("PlayerState");

	// Token: 0x04002246 RID: 8774
	public static readonly int INT_THIRDACTION = Animator.StringToHash("ThirdAction");

	// Token: 0x04002247 RID: 8775
	public static readonly int INT_MALFUNCTION = Animator.StringToHash("Malfunction");

	// Token: 0x04002248 RID: 8776
	public static readonly int INT_MALFTYPE = Animator.StringToHash("MalfType");

	// Token: 0x04002249 RID: 8777
	public static readonly int TRIGGER_BUTTERFINGERS = Animator.StringToHash("Butterfingers");

	// Token: 0x0400224A RID: 8778
	public static readonly int TRIGGER_CHECKAMMO = Animator.StringToHash("CheckAmmo");

	// Token: 0x0400224B RID: 8779
	public static readonly int TRIGGER_CHECKCHAMBER = Animator.StringToHash("CheckChamber");

	// Token: 0x0400224C RID: 8780
	public static readonly int TRIGGER_FIREMODECHECK = Animator.StringToHash("FiremodeCheck");

	// Token: 0x0400224D RID: 8781
	public static readonly int TRIGGER_FIREMODESWITCH = Animator.StringToHash("FiremodeSwitch");

	// Token: 0x0400224E RID: 8782
	public static readonly int TRIGGER_HAMMERARMED = Animator.StringToHash("HammerArmed");

	// Token: 0x0400224F RID: 8783
	public static readonly int TRIGGER_FIRINGBULLET = Animator.StringToHash("FiringBullet");

	// Token: 0x04002250 RID: 8784
	public static readonly int TRIGGER_GESTURE = Animator.StringToHash("Gesture");

	// Token: 0x04002251 RID: 8785
	public static readonly int TRIGGER_GOMELE = Animator.StringToHash("GoMele");

	// Token: 0x04002252 RID: 8786
	public static readonly int TRIGGER_HANDREADY = Animator.StringToHash("HandReady");

	// Token: 0x04002253 RID: 8787
	public static readonly int TRIGGER_IDLETIME = Animator.StringToHash("IdleTime");

	// Token: 0x04002254 RID: 8788
	public static readonly int TRIGGER_LOOK = Animator.StringToHash("Look");

	// Token: 0x04002255 RID: 8789
	public static readonly int TRIGGER_MAGINFROMINV = Animator.StringToHash("MagInFromInv");

	// Token: 0x04002256 RID: 8790
	public static readonly int TRIGGER_MAGOUTFROMINV = Animator.StringToHash("MagOutFromInv");

	// Token: 0x04002257 RID: 8791
	public static readonly int TRIGGER_MAGSWAPEND = Animator.StringToHash("MagSwapEnd");

	// Token: 0x04002258 RID: 8792
	public static readonly int TRIGGER_MODSWITCH = Animator.StringToHash("ModSwitch");

	// Token: 0x04002259 RID: 8793
	public static readonly int TRIGGER_RADIO = Animator.StringToHash("Radio");

	// Token: 0x0400225A RID: 8794
	public static readonly int TRIGGER_RELOAD = Animator.StringToHash("Reload");

	// Token: 0x0400225B RID: 8795
	public static readonly int TRIGGER_RELOADFAST = Animator.StringToHash("ReloadFast");

	// Token: 0x0400225C RID: 8796
	public static readonly int TRIGGER_STOCKSWITCH = Animator.StringToHash("StockSwitch");
}
