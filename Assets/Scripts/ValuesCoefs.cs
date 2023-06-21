using System;
using UnityEngine;

// Token: 0x020009FE RID: 2558
[Serializable]
public class ValuesCoefs
{
	// Token: 0x04003E9E RID: 16030
	[Range(0.01f, 10f)]
	public float MainTexColorCoef = 0.2f;

	// Token: 0x04003E9F RID: 16031
	[Range(-10f, 10f)]
	public float MinimumTemperatureValue = 0.25f;

	// Token: 0x04003EA0 RID: 16032
	[Range(-1f, 1f)]
	public float RampShift;
}
