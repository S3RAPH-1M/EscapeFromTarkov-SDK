using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using EFT.Weather;
using JetBrains.Annotations;
using UnityEngine;

namespace EFT.EnvironmentEffect
{
	// Token: 0x02001612 RID: 5650
	public class EnvironmentManager : MonoBehaviour
	{
		// Token: 0x0400A9EB RID: 43499
		[SerializeField]
		[Space]
		private AudioSource OutdoorSource;

		public static EnvironmentManager Instance;
		// Token: 0x0400A9EC RID: 43500
		[SerializeField]
		private AudioSource OutdoorMixSource;

		// Token: 0x0400A9ED RID: 43501
		[SerializeField]
		private AudioSource BunkerSource;

		// Token: 0x0400A9EE RID: 43502
		[SerializeField]
		private AudioSource IndoorSource;

		// Token: 0x0400A9EF RID: 43503
		[Header("Rain")]
		[SerializeField]
		private AudioSource Rain1;

		// Token: 0x0400A9F0 RID: 43504
		[SerializeField]
		private AudioSource Rain2;

		// Token: 0x0400A9F1 RID: 43505
		[SerializeField]
		private AudioClip[] OutdoorRainClips;

		// Token: 0x0400A9F2 RID: 43506
		[SerializeField]
		private AudioClip[] IndoorRainClips;

		// Token: 0x0400A9F3 RID: 43507
		[SerializeField]
		private float NightBlendStart = 0.1f;

		// Token: 0x0400A9F4 RID: 43508
		[SerializeField]
		private float NightBlendEnd;

		// Token: 0x0400A9F5 RID: 43509
		[Header("Outdoor")]
		[SerializeField]
		private float OutdoorFadeTime = 0.25f;

		// Token: 0x0400A9F6 RID: 43510
		[SerializeField]
		private float OutdoorExposureSpeed = 2f;

		// Token: 0x0400A9F7 RID: 43511
		[SerializeField]
		private float OutdoorExposureOffset = 0.23f;

		// Token: 0x0400A9F8 RID: 43512
		[SerializeField]
		private float OutdoorRainVolume = 1f;

		// Token: 0x0400A9F9 RID: 43513
		[Header("Long Shadow Reduising")]
		public bool EnableLongShadowsCorrection = true;

		// Token: 0x0400A9FA RID: 43514
		[SerializeField]
		[GAttribute6(0f, 24f, -1f)]
		private Vector2 ShadowInterval1 = new Vector2(5f, 10f);

		// Token: 0x0400A9FB RID: 43515
		[SerializeField]
		[GAttribute6(0f, 24f, -1f)]
		private Vector2 ShadowInterval2 = new Vector2(17f, 23f);

		// Token: 0x0400A9FC RID: 43516
		[SerializeField]
		private float ShadowDecreaseFactor = 3f;

		// Token: 0x0400A9FD RID: 43517
		[SerializeField]
		private float ShadowMinDistance = 20f;
	}
}
