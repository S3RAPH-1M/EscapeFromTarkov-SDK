using System;
using System.Collections.Generic;
using JsonType;
using UnityEngine;

namespace EFT.ItemGameSounds
{
	// Token: 0x02001A92 RID: 6802
	public class ItemDropSounds : ScriptableObject
	{
		// Token: 0x040091BA RID: 37306
		public AnimationCurve EnergyToVolumeCurve;

		// Token: 0x040091BB RID: 37307
		public BaseBallistic.ESurfaceSound DefaultSurfaceSound;

		// Token: 0x040091BC RID: 37308
		public ItemDropSurfaceSet[] SurfaceSets;

	}
}
