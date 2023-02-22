using System;
using System.Linq;
using UnityEngine;

namespace EFT
{
	// Token: 0x02001462 RID: 5218
	public class SoundBank : ScriptableObject
	{
		// Token: 0x0400774D RID: 30541
		public float CustomLength;

		// Token: 0x0400774E RID: 30542
		public float BaseVolume = 1f;

		// Token: 0x0400774F RID: 30543
		public float DeltaVolume;

		// Token: 0x04007750 RID: 30544
		public float Rolloff = 100f;

		// Token: 0x04007751 RID: 30545
		public bool IgnoreOcclusion;

		// Token: 0x04007752 RID: 30546
		public bool Physical;

		// Token: 0x04007753 RID: 30547
		public bool _noEnvironment;

		// Token: 0x04007754 RID: 30548
		public BetterAudio.AudioSourceGroupType SourceType = BetterAudio.AudioSourceGroupType.Environment;

		// Token: 0x04007755 RID: 30549
		[SerializeField]
		private float _clipLiength;

		// Token: 0x04007756 RID: 30550
		public EnvironmentVariety[] Environments = new EnvironmentVariety[Enum.GetNames(typeof(EnvironmentType)).Length];

		// Token: 0x04007757 RID: 30551
		public DistanceBlendOptions BlendOptions;

		// Token: 0x04007758 RID: 30552
		private byte[] byte_0;

		// Token: 0x04007759 RID: 30553
		private byte byte_1;
	}
}