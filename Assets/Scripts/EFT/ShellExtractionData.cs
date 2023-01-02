using System;
using UnityEngine;

namespace EFT
{
	// Token: 0x0200128D RID: 4749
	public sealed class ShellExtractionData : MonoBehaviour
	{

		// Token: 0x04006B09 RID: 27401
		public ShellExtractionData.ExtractionSettings ShotSettings;

		// Token: 0x04006B0A RID: 27402
		public ShellExtractionData.ExtractionSettings MisfireSettings;

		// Token: 0x04006B0B RID: 27403
		public ShellExtractionData.ExtractionSettings JamSettings;

		// Token: 0x04006B0C RID: 27404
		public ShellExtractionData.ExtractionSettings PatronExtractionSettings;

		// Token: 0x0200128E RID: 4750
		[Serializable]
		public struct ExtractionSettings
		{
			// Token: 0x04006B0D RID: 27405
			public Vector2 ShellsForceXRange;

			// Token: 0x04006B0E RID: 27406
			public Vector2 ShellsForceYRange;

			// Token: 0x04006B0F RID: 27407
			public Vector2 ShellsForceZRange;

			// Token: 0x04006B10 RID: 27408
			public Vector2 ShellsRotationRangeX;

			// Token: 0x04006B11 RID: 27409
			public Vector2 ShellsRotationRangeY;

			// Token: 0x04006B12 RID: 27410
			public Vector2 ShellsRotationRangeZ;

			// Token: 0x04006B13 RID: 27411
			public float ShellForceMultiplier;
		}
	}
}
