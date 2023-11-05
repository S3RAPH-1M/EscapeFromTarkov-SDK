using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

[ExecuteInEditMode]

public class AmbientLight: MonoBehaviour
{
	private class Class384
	{
		public CommandBuffer CbStencil;

		public CommandBuffer CbAmbient;

		public RenderTexture Texture;

		public bool HDR;

		public bool WasRendering;
	}

	[Serializable]
	public class CullingSettings
	{
		public float Distance = 100f;

		public float FadeLength = 5f;

		private float _maxSqrtDistance;

		private float _minSqrtDistance;

		private float _invSqrtDistRange;

		public void Update()
		{
			_maxSqrtDistance = Distance * Distance;
			_minSqrtDistance = (Distance - FadeLength) * (Distance - FadeLength);
			_invSqrtDistRange = 1f / (_minSqrtDistance - _maxSqrtDistance);
		}

		public bool PassCulling(float sqrtDistance, out float fadeValue)
		{
			if (sqrtDistance > _maxSqrtDistance)
			{
				fadeValue = 0f;
				return false;
			}
			if (sqrtDistance < _minSqrtDistance)
			{
				fadeValue = 1f;
				return true;
			}
			fadeValue = (sqrtDistance - _maxSqrtDistance) * _invSqrtDistRange;
			return true;
		}
	}

	private readonly Dictionary<Camera, Class384> dictionary_0 = new Dictionary<Camera, Class384>();

	
	public static bool UseSortedSources = true;


	public Shader DepthWriteShader;

	public Shader ClearStencilShader;

	public Shader WriteStencilShader;

	public Shader ScreenAmbientShader;


	[Space]
	public float AmbientBlur;

	[Header("Reflections")]
	public float ReflectionIntensity;

	public float ReflectionIntensitySSR = 1f;

	public float RenderDelay = 0.05f;

	public int QubemapResolution = 128;

	public LayerMask CullingMask;

	[Range(0f, 1f)]
	public float ReflectionBottomShade;

	public AnimationCurve _reflectionWettingFunc = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

	private Material material_0;

	private Material material_1;

	private Material material_2;

	private Material material_3;

	private Material material_4;

	private MaterialPropertyBlock materialPropertyBlock_0;

	private static Mesh mesh_0;

	private static Mesh mesh_1;

	private static readonly Matrix4x4 matrix4x4_0 = Matrix4x4.identity;

	private static int[] int_0;

	private static int[] int_1;

	private static int int_2;

	private bool bool_0;

	private readonly List<UnityEngine.Object> list_0 = new List<UnityEngine.Object>();

	private RenderTexture renderTexture_0;

	private int int_3 = -1;

	private Camera camera_0;

	private float float_0;

	private static readonly int int_4 = Shader.PropertyToID("_Cull");

	private static readonly int int_5 = Shader.PropertyToID("_ZTest");

	private static readonly int int_6 = Shader.PropertyToID("_SrcBlend");

	private static readonly int int_7 = Shader.PropertyToID("_DstBlend");

	private static readonly int int_8 = Shader.PropertyToID("_CullingFade");

	private static readonly int int_9 = Shader.PropertyToID("_AmbientBlur");

	private static readonly int int_10 = Shader.PropertyToID("_EFT_Ambient");

	private static readonly int int_11 = Shader.PropertyToID("_ReflectionIntensity");

	private static readonly int int_12 = Shader.PropertyToID("_ReflectionBottomShade");

	private static readonly int int_13 = Shader.PropertyToID("_MyGlobalReflectionProbe");

	private static readonly string string_0 = "StencilShadows";

	private static readonly string string_1 = "AnalyticSources";

	private static readonly string string_2 = "DynamicAnalyticSources";

	private RenderTexture RenderTexture_0
	{
		get
		{
			if (renderTexture_0 != null)
			{
				return renderTexture_0;
			}
			renderTexture_0 = new RenderTexture(QubemapResolution, QubemapResolution, 0, RenderTextureFormat.ARGBHalf)
			{
				name = "AmbientLight _cubeRT",
				dimension = TextureDimension.Cube,
				useMipMap = true,
				hideFlags = HideFlags.DontSave,
				autoGenerateMips = true
			};
			Shader.SetGlobalTexture(int_13, renderTexture_0);
			return renderTexture_0;
		}
	}



	
}
