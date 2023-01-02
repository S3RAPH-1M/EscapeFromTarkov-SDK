using System;
using System.Collections.Generic;
using EFT;
using JetBrains.Annotations;

// Token: 0x020005DD RID: 1501
public abstract class ObjectInHandsAnimator
{

	public int LACTIONS_LAYER_INDEX = -1;
	public enum PlayerState
	{
		// Token: 0x040021E4 RID: 8676
		None,
		// Token: 0x040021E5 RID: 8677
		Idle,
		// Token: 0x040021E6 RID: 8678
		Jump,
		// Token: 0x040021E7 RID: 8679
		Sprint,
		// Token: 0x040021E8 RID: 8680
		Prone
	}
}
