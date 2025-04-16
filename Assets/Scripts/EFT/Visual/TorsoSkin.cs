using System;
using Diz.Skinning;
using UnityEngine;

namespace EFT.Visual
{
	// Token: 0x02001DD1 RID: 7633
	public class TorsoSkin : AbstractSkin
	{
		// Token: 0x04008E0C RID: 36364
		[SerializeField]
		private Skin _skin;

		// Token: 0x04008E0D RID: 36365
		[SerializeField]
		private Mesh _base;

		// Token: 0x04008E0E RID: 36366
		[SerializeField]
		private Mesh _armor;

		// Token: 0x04008E0F RID: 36367
		[SerializeField]
		private Mesh _vest;
	}
}
