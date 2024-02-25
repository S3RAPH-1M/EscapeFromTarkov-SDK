using System.Collections.Generic;
using EFT.EnvironmentEffect;
using Prism.Utils;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("PRISM/Prism Effects")]
public class PrismEffects : MonoBehaviour
{
	public PrismPreset currentPrismPreset;

	private bool bool_0;

	public bool isParentPrism;

	public bool isChildPrism;

	private RenderTexture renderTexture_0;

	public Material m_Material;

	public Shader m_Shader;

	public Material m_Material2;

	public Shader m_Shader2;

	public PrismEffects m_MasterEffectExposure;

	private List<PrismEffects> list_0;

	public Material m_AOMaterial;

	public Shader m_AOShader;

	public Material m_Material3;

	public Shader m_Shader3;

	private Camera camera_0;

	public bool doBigPass = true;

	public bool useSeparableBlur = true;

	public Texture2D lensDirtTexture;

	public bool useLensDirt = true;

	[Space(10f)]
	public bool useBloom;

	public bool bloomUseScreenBlend;

	public BloomType bloomType = BloomType.HDR;

	public bool debugBloomTex;

	[Range(1f, 12f)]
	public int bloomDownsample = 2;

	[Range(0f, 12f)]
	public int bloomBlurPasses = 4;

	public float bloomIntensity = 0.15f;

	[Range(-2f, 2f)]
	public float bloomThreshold = 0.01f;

	public float dirtIntensity = 1f;

	public bool useBloomStability = true;

	private RenderTexture renderTexture_1;

	public bool useUIBlur;

	public int uiBlurGrabTextureFromPassNumber = 2;

	private RenderTexture renderTexture_2;

	[Space(10f)]
	public bool useVignette;

	public float vignetteStart = 0.9f;

	public float vignetteEnd = 0.4f;

	public float vignetteStrength = 1f;

	public Color vignetteColor = Color.black;

	[Space(10f)]
	public bool useNightVision;

	[SerializeField]
	[Tooltip("The main color of the NV effect")]
	public Color m_NVColor = new Color(0f, 1f, 0.1724138f, 0f);

	[Tooltip("The color that the NV effect will 'bleach' towards (white = default)")]
	[SerializeField]
	public Color m_TargetBleachColor = new Color(1f, 1f, 1f, 0f);

	[Range(0f, 0.1f)]
	[Tooltip("How much base lighting does the NV effect pick up")]
	public float m_baseLightingContribution = 0.025f;

	[Range(0f, 128f)]
	[Tooltip("The higher this value, the more bright areas will get 'bleached out'")]
	public float m_LightSensitivityMultiplier = 100f;

	[Space(10f)]
	public bool useNoise;

	public Texture2D noiseTexture;

	public float noiseScale = 1f;

	public float noiseIntensity = 0.2f;

	public NoiseType noiseType = NoiseType.RandomTimeNoise;

	[Space(10f)]
	public bool useChromaticAberration;

	public AberrationType aberrationType = AberrationType.Vertical;

	[Range(0f, 1f)]
	public float chromaticDistanceOne = 0.29f;

	[Range(0f, 1f)]
	public float chromaticDistanceTwo = 0.599f;

	public float chromaticIntensity = 0.03f;

	public float chromaticBlurWidth = 1f;

	public bool useChromaticBlur;

	[Space(10f)]
	public bool useTonemap;

	public TonemapType tonemapType = TonemapType.RomB;

	public Vector3 toneValues = new Vector3(-1f, 2.72f, 0.15f);

	public Vector3 secondaryToneValues = new Vector3(0.59f, 0.14f, 0.14f);

	public bool useExposure;

	public bool debugViewExposure;

	private RenderTexture renderTexture_3;

	public float exposureMiddleGrey = 0.12f;

	public float exposureLowerLimit = -6f;

	public float exposureUpperLimit = 6f;

	public float exposureSpeed = 6f;

	public int histWidth = 1;

	public int histHeight = 1;

	private bool bool_1 = true;

	public bool useGammaCorrection;

	public float gammaValue = 1f;

	[Space(10f)]
	public bool useDof;

	public bool dofForceEnableMedian;

	public bool useNearDofBlur;

	public bool useFullScreenBlur;

	public float dofNearFocusDistance = 15f;

	public float dofFocusPoint = 5f;

	public float dofFocusDistance = 15f;

