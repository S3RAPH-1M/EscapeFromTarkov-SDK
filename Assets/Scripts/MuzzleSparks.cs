using System;
using UnityEngine;

// Token: 0x020009A3 RID: 2467
public class MuzzleSparks : MonoBehaviour
{
	// Token: 0x04003BE6 RID: 15334
	public float StartPos;

	// Token: 0x04003BE7 RID: 15335
	public float EmitterRadius;

	// Token: 0x04003BE8 RID: 15336
	public float ConusSize = 1f;

	// Token: 0x04003BE9 RID: 15337
	public int CountMin = 1;

	// Token: 0x04003BEA RID: 15338
	public int CountRange = 3;

	public MuzzleSparks.CurveValue LifetimeCurve;

	public MuzzleSparks.CurveValue SpeedCurve;

	public MuzzleSparks.CurveValue GravityCurve;

	public MuzzleSparks.CurveValue DragCurve;

	public MuzzleSparks.ByteCurveValue EmissionCurve;

	public MuzzleSparks.ByteCurveValue SizeCurve;

	public MuzzleSparks.ByteCurveValue TurbulenceAmplitudeCurve;

	public MuzzleSparks.ByteCurveValue TurbulenceFrequencyCurve;

	// Token: 0x04003BF3 RID: 15347
	public float EmissionTimeShift;

	// Token: 0x04003C0C RID: 15372
	private Transform transform_0;

	// Token: 0x04003C0D RID: 15373
	private const int int_0 = 128;

	// Token: 0x04003C0E RID: 15374
	private const float float_0 = 0.0078125f;

	[Serializable]
	public class CurveValue
	{
		// Token: 0x06003D15 RID: 15637 RVA: 0x00123B40 File Offset: 0x00121D40
		public void RecalcVals()
		{
			for (int i = 0; i < 128; i++)
			{
				this.Values[i] = this.Curve.Evaluate((float)i * 0.0078125f) * this.Value;
			}
		}

		// Token: 0x06003D16 RID: 15638 RVA: 0x00123B80 File Offset: 0x00121D80
		public void RecalcVals(Func<float, float> func)
		{
			for (int i = 0; i < 128; i++)
			{
				this.Values[i] = func(this.Curve.Evaluate((float)i * 0.0078125f) * this.Value);
			}
		}

		// Token: 0x04003BF7 RID: 15351
		public AnimationCurve Curve = AnimationCurve.Linear(0f, 1f, 1f, 1f);

		// Token: 0x04003BF8 RID: 15352
		public float Value = 1f;

		// Token: 0x04003BF9 RID: 15353
		public float[] Values = new float[128];
	}

	// Token: 0x020009A5 RID: 2469
	[Serializable]
	public class ByteCurveValue
	{
		// Token: 0x06003D18 RID: 15640 RVA: 0x00123C18 File Offset: 0x00121E18
		public void RecalcVals()
		{
			for (int i = 0; i < 128; i++)
			{
				this.Values[i] = (byte)(this.Curve.Evaluate((float)i * 0.0078125f) * (float)this.Value);
			}
		}

		// Token: 0x06003D19 RID: 15641 RVA: 0x00123C5C File Offset: 0x00121E5C
		public void RecalcVals(Func<float, float> func)
		{
			for (int i = 0; i < 128; i++)
			{
				this.Values[i] = (byte)func(this.Curve.Evaluate((float)i * 0.0078125f) * (float)this.Value);
			}
		}

		// Token: 0x04003BFA RID: 15354
		public AnimationCurve Curve = AnimationCurve.Linear(0f, 1f, 1f, 1f);

		// Token: 0x04003BFB RID: 15355
		public byte Value = byte.MaxValue;

		// Token: 0x04003BFC RID: 15356
		public byte[] Values = new byte[128];
	}
}
