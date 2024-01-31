using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DeferredDecals;
using EFT;
using EFT.Ballistics;
using EFT.Particles;
using UnityEngine;

namespace Systems.Effects
{
	// Token: 0x02000B32 RID: 2866
	public class Effects : MonoBehaviour
	{
		// Token: 0x040047B0 RID: 18352
		private static readonly int int_0;

		// Token: 0x040047B1 RID: 18353
		public DeferredDecalRenderer DeferredDecals;

		// Token: 0x040047B2 RID: 18354
		public bool UseDecalPainter;

		// Token: 0x040047B3 RID: 18355
		public TextureDecalsPainter TexDecals;

		// Token: 0x040047B4 RID: 18356
		public ParticleSystem MuzzleFumeParticleSystem;

		// Token: 0x040047B5 RID: 18357
		public SimpleSparksRenderer MuzzleSparkParticleSystem;

		// Token: 0x040047B6 RID: 18358
		public ParticleSystem MuzzleHeatParticleSystem;

		// Token: 0x040047B7 RID: 18359
		public ParticleSystem MuzzleHeatHazeParticleSystem;

		// Token: 0x040047B8 RID: 18360
		public SoundBank[] AdditionalSoundEffects;

		// Token: 0x040047B9 RID: 18361
		public Effects.Effect[] EffectsArray;

		// Token: 0x040047BA RID: 18362
		public Effects.EmissionEffect[] EmissionEffects;

		// Token: 0x040047BB RID: 18363
		private EffectsCommutator effectsCommutator_0;

		// Token: 0x040047BD RID: 18365
		private Dictionary<MaterialType, Effects.Effect> dictionary_0;

		// Token: 0x040047BE RID: 18366
		private Dictionary<string, Effects.Effect> dictionary_1;

		// Token: 0x040047BF RID: 18367
		private List<Effects.GStruct64> list_0;

		// Token: 0x02000B33 RID: 2867
		[Serializable]
		public class EmissionEffect
		{
			// Token: 0x040047C0 RID: 18368
			public string Key;

			// Token: 0x040047C1 RID: 18369
			public GrenadeEmission Instance;

			// Token: 0x040047C2 RID: 18370
			private List<GrenadeEmission> _cache;
		}

		// Token: 0x02000B34 RID: 2868
		public struct GStruct64
		{
			// Token: 0x040047C3 RID: 18371
			public Effects.Effect Effect;

			// Token: 0x040047C4 RID: 18372
			public Vector3 Position;

			// Token: 0x040047C5 RID: 18373
			public Vector3 Normal;

			// Token: 0x040047C6 RID: 18374
			public BallisticCollider HitCollider;

			// Token: 0x040047C7 RID: 18375
			public bool WithDecal;

			// Token: 0x040047C8 RID: 18376
			public float Volume;

			// Token: 0x040047C9 RID: 18377
			public bool IsKnife;

			// Token: 0x040047CA RID: 18378
			public bool IsHitPointVisible;

			// Token: 0x040047CB RID: 18379
			public bool IsGrenade;

			// Token: 0x040047CC RID: 18380
			public EPointOfView Pov;
		}

		// Token: 0x02000B35 RID: 2869
		[Serializable]
		public class Effect
		{
			// Token: 0x040047CD RID: 18381
			public string Name;

			// Token: 0x040047CE RID: 18382
			public MaterialType[] MaterialTypes;

			// Token: 0x040047CF RID: 18383
			public BasicParticleSystemMediator BasicParticleSystemMediator;

			// Token: 0x040047D0 RID: 18384
			public Effects.Effect.ParticleSys[] Particles;

			// Token: 0x040047D1 RID: 18385
			public SoundBank Sound;

			// Token: 0x040047D2 RID: 18386
			public SoundBank SoundFP;

			// Token: 0x040047D3 RID: 18387
			public DecalSystem Decal;

			// Token: 0x040047D4 RID: 18388
			public bool Flash;

			// Token: 0x040047D5 RID: 18389
			public int FlareID;

			// Token: 0x040047D6 RID: 18390
			public float FlashMaxDist;

			// Token: 0x040047D7 RID: 18391
			public float FlashTime;

			// Token: 0x040047D8 RID: 18392
			public bool Light;

			// Token: 0x040047D9 RID: 18393
			public Color LightColor;

			// Token: 0x040047DA RID: 18394
			public float LightMaxDist;

			// Token: 0x040047DB RID: 18395
			public float LightRange;

			// Token: 0x040047DC RID: 18396
			public float LightIntensity;

			// Token: 0x040047DD RID: 18397
			public float LightTime;

			// Token: 0x040047DE RID: 18398
			public float ParticlesShift;

			// Token: 0x040047DF RID: 18399
			public bool WithShadows;

			// Token: 0x040047E0 RID: 18400
			public bool Wind;

			// Token: 0x040047E1 RID: 18401
			public float WindIntensity;

			// Token: 0x040047E2 RID: 18402
			public float WindRadius;

			// Token: 0x040047E3 RID: 18403
			public float WindTime;

			// Token: 0x040047E4 RID: 18404
			public float WindMaxDist;

			// Token: 0x040047E5 RID: 18405
			public const string CHOKE_IMPACT_KEY = "Impact";

			// Token: 0x040047E6 RID: 18406
			public const string CHOKE_GRENADE_KEY = "Grenade";

			// Token: 0x040047E7 RID: 18407
			public bool UseDeferredDecals;

			// Token: 0x040047E8 RID: 18408
			[HideInInspector]
			public DeferredDecalRenderer DeferredDecals;

			// Token: 0x040047EA RID: 18410
			private Vector2 _impactsGagRadius;

			// Token: 0x02000B36 RID: 2870
			[Serializable]
			public class ParticleSys
			{
				// Token: 0x040047EB RID: 18411
				public Emitter Particle;

				// Token: 0x040047EC RID: 18412
				public Vector2 Distance;

				// Token: 0x040047ED RID: 18413
				public Effects.Effect.ParticleSys.Type RandomType;

				// Token: 0x040047EE RID: 18414
				public int MinCount;

				// Token: 0x040047EF RID: 18415
				public int RandomCountRange;

				// Token: 0x040047F0 RID: 18416
				public bool UseRandomScale;

				// Token: 0x040047F1 RID: 18417
				public Vector3 RandomScale;

				// Token: 0x02000B37 RID: 2871
				public enum Type
				{
					// Token: 0x040047F3 RID: 18419
					Forward,
					// Token: 0x040047F4 RID: 18420
					Cone,
					// Token: 0x040047F5 RID: 18421
					Hemisphere,
					// Token: 0x040047F6 RID: 18422
					Circle,
					// Token: 0x040047F7 RID: 18423
					ConeNormalized,
					// Token: 0x040047F8 RID: 18424
					Cone60
				}
			}
		}
	}
}