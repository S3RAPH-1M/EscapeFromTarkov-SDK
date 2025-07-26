using System;
using System.Runtime.CompilerServices;
using Diz.Skinning;
using UnityEngine;

namespace EFT.Visual
{
	// Token: 0x02001DB4 RID: 7604
	public class ArmBandView : Dress
	{
		// Token: 0x04008DD6 RID: 36310
		[SerializeField]
		private ArmBandView.MeshCustomizationIdPair[] _customizationIdPair;

		// Token: 0x04008DD7 RID: 36311
		[SerializeField]
		private Skin[] _main;

		// Token: 0x02001DB5 RID: 7605
		[Serializable]
		public class MeshCustomizationIdPair
		{
			// Token: 0x04008DD8 RID: 36312
			public string CustomizationId;

			// Token: 0x04008DD9 RID: 36313
			public Mesh[] Meshes;
		}

		// Token: 0x02001DB6 RID: 7606
		[CompilerGenerated]
		[Serializable]
		public class Class1727
		{
			// Token: 0x04008DDA RID: 36314
			public static readonly ArmBandView.Class1727 class1727_0;

			// Token: 0x04008DDB RID: 36315
			public static Func<ArmBandView.MeshCustomizationIdPair, string> func_0;

			// Token: 0x04008DDC RID: 36316
			public static Func<ArmBandView.MeshCustomizationIdPair, Mesh[]> func_1;
		}
	}
}
