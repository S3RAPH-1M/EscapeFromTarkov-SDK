using System;
using System.Collections;
using Audio.Data;
using EFT.Ballistics;
using UnityEngine;

namespace EFT.Animations.Audio
{
	// Token: 0x02002204 RID: 8708
	public class BipodAudioController : MonoBehaviour
	{
		// Token: 0x0400BB4F RID: 47951
		private const float float_0 = 1f;

		// Token: 0x0400BB50 RID: 47952
		[SerializeField]
		private AudioMultipleClipContainer _bipodOpenSounds;

		// Token: 0x0400BB51 RID: 47953
		[SerializeField]
		private AudioMultipleClipContainer _bipodCloseSounds;

		// Token: 0x0400BB52 RID: 47954
		[SerializeField]
		private SurfaceSoundContainers _bipodMountSurfaceSounds;
	}
}
