using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000A5E RID: 2654
public class TracersLight : MonoBehaviour
{
	// Token: 0x040040F0 RID: 16624
	[ColorUsage(true, true, 0f, 8f, 0.125f, 3f)]
	public Color Color;

	// Token: 0x040040F1 RID: 16625
	[SerializeField]
	private float _maxFlyingTime;

	// Token: 0x040040F2 RID: 16626
	[SerializeField]
	private AnimationCurve _sizeTimeCurve;

	// Token: 0x040040F3 RID: 16627
	[SerializeField]
	private AnimationCurve _colorAlphaCurve;

	// Token: 0x040040F4 RID: 16628
	[SerializeField]
	private float _grenadeFlyingMaxTime;

	// Token: 0x040040F5 RID: 16629
	[SerializeField]
	private float _grenadeSizeCoef;

	// Token: 0x040040F6 RID: 16630
	[SerializeField]
	private MeshFilter _tracersMF;

	// Token: 0x040040F7 RID: 16631
	[SerializeField]
	private float _speedModifier;

	// Token: 0x040040F8 RID: 16632
	[SerializeField]
	private float _grenadeSpeedModifier;

	// Token: 0x040040FA RID: 16634
	private List<TracersLight.Class532> list_1;

	// Token: 0x040040FB RID: 16635
	private bool bool_0;

	// Token: 0x040040FC RID: 16636
	private bool bool_1;

	// Token: 0x040040FD RID: 16637
	private static readonly float float_0;

	// Token: 0x02000A5F RID: 2655
	private class Class532
	{
		// Token: 0x06004258 RID: 16984 RVA: 0x00002050 File Offset: 0x00000250
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Class532(Vector3 positionShift, Vector3 direction, Color currentTracerColor, Color backCurrentTracerColor, float sizePercent, float speed)
		{
			throw null;
		}

		// Token: 0x040040FE RID: 16638
		public readonly Color BackCurrentTracerColor;

		// Token: 0x040040FF RID: 16639
		public readonly Color CurrentTracerColor;

		// Token: 0x04004100 RID: 16640
		public Vector3 Direction;

		// Token: 0x04004101 RID: 16641
		public readonly Vector3 PositionShift;

		// Token: 0x04004102 RID: 16642
		public readonly float SizePercent;

		// Token: 0x04004103 RID: 16643
		public readonly float Speed;
	}
}
