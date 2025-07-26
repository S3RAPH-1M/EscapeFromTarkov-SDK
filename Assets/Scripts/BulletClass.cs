using System.Collections.Generic;
using System.ComponentModel;
using EFT.InventoryLogic;
using JsonType;
using UnityEngine;

public class BulletClass : Item
{
	public float buckshotDispersion;

	public SonicBulletSoundPlayer.SonicType SonicType = SonicBulletSoundPlayer.SonicType.Sonic545;

	[DefaultValue(false)]
	public bool IsUsed;
}
