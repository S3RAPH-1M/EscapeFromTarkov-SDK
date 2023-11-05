using System;

using UnityEngine;
using UnityEngine.Rendering;

namespace EFT.Weather
{
	[Serializable]
	public class ToDController
	{
		public struct GStruct225
		{
			public SphericalHarmonicsL2 FullSH;

			public SphericalHarmonicsL2 SHWithoutTop;
		}

		[Header("midnight(-1) sunrize/sunset(0) midday(1)")]
		public Vector2 RayleighMultiplierMinMax;

		public AnimationCurve RayleighMultiplier;

		public Vector2 MieMultiplierMinMax;

		public AnimationCurve MieMultiplier;

		[Header("1 - DirectionalityMult * Directionality")]
		public float DirectionalityMult;

		public AnimationCurve Directionality;

		public Vector2 BrightnessMinMax;

		public AnimationCurve Brightness;

		public float ScatteringBrightnessMultiplier = 1f;

		public AnimationCurve ScatteringBrightness;

		public float BrightnessOvercast;

		public Vector2 ContrastMinMax;

		public AnimationCurve Contrast;

		[GAttribute6(0f, 1f, -1f)]
		[Space(16f)]
		public Vector2 MoonLightMinMax;

		[Space(16f)]
		public Gradient LightColor;

		[Header("SHAmbient")]
		public AmbientLight AmbientLightScript;

		public AmbientHighlight AmbientHighlightScript;

		public bool HighlightWithoutTopHarmonics = true;

		[Space(16f)]
		public AnimationCurve TopHarmonicIntensity;

		public AnimationCurve HorizontHarmonicIntensity;

		public AnimationCurve BounceHarmonicIntensity;

		public AnimationCurve ForwarHarmonicIntensity;

		[Space(16f)]
		public Gradient ForwarHarmonicMultiplyer = new Gradient
		{
			colorKeys = new GradientColorKey[1]
			{
				new GradientColorKey(new Color(0.5f, 0.5f, 0.5f), 0f)
			}
		};

		public Gradient BackwardHarmonicMultiplyer = new Gradient
		{
			colorKeys = new GradientColorKey[1]
			{
				new GradientColorKey(new Color(0.5f, 0.5f, 0.5f), 0f)
			}
		};

		[Space(16f)]
		public Gradient AddTopAmbient;

		public Gradient AddAmbient;

		[Space(16f)]
		public AnimationCurve AmbientBrightness;

		public AnimationCurve AmbientSaturation;

		public AnimationCurve AmbientContrast;

		public Color CloudnessLightColor;

		private readonly Vector3[] _dirs = new Vector3[5]
		{
			Vector3.up,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero
		};

		private readonly float[] _qualityUpdateIntervals = new float[4] { 1f, 0.5f, 0.1f, 0f };

		public SphericalHarmonicsL2 SH { get; private set; }

		public Color TopHorizontSkyColor { get; private set; }

		public Color EnvironmentColor { get; set; } = new Color(0.013f, 0.013f, 0.013f, 0f);


		public float HarmonicsDaylight { get; set; }

	}
}