	public float dofRadius = 0.6f;

	public float dofBokehFactor = 60f;

	public DoFSamples dofSampleAmount = DoFSamples.Medium;

	public bool dofBlurSkybox = true;

	public bool debugDofPass;

	public Transform dofFocusTransform;

	[Space(10f)]
	public bool useLut;

	public Texture2D twoDLookupTex;

	public Texture3D threeDLookupTex;

	public string basedOnTempTex = "";

	public float lutLerpAmount = 0.6f;

	public bool useSecondLut;

	public Texture2D secondaryTwoDLookupTex;

	public Texture3D secondaryThreeDLookupTex;

	public string secondaryBasedOnTempTex = "";

	public float secondaryLutLerpAmount;

	[Space(10f)]
	public bool useSharpen;

	public float sharpenAmount = 1f;

	public bool useFog;

	public bool fogAffectSkybox;

	public float fogIntensity;

	public float fogStartPoint = 50f;

	public float fogDistance = 170f;

	public Color fogColor = Color.white;

	public Color fogEndColor = Color.gray;

	public float fogHeight = 2f;

	public bool useAmbientObscurance;

	public SampleCount aoSampleCount = SampleCount.Low;

	public bool useAODistanceCutoff;

	public float aoDistanceCutoffLength = 50f;

	public float aoDistanceCutoffStart = 500f;

	public float aoIntensity = 0.7f;

	public float aoMinIntensity;

	public float aoRadius = 1f;

	public bool aoDownsample;

	public AOBlurType aoBlurType = AOBlurType.Fast;

	[Range(0f, 3f)]
	public int aoBlurIterations = 1;

	public float aoBias = 0.1f;

	public float aoBlurFilterDistance = 1.25f;

	public float aoLightingContribution = 1f;

	public bool aoShowDebug;

	public bool useRays;

	public Transform rayTransform;

	public float rayWeight = 0.58767f;

	public Color rayColor = Color.white;

	public Color rayThreshold = new Color(0.87f, 0.74f, 0.65f);

	public bool raysShowDebug;

	[Space(10f)]
	public bool advancedVignette;

	public bool advancedAO;

	private static readonly int int_0 = Shader.PropertyToID("_BloomIntensity");

	private static readonly int int_1 = Shader.PropertyToID("_BloomThreshold");

	private static readonly int int_2 = Shader.PropertyToID("_DirtIntensity");

	private static readonly int int_3 = Shader.PropertyToID("_FogIntensity");

	private static readonly int int_4 = Shader.PropertyToID("_VignetteStart");

	private static readonly int int_5 = Shader.PropertyToID("_VignetteEnd");

	private static readonly int int_6 = Shader.PropertyToID("_VignetteIntensity");

	private static readonly int int_7 = Shader.PropertyToID("_VignetteColor");

	private static readonly int int_8 = Shader.PropertyToID("_NVColor");

	private static readonly int int_9 = Shader.PropertyToID("_TargetWhiteColor");

	private static readonly int int_10 = Shader.PropertyToID("_BaseLightingContribution");

	private static readonly int int_11 = Shader.PropertyToID("_LightSensitivityMultiplier");

	private static readonly int int_12 = Shader.PropertyToID("_GrainIntensity");

	private static readonly int int_13 = Shader.PropertyToID("_GrainTex");

	private static readonly int int_14 = Shader.PropertyToID("_RandomInts");

	private static readonly int int_15 = Shader.PropertyToID("_ChromaticIntensity");

	private static readonly int int_16 = Shader.PropertyToID("_ChromaticParams");

	private static readonly int int_17 = Shader.PropertyToID("_ToneParams");

	private static readonly int int_18 = Shader.PropertyToID("_SecondaryToneParams");

	private static readonly int int_19 = Shader.PropertyToID("_Gamma");

	private static readonly int int_20 = Shader.PropertyToID("_SharpenAmount");

	private static readonly int int_21 = Shader.PropertyToID("_DirtTex");

	private static readonly int int_22 = Shader.PropertyToID("_ExposureLowerLimit");

	private static readonly int int_23 = Shader.PropertyToID("_ExposureUpperLimit");

	private static readonly int int_24 = Shader.PropertyToID("_ExposureMiddleGrey");

	private static readonly int int_25 = Shader.PropertyToID("_ExposureSpeed");

	private static readonly int int_26 = Shader.PropertyToID("useNoise");

