using UnityEngine;

namespace EFT.Interactive
{
	public sealed class LampController : Turnable
	{
		// Token: 0x0400ACC4 RID: 44228
		private const float float_0 = 30f;

		// Token: 0x0400ACC5 RID: 44229
		[SerializeField]
		private AnimationCurve _animationCurve;

		// Token: 0x0400ACC6 RID: 44230
		[SerializeField]
		private bool _useCurve;

		// Token: 0x0400ACC7 RID: 44231
		[SerializeField]
		private AudioSource AudioSource;

		// Token: 0x0400ACC8 RID: 44232
		[Space(32f)]
		public Light[] Lights = new Light[0];

		// Token: 0x0400ACC9 RID: 44233
		public BaseLight[] AreaAndTubeLights = new BaseLight[0];

		// Token: 0x0400ACCA RID: 44234
		public AdvancedLight[] CustomLights = new AdvancedLight[0];

		// Token: 0x0400ACCB RID: 44235
		[SerializeField]
		private MultiFlareLight[] MultiFlareLights = new MultiFlareLight[0];

		// Token: 0x0400ACCC RID: 44236
		[SerializeField]
		private MaterialEmission[] _materialEmissions = new MaterialEmission[0];

		// Token: 0x0400ACCD RID: 44237
		[SerializeField]
		private MaterialColor[] Materials;

		// Token: 0x0400ACCE RID: 44238
		[SerializeField]
		private GameObject[] OnObjects;

		// Token: 0x0400ACCF RID: 44239
		[SerializeField]
		private GameObject[] OffObjects;

		// Token: 0x0400ACD0 RID: 44240
		[SerializeField]
		private GameObject[] DestroyedObjects;

		// Token: 0x0400ACD1 RID: 44241
		[Header("Working Interval (hours)")]
		public bool isTimeOfDayDependant;

		// Token: 0x0400ACD2 RID: 44242
		public bool isCertainInterval;

		// Token: 0x0400ACD3 RID: 44243
		[GAttribute6(0f, 12f, -1f)]
		public Vector2 MinMaxAmount1 = new Vector2(0f, 7f);

		// Token: 0x0400ACD4 RID: 44244
		[GAttribute6(12f, 24f, -1f)]
		public Vector2 MinMaxAmount2 = new Vector2(22f, 24f);

		// Token: 0x0400ACD5 RID: 44245
		[Header("Audio")]
		public int Rolloff = 60;

		// Token: 0x0400ACD6 RID: 44246
		[SerializeField]
		private AudioClip TurnOffClip;

		// Token: 0x0400ACD7 RID: 44247
		[SerializeField]
		private AudioClip TurnedOnClipStart;

		// Token: 0x0400ACD8 RID: 44248
		[SerializeField]
		private AudioClip TurnedOnClipLoop;

		// Token: 0x0400ACD9 RID: 44249
		[SerializeField]
		private AudioClip FlickeringClipLoop;

		// Token: 0x0400ACDA RID: 44250
		[SerializeField]
		private float PitchRandom;

		// Token: 0x0400ACDB RID: 44251
		[Space(32f)]
		[SerializeField]
		private Vector2 TurnedOnLengthMinMax;

		// Token: 0x0400ACDC RID: 44252
		[SerializeField]
		private Vector2 TurnedOffLengthMinMax;

		// Token: 0x0400ACDD RID: 44253
		[SerializeField]
		private float FadeInPower;

		// Token: 0x0400ACDE RID: 44254
		[SerializeField]
		private float FadeOutPower;

		// Token: 0x0400ACDF RID: 44255
		[Space(32f)]
		[SerializeField]
		private bool Blinking;

		// Token: 0x0400ACE0 RID: 44256
		[SerializeField]
		private float BlinkingFreq;

		// Token: 0x0400ACE1 RID: 44257
		[SerializeField]
		private float SingleBlinkLength;

		// Token: 0x0400ACE2 RID: 44258
		[Range(0f, 1f)]
		[SerializeField]
		private float Randomness;

		// Token: 0x0400ACE3 RID: 44259
		[Space(32f)]
		public float FlickeringFreq;

		// Token: 0x0400ACE4 RID: 44260
		[SerializeField]
		private float TurningOnFlickering;

		// Token: 0x0400ACE5 RID: 44261
		[SerializeField]
		private float TurningOffFlickering;

		// Token: 0x0400ACE6 RID: 44262
		[SerializeField]
		private float TurnedOnFlickering;

		// Token: 0x0400ACE7 RID: 44263
		[SerializeField]
		[Header("Flick Audio")]
		[Space(32f)]
		private AudioClip[] TurnOnClips;

		// Token: 0x0400ACE8 RID: 44264
		[SerializeField]
		private float FlickHighTreshold = 0.8f;

		// Token: 0x0400ACE9 RID: 44265
		[SerializeField]
		private float FlickLowTreshold = 0.35f;

		// Token: 0x0400ACEA RID: 44266
		[SerializeField]
		private Vector2 FlickVolume = new Vector2(0.3f, 0.7f);

		// Token: 0x0400ACEB RID: 44267
		[SerializeField]
		[Header("Damage")]
		private string SparksEffect = "Glass";

		// Token: 0x0400ACEC RID: 44268
		[SerializeField]
		private Vector2 SparksFreq = new Vector2(2f, 3f);

		// Token: 0x0400ACED RID: 44269
		[SerializeField]
		private string DestroyEffect = "Lamp";

		// Token: 0x0400ACEE RID: 44270
		[SerializeField]
		private float IntactTime;

		// Token: 0x0400ACEF RID: 44271
		[Range(0f, 1f)]
		[SerializeField]
		private float JointBreakProbability;

		// Token: 0x0400ACF0 RID: 44272
		[SerializeField]
		private Transform SparksEmmiterTransform;

		// Token: 0x0400ACF1 RID: 44273
		[SerializeField]
		private Transform DestroyEffectPivot;

		// Token: 0x0400ACF2 RID: 44274
		[SerializeField]
		private Vector3 EffectDirection;
	}
}