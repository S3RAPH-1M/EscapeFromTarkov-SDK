using System;
using EFT.InventoryLogic;
using JetBrains.Annotations;

namespace EFT.Interactive
{
	// Token: 0x020021EC RID: 8684
	[Serializable]
	public class ExfiltrationRequirement
	{
		// Token: 0x0400ABF6 RID: 44022
		public ERequirementState Requirement;

		// Token: 0x0400ABF7 RID: 44023
		public string Id;

		// Token: 0x0400ABF8 RID: 44024
		public int Count;

		// Token: 0x0400ABF9 RID: 44025
		public EquipmentSlot RequiredSlot;

		// Token: 0x0400ABFA RID: 44026
		public string RequirementTip;
	}
}