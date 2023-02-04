using System;
using UnityEngine;

namespace BezierSplineTools
{
	// Token: 0x02000D37 RID: 3383
	public class SplineWalker : MonoBehaviour
	{
		// Token: 0x040052FB RID: 21243
		public BezierSpline spline;

		// Token: 0x040052FC RID: 21244
		public float duration;

		// Token: 0x040052FD RID: 21245
		public bool lookForward;

		// Token: 0x040052FE RID: 21246
		public SplineWalkerMode mode;
	}
}
