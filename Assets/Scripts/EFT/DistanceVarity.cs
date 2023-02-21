using System;
using UnityEngine;

namespace EFT
{
	// Token: 0x02001468 RID: 5224
	[Serializable]
	public class DistanceVarity
	{
		// Token: 0x17000FE9 RID: 4073
		public AudioClip this[int i]
		{
			get
			{
				return this.Clips[i];
			}
			set
			{
				this.Clips[i] = value;
			}
		}

		// Token: 0x17000FEA RID: 4074
		// (get) Token: 0x06007E1A RID: 32282 RVA: 0x002494E4 File Offset: 0x002476E4
		public int Length
		{
			get
			{
				return this.Clips.Length;
			}
		}

		// Token: 0x0400775B RID: 30555
		public AudioClip[] Clips = new AudioClip[1];
	}
}
