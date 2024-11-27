using System;
using UnityEngine;

namespace EFT
{
	// Token: 0x02001940 RID: 6464
	[Serializable]
	public class AudioMultipleClipContainer : IAudioClipContainer
	{		
		// Token: 0x040092DE RID: 37598
		[SerializeField]
		private AudioClip[] _clips;

		// Token: 0x040092DF RID: 37599
		[SerializeField]
		[Range(0f, 1f)]
		private float _volume = 1f;

		// Token: 0x040092E0 RID: 37600
		[SerializeField]
		private int _maxDistance = 100;
	}
}
