using System;
using System.Collections.Generic;
using EFT.InventoryLogic;

// Token: 0x020009FC RID: 2556
[Serializable]
public class ThermalVisionUtilities
{
	// Token: 0x04003E96 RID: 16022
	public ThermalVisionComponent.SelectablePalette CurrentRampPalette;

	// Token: 0x04003E97 RID: 16023
	public float DepthFade = 0.03f;

	// Token: 0x04003E98 RID: 16024
	public List<RampTexPalletteConnector> RampTexPalletteConnectors;

	// Token: 0x04003E99 RID: 16025
	public ValuesCoefs ValuesCoefs;

	// Token: 0x04003E9A RID: 16026
	public Noise NoiseParameters;

	// Token: 0x04003E9B RID: 16027
	public MaskDescription MaskDescription;
}
