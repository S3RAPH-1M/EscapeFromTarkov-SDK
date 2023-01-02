using System;
using UnityEngine;

namespace EFT.Weather
{
	// Token: 0x0200162B RID: 5675
	public interface IWeatherCurve
	{
		// Token: 0x170010DF RID: 4319
		// (get) Token: 0x060088BB RID: 35003
		Vector2 Wind { get; }

		// Token: 0x170010E0 RID: 4320
		// (get) Token: 0x060088BC RID: 35004
		Vector2 TopWind { get; }

		// Token: 0x170010E1 RID: 4321
		// (get) Token: 0x060088BD RID: 35005
		float Rain { get; }

		// Token: 0x170010E2 RID: 4322
		// (get) Token: 0x060088BE RID: 35006
		float Cloudiness { get; }

		// Token: 0x170010E3 RID: 4323
		// (get) Token: 0x060088BF RID: 35007
		float Fog { get; }

		// Token: 0x170010E4 RID: 4324
		// (get) Token: 0x060088C0 RID: 35008
		float Temperature { get; }

		// Token: 0x170010E5 RID: 4325
		// (get) Token: 0x060088C1 RID: 35009
		float LightningThunderProbability { get; }
	}
}
