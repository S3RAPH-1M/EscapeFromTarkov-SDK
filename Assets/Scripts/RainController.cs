using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RainController : MonoBehaviour
{
	public enum ERainIntensity
	{
		None = 0,
		Low = 1,
		Med = 2,
		High = 3
	}

	[GAttribute6(0f, 1f, -1f)]
	public Vector2 PuddleWaterLevel = new Vector2(0f, 0.95f);

	[SerializeField]
	private DepthPhotograper _depthPhotograper;

	[SerializeField]
	private RainSplashController _rainSplashController;

	[SerializeField]
	private RainFallDrops _rainFallDrops;

	[SerializeField]
	private WetRenderer _wetRenderer;

	[SerializeField]
	private RippleController _rippleController;

	[CompilerGenerated]
	private static bool bool_0;

	[CompilerGenerated]
	private static float float_0;

	[CompilerGenerated]
	private static float float_1;

	[CompilerGenerated]
	private static Vector3 vector3_0;

	private RainScreenDrops rainScreenDrops_0;



	private Transform transform_0;

	private static readonly List<RainCondensator> list_0 = new List<RainCondensator>();

	private static readonly int int_0 = Shader.PropertyToID("_WaterLevel");

	private static readonly int int_1 = Shader.PropertyToID("_RainIntensity");

	public static bool IsCameraUnderRain
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		private set
		{
			bool_0 = value;
		}
	}

	public static float Intensity
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		private set
		{
			float_0 = value;
		}
	}

	public static float WettingIntensity
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		private set
		{
			float_1 = value;
		}
	}

	public static ERainIntensity IntensityType
	{
		get
		{
			if (Intensity > 0.7f)
			{
				return ERainIntensity.High;
			}
			if (Intensity > 0.2f)
			{
				return ERainIntensity.Med;
			}
			if (Intensity > 0.01f)
			{
				return ERainIntensity.Low;
			}
			return ERainIntensity.None;
		}
	}

	public static Vector3 FallingVectorV3
	{
		[CompilerGenerated]
		get
		{
			return vector3_0;
		}
		[CompilerGenerated]
		private set
		{
			vector3_0 = value;
		}
	}

	
}
