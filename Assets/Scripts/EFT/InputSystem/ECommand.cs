using System;

namespace EFT.InputSystem
{
	// Token: 0x020013FE RID: 5118
	public enum ECommand
	{
		// Token: 0x040073A8 RID: 29608
		None,
		// Token: 0x040073A9 RID: 29609
		ToggleShooting,
		// Token: 0x040073AA RID: 29610
		EndShooting,
		// Token: 0x040073AB RID: 29611
		ToggleAlternativeShooting,
		// Token: 0x040073AC RID: 29612
		ToggleSpeed,
		// Token: 0x040073AD RID: 29613
		ChangeScope,
		// Token: 0x040073AE RID: 29614
		ChangeScopeMagnification,
		// Token: 0x040073AF RID: 29615
		CheckFireMode,
		// Token: 0x040073B0 RID: 29616
		DecreaseWalkSpeed,
		// Token: 0x040073B1 RID: 29617
		BeginInteracting,
		// Token: 0x040073B2 RID: 29618
		EndInteracting,
		// Token: 0x040073B3 RID: 29619
		BeginSpecialInteracting,
		// Token: 0x040073B4 RID: 29620
		EndSpecialInteracting,
		// Token: 0x040073B5 RID: 29621
		ThrowGrenade,
		// Token: 0x040073B6 RID: 29622
		NextGrenadeStage,
		// Token: 0x040073B7 RID: 29623
		ReloadWeapon,
		// Token: 0x040073B8 RID: 29624
		NextMagazine,
		// Token: 0x040073B9 RID: 29625
		PreviousMagazine,
		// Token: 0x040073BA RID: 29626
		QuickReloadWeapon,
		// Token: 0x040073BB RID: 29627
		ChangeWeaponMode,
		// Token: 0x040073BC RID: 29628
		ForceAutoWeaponMode,
		// Token: 0x040073BD RID: 29629
		ToggleDuck,
		// Token: 0x040073BE RID: 29630
		ToggleSprinting,
		// Token: 0x040073BF RID: 29631
		EndSprinting,
		// Token: 0x040073C0 RID: 29632
		ToggleBreathing,
		// Token: 0x040073C1 RID: 29633
		EndBreathing,
		// Token: 0x040073C2 RID: 29634
		ToggleProne,
		// Token: 0x040073C3 RID: 29635
		ResetLookDirection,
		// Token: 0x040073C4 RID: 29636
		NextWalkPose,
		// Token: 0x040073C5 RID: 29637
		PreviousWalkPose,
		// Token: 0x040073C6 RID: 29638
		ToggleStepLeft,
		// Token: 0x040073C7 RID: 29639
		ToggleStepRight,
		// Token: 0x040073C8 RID: 29640
		ReturnFromLeftStep,
		// Token: 0x040073C9 RID: 29641
		ReturnFromRightStep,
		// Token: 0x040073CA RID: 29642
		ExamineWeapon,
		// Token: 0x040073CB RID: 29643
		ToggleInventory,
		// Token: 0x040073CC RID: 29644
		SelectKnife,
		// Token: 0x040073CD RID: 29645
		ToggleTacticalDevice,
		// Token: 0x040073CE RID: 29646
		Jump,
		// Token: 0x040073CF RID: 29647
		SelectFirstPrimaryWeapon,
		// Token: 0x040073D0 RID: 29648
		SelectSecondPrimaryWeapon,
		// Token: 0x040073D1 RID: 29649
		SelectSecondaryWeapon,
		// Token: 0x040073D2 RID: 29650
		SelectFastSlot4,
		// Token: 0x040073D3 RID: 29651
		SelectFastSlot5,
		// Token: 0x040073D4 RID: 29652
		SelectFastSlot6,
		// Token: 0x040073D5 RID: 29653
		SelectFastSlot7,
		// Token: 0x040073D6 RID: 29654
		SelectFastSlot8,
		// Token: 0x040073D7 RID: 29655
		SelectFastSlot9,
		// Token: 0x040073D8 RID: 29656
		SelectFastSlot0,
		// Token: 0x040073D9 RID: 29657
		FoldStock,
		// Token: 0x040073DA RID: 29658
		ChangePointOfView,
		// Token: 0x040073DB RID: 29659
		Escape,
		// Token: 0x040073DC RID: 29660
		CheckAmmo,
		// Token: 0x040073DD RID: 29661
		EndAlternativeShooting,
		// Token: 0x040073DE RID: 29662
		NextTacticalDevice,
		// Token: 0x040073DF RID: 29663
		QuickKnifeKick,
		// Token: 0x040073E0 RID: 29664
		MumbleEnd,
		// Token: 0x040073E1 RID: 29665
		DisplayTimer,
		// Token: 0x040073E2 RID: 29666
		DisplayTimerAndExits,
		// Token: 0x040073E3 RID: 29667
		ToggleGoggles,
		// Token: 0x040073E4 RID: 29668
		ToggleLeanRight,
		// Token: 0x040073E5 RID: 29669
		ToggleLeanLeft,
		// Token: 0x040073E6 RID: 29670
		ToggleBlindAbove,
		// Token: 0x040073E7 RID: 29671
		ToggleBlindRight,
		// Token: 0x040073E8 RID: 29672
		BlindShootEnd,
		// Token: 0x040073E9 RID: 29673
		LeanLeftSlow,
		// Token: 0x040073EA RID: 29674
		CheckChamber,
		// Token: 0x040073EB RID: 29675
		MumbleToggle,
		// Token: 0x040073EC RID: 29676
		ToggleMumbleDropdown,
		// Token: 0x040073ED RID: 29677
		MumbleDropdownHide,
		// Token: 0x040073EE RID: 29678
		QuickMumbleStart,
		// Token: 0x040073EF RID: 29679
		ScrollNext,
		// Token: 0x040073F0 RID: 29680
		ScrollPrevious,
		// Token: 0x040073F1 RID: 29681
		ToggleWalk,
		// Token: 0x040073F2 RID: 29682
		EndWalk,
		// Token: 0x040073F3 RID: 29683
		EndLeanLeft,
		// Token: 0x040073F4 RID: 29684
		EndLeanRight,
		// Token: 0x040073F5 RID: 29685
		RestorePose,
		// Token: 0x040073F6 RID: 29686
		OpticCalibrationSwitchUp,
		// Token: 0x040073F7 RID: 29687
		OpticCalibrationSwitchDown,
		// Token: 0x040073F8 RID: 29688
		MakeScreenshot,
		// Token: 0x040073F9 RID: 29689
		ShowConsole,
		// Token: 0x040073FA RID: 29690
		ThrowItem,
		// Token: 0x040073FB RID: 29691
		EnterHideout,
		// Token: 0x040073FC RID: 29692
		ToggleInfo,
		// Token: 0x040073FD RID: 29693
		ToggleCompass,
		// Token: 0x040073FE RID: 29694
		HideCompass,
		// Token: 0x040073FF RID: 29695
		DropBackpack,
		// Token: 0x04007400 RID: 29696
		ChamberUnload,
		// Token: 0x04007401 RID: 29697
		UnloadMagazine,
		// Token: 0x04007402 RID: 29698
		TryHighThrow,
		// Token: 0x04007403 RID: 29699
		FinishHighThrow,
		// Token: 0x04007404 RID: 29700
		TryLowThrow,
		// Token: 0x04007405 RID: 29701
		FinishLowThrow,
		// Token: 0x04007406 RID: 29702
		F1,
		// Token: 0x04007407 RID: 29703
		F2,
		// Token: 0x04007408 RID: 29704
		F3,
		// Token: 0x04007409 RID: 29705
		F4,
		// Token: 0x0400740A RID: 29706
		F5,
		// Token: 0x0400740B RID: 29707
		F6,
		// Token: 0x0400740C RID: 29708
		F7,
		// Token: 0x0400740D RID: 29709
		F8,
		// Token: 0x0400740E RID: 29710
		F9,
		// Token: 0x0400740F RID: 29711
		F10,
		// Token: 0x04007410 RID: 29712
		F11,
		// Token: 0x04007411 RID: 29713
		F12,
		// Token: 0x04007412 RID: 29714
		DoubleF1,
		// Token: 0x04007413 RID: 29715
		DoubleF2,
		// Token: 0x04007414 RID: 29716
		DoubleF3,
		// Token: 0x04007415 RID: 29717
		DoubleF4,
		// Token: 0x04007416 RID: 29718
		DoubleF5,
		// Token: 0x04007417 RID: 29719
		DoubleF6,
		// Token: 0x04007418 RID: 29720
		DoubleF7,
		// Token: 0x04007419 RID: 29721
		DoubleF8,
		// Token: 0x0400741A RID: 29722
		DoubleF9,
		// Token: 0x0400741B RID: 29723
		DoubleF10,
		// Token: 0x0400741C RID: 29724
		DoubleF11,
		// Token: 0x0400741D RID: 29725
		DoubleF12,
		// Token: 0x0400741E RID: 29726
		ToggleTalk,
		// Token: 0x0400741F RID: 29727
		StopTalk,
		// Token: 0x04007420 RID: 29728
		ToggleVoip
	}
}
