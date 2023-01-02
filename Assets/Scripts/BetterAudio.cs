using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using EFT;
using EFT.ItemGameSounds;
using JetBrains.Annotations;
using JsonType;
using UnityEngine;
using UnityEngine.Audio;

// Token: 0x02000771 RID: 1905
public sealed class BetterAudio : MonoBehaviour
{

	public const float TRANSITION_TIME = 0.25f;

	// Token: 0x04002CC0 RID: 11456
	public const float SOUND_SPEED = 340f;

	public WeaponSounds MiscCollisionSounds;

	// Token: 0x04002CC3 RID: 11459
	public ItemDropSounds ItemDropSounds;

	// Token: 0x04002CD2 RID: 11474
	public AudioMixer Master;

	// Token: 0x04002CD4 RID: 11476
	public AudioMixerSnapshot[] Snapshots;

	// Token: 0x04002CD5 RID: 11477
	public AudioMixerGroup MasterMixerGroup;

	// Token: 0x04002CD6 RID: 11478
	public AudioMixerGroup GunshotOccludedMixerGroup;

	// Token: 0x04002CD7 RID: 11479
	public AudioMixerGroup SimpleOccludedMixerGroup;

	// Token: 0x04002CD8 RID: 11480
	public AudioMixerGroup MutedGroup;

	// Token: 0x04002CD9 RID: 11481
	public AudioMixerGroup UpperOccluded;

	// Token: 0x04002CDA RID: 11482
	public AudioMixerGroup LowerOccluded;

	// Token: 0x04002CDB RID: 11483
	public AudioMixerGroup GunshotMixerGroup;

	// Token: 0x04002CDC RID: 11484
	public AudioMixerGroup VeryStandartMixerGroup;

	// Token: 0x04002CDD RID: 11485
	public AudioMixerGroup SelfSpeechReverb;

	// Token: 0x04002CDE RID: 11486
	public AudioMixerGroup OutEnvironment;

	// Token: 0x04002CDF RID: 11487
	public AudioMixerGroup VoipMixer;

	// Token: 0x04002CE3 RID: 11491
	public int OcclusionMask;

	// Token: 0x04002CE4 RID: 11492
	public int OcclusionHighPolyMask;

	public enum AudioSourceGroupType
	{
		// Token: 0x04002CF0 RID: 11504
		Gunshots,
		// Token: 0x04002CF1 RID: 11505
		Weaponry,
		// Token: 0x04002CF2 RID: 11506
		Impacts,
		// Token: 0x04002CF3 RID: 11507
		Character,
		// Token: 0x04002CF4 RID: 11508
		Environment,
		// Token: 0x04002CF5 RID: 11509
		Collisions,
		// Token: 0x04002CF6 RID: 11510
		Speech,
		// Token: 0x04002CF7 RID: 11511
		Distant,
		// Token: 0x04002CF8 RID: 11512
		NonspatialBypass,
		// Token: 0x04002CF9 RID: 11513
		Nonspatial,
		// Token: 0x04002CFA RID: 11514
		Voip,
		// Token: 0x04002CFB RID: 11515
		Grenades
	}
}
