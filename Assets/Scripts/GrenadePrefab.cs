using System;
using UnityEngine;

// Token: 0x0200059A RID: 1434
[DisallowMultipleComponent]
public class GrenadePrefab : WeaponPrefab
{
	[Header("Element 0 defines grenade initial position!")]
	public string[] ThrowingParts;

	// Token: 0x0400213A RID: 8506
	public GrenadeSettings GrenadeItself;
}
