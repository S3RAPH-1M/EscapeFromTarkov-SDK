using System;
using UnityEngine;

// Token: 0x02000617 RID: 1559
[DisallowMultipleComponent]
public class UsableHandsPrefab : WeaponPrefab
{
	// Token: 0x04002353 RID: 9043
	[Header("Bone name for item")]
	public string UsableItemBoneName = "item_position";

	// Token: 0x04002354 RID: 9044
	public Transform ItemSpawnTransform;
}
