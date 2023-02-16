using System;
using System.Globalization;
using System.IO;

namespace AnimationEventSystem
{
	// Token: 0x02000E38 RID: 3640
	[Serializable]
	public class AnimationEventParameter
	{

		// Token: 0x0400580F RID: 22543
		public bool BoolParam;

		// Token: 0x04005810 RID: 22544
		public float FloatParam;

		// Token: 0x04005811 RID: 22545
		public int IntParam;

		// Token: 0x04005812 RID: 22546
		public string StringParam;

		// Token: 0x04005813 RID: 22547
		public EAnimationEventParamType ParamType;
	}
}
