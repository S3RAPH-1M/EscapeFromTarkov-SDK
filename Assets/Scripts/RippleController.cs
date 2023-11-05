using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode]
public class RippleController : MonoBehaviour
{
	[Serializable]
	public class Cycle
	{
		public float CucleSpeed = 0.4f;

		[GAttribute6(0.0001f, 1f, -1f)]
		public Vector2 CucleLengthRelationMinMax = new Vector2(0.01f, 1f);

		[GAttribute6(0f, 1f, -1f)]
		public Vector2 IntensityMinMax = new Vector2(0f, 0.1f);

		private float _time;

		private float _lastCucleLengthRelation = 1f;

		public Vector4 Update(float dt, float intensity)
		{
			_time += dt * CucleSpeed;
			float num = 1f / Mathf.Lerp(CucleLengthRelationMinMax.x, CucleLengthRelationMinMax.y, intensity);
			_time = smethod_0(_time, _lastCucleLengthRelation, num);
			_lastCucleLengthRelation = num;
			return new Vector4(_time, _lastCucleLengthRelation, Mathf.InverseLerp(IntensityMinMax.x, IntensityMinMax.y, intensity));
		}

		private static float smethod_0(float currentTime, float lastCucleLengthRelation, float newCucleLengthRelation)
		{
			return currentTime * (newCucleLengthRelation / lastCucleLengthRelation);
		}
	}

	private static int int_0;

	private static int int_1;

	private static int int_2;

	private static int int_3;

	private static int int_4;

	private static int int_5;

	private static int int_6;

	private static int int_7;

	private static int int_8;

	private static int int_9;

	private static int int_10;

	private static bool bool_0;

	[CompilerGenerated]
	private float float_0;

	public Texture2D RippleTexture;

	[Header("Water Ripples")]
	public Cycle WaterCucle;

	public int RippleWaveCount = 3;

	public float RippleWaveFreq = 3f;

	[Header("Environment Ripples")]
	public Cycle EnvironmentCucle;

	[Range(0f, 1f)]
	public float WetDropsSpecular = 0.576f;

	[Range(0f, 1f)]
	public float WetDropsGlossness = 0.553f;

	[Range(0f, 1f)]
	public float WetDropsAlbedo = 0.248f;

	[Range(0f, 1f)]
	public float WetDropsNormal = 1f;

	[Range(0f, 3f)]
	public float RippleFakeLightIntensity = 0.4f;

	[Range(0f, 5f)]
	public float RainIntensityRippleScale = 2f;

	[SerializeField]
	private bool _forceTriplanar = true;

	[SerializeField]
	private bool _useFakeRippleLight = true;

	public float Intensity
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
