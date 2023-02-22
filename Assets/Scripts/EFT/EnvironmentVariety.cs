using System;

namespace EFT
{
	// Token: 0x02001467 RID: 5223
	[Serializable]
	public class EnvironmentVariety
	{
		// Token: 0x17000FE7 RID: 4071
		public DistanceVarity this[int i]
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

		// Token: 0x17000FE8 RID: 4072
		// (get) Token: 0x06007E16 RID: 32278 RVA: 0x00249499 File Offset: 0x00247699
		public int Length
		{
			get
			{
				return this.Clips.Length;
			}
		}

		// Token: 0x0400775A RID: 30554
		public DistanceVarity[] Clips = new DistanceVarity[]
		{
			new DistanceVarity(),
			new DistanceVarity(),
			new DistanceVarity()
		};
	}
}
