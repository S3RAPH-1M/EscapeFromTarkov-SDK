using System;
using System.Runtime.CompilerServices;
using Diz.Skinning;
using UnityEngine;
using UnityEngine.Serialization;

namespace EFT.Visual
{
	// Token: 0x02001DC1 RID: 7617
	public class LoddedSkin : MonoBehaviour
	{
		// Token: 0x04008DF5 RID: 36341
		[FormerlySerializedAs("Skins")]
		[SerializeField]
		private AbstractSkin[] _lods;

		// Token: 0x02001DC2 RID: 7618
		[CompilerGenerated]
		[Serializable]
		public class Class1729
		{
			// Token: 0x04008DF6 RID: 36342
			public static readonly LoddedSkin.Class1729 class1729_0;

			// Token: 0x04008DF7 RID: 36343
			public static Func<AbstractSkin, Renderer> func_0;
		}
	}
}
