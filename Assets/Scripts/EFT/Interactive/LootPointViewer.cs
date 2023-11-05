using System.Collections.Generic;
using System.Runtime.CompilerServices;
using EFT.InventoryLogic;
using UnityEngine;

namespace EFT.Interactive
{
	public class LootPointViewer : MonoBehaviour
	{
		private LootPoint lootPoint_0;

		private List<GameObject> list_0 = new List<GameObject>();

		[CompilerGenerated]
		private Item item_0;

		private LootPoint LootPoint_0 => lootPoint_0 ?? (lootPoint_0 = GetComponent<LootPoint>());

		public Item CurrentItem
		{
			[CompilerGenerated]
			get
			{
				return item_0;
			}
			[CompilerGenerated]
			private set
			{
				item_0 = value;
			}
		}
	}
}
