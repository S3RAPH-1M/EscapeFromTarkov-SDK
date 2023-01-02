using System;
using System.Linq;
using UnityEngine;

namespace EFT
{
	// Token: 0x02001462 RID: 5218
	public class SoundBank : ScriptableObject
	{
		public float CustomLength;

		// Token: 0x04007738 RID: 30520
		public float BaseVolume = 1f;

		// Token: 0x04007739 RID: 30521
		public float DeltaVolume;

		// Token: 0x0400773A RID: 30522
		public float Rolloff = 100f;

		// Token: 0x0400773B RID: 30523
		public bool IgnoreOcclusion;

		// Token: 0x0400773C RID: 30524
		public bool Physical;

		// Token: 0x0400773D RID: 30525
		public bool _noEnvironment;

		// Token: 0x0400773E RID: 30526
		public BetterAudio.AudioSourceGroupType SourceType = BetterAudio.AudioSourceGroupType.Environment;

		// Token: 0x0400773F RID: 30527
		[SerializeField]
		private float _clipLiength;

		// Token: 0x04007741 RID: 30529
		public DistanceBlendOptions BlendOptions;
	}
}
