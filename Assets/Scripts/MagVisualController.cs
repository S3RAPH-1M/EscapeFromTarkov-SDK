using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using EFT.AssetsManager;
using JetBrains.Annotations;
using UnityEngine;

// Token: 0x0200060C RID: 1548
[DisallowMultipleComponent]
public class MagVisualController : WeaponModPoolObject
{
	// Token: 0x0400231F RID: 8991
	private List<AmmoPoolObject> list_0 = new List<AmmoPoolObject>();

	// Token: 0x04002320 RID: 8992
	private Animation animation_0;

	// Token: 0x04002321 RID: 8993
	private int int_0 = -1;

	// Token: 0x04002322 RID: 8994
	private bool bool_3;
}