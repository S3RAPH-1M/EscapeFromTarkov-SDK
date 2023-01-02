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
		// Token: 0x170010C6 RID: 4294
		// (get) Token: 0x06008811 RID: 34833 RVA: 0x0026380E File Offset: 0x00261A0E
		// (set) Token: 0x06008812 RID: 34834 RVA: 0x00263815 File Offset: 0x00261A15
		public static EnvironmentManager Instance { get; private set; }

		// Token: 0x170010C7 RID: 4295
		// (get) Token: 0x06008813 RID: 34835 RVA: 0x0026381D File Offset: 0x00261A1D
		// (set) Token: 0x06008814 RID: 34836 RVA: 0x00263825 File Offset: 0x00261A25
		public EnvironmentType Environment { get; private set; }

		// Token: 0x170010C8 RID: 4296
		// (get) Token: 0x06008815 RID: 34837 RVA: 0x0026382E File Offset: 0x00261A2E
		// (set) Token: 0x06008816 RID: 34838 RVA: 0x00263836 File Offset: 0x00261A36
		public bool InBunker { get; private set; }

		// Token: 0x170010C9 RID: 4297
		// (get) Token: 0x06008817 RID: 34839 RVA: 0x0026383F File Offset: 0x00261A3F
		// (set) Token: 0x06008818 RID: 34840 RVA: 0x00263847 File Offset: 0x00261A47
		public float PrismExposureSpeed { get; private set; }

		// Token: 0x170010CA RID: 4298
		// (get) Token: 0x06008819 RID: 34841 RVA: 0x00263850 File Offset: 0x00261A50
		// (set) Token: 0x0600881A RID: 34842 RVA: 0x00263858 File Offset: 0x00261A58
		public float PrismExposureOffset { get; private set; }

		// Token: 0x170010CB RID: 4299
		// (get) Token: 0x0600881B RID: 34843 RVA: 0x00263861 File Offset: 0x00261A61

		// Token: 0x04007C8F RID: 31887
		[Space]
		[SerializeField]
		private AudioSource OutdoorSource;

		// Token: 0x04007C90 RID: 31888
		[SerializeField]
		private AudioSource OutdoorMixSource;

		// Token: 0x04007C91 RID: 31889
		[SerializeField]
		private AudioSource BunkerSource;

		// Token: 0x04007C92 RID: 31890
		[SerializeField]
		private AudioSource IndoorSource;

		// Token: 0x04007C93 RID: 31891
		[SerializeField]
		[Header("Rain")]
		private AudioSource Rain1;

		// Token: 0x04007C94 RID: 31892
		[SerializeField]
		private AudioSource Rain2;

		// Token: 0x04007C95 RID: 31893
		[SerializeField]
		private AudioClip[] OutdoorRainClips;

		// Token: 0x04007C96 RID: 31894
		[SerializeField]
		private AudioClip[] IndoorRainClips;

		// Token: 0x04007C97 RID: 31895
		[SerializeField]
		private float NightBlendStart = 0.1f;

		// Token: 0x04007C98 RID: 31896
		[SerializeField]
		private float NightBlendEnd;

		// Token: 0x04007C99 RID: 31897
		[Header("Outdoor")]
		[SerializeField]
		private float OutdoorFadeTime = 0.25f;

		// Token: 0x04007C9A RID: 31898
		[SerializeField]
		private float OutdoorExposureSpeed = 2f;

		// Token: 0x04007C9B RID: 31899
		[SerializeField]
		private float OutdoorExposureOffset = 0.23f;

		// Token: 0x04007C9C RID: 31900
		[SerializeField]
		private float OutdoorRainVolume = 1f;

		// Token: 0x04007C9D RID: 31901
		[Header("Long Shadow Reduising")]
		public bool EnableLongShadowsCorrection = true;

		// Token: 0x04007CA0 RID: 31904
		[SerializeField]
		private float ShadowDecreaseFactor = 3f;

		// Token: 0x04007CA1 RID: 31905
		[SerializeField]
		private float ShadowMinDistance = 20f;

		// Token: 0x04007CA2 RID: 31906
		[CompilerGenerated]
		private static EnvironmentManager environmentManager_0;

		// Token: 0x04007CA3 RID: 31907
		[CompilerGenerated]
		private EnvironmentType environmentType_0;

		// Token: 0x04007CA4 RID: 31908
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04007CA5 RID: 31909
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04007CA6 RID: 31910
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04007CA7 RID: 31911
		private AudioSource audioSource_0;

		// Token: 0x04007CA9 RID: 31913
		private float float_2;

		// Token: 0x04007CAA RID: 31914
		private float float_3;

		// Token: 0x04007CAB RID: 31915
		private float float_4 = 1f;

		// Token: 0x04007CAC RID: 31916
		private Coroutine coroutine_0;

		// Token: 0x04007CAD RID: 31917
		private Coroutine coroutine_1;

		// Token: 0x04007CAE RID: 31918
		private float float_5;

		// Token: 0x04007CAF RID: 31919
		private float float_6 = 0.25f;

		// Token: 0x04007CB0 RID: 31920
		private float float_7;

		// Token: 0x04007CB1 RID: 31921
		private float float_8;
		// Token: 0x04007CB4 RID: 31924
		private int int_0;

	}
}
