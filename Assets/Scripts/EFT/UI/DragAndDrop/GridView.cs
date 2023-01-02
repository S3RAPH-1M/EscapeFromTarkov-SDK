using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EFT.InventoryLogic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace EFT.UI.DragAndDrop
{
	// Token: 0x020023B8 RID: 9144
	public class GridView : MonoBehaviour
	{
		// Token: 0x0400B91E RID: 47390
		[SerializeField]
		private Image _highlightPanel;

		// Token: 0x0400B91F RID: 47391
		[SerializeField]
		private bool _nonInteractable;
	}
}
