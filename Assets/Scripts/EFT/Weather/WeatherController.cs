using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace EFT.Weather
{
	public class WeatherController : MonoBehaviour
	{
		public static WeatherController Instance;

		public CloudsController CloudsController;

		public LightningController LightningController;

		public WindController WindController;

		public RainController RainController;

		public Camera PlayerCamera;

		[Header("GlobalFog")]
		public Gradient GlobalFogColor;

		public float GlobalFogOvercast;

		public AnimationCurve GlobalFogY;

		public AnimationCurve GlobalFogStrength;

		[Header("Smoke")]
		public AnimationCurve SmokeDesaturation;

		[GAttribute6(-0.5f, 1f, -1f)]
		[Header("Desaturate")]
		public Vector2 MinMaxAmmount;

		[Tooltip("bigger value summons lightning rarely")]
		[Space(16f)]
		public float LightningSummonBandWidth = 20f;

		public float MinLyingWater;

		public AnimationCurve FogMultyplyer;

		public ToDController TimeOfDayController;

		public bool isDrawDebugGui;

		public float CubemapDayMult = 0.55f;

		public float CubemapNightMult = -0.78f;

		public int OpticCameraResolution = 1024;

		[CompilerGenerated]
		private float float_0;

		public WeatherDebug WeatherDebug;



	

		private TOD_Scattering tod_Scattering_0;

		private CustomGlobalFog customGlobalFog_0;


		private static readonly int int_0 = Shader.PropertyToID("_CubemapNightMultiplier");

		private static readonly int int_1 = Shader.PropertyToID("_CubemapDayMultiplier");

		private static readonly int int_2 = Shader.PropertyToID("_TopHorizontSkyColor");

		private static readonly int int_3 = Shader.PropertyToID("_ForceIndoor");

		private static readonly int int_4 = Shader.PropertyToID("_MinAmbientColor");

		public float SunHeight
		{
			[CompilerGenerated]
			get
			{
				return float_0;
			}
			[CompilerGenerated]
			set
			{
				float_0 = value;
			}
		}




		
	}
}
