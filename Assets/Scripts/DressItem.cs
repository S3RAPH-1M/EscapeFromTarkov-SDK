using System;
using UnityEngine;

// Token: 0x0200079E RID: 1950
public class DressItem : MonoBehaviour
{
	// Token: 0x0600318D RID: 12685 RVA: 0x000E1892 File Offset: 0x000DFA92
	public void EnableLoot(bool on)
	{
		this.LootPrefab.SetActive(on);
		this.DressPrefab.SetActive(!on);
	}

	// Token: 0x04002E58 RID: 11864
	public GameObject LootPrefab;

	// Token: 0x04002E59 RID: 11865
	public GameObject DressPrefab;
}
