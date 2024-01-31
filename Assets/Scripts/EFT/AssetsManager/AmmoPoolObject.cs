using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace EFT.AssetsManager
{
	// Token: 0x0200231E RID: 8990
	[DisallowMultipleComponent]
	public class AmmoPoolObject : AssetPoolObject
	{		
		// Token: 0x0400B2AD RID: 45741
		public Shell Shell;

		// Token: 0x0400B2AE RID: 45742
		private List<Transform> list_0;

		// Token: 0x0400B2AF RID: 45743
		private List<Transform> list_1;

		// Token: 0x0400B2B0 RID: 45744
		[SerializeField]
		private ECaliber _caliber;

		// Token: 0x0400B2B1 RID: 45745
		[CompilerGenerated]
		private bool bool_3;

		// Token: 0x0400B2B2 RID: 45746
		private float float_0 = -100f;
	}
}