	private static readonly int int_27 = Shader.PropertyToID("useNightVision");

	private static readonly int int_28 = Shader.PropertyToID("_SunWeight");

	private static readonly int int_29 = Shader.PropertyToID("_AOIntensity");

	private static readonly int int_30 = Shader.PropertyToID("_AOLuminanceWeighting");

	private static readonly int int_31 = Shader.PropertyToID("_AOSampleCount");

	private static readonly int int_32 = Shader.PropertyToID("_AOSpiralTurns");

	private static readonly int int_33 = Shader.PropertyToID("_SunColor");

	private static readonly int int_34 = Shader.PropertyToID("_SunThreshold");

	private static readonly int int_35 = Shader.PropertyToID("_SunPosition");

	private static readonly int int_36 = Shader.PropertyToID("_FogHeight");

	private static readonly int int_37 = Shader.PropertyToID("_FogDistance");

	private static readonly int int_38 = Shader.PropertyToID("_FogStart");

	private static readonly int int_39 = Shader.PropertyToID("_FogColor");

	private static readonly int int_40 = Shader.PropertyToID("_FogEndColor");

	private static readonly int int_41 = Shader.PropertyToID("_FogBlurSkybox");

	private static readonly int int_42 = Shader.PropertyToID("_InverseView");

	private static readonly int int_43 = Shader.PropertyToID("_AORadius");

	private static readonly int int_44 = Shader.PropertyToID("_AOBias");

	private static readonly int int_45 = Shader.PropertyToID("_AOTargetScale");

	private static readonly int int_46 = Shader.PropertyToID("_AOCutoff");

	private static readonly int int_47 = Shader.PropertyToID("_AOCutoffRange");

	private static readonly int int_48 = Shader.PropertyToID("_AOCameraModelView");

	private static readonly int int_49 = Shader.PropertyToID("_AOProjInfo");

	private static readonly int int_50 = Shader.PropertyToID("_LutScale");

	private static readonly int int_51 = Shader.PropertyToID("_LutOffset");

	private static readonly int int_52 = Shader.PropertyToID("_LutTex");

	private static readonly int int_53 = Shader.PropertyToID("_LutAmount");

	private static readonly int int_54 = Shader.PropertyToID("_SecondLutScale");

	private static readonly int int_55 = Shader.PropertyToID("_SecondLutOffset");

	private static readonly int int_56 = Shader.PropertyToID("_SecondLutTex");

	private static readonly int int_57 = Shader.PropertyToID("_SecondLutAmount");

	private static readonly int int_58 = Shader.PropertyToID("_DofFocusPoint");

	private static readonly int int_59 = Shader.PropertyToID("_DofFocusDistance");

	private static readonly int int_60 = Shader.PropertyToID("_DofRadius");

	private static readonly int int_61 = Shader.PropertyToID("_DofFactor");

	private static readonly int int_62 = Shader.PropertyToID("_DofUseNearBlur");

	private static readonly int int_63 = Shader.PropertyToID("_DofNearFocusDistance");

	private static readonly int int_64 = Shader.PropertyToID("_DofBlurSkybox");

	private static readonly int int_65 = Shader.PropertyToID("_BrightnessTexture");

	private static readonly int int_66 = Shader.PropertyToID("_BlurVector");

	private static readonly int int_67 = Shader.PropertyToID("_LastCameraDepthTexture1");

	private static readonly int int_68 = Shader.PropertyToID("_DoF1");

	private static readonly int int_69 = Shader.PropertyToID("_DofUseLerp");

	private static readonly int int_70 = Shader.PropertyToID("currentIteration");

	private static readonly int int_71 = Shader.PropertyToID("_BlurredScreenTex");

	private static readonly int int_72 = Shader.PropertyToID("_Bloom1");

	private static readonly int int_73 = Shader.PropertyToID("_BloomAcc");

	private static readonly int int_74 = Shader.PropertyToID("_Bloom2");

	private static readonly int int_75 = Shader.PropertyToID("_Bloom3");

	private static readonly int int_76 = Shader.PropertyToID("_Bloom4");

	private static readonly int int_77 = Shader.PropertyToID("_AOBlurVector");

	private static readonly int int_78 = Shader.PropertyToID("_AOTex");

	private static readonly int int_79 = Shader.PropertyToID("_RaysTexture");

	private bool bool_2;
}
