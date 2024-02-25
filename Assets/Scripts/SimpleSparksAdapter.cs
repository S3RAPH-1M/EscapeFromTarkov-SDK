using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000A19 RID: 2585
public class SimpleSparksAdapter : Emitter
{
	// Token: 0x04003EC6 RID: 16070
	public SimpleSparksRenderer SimpleSparksObject;

	// Token: 0x04003EC7 RID: 16071
	[GAttribute7("Curve 240;Value 60", true)]
	public SimpleSparksAdapter.CurveValue LifetimeCurve;

	// Token: 0x04003EC8 RID: 16072
	[GAttribute7("Curve 240;Value 60", true)]
	public SimpleSparksAdapter.CurveValue SpeedCurve;

	// Token: 0x04003EC9 RID: 16073
	[GAttribute7("Curve 240;Value 60", true)]
	public SimpleSparksAdapter.CurveValue GravityCurve;

	// Token: 0x04003ECA RID: 16074
	[GAttribute7("Curve 240;Value 60", true)]
	public SimpleSparksAdapter.CurveValue DragCurve;

	// Token: 0x04003ECB RID: 16075
	[GAttribute7("Curve 240;Value 120 S 0 255", true)]
	public SimpleSparksAdapter.ByteCurveValue EmissionCurve;

	// Token: 0x04003ECC RID: 16076
	[GAttribute7("Curve 240;Value 120 S 0 255", true)]
	public SimpleSparksAdapter.ByteCurveValue SizeCurve;

	// Token: 0x04003ECD RID: 16077
	[GAttribute7("Curve 240;Value 120 S 0 255", true)]
	public SimpleSparksAdapter.ByteCurveValue TurbulenceAmplitudeCurve;

	// Token: 0x04003ECE RID: 16078
	[GAttribute7("Curve 240;Value 120 S 0 255", true)]
	public SimpleSparksAdapter.ByteCurveValue TurbulenceFrequencyCurve;

	// Token: 0x04003ECF RID: 16079
	public float EmissionTimeShift;

	// Token: 0x04003ED0 RID: 16080
	private const int int_0 = 128;

	// Token: 0x04003ED1 RID: 16081
	private const float float_0 = 0.0078125f;

	// Token: 0x02000A1A RID: 2586
	[Serializable]
	public class CurveValue
	{
		// Token: 0x04003ED2 RID: 16082
		public AnimationCurve Curve;

		// Token: 0x04003ED3 RID: 16083
		public float Value;

		// Token: 0x04003ED4 RID: 16084
		public float[] Values;
	}

	// Token: 0x02000A1B RID: 2587
	[Serializable]
	public class ByteCurveValue
	{
		// Token: 0x04003ED5 RID: 16085
		public AnimationCurve Curve;

		// Token: 0x04003ED6 RID: 16086
		public byte Value;

		// Token: 0x04003ED7 RID: 16087
		public byte[] Values;
	}
}
