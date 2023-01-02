using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace EFT.AssetsManager
{
	// Token: 0x02001D37 RID: 7479
	[DisallowMultipleComponent]
	public class AssetPoolObject : MonoBehaviour
	{

		// Token: 0x04009711 RID: 38673

		// Token: 0x04009712 RID: 38674
		public List<string> PoolHistory = new List<string>();

		// Token: 0x04009713 RID: 38675
		public List<Collider> Colliders = new List<Collider>();

		// Token: 0x04009715 RID: 38677
		[SerializeField]
		private List<Component> _originallyEnabledComponents = new List<Component>();

		// Token: 0x04009716 RID: 38678
		[CompilerGenerated]
		private bool bool_0;
		// Token: 0x04009718 RID: 38680
		[CompilerGenerated]
		private bool bool_1;

		// Token: 0x0400971B RID: 38683
		private bool bool_2;

		// Token: 0x0400971C RID: 38684
		public List<Component> RegisteredComponentsToClean = new List<Component>();

		// Token: 0x0400971D RID: 38685
		public List<AssetPoolObject.GClass2274> RegisteredCollidersToDisable = new List<AssetPoolObject.GClass2274>();


		// Token: 0x02001D39 RID: 7481
		public class GClass2274
		{
			// Token: 0x0400971E RID: 38686
			public Collider Collider;

			// Token: 0x0400971F RID: 38687
			public int Layer;

			// Token: 0x04009720 RID: 38688
			public bool WasEnabled;
		}
	}
}
