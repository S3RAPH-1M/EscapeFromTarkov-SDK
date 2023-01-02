using System;
using System.Runtime.CompilerServices;
using Diz.Skinning;
using EFT.InventoryLogic;
using UnityEngine;

namespace EFT.Visual
{
	// Token: 0x02001523 RID: 5411
	public class TorsoSkin : AbstractSkin
	{
		[SerializeField]
		private Skin _skin;

		// Token: 0x0400797F RID: 31103
		[SerializeField]
		private Mesh _base;

		// Token: 0x04007980 RID: 31104
		[SerializeField]
		private Mesh _armor;

		// Token: 0x04007981 RID: 31105
		[SerializeField]
		private Mesh _vest;
	}
}
