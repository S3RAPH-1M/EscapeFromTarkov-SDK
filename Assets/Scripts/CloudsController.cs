using System;
using System.Collections.Generic;
using EFT.Weather;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
public class CloudsController : MonoBehaviour
{
	[Serializable]
	public class CloudAutomatization
	{
		[Header("midnight(left) sunrize/sunset(center) midday(right)")]
		public Gradient CloudColor;

		public Gradient SunMultyplyer;

		public Gradient BottomReflections;

		public Gradient CloudySun;

		[Range(0f, 1f)]
		public float CloudColorOvercast;

		[Range(0f, 1f)]
		public float SunMultyplyerOvercast;

		[Range(0f, 50f)]
		public float PlanetSizeOvercast;

		
		
	}

	[Serializable]
	public class CloudLayer
	{
		public bool Enabled;

		[Range(0f, 1f)]
		public float RoughnessMin;

		[Range(0f, 1f)]
		public float NoiseMapRoughness;

		[Range(-1f, 1f)]
		public float DensityShift;

		[Space(16f)]
		public float Height = 400f;

		public float Curviness = 1f;

		public float Scale = 0.1f;

		[Space(16f)]
		public float CloudPositionMultyply = 1f;

		public Vector2 CloudPositionShift;

		[Space(16f)]
		[Range(0f, 1f)]
		public float ShadowStrength;

		[HideInInspector]
		public bool IsDrawLight;

		private Material _cloudMaterial;

		private Material _lightMaterial;

		private Material _pointLightMaterial;

		private MaterialPropertyBlock _cloudBlock;

		private MaterialPropertyBlock _lightBlock;

		private MaterialPropertyBlock _pointLightBlock;

		private MaterialPropertyBlock[] _materialBlocks;

		private Texture _lightMap;

		private Vector4 _matTransform;

		private Vector4 _lightPosition;

		private Color _lightIntensity;

		private Color _pointLightIntensity;

		public float Density { private get; set; }

		public float FogDensity
		{
			set
			{
				_cloudMaterial.SetFloat(int_0, value);
			}
		}

		
	}

	[Serializable]
	public class CloudShadows
	{
		[Flags]
		private enum ECommandBufferVariant : byte
		{
			Blur = 1,
			Modify = 2,
			Draw = 4
		}

		private int _lightdirection_ID;

		private int _sunmatrix_ID;

		private int _cloudroughnessmin_ID;

		private int _cloudnoisemaproughness_ID;

		private int _clouddensity_ID;

		private int _cloudcurviness_ID;

		private int _cloudscale_ID;

		private int _cloudposition_ID;

		private int _shadowscale_ID;

		private int _shadowstrength_ID;

		private int _addColorFieldID = Shader.PropertyToID("_AddColor");

		private int _multColorFieldID = Shader.PropertyToID("_MultColor");

		private int _intensityFieldID = Shader.PropertyToID("_Intensity");

		private int _blurOffsets0FieldID = Shader.PropertyToID("_BlurOffsets0");

		public Material CloudShadowMaterial;

		public int TextureSize = 512;

		public float Blur;

		public float ViewDistance = 1000f;

		public float ShadowScale = 1f;

		private Material[] _cloudShadowMaterial;

		private Material _cloudModifyMaterial;

		private Material _cloudBlurMaterial0;

		private Material _cloudBlurMaterial1;

		private Material _cloudColorBlendMaterial;

		private Transform _playerT;

		private Vector3 _lastPlayerPosition = Vector3.zero;

		private Transform _lightT;

		private RenderTexture _renderTexture0;

		private RenderTexture _renderTexture1;

		private Light _light;

		private CommandBuffer[] _commandBuffer;

		private readonly CameraEvent _cameraEvent = CameraEvent.BeforeGBuffer;

		private ECommandBufferVariant _prevCommandBufferVariant;

		
	}

	private static readonly int int_0 = Shader.PropertyToID("_FogDensity");

	private static readonly int int_1 = Shader.PropertyToID("_CloudRoughnessMin");

	private static readonly int int_2 = Shader.PropertyToID("_CloudNoiseMapRoughness");

	private static readonly int int_3 = Shader.PropertyToID("_CloudDensity");

	private static readonly int int_4 = Shader.PropertyToID("_CloudCurviness");

	private static readonly int int_5 = Shader.PropertyToID("_CloudScale");

	private static readonly int int_6 = Shader.PropertyToID("_RealHeight");

	private static readonly int int_7 = Shader.PropertyToID("_CloudPosition");

	private static readonly int int_8 = Shader.PropertyToID("_ForwardLightWidth");

	private static readonly int int_9 = Shader.PropertyToID("_DstFactorA");

	private static readonly int int_10 = Shader.PropertyToID("_MapTransform");

	private static readonly int int_11 = Shader.PropertyToID("_LightMap");

	private static readonly int int_12 = Shader.PropertyToID("_LightColor");

	private static readonly int int_13 = Shader.PropertyToID("_LightPosition");

	public static CloudsController Instance;

	public Mesh Icosphere;

	public Material CloudMaterial;

	public Material CloudShadowMaterial;

	public Material CloudLightMaterial;

	public Material CloudPointLightMaterial;

	public float FogDensityMultyplier = 1f;

	public float SunPositionUpdateDeltaSqrMangitude = 100f;

	public CloudLayer[] CloudLayers;

	public CloudShadows Shadows;

	public CloudAutomatization Automatization;

	public Vector2 CloudPosition;

	private float float_0;

	private Mesh mesh_0;

	public float FogDensity
	{
		set
		{
			value *= FogDensityMultyplier;
			CloudLayer[] cloudLayers = CloudLayers;
			for (int i = 0; i < cloudLayers.Length; i++)
			{
				cloudLayers[i].FogDensity = value;
			}
		}
	}

	public float Density
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			CloudLayer[] cloudLayers = CloudLayers;
			for (int i = 0; i < cloudLayers.Length; i++)
			{
				cloudLayers[i].Density = value;
			}
		}
	}


}
