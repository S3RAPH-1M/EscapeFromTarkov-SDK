using System;
using UnityEngine;

namespace Prism.Utils
{
	// Token: 0x02000C57 RID: 3159
	public class PrismAnimCurveCreator : MonoBehaviour
	{
		// Token: 0x06004E2A RID: 20010 RVA: 0x0017FC28 File Offset: 0x0017DE28
		[ContextMenu("Generate curve")]
		private void method_0()
		{
			this.thisCurve = new AnimationCurve();
			for (int i = 0; i < this.curvePointsX.Length; i++)
			{
				this.thisCurve.AddKey(this.curvePointsX[i], this.curvePointsY[i]);
			}
		}

		// Token: 0x04004DBB RID: 19899
		public float[] curvePointsX;

		// Token: 0x04004DBC RID: 19900
		public float[] curvePointsY;

		// Token: 0x04004DBD RID: 19901
		public AnimationCurve thisCurve;
	}
}
