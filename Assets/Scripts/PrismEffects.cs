using System;
using System.Collections.Generic;
using EFT.EnvironmentEffect;
using Prism.Utils;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

// Token: 0x02000781 RID: 1921
[RequireComponent(typeof(Camera))]
[AddComponentMenu("PRISM/Prism Effects")]
public class PrismEffects : MonoBehaviour
{
	// Token: 0x17000771 RID: 1905
	// (get) Token: 0x0600323A RID: 12858 RVA: 0x000DF997 File Offset: 0x000DDB97
	public bool forceSecondChromaticPass
	{
		get
		{
			return ((this.useDof && this.useChromaticAberration) || this.useChromaticBlur) && this.useChromaticAberration;
		}
	}

	// Token: 0x17000772 RID: 1906
	// (get) Token: 0x0600323B RID: 12859 RVA: 0x000DF9B9 File Offset: 0x000DDBB9
	public RenderTexture AdaptationTexture
	{
		get
		{
			return this.renderTexture_3;
		}
	}

	// Token: 0x17000773 RID: 1907
	// (get) Token: 0x0600323C RID: 12860 RVA: 0x000DF9C1 File Offset: 0x000DDBC1
	public bool useMedianDoF
	{
		get
		{
			return (this.useBloom || this.useExposure || this.useDof) && this.dofForceEnableMedian;
		}
	}

	// Token: 0x17000774 RID: 1908
	// (get) Token: 0x0600323D RID: 12861 RVA: 0x000DF9E3 File Offset: 0x000DDBE3
	private RenderTextureFormat RenderTextureFormat_0
	{
		get
		{
			if (this.bool_2)
			{
				return RenderTextureFormat.R8;
			}
			return RenderTextureFormat.ARGB32;
		}
	}

	// Token: 0x17000775 RID: 1909
	// (get) Token: 0x0600323E RID: 12862 RVA: 0x000DF9F4 File Offset: 0x000DDBF4
	// (set) Token: 0x0600323F RID: 12863 RVA: 0x000DFA2F File Offset: 0x000DDC2F
	public int aoSampleCountValue
	{
		get
		{
			SampleCount sampleCount = this.aoSampleCount;
			if (sampleCount == SampleCount.Low)
			{
				return 10;
			}
			if (sampleCount == SampleCount.Medium)
			{
				return 14;
			}
			if (sampleCount != SampleCount.High)
			{
				return Mathf.Clamp((int)this.aoSampleCount, 1, 256);
			}
			return 18;
		}
		set
		{
			this.aoSampleCount = (SampleCount)value;
		}
	}

	// Token: 0x17000776 RID: 1910
	// (get) Token: 0x06003240 RID: 12864 RVA: 0x000DFA38 File Offset: 0x000DDC38
	public bool UsingTerrain
	{
		get
		{
			return Terrain.activeTerrain;
		}
	}

	// Token: 0x17000777 RID: 1911
	// (get) Token: 0x06003241 RID: 12865 RVA: 0x000DFA49 File Offset: 0x000DDC49
	public bool IsGBufferAvailable
	{
		get
		{
			return this.camera_0.actualRenderingPath == RenderingPath.DeferredShading;
		}
	}

	// Token: 0x06003242 RID: 12866 RVA: 0x000DFA59 File Offset: 0x000DDC59

	// Token: 0x06003243 RID: 12867 RVA: 0x000DFA67 File Offset: 0x000DDC67
	public void DontRenderPrismThisFrame()
	{
		this.bool_0 = true;
	}

	// Token: 0x06003244 RID: 12868 RVA: 0x000DFA70 File Offset: 0x000DDC70
	public Camera GetPrismCamera()
	{
		if (this.camera_0 == null)
		{
			this.camera_0 = base.GetComponent<Camera>();
		}
		return this.camera_0;
	}

	// Token: 0x06003245 RID: 12869 RVA: 0x000DFA9E File Offset: 0x000DDC9E
	public void ResetToneParamsRomB()
	{
		this.toneValues = new Vector3(-1f, 2.72f, 0.15f);
		this.secondaryToneValues = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06003246 RID: 12870 RVA: 0x000DFAD4 File Offset: 0x000DDCD4
	public void ResetToneParamsFilmic()
	{
		this.toneValues = new Vector3(6.2f, 0.5f, 1.7f);
		this.secondaryToneValues = new Vector3(0.004f, 0.06f, 0f);
	}

	// Token: 0x06003247 RID: 12871 RVA: 0x000DFB0A File Offset: 0x000DDD0A
	public void ResetToneParamsACES()
	{
		this.toneValues = new Vector3(2.51f, 0.03f, 2.43f);
		this.secondaryToneValues = new Vector3(0.59f, 0.14f, 0f);
	}

	// Token: 0x06003248 RID: 12872 RVA: 0x000DFB40 File Offset: 0x000DDD40
	public void SetGamma(float value)
	{
		this.gammaValue = value;
	}

	// Token: 0x06003249 RID: 12873 RVA: 0x000DFB49 File Offset: 0x000DDD49
	public void SetChromaticIntensity(float value)
	{
		this.chromaticIntensity = value;
	}

	// Token: 0x0600324A RID: 12874 RVA: 0x000DFB52 File Offset: 0x000DDD52
	public void SetNoiseIntensity(float value)
	{
		this.noiseIntensity = value;
	}

	// Token: 0x0600324B RID: 12875 RVA: 0x000DFB5B File Offset: 0x000DDD5B
	public void SetVignetteStrength(float value)
	{
		this.vignetteStrength = value;
	}

	// Token: 0x0600324C RID: 12876 RVA: 0x000DFB64 File Offset: 0x000DDD64
	public void SetPrimaryLutStrength(float value)
	{
		this.lutLerpAmount = value;
	}

	// Token: 0x0600324D RID: 12877 RVA: 0x000DFB6D File Offset: 0x000DDD6D
	public void SetSecondaryLutStrength(float value)
	{
		this.secondaryLutLerpAmount = value;
	}

	// Token: 0x0600324E RID: 12878 RVA: 0x000DFB78 File Offset: 0x000DDD78
	public void SetPrismPreset(PrismPreset preset)
	{
		if (!preset)
		{
			this.useBloom = false;
			this.useDof = false;
			this.useChromaticAberration = false;
			this.useVignette = false;
			this.useNoise = false;
			this.useTonemap = false;
			this.useFog = false;
			this.useNightVision = false;
			this.useExposure = false;
			this.useLut = false;
			this.useSecondLut = false;
			this.useGammaCorrection = false;
			this.useAmbientObscurance = false;
			this.useRays = false;
			this.useUIBlur = false;
			return;
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Bloom)
		{
			this.useBloom = preset.useBloom;
			this.bloomType = preset.bloomType;
			this.bloomDownsample = preset.bloomDownsample;
			this.bloomBlurPasses = preset.bloomBlurPasses;
			this.bloomIntensity = preset.bloomIntensity;
			this.bloomThreshold = preset.bloomThreshold;
			this.useBloomStability = preset.useBloomStability;
			this.bloomUseScreenBlend = preset.bloomUseScreenBlend;
			this.useLensDirt = preset.useBloomLensdirt;
			this.dirtIntensity = preset.bloomLensdirtIntensity;
			this.lensDirtTexture = preset.bloomLensdirtTexture;
			this.useFullScreenBlur = preset.useFullScreenBlur;
			this.useUIBlur = preset.useUIBlur;
			this.uiBlurGrabTextureFromPassNumber = preset.uiBlurGrabTextureFromPassNumber;
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.DepthOfField)
		{
			this.useDof = preset.useDoF;
			this.dofRadius = preset.dofRadius;
			this.dofSampleAmount = preset.dofSampleCount;
			this.dofBokehFactor = preset.dofBokehFactor;
			this.dofFocusPoint = preset.dofFocusPoint;
			this.dofFocusDistance = preset.dofFocusDistance;
			this.useNearDofBlur = preset.useNearBlur;
			this.dofBlurSkybox = preset.dofBlurSkybox;
			this.dofNearFocusDistance = preset.dofNearFocusDistance;
			this.dofForceEnableMedian = preset.dofForceEnableMedian;
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.ChromaticAberration)
		{
			this.useChromaticAberration = preset.useChromaticAb;
			this.aberrationType = preset.aberrationType;
			this.chromaticIntensity = preset.chromIntensity;
			this.chromaticDistanceOne = preset.chromStart;
			this.chromaticDistanceTwo = preset.chromEnd;
			this.useChromaticBlur = preset.useChromaticBlur;
			this.chromaticBlurWidth = preset.chromaticBlurWidth;
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Vignette)
		{
			this.useVignette = preset.useVignette;
			this.vignetteStrength = preset.vignetteIntensity;
			this.vignetteEnd = preset.vignetteEnd;
			this.vignetteStart = preset.vignetteStart;
			this.vignetteColor = preset.vignetteColor;
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Noise)
		{
			this.useNoise = preset.useNoise;
			this.noiseIntensity = preset.noiseIntensity;
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Tonemap)
		{
			this.useTonemap = preset.useTonemap;
			this.tonemapType = preset.toneType;
			this.toneValues = preset.toneValues;
			this.secondaryToneValues = preset.secondaryToneValues;
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Exposure)
		{
			this.useExposure = preset.useExposure;
			this.exposureMiddleGrey = preset.exposureMiddleGrey;
			this.exposureLowerLimit = preset.exposureLowerLimit;
			this.exposureUpperLimit = preset.exposureUpperLimit;
			this.exposureSpeed = preset.exposureSpeed;
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Gamma)
		{
			this.useGammaCorrection = preset.useGammaCorrection;
			this.gammaValue = preset.gammaValue;
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.ColorCorrection)
		{
			this.useLut = preset.useLUT;
			this.lutLerpAmount = preset.lutIntensity;
			this.basedOnTempTex = preset.lutPath;
			this.twoDLookupTex = preset.twoDLookupTex;
			this.useSecondLut = preset.useSecondLut;
			this.secondaryLutLerpAmount = preset.secondaryLutLerpAmount;
			this.secondaryBasedOnTempTex = preset.secondaryLutPath;
			this.secondaryTwoDLookupTex = preset.secondaryTwoDLookupTex;
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Nightvision)
		{
			this.useNightVision = preset.useNV;
			this.m_NVColor = preset.nvColor;
			this.m_TargetBleachColor = preset.nvBleachColor;
			this.m_baseLightingContribution = preset.nvLightingContrib;
			this.m_LightSensitivityMultiplier = preset.nvLightSensitivity;
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Fog)
		{
			this.useFog = preset.useFog;
			this.fogIntensity = preset.fogIntensity;
			this.fogStartPoint = preset.fogStartPoint;
			this.fogDistance = preset.fogDistance;
			this.fogColor = preset.fogColor;
			this.fogEndColor = preset.fogEndColor;
			this.fogHeight = preset.fogHeight;
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.AmbientObscurance)
		{
			this.useAmbientObscurance = preset.useAmbientObscurance;
			this.useAODistanceCutoff = preset.useAODistanceCutoff;
			this.aoIntensity = preset.aoIntensity;
			this.aoRadius = preset.aoRadius;
			this.aoDistanceCutoffStart = preset.aoDistanceCutoffStart;
			this.aoDownsample = preset.aoDownsample;
			this.aoBlurIterations = preset.aoBlurIterations;
			this.aoDistanceCutoffLength = preset.aoDistanceCutoffLength;
			this.aoSampleCount = preset.aoSampleCount;
			this.aoBias = preset.aoBias;
			this.aoBlurFilterDistance = preset.aoBlurFilterDistance;
			this.aoBlurType = preset.aoBlurType;
			this.aoLightingContribution = preset.aoLightingContribution;
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Godrays)
		{
			this.useRays = preset.useRays;
			this.rayWeight = preset.rayWeight;
			this.rayColor = preset.rayColor;
			this.rayThreshold = preset.rayThreshold;
		}
		if (preset.presetType == PrismPresetType.Full || !this.currentPrismPreset)
		{
			this.currentPrismPreset = preset;
		}
		this.Reset();
	}

	// Token: 0x0600324F RID: 12879 RVA: 0x000E010C File Offset: 0x000DE30C
	public void LerpToPreset(PrismPreset preset, float t)
	{
		t = Mathf.Clamp(t, 0f, 1f);
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Bloom)
		{
			this.bloomDownsample = (int)Mathf.Lerp((float)this.currentPrismPreset.bloomDownsample, (float)preset.bloomDownsample, t);
			this.bloomBlurPasses = (int)Mathf.Lerp((float)this.currentPrismPreset.bloomBlurPasses, (float)preset.bloomBlurPasses, t);
			this.bloomIntensity = Mathf.Lerp(this.currentPrismPreset.bloomIntensity, preset.bloomIntensity, t);
			this.bloomThreshold = Mathf.Lerp(this.currentPrismPreset.bloomThreshold, preset.bloomThreshold, t);
			this.dirtIntensity = Mathf.Lerp(this.currentPrismPreset.bloomLensdirtIntensity, preset.bloomLensdirtIntensity, t);
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.DepthOfField)
		{
			this.dofRadius = Mathf.Lerp(this.currentPrismPreset.dofRadius, preset.dofRadius, t);
			this.dofBokehFactor = Mathf.Lerp(this.currentPrismPreset.dofBokehFactor, preset.dofBokehFactor, t);
			this.dofFocusPoint = Mathf.Lerp(this.currentPrismPreset.dofFocusPoint, preset.dofFocusPoint, t);
			this.dofFocusDistance = Mathf.Lerp(this.currentPrismPreset.dofFocusDistance, preset.dofFocusDistance, t);
			this.dofNearFocusDistance = Mathf.Lerp(this.currentPrismPreset.dofNearFocusDistance, preset.dofNearFocusDistance, t);
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.ChromaticAberration)
		{
			this.chromaticIntensity = Mathf.Lerp(this.currentPrismPreset.chromIntensity, preset.chromIntensity, t);
			this.chromaticDistanceOne = Mathf.Lerp(this.currentPrismPreset.chromStart, preset.chromStart, t);
			this.chromaticDistanceTwo = Mathf.Lerp(this.currentPrismPreset.chromEnd, preset.chromEnd, t);
			this.chromaticBlurWidth = Mathf.Lerp(this.currentPrismPreset.chromaticBlurWidth, preset.chromaticBlurWidth, t);
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Vignette)
		{
			this.vignetteStrength = Mathf.Lerp(this.currentPrismPreset.vignetteIntensity, preset.vignetteIntensity, t);
			this.vignetteEnd = Mathf.Lerp(this.currentPrismPreset.vignetteEnd, preset.vignetteEnd, t);
			this.vignetteStart = Mathf.Lerp(this.currentPrismPreset.vignetteStart, preset.vignetteStart, t);
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Noise)
		{
			this.noiseIntensity = Mathf.Lerp(this.currentPrismPreset.noiseIntensity, preset.noiseIntensity, t);
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Tonemap)
		{
			this.toneValues = Vector3.Lerp(this.currentPrismPreset.toneValues, preset.toneValues, t);
			this.secondaryToneValues = Vector3.Lerp(this.currentPrismPreset.secondaryToneValues, preset.secondaryToneValues, t);
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Exposure)
		{
			this.exposureMiddleGrey = Mathf.Lerp(this.currentPrismPreset.exposureMiddleGrey, preset.exposureMiddleGrey, t);
			this.exposureLowerLimit = Mathf.Lerp(this.currentPrismPreset.exposureLowerLimit, preset.exposureLowerLimit, t);
			this.exposureUpperLimit = Mathf.Lerp(this.currentPrismPreset.exposureUpperLimit, preset.exposureUpperLimit, t);
			this.exposureSpeed = Mathf.Lerp(this.currentPrismPreset.exposureSpeed, preset.exposureSpeed, t);
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Gamma)
		{
			this.gammaValue = Mathf.Lerp(this.currentPrismPreset.gammaValue, preset.gammaValue, t);
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.ColorCorrection)
		{
			this.lutLerpAmount = Mathf.Lerp(this.currentPrismPreset.lutIntensity, preset.lutIntensity, t);
			this.secondaryLutLerpAmount = Mathf.Lerp(this.currentPrismPreset.secondaryLutLerpAmount, preset.secondaryLutLerpAmount, t);
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Fog)
		{
			this.fogIntensity = Mathf.Lerp(this.currentPrismPreset.fogIntensity, preset.fogIntensity, t);
			this.fogStartPoint = Mathf.Lerp(this.currentPrismPreset.fogStartPoint, preset.fogStartPoint, t);
			this.fogDistance = Mathf.Lerp(this.currentPrismPreset.fogDistance, preset.fogDistance, t);
			this.fogColor = Color.Lerp(this.currentPrismPreset.fogColor, preset.fogColor, t);
			this.fogEndColor = Color.Lerp(this.currentPrismPreset.fogEndColor, preset.fogEndColor, t);
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.AmbientObscurance)
		{
			this.aoDistanceCutoffStart = Mathf.Lerp(this.currentPrismPreset.aoDistanceCutoffStart, preset.aoDistanceCutoffStart, t);
			this.aoIntensity = Mathf.Lerp(this.currentPrismPreset.aoIntensity, preset.aoIntensity, t);
			this.aoRadius = Mathf.Lerp(this.currentPrismPreset.aoRadius, preset.aoRadius, t);
			this.aoBias = Mathf.Lerp(this.currentPrismPreset.aoBias, preset.aoBias, t);
			this.aoDistanceCutoffLength = Mathf.Lerp(this.currentPrismPreset.aoDistanceCutoffLength, preset.aoDistanceCutoffLength, t);
			this.aoBlurIterations = (int)Mathf.Lerp((float)this.currentPrismPreset.aoBlurIterations, (float)preset.aoBlurIterations, t);
			this.aoLightingContribution = (float)((int)Mathf.Lerp(this.currentPrismPreset.aoLightingContribution, preset.aoLightingContribution, t));
		}
		if (preset.presetType == PrismPresetType.Full || preset.presetType == PrismPresetType.Godrays)
		{
			this.rayWeight = Mathf.Lerp(this.currentPrismPreset.rayWeight, preset.rayWeight, t);
			this.rayColor = Color.Lerp(this.currentPrismPreset.rayColor, preset.rayColor, t);
			this.rayThreshold = Color.Lerp(this.currentPrismPreset.rayThreshold, preset.rayThreshold, t);
		}
	}

	// Token: 0x06003250 RID: 12880 RVA: 0x000E06DC File Offset: 0x000DE8DC
	private void OnEnable()
	{
		this.bool_2 = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.R8);
		this.camera_0 = base.GetComponent<Camera>();
		if (!this.m_Shader)
		{
			this.m_Shader = Shader.Find("Hidden/PrismEffects");
			if (!this.m_Shader)
			{
				Debug.LogError("Couldn't find shader for PRISM! You shouldn't see this error.");
			}
		}
		if (!this.m_Shader2)
		{
			this.m_Shader2 = Shader.Find("Hidden/PrismEffectsSecondary");
			if (!this.m_Shader2)
			{
				Debug.LogError("Couldn't find secondary shader for PRISM! You shouldn't see this error.");
			}
		}
		if (!this.m_Shader3)
		{
			this.m_Shader3 = Shader.Find("Hidden/PrismEffectsTertiary");
			if (!this.m_Shader3)
			{
				Debug.LogError("Couldn't find tertiary shader for PRISM! You shouldn't see this error.");
			}
		}
		if (!this.m_AOShader)
		{
			this.m_AOShader = Shader.Find("Hidden/PrismKinoObscurance");
			if (!this.m_AOShader)
			{
				Debug.LogError("Couldn't find ao shader for PRISM! You shouldn't see this error.");
			}
		}
		if (!this.renderTexture_3)
		{
			this.renderTexture_3 = new RenderTexture(this.histWidth, this.histHeight, 0, RenderTextureFormat.ARGB32)
			{
				name = "Current Adaptation Tex"
			};
			this.renderTexture_3.filterMode = FilterMode.Bilinear;
			this.renderTexture_3.autoGenerateMips = false;
		}
		if (this.useUIBlur)
		{
			this.renderTexture_2.name = "UI Blur Tex";
			this.renderTexture_3.filterMode = FilterMode.Bilinear;
			this.renderTexture_3.autoGenerateMips = false;
		}
		if (this.useDof || this.useFog)
		{
			this.camera_0.depthTextureMode |= DepthTextureMode.Depth;
		}
		if (this.useAmbientObscurance && (!this.IsGBufferAvailable || this.UsingTerrain))
		{
			this.camera_0.depthTextureMode |= DepthTextureMode.Depth;
			this.camera_0.depthTextureMode |= DepthTextureMode.DepthNormals;
		}
		this.bool_1 = true;
	}

	// Token: 0x06003251 RID: 12881 RVA: 0x000E091F File Offset: 0x000DEB1F
	[ContextMenu("DontRenderDepthTexture")]
	private void method_0()
	{
		this.camera_0.depthTextureMode = DepthTextureMode.None;
	}

	// Token: 0x06003252 RID: 12882 RVA: 0x000E0930 File Offset: 0x000DEB30
	private void OnDestroy()
	{
		if (this.list_0 != null)
		{
			foreach (PrismEffects prismEffects in this.list_0)
			{
				prismEffects.m_MasterEffectExposure = null;
			}
		}
		if (this.threeDLookupTex)
		{
			UnityEngine.Object.DestroyImmediate(this.threeDLookupTex);
		}
		this.threeDLookupTex = null;
		this.basedOnTempTex = "";
		this.twoDLookupTex = null;
		if (this.secondaryThreeDLookupTex)
		{
			UnityEngine.Object.DestroyImmediate(this.secondaryThreeDLookupTex);
		}
		this.secondaryThreeDLookupTex = null;
		this.secondaryBasedOnTempTex = "";
		this.secondaryTwoDLookupTex = null;
	}

	// Token: 0x06003253 RID: 12883 RVA: 0x000E09F4 File Offset: 0x000DEBF4
	private void OnDisable()
	{
		if (this.m_Material)
		{
			UnityEngine.Object.DestroyImmediate(this.m_Material);
			this.m_Material = null;
		}
		if (this.m_Material2)
		{
			UnityEngine.Object.DestroyImmediate(this.m_Material2);
			this.m_Material2 = null;
		}
		if (this.m_Material3)
		{
			UnityEngine.Object.DestroyImmediate(this.m_Material3);
			this.m_Material3 = null;
		}
		if (this.m_AOMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.m_AOMaterial);
			this.m_AOMaterial = null;
		}
		if (this.m_AOShader == this.m_Shader || this.m_Shader2 == this.m_Shader || this.m_Shader3 == this.m_Shader)
		{
			this.m_AOShader = null;
			this.m_Shader2 = null;
			this.m_Shader3 = null;
		}
		if (this.threeDLookupTex)
		{
			UnityEngine.Object.DestroyImmediate(this.threeDLookupTex);
			this.basedOnTempTex = "";
		}
		if (this.secondaryThreeDLookupTex)
		{
			UnityEngine.Object.DestroyImmediate(this.secondaryThreeDLookupTex);
			this.secondaryBasedOnTempTex = "";
		}
		if (this.renderTexture_3)
		{
			UnityEngine.Object.DestroyImmediate(this.renderTexture_3);
			this.renderTexture_3 = null;
		}
		if (this.renderTexture_2)
		{
			UnityEngine.Object.DestroyImmediate(this.renderTexture_2);
			this.renderTexture_2 = null;
		}
	}

	// Token: 0x06003254 RID: 12884 RVA: 0x000DF131 File Offset: 0x000DD331
	private Material method_1(Shader shader)
	{
		if (!shader)
		{
			return null;
		}
		return new Material(shader)
		{
			hideFlags = HideFlags.HideAndDontSave
		};
	}

	// Token: 0x06003255 RID: 12885 RVA: 0x000E0B4F File Offset: 0x000DED4F
	public void Reset()
	{
		this.OnDisable();
		this.OnEnable();
	}

	// Token: 0x06003256 RID: 12886 RVA: 0x000E0B60 File Offset: 0x000DED60
	private bool method_2()
	{
		if (this.m_Material == null && this.m_Shader != null && this.m_Shader.isSupported)
		{
			this.m_Material = this.method_1(this.m_Shader);
		}
		if (this.m_Material2 == null && this.m_Shader2 != null && this.m_Shader2.isSupported)
		{
			this.m_Material2 = this.method_1(this.m_Shader2);
		}
		if (this.m_Material3 == null && this.m_Shader3 != null && this.m_Shader3.isSupported)
		{
			this.m_Material3 = this.method_1(this.m_Shader3);
		}
		if (this.m_AOMaterial == null && this.m_AOShader != null && this.m_AOShader.isSupported)
		{
			this.m_AOMaterial = this.method_1(this.m_AOShader);
		}
		if (!this.m_Shader.isSupported)
		{
			Debug.LogError("Prism is not supported on this platform, or you have a shader compilation error somewhere. Disabling.");
			base.enabled = false;
			return false;
		}
		if (!this.m_Shader2.isSupported)
		{
			Debug.LogError("Prism (secondary shader) is not supported on this platform. Disabling.");
			base.enabled = false;
			return false;
		}
		if (!this.m_Shader3.isSupported)
		{
			Debug.LogError("Prism (tertiary shader) is not supported on this platform. Disabling some effects.");
			this.m_Shader3 = this.m_Shader;
			this.useRays = false;
		}
		if (!this.m_AOShader.isSupported)
		{
			Debug.LogError("Prism (AO) is not supported on this platform, or you have a shader compilation error somewhere. Disabling AO.");
			this.m_AOShader = this.m_Shader;
			this.useAmbientObscurance = false;
		}
		if (this.useLut && this.threeDLookupTex == null && this.twoDLookupTex)
		{
			this.Convert(this.twoDLookupTex, false);
			if (this.threeDLookupTex == null)
			{
				this.useLut = false;
				Debug.LogWarning("No LUT found - disabling LookupTexture");
			}
		}
		if (this.useLut && this.useSecondLut && this.secondaryThreeDLookupTex == null && this.secondaryTwoDLookupTex)
		{
			this.Convert(this.secondaryTwoDLookupTex, true);
			if (this.secondaryThreeDLookupTex == null)
			{
				this.useSecondLut = false;
				Debug.LogWarning("No secondary LUT found - disabling secondary LookupTexture");
			}
		}
		return true;
	}

	// Token: 0x06003257 RID: 12887 RVA: 0x000E0D94 File Offset: 0x000DEF94
	public void UpdateShaderValues()
	{
		if (this.m_Material == null)
		{
			return;
		}
		this.m_Material.shaderKeywords = null;
		this.m_Material2.shaderKeywords = null;
		this.m_AOMaterial.shaderKeywords = null;
		if (this.useBloom)
		{
			if (this.bloomType == BloomType.Simple)
			{
				Shader.DisableKeyword("PRISM_HDR_BLOOM");
				Shader.EnableKeyword("PRISM_SIMPLE_BLOOM");
				this.m_Material2.SetFloat(PrismEffects.int_0, this.bloomIntensity);
				this.m_Material2.SetFloat(PrismEffects.int_1, this.bloomThreshold);
				this.m_Material.SetFloat(PrismEffects.int_0, this.bloomIntensity);
				this.m_Material.SetFloat(PrismEffects.int_1, this.bloomThreshold);
				if (!this.camera_0.allowHDR)
				{
					Shader.EnableKeyword("PRISM_BLOOM_SCREENBLEND");
				}
				else
				{
					Shader.DisableKeyword("PRISM_BLOOM_SCREENBLEND");
				}
			}
			else if (this.bloomType == BloomType.HDR)
			{
				Shader.DisableKeyword("PRISM_SIMPLE_BLOOM");
				Shader.EnableKeyword("PRISM_HDR_BLOOM");
				Shader.DisableKeyword("PRISM_BLOOM_SCREENBLEND");
				this.m_Material.SetFloat(PrismEffects.int_1, this.bloomThreshold);
				this.m_Material2.SetFloat(PrismEffects.int_1, this.bloomThreshold);
				this.m_Material2.SetFloat(PrismEffects.int_0, this.bloomIntensity);
				this.m_Material.SetFloat(PrismEffects.int_0, this.bloomIntensity);
			}
			float value = this.dirtIntensity * this.dirtIntensity;
			this.m_Material.SetFloat(PrismEffects.int_2, value);
			this.m_Material2.SetFloat(PrismEffects.int_2, value);
			if (this.useUIBlur)
			{
				Shader.EnableKeyword("PRISM_UIBLUR");
			}
			else
			{
				Shader.DisableKeyword("PRISM_UIBLUR");
			}
		}
		else
		{
			Shader.DisableKeyword("PRISM_HDR_BLOOM");
			Shader.EnableKeyword("PRISM_SIMPLE_BLOOM");
			Shader.DisableKeyword("PRISM_BLOOM_SCREENBLEND");
			Shader.DisableKeyword("PRISM_USE_STABLEBLOOM");
			Shader.DisableKeyword("PRISM_USE_BLOOM");
			Shader.DisableKeyword("PRISM_UIBLUR");
		}
		this.method_3();
		if (this.useFog)
		{
			this.method_5(this.m_Material);
		}
		else
		{
			this.m_Material.SetFloat(PrismEffects.int_3, 0f);
		}
		if (this.useVignette)
		{
			this.m_Material.SetFloat(PrismEffects.int_4, this.vignetteStart);
			this.m_Material.SetFloat(PrismEffects.int_5, this.vignetteEnd);
			this.m_Material.SetFloat(PrismEffects.int_6, this.vignetteStrength);
			this.m_Material.SetColor(PrismEffects.int_7, this.vignetteColor);
		}
		else
		{
			this.m_Material.SetFloat(PrismEffects.int_6, 0f);
		}
		if (this.useNightVision)
		{
			this.m_Material.SetVector(PrismEffects.int_8, this.m_NVColor);
			this.m_Material.SetVector(PrismEffects.int_9, this.m_TargetBleachColor);
			this.m_Material.SetFloat(PrismEffects.int_10, this.m_baseLightingContribution);
			this.m_Material.SetFloat(PrismEffects.int_11, this.m_LightSensitivityMultiplier);
		}
		if (this.useNoise)
		{
			new Vector2(this.noiseIntensity * 0.01f, this.noiseIntensity);
			this.m_Material.SetVector(PrismEffects.int_12, new Vector2(this.noiseIntensity * 0.01f, this.noiseIntensity));
			this.m_Material.SetTexture(PrismEffects.int_13, this.noiseTexture);
			Vector2 v = new Vector2(0.5f - UnityEngine.Random.value, 0.5f - UnityEngine.Random.value);
			this.m_Material.SetVector(PrismEffects.int_14, v);
		}
		if (this.useChromaticAberration)
		{
			float value2 = this.chromaticIntensity * this.chromaticIntensity;
			float z;
			if (this.aberrationType == AberrationType.Vertical)
			{
				z = 1f;
			}
			else
			{
				z = 0f;
			}
			this.m_Material.SetFloat(PrismEffects.int_15, value2);
			this.m_Material2.SetFloat(PrismEffects.int_15, value2);
			this.m_Material.SetVector(PrismEffects.int_16, new Vector4(this.chromaticDistanceOne, this.chromaticDistanceTwo, z, 0f));
			this.m_Material2.SetVector(PrismEffects.int_16, new Vector4(this.chromaticDistanceOne, this.chromaticDistanceTwo, z, 0f));
		}
		else
		{
			this.m_Material.SetFloat(PrismEffects.int_15, 0f);
		}
		if (this.useTonemap)
		{
			this.m_Material.SetVector(PrismEffects.int_17, new Vector4(this.toneValues.x, this.toneValues.y, this.toneValues.z, this.toneValues.z));
			this.m_Material.SetVector(PrismEffects.int_18, new Vector4(this.secondaryToneValues.x, this.secondaryToneValues.y, this.secondaryToneValues.z, this.secondaryToneValues.z));
		}
		if (this.useGammaCorrection)
		{
			this.m_Material.SetFloat(PrismEffects.int_19, this.gammaValue);
		}
		else
		{
			this.m_Material.SetFloat(PrismEffects.int_19, 0f);
		}
		if (this.useDof)
		{
			this.method_9(this.m_Material);
		}
		if (this.useSharpen)
		{
			this.m_Material2.SetFloat(PrismEffects.int_20, this.sharpenAmount);
		}
		if (this.useLensDirt)
		{
			this.m_Material.SetTexture(PrismEffects.int_21, this.lensDirtTexture);
			this.m_Material2.SetTexture(PrismEffects.int_21, this.lensDirtTexture);
		}
		else
		{
			this.m_Material.SetFloat(PrismEffects.int_2, 0f);
		}
		if (this.useExposure)
		{
			this.m_Material.SetFloat(PrismEffects.int_22, this.exposureLowerLimit);
			this.m_Material.SetFloat(PrismEffects.int_23, this.exposureUpperLimit);
			this.m_Material.SetFloat(PrismEffects.int_24, this.exposureMiddleGrey);
			this.m_Material2.SetFloat(PrismEffects.int_25, this.exposureSpeed);
			this.m_Material2.SetFloat(PrismEffects.int_22, this.exposureLowerLimit);
			this.m_Material2.SetFloat(PrismEffects.int_23, this.exposureUpperLimit);
			this.m_Material2.SetFloat(PrismEffects.int_24, this.exposureMiddleGrey);
			Shader.EnableKeyword("PRISM_USE_EXPOSURE");
		}
		else
		{
			Shader.DisableKeyword("PRISM_USE_EXPOSURE");
		}
		Shader.DisableKeyword("PRISM_DOF_LOWSAMPLE");
		Shader.DisableKeyword("PRISM_DOF_MEDSAMPLE");
		if (this.useDof)
		{
			if (this.dofSampleAmount == DoFSamples.Low)
			{
				Shader.EnableKeyword("PRISM_DOF_LOWSAMPLE");
			}
			else if (this.dofSampleAmount == DoFSamples.Medium)
			{
				Shader.EnableKeyword("PRISM_DOF_MEDSAMPLE");
			}
			else
			{
				Shader.EnableKeyword("PRISM_DOF_MEDSAMPLE");
				Debug.LogWarning("High sample DoF is currently deprecated. If you want to increase your DoF samples, change around line 81 ('DOF_SAMPLES') in PRISM.cginc to a higher number");
				this.dofSampleAmount = DoFSamples.Medium;
			}
			if (this.useNearDofBlur)
			{
				Shader.EnableKeyword("PRISM_DOF_USENEARBLUR");
			}
			else
			{
				Shader.DisableKeyword("PRISM_DOF_USENEARBLUR");
			}
		}
		else
		{
			Shader.DisableKeyword("PRISM_DOF_USENEARBLUR");
			if (this.useFullScreenBlur)
			{
				this.m_Material.EnableKeyword("PRISM_DOF_USENEARBLUR");
				this.m_Material2.EnableKeyword("PRISM_DOF_USENEARBLUR");
			}
			else
			{
				this.m_Material.DisableKeyword("PRISM_DOF_USENEARBLUR");
				this.m_Material2.DisableKeyword("PRISM_DOF_USENEARBLUR");
			}
		}
		this.method_7();
		this.method_8();
		if (!this.useLut)
		{
			this.m_Material.DisableKeyword("PRISM_GAMMA_LOOKUP");
			this.m_Material.DisableKeyword("PRISM_LINEAR_LOOKUP");
		}
		else if (this.camera_0.allowHDR)
		{
			this.m_Material.EnableKeyword("PRISM_LINEAR_LOOKUP");
			this.m_Material.DisableKeyword("PRISM_GAMMA_LOOKUP");
		}
		else
		{
			this.m_Material.EnableKeyword("PRISM_GAMMA_LOOKUP");
			this.m_Material.DisableKeyword("PRISM_LINEAR_LOOKUP");
		}
		if (this.useTonemap && this.tonemapType == TonemapType.Filmic)
		{
			this.m_Material.EnableKeyword("PRISM_FILMIC_TONEMAP");
			Shader.EnableKeyword("PRISM_FILMIC_TONEMAP");
			Shader.DisableKeyword("PRISM_ROMB_TONEMAP");
			Shader.DisableKeyword("PRISM_ACES_TONEMAP");
		}
		else if (this.useTonemap && this.tonemapType == TonemapType.RomB)
		{
			this.m_Material.EnableKeyword("PRISM_ROMB_TONEMAP");
			Shader.EnableKeyword("PRISM_ROMB_TONEMAP");
			Shader.DisableKeyword("PRISM_FILMIC_TONEMAP");
			Shader.DisableKeyword("PRISM_ACES_TONEMAP");
		}
		else if (this.useTonemap && this.tonemapType == TonemapType.ACES)
		{
			this.m_Material.EnableKeyword("PRISM_ACES_TONEMAP");
			Shader.EnableKeyword("PRISM_ACES_TONEMAP");
			Shader.DisableKeyword("PRISM_FILMIC_TONEMAP");
			Shader.DisableKeyword("PRISM_ROMB_TONEMAP");
		}
		else
		{
			Shader.DisableKeyword("PRISM_FILMIC_TONEMAP");
			Shader.DisableKeyword("PRISM_ROMB_TONEMAP");
			Shader.DisableKeyword("PRISM_ACES_TONEMAP");
		}
		if (this.useNoise)
		{
			this.m_Material.SetFloat(PrismEffects.int_26, 1f);
		}
		else
		{
			this.m_Material.SetFloat(PrismEffects.int_26, 0f);
		}
		if (this.useNightVision)
		{
			this.m_Material.SetFloat(PrismEffects.int_27, 1f);
			Shader.EnableKeyword("PRISM_USE_NIGHTVISION");
		}
		else
		{
			this.m_Material.SetFloat(PrismEffects.int_27, 0f);
			Shader.DisableKeyword("PRISM_USE_NIGHTVISION");
		}
		if (this.useRays)
		{
			this.method_4(this.m_Material3);
			this.method_4(this.m_Material);
		}
		else
		{
			this.m_Material.SetFloat(PrismEffects.int_28, 0f);
		}
		if (this.useAmbientObscurance)
		{
			if (!this.IsGBufferAvailable || this.UsingTerrain)
			{
				this.camera_0.depthTextureMode |= DepthTextureMode.Depth;
				this.camera_0.depthTextureMode |= DepthTextureMode.DepthNormals;
			}
			this.m_Material.SetFloat(PrismEffects.int_29, this.aoIntensity);
			this.m_Material.SetFloat(PrismEffects.int_30, this.aoLightingContribution);
			if (!this.useAODistanceCutoff && !this.useDof)
			{
				this.m_AOMaterial.DisableKeyword("_AOCUTOFF_ON");
			}
			else
			{
				this.m_AOMaterial.EnableKeyword("_AOCUTOFF_ON");
			}
			if (this.IsGBufferAvailable && !this.UsingTerrain)
			{
				this.m_AOMaterial.EnableKeyword("_SOURCE_GBUFFER");
			}
			else
			{
				this.m_AOMaterial.DisableKeyword("_SOURCE_GBUFFER");
			}
			if (this.aoSampleCount == SampleCount.Low)
			{
				this.m_AOMaterial.EnableKeyword("_AOSAMPLECOUNT_LOWEST");
				this.m_AOMaterial.DisableKeyword("_AOSAMPLECOUNT_CUSTOM");
				this.m_AOMaterial.SetInt(PrismEffects.int_31, this.aoSampleCountValue);
			}
			else
			{
				this.m_AOMaterial.EnableKeyword("_AOSAMPLECOUNT_CUSTOM");
				this.m_AOMaterial.DisableKeyword("_AOSAMPLECOUNT_LOWEST");
				this.m_AOMaterial.SetInt(PrismEffects.int_31, this.aoSampleCountValue);
			}
			this.m_AOMaterial.SetInt(PrismEffects.int_32, this.aoSampleCountValue);
			return;
		}
		this.m_Material.SetFloat(PrismEffects.int_29, this.aoMinIntensity);
	}

	// Token: 0x06003258 RID: 12888 RVA: 0x000E1880 File Offset: 0x000DFA80
	private void method_3()
	{
		if ((this.useBloom && !this.useBloomStability) || (this.useBloom && !this.renderTexture_1))
		{
			Shader.EnableKeyword("PRISM_USE_BLOOM");
			Shader.DisableKeyword("PRISM_USE_STABLEBLOOM");
		}
		else if (this.useBloom && this.useBloomStability)
		{
			Shader.EnableKeyword("PRISM_USE_STABLEBLOOM");
			Shader.DisableKeyword("PRISM_USE_BLOOM");
		}
		else
		{
			Shader.DisableKeyword("PRISM_USE_STABLEBLOOM");
			Shader.DisableKeyword("PRISM_USE_BLOOM");
		}
		if (this.bloomUseScreenBlend)
		{
			Shader.EnableKeyword("PRISM_BLOOM_SCREENBLEND");
			return;
		}
		Shader.DisableKeyword("PRISM_BLOOM_SCREENBLEND");
	}

	// Token: 0x06003259 RID: 12889 RVA: 0x000E1920 File Offset: 0x000DFB20
	private void method_4(Material raysMaterial)
	{
		raysMaterial.SetFloat(PrismEffects.int_28, this.rayWeight);
		raysMaterial.SetColor(PrismEffects.int_33, this.rayColor);
		raysMaterial.SetColor(PrismEffects.int_34, this.rayThreshold);
		if (!this.rayTransform)
		{
			raysMaterial.SetVector(PrismEffects.int_35, new Vector4(base.transform.position.x, base.transform.position.y, base.transform.position.z, 1f));
			return;
		}
		Vector3 vector = this.camera_0.WorldToViewportPoint(this.rayTransform.position);
		raysMaterial.SetVector(PrismEffects.int_35, new Vector4(vector.x, vector.y, vector.z, this.rayWeight));
		if (vector.z >= 0f)
		{
			raysMaterial.SetColor(PrismEffects.int_33, this.rayColor);
			return;
		}
		raysMaterial.SetColor(PrismEffects.int_33, Color.black);
	}

	// Token: 0x0600325A RID: 12890 RVA: 0x000E1A24 File Offset: 0x000DFC24
	private void method_5(Material fogMaterial)
	{
		fogMaterial.SetFloat(PrismEffects.int_36, this.fogHeight);
		fogMaterial.SetFloat(PrismEffects.int_3, 1f);
		fogMaterial.SetFloat(PrismEffects.int_37, this.fogDistance);
		fogMaterial.SetFloat(PrismEffects.int_38, this.fogStartPoint);
		fogMaterial.SetColor(PrismEffects.int_39, this.fogColor);
		fogMaterial.SetColor(PrismEffects.int_40, this.fogEndColor);
		if (this.fogAffectSkybox)
		{
			fogMaterial.SetFloat(PrismEffects.int_41, 1f);
		}
		else
		{
			fogMaterial.SetFloat(PrismEffects.int_41, 0.9999999f);
		}
		fogMaterial.SetMatrix(PrismEffects.int_42, this.camera_0.cameraToWorldMatrix);
	}

	// Token: 0x0600325B RID: 12891 RVA: 0x000E1AD8 File Offset: 0x000DFCD8
	private void method_6(Material aoMaterial)
	{
		this.m_Material.SetFloat(PrismEffects.int_30, this.aoLightingContribution);
		aoMaterial.SetFloat(PrismEffects.int_29, this.aoIntensity);
		aoMaterial.SetFloat(PrismEffects.int_43, this.aoRadius);
		aoMaterial.SetFloat(PrismEffects.int_44, this.aoBias * 0.02f);
		aoMaterial.SetFloat(PrismEffects.int_45, this.aoDownsample ? 0.5f : 1f);
		if (this.useDof)
		{
			aoMaterial.SetFloat(PrismEffects.int_46, this.dofFocusPoint);
			aoMaterial.SetFloat(PrismEffects.int_47, this.dofFocusDistance);
		}
		else
		{
			aoMaterial.SetFloat(PrismEffects.int_46, this.aoDistanceCutoffStart);
			aoMaterial.SetFloat(PrismEffects.int_47, this.aoDistanceCutoffLength);
		}
		aoMaterial.SetMatrix(PrismEffects.int_48, this.camera_0.cameraToWorldMatrix);
		Matrix4x4 projectionMatrix = this.camera_0.projectionMatrix;
	}

	// Token: 0x0600325C RID: 12892 RVA: 0x000E1C68 File Offset: 0x000DFE68
	private void method_7()
	{
		if (this.useLut && this.twoDLookupTex && this.threeDLookupTex)
		{
			int width = this.threeDLookupTex.width;
			this.threeDLookupTex.wrapMode = TextureWrapMode.Clamp;
			this.m_Material.SetFloat(PrismEffects.int_50, (float)(width - 1) / (1f * (float)width));
			this.m_Material.SetFloat(PrismEffects.int_51, 1f / (2f * (float)width));
			this.m_Material.SetTexture(PrismEffects.int_52, this.threeDLookupTex);
			this.m_Material.SetFloat(PrismEffects.int_53, this.lutLerpAmount);
			return;
		}
		this.m_Material.SetFloat(PrismEffects.int_53, 0f);
	}

	// Token: 0x0600325D RID: 12893 RVA: 0x000E1D38 File Offset: 0x000DFF38
	private void method_8()
	{
		if (this.useSecondLut && this.secondaryTwoDLookupTex && this.secondaryThreeDLookupTex)
		{
			int width = this.secondaryThreeDLookupTex.width;
			this.secondaryThreeDLookupTex.wrapMode = TextureWrapMode.Clamp;
			this.m_Material.SetFloat(PrismEffects.int_54, (float)(width - 1) / (1f * (float)width));
			this.m_Material.SetFloat(PrismEffects.int_55, 1f / (2f * (float)width));
			this.m_Material.SetTexture(PrismEffects.int_56, this.secondaryThreeDLookupTex);
			this.m_Material.SetFloat(PrismEffects.int_57, this.secondaryLutLerpAmount);
			return;
		}
		this.m_Material.SetFloat(PrismEffects.int_57, 0f);
	}

	// Token: 0x0600325E RID: 12894 RVA: 0x000E1E05 File Offset: 0x000E0005
	public void SetDofTransform(Transform target)
	{
		this.dofFocusTransform = target;
	}

	// Token: 0x0600325F RID: 12895 RVA: 0x000E1E0E File Offset: 0x000E000E
	public void SetDofPoint(Vector3 point)
	{
		this.dofFocusPoint = Vector3.Distance(this.camera_0.transform.position, point);
	}

	// Token: 0x06003260 RID: 12896 RVA: 0x000E1E2C File Offset: 0x000E002C
	public void ResetDofTransform()
	{
		this.dofFocusTransform = null;
	}

	// Token: 0x06003261 RID: 12897 RVA: 0x000E1E38 File Offset: 0x000E0038
	private void method_9(Material targetMat)
	{
		if (this.dofFocusTransform)
		{
			targetMat.SetFloat(PrismEffects.int_58, Vector3.Distance(base.transform.position, this.dofFocusTransform.position));
		}
		else
		{
			targetMat.SetFloat(PrismEffects.int_58, this.dofFocusPoint);
		}
		targetMat.SetFloat(PrismEffects.int_59, this.dofFocusDistance);
		targetMat.SetFloat(PrismEffects.int_60, this.dofRadius);
		targetMat.SetFloat(PrismEffects.int_61, this.dofBokehFactor);
		if (this.useNearDofBlur)
		{
			targetMat.SetFloat(PrismEffects.int_62, 1f);
			targetMat.SetFloat(PrismEffects.int_63, this.dofNearFocusDistance);
		}
		else
		{
			targetMat.SetFloat(PrismEffects.int_62, 0f);
		}
		if (this.dofBlurSkybox)
		{
			targetMat.SetFloat(PrismEffects.int_64, 1f);
			return;
		}
		targetMat.SetFloat(PrismEffects.int_64, 0.9999999f);
	}

	// Token: 0x06003262 RID: 12898 RVA: 0x000E1F24 File Offset: 0x000E0124
	private void method_10(RenderTexture source, RenderTextureFormat rtFormat)
	{
		RenderTexture renderTexture = RenderTexture.GetTemporary(source.width / 2, source.width / 2, 0, rtFormat);
		renderTexture.name = "PeismEffects DownSampledTex";
		renderTexture.filterMode = FilterMode.Bilinear;
		int num = this.histWidth;
		while (renderTexture.height > num || renderTexture.width > num)
		{
			int num2 = renderTexture.width / 2;
			if (num2 < num)
			{
				num2 = num;
			}
			int num3 = renderTexture.height / 2;
			if (num3 < num)
			{
				num3 = num;
			}
			RenderTexture temporary = RenderTexture.GetTemporary(num2, num3, 0, rtFormat);
			temporary.name = "Prism Effects rtTempDst";
			RenderTexture.ReleaseTemporary(renderTexture);
			renderTexture = temporary;
		}
		this.renderTexture_3.MarkRestoreExpected();
		int pass = 4;
		if (this.bool_1)
		{
			Graphics.Blit(renderTexture, this.renderTexture_3);
		}
		this.m_Material.SetTexture(PrismEffects.int_65, this.renderTexture_3);
		this.m_Material2.SetTexture(PrismEffects.int_65, this.renderTexture_3);
		RenderTexture.ReleaseTemporary(renderTexture);
	}

	// Token: 0x06003263 RID: 12899 RVA: 0x000E2044 File Offset: 0x000E0244
	private RenderTexture method_11(RenderTexture tex, int iterations = 1)
	{
		for (int i = 0; i < iterations; i++)
		{
			Vector2 v = new Vector2(0f, 1f);
			RenderTexture temporary = RenderTexture.GetTemporary(tex.width, tex.height, 0, RenderTextureFormat.ARGB32);
			temporary.name = "Prism Effects BlurOne";
			this.m_Material2.SetVector(PrismEffects.int_66, v);
			v = new Vector2(1f, 0f);
			this.m_Material2.SetVector(PrismEffects.int_66, v);
			RenderTexture.ReleaseTemporary(temporary);
		}
		RenderTexture.ReleaseTemporary(tex);
		return tex;
	}

	// Token: 0x06003264 RID: 12900 RVA: 0x000E20FC File Offset: 0x000E02FC
	[ImageEffectTransformsToLDR]
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{

	}

	// Token: 0x06003265 RID: 12901 RVA: 0x000E2154 File Offset: 0x000E0354
	private void method_12(RenderTexture source, RenderTexture destination)
	{
		bool flag = true;
		if (this.bool_0)
		{
			Graphics.CopyTexture(source, destination);
			this.bool_0 = false;
			return;
		}
		if (this.method_2() && flag)
		{
			EnvironmentManager instance = EnvironmentManager.Instance;
			if (instance != null)
			{
				//this.exposureSpeed = instance.PrismExposureSpeed;
				//this.exposureMiddleGrey = instance.PrismExposureOffset;
			}
			this.UpdateShaderValues();
			if (this.threeDLookupTex == null && this.useLut)
			{
				this.SetIdentityLut(false);
			}
			if (this.secondaryThreeDLookupTex == null && this.useSecondLut)
			{
				this.SetIdentityLut(true);
			}
			RenderTextureFormat renderTextureFormat = RuntimeUtilities.defaultHDRRenderTextureFormat;
			if (this.camera_0.allowHDR)
			{
				renderTextureFormat = RuntimeUtilities.defaultHDRRenderTextureFormat;
			}
			else
			{
				renderTextureFormat = RenderTextureFormat.ARGB32;
			}
			if (this.isParentPrism)
			{
				if (!this.renderTexture_0 || this.renderTexture_0.width != source.width || this.renderTexture_0.height != source.height)
				{
					this.renderTexture_0 = new RenderTexture(source.width, source.height, 16, RenderTextureFormat.RHalf, RenderTextureReadWrite.Linear);
					this.renderTexture_0.name = "PrismEffects DepthTex";
				}
				Graphics.SetRenderTarget(this.renderTexture_0);
				GL.Clear(true, true, Color.white);
				Shader.SetGlobalTexture(PrismEffects.int_67, this.renderTexture_0);
				if (this.debugDofPass)
				{
					return;
				}
			}
			int num = 1;
			if (this.aoDownsample)
			{
				num = 2;
			}
			int width = source.width / num;
			int height = source.height / num;
			int width2 = source.width / 4;
			int height2 = source.height / 4;
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0, this.RenderTextureFormat_0, RenderTextureReadWrite.Linear);
			temporary.name = "Prism Effects AO RT";
			RenderTexture temporary2 = RenderTexture.GetTemporary(source.width, source.height, 0, renderTextureFormat);
			temporary2.name = "Prism Effects TempDofDest";
			RenderTexture temporary3 = RenderTexture.GetTemporary(source.width, source.height, 0, renderTextureFormat);
			temporary3.name = "Prism Effects TempDest";
			RenderTexture temporary4 = RenderTexture.GetTemporary(width2, height2, 0, RenderTextureFormat.ARGB32);
			temporary4.name = "Prism Effects Rays Tex";
			RenderTexture temporary5 = RenderTexture.GetTemporary(source.width / 2, source.height / 2, 0, renderTextureFormat);
			temporary5.name = "Prism Effects FullSizeMedian";
			RenderTexture temporary6 = RenderTexture.GetTemporary(source.width, source.height, 0, renderTextureFormat);
			temporary6.name = "Prism Effects DofTex";
			if (this.useAmbientObscurance)
			{
				this.method_6(this.m_AOMaterial);
				if (this.aoBlurType == AOBlurType.Fast)
				{
					for (int i = 0; i < this.aoBlurIterations; i++)
					{
						this.m_AOMaterial.SetVector(PrismEffects.int_77, new Vector4(-1f, 0f, 0f, 0f));
						RenderTexture temporary7 = RenderTexture.GetTemporary(width, height, 0, this.RenderTextureFormat_0, RenderTextureReadWrite.Linear);
						temporary7.name = "PrismEffects TmpRT3";
						RenderTexture.ReleaseTemporary(temporary);
						this.m_AOMaterial.SetVector(PrismEffects.int_77, new Vector4(0f, 1f, 0f, 0f));
						temporary = RenderTexture.GetTemporary(width, height, 0, this.RenderTextureFormat_0, RenderTextureReadWrite.Linear);
						temporary.name = "PrismEffects AOTex";
						RenderTexture.ReleaseTemporary(temporary7);
					}
				}
				else
				{
					for (int j = 0; j < this.aoBlurIterations; j++)
					{
						for (int k = 0; k < 2; k++)
						{
							this.m_AOMaterial.SetVector(PrismEffects.int_77, new Vector4(-1f, 0f, 0f, 0f));
							RenderTexture temporary7 = RenderTexture.GetTemporary(width, height, 0, this.RenderTextureFormat_0, RenderTextureReadWrite.Linear);
							temporary7.name = "PrismEffects TmpRT3";
							RenderTexture.ReleaseTemporary(temporary);
							this.m_AOMaterial.SetVector(PrismEffects.int_77, new Vector4(0f, 1f, 0f, 0f));
							temporary = RenderTexture.GetTemporary(width, height, 0, this.RenderTextureFormat_0, RenderTextureReadWrite.Linear);
							temporary.name = "PrismEffects AOTex";
							RenderTexture.ReleaseTemporary(temporary7);
						}
					}
				}
				if (this.aoShowDebug)
				{
					goto IL_FC9;
				}
				this.m_Material.SetTexture(PrismEffects.int_78, temporary);
				if (this.isParentPrism)
				{
					Shader.SetGlobalFloat(PrismEffects.int_29, this.aoIntensity);
					Shader.SetGlobalTexture(PrismEffects.int_78, temporary);
				}
			}
			if (this.useMedianDoF)
			{
				this.m_Material.SetTexture(PrismEffects.int_68, temporary5);
				this.m_Material.SetFloat(PrismEffects.int_69, 1f);
			}
			else
			{
				this.m_Material.SetTexture(PrismEffects.int_68, source);
				this.m_Material.SetFloat(PrismEffects.int_69, 0f);
			}
			if (this.debugDofPass && this.useDof)
			{
				this.method_9(this.m_Material2);
			}
			else
			{
				if (this.useExposure)
				{
					bool flag2 = false;
					if (this.m_MasterEffectExposure != null)
					{
						flag2 = true;
						Graphics.Blit(this.m_MasterEffectExposure.AdaptationTexture, this.renderTexture_3);
						this.m_Material.SetTexture(PrismEffects.int_65, this.renderTexture_3);
						this.m_Material2.SetTexture(PrismEffects.int_65, this.renderTexture_3);
					}
					if (!flag2)
					{
						if (this.useMedianDoF)
						{
							this.method_10(temporary5, renderTextureFormat);
						}
						else
						{
							this.method_10(source, renderTextureFormat);
						}
					}
					if (this.debugViewExposure)
					{
						goto IL_FC9;
					}
				}
				if (this.useBloom)
				{
					if (this.bloomType == BloomType.HDR)
					{
						this.bloomDownsample = 2;
					}
					int num2 = source.width / this.bloomDownsample;
					int num3 = source.height / this.bloomDownsample;
					RenderTexture renderTexture = RenderTexture.GetTemporary(num2, num3, 0, renderTextureFormat);
					renderTexture.name = "Prism Effects HaldRezColorDown";
					renderTexture.filterMode = FilterMode.Bilinear;
					if (this.useMedianDoF)
					{

					}
					else
					{
					}
					if (this.useRays)
					{
						this.method_13(temporary4);
						if (this.raysShowDebug)
						{
							Graphics.Blit(temporary4, destination);
							RenderTexture.ReleaseTemporary(renderTexture);
							goto IL_FC9;
						}
					}
					RenderTexture renderTexture2 = RenderTexture.GetTemporary(num2, num3, 0, renderTextureFormat);
					renderTexture2.name = "Prism Effects Median Colror";
					if (this.bloomType == BloomType.Simple)
					{
						int num4 = 0;
						for (int l = 0; l < this.bloomBlurPasses; l++)
						{
							RenderTexture temporary8 = RenderTexture.GetTemporary(num2, num3, 0, renderTextureFormat);
							temporary8.name = "Prism Effects Blur4";
							this.m_Material2.SetInt(PrismEffects.int_70, l + num4);
							if (this.useUIBlur && this.uiBlurGrabTextureFromPassNumber == l && this.renderTexture_2.width > 0 && this.renderTexture_2.height > 0)
							{
								Graphics.Blit(temporary8, this.renderTexture_2);
								Shader.SetGlobalTexture(PrismEffects.int_71, this.renderTexture_2);
							}
							RenderTexture.ReleaseTemporary(renderTexture2);
							renderTexture2 = temporary8;
						}
						this.m_Material.SetTexture(PrismEffects.int_72, renderTexture2);
						if (this.debugBloomTex)
						{
							this.m_Material3.SetFloat(PrismEffects.int_1, this.bloomThreshold);
							this.m_Material3.SetFloat(PrismEffects.int_0, this.bloomIntensity);
							RenderTexture.ReleaseTemporary(renderTexture);
							RenderTexture.ReleaseTemporary(renderTexture2);
							goto IL_FC9;
						}
						if (this.renderTexture_1 && this.useBloomStability)
						{
							this.m_Material.SetTexture(PrismEffects.int_73, this.renderTexture_1);
						}
						if (this.renderTexture_1)
						{
							RenderTexture.ReleaseTemporary(this.renderTexture_1);
							this.renderTexture_1 = null;
						}
						if (this.useBloomStability)
						{
							this.renderTexture_1 = RenderTexture.GetTemporary(num2, num3, 0, renderTextureFormat);
							this.renderTexture_1.name = "Prism Effects AccumulationBuffer";
							this.renderTexture_1.filterMode = FilterMode.Bilinear;
							Graphics.Blit(renderTexture2, this.renderTexture_1);
						}
						RenderTexture.ReleaseTemporary(renderTexture);
					}
					else if (this.bloomType == BloomType.HDR)
					{
						RenderTexture renderTexture3 = RenderTexture.GetTemporary(num2 / 2, num3 / 2, 0, renderTextureFormat);
						renderTexture3.name = "Prism Effects QuarterRezColorDown";
						renderTexture3.filterMode = FilterMode.Bilinear;
						RenderTexture renderTexture4 = RenderTexture.GetTemporary(num2 / 4, num3 / 4, 0, renderTextureFormat);
						renderTexture4.name = "PrismEffects EighthRezColorDown";
						renderTexture4.filterMode = FilterMode.Bilinear;
						RenderTexture renderTexture5 = RenderTexture.GetTemporary(num2 / 8, num3 / 8, 0, renderTextureFormat);
						renderTexture5.name = "PrismEffects SixteenthRezColorDown";
						renderTexture5.filterMode = FilterMode.Bilinear;
						renderTexture = this.method_11(renderTexture, 1);
						renderTexture3 = this.method_11(renderTexture3, 1);
						renderTexture4 = this.method_11(renderTexture4, 2);
						renderTexture5 = this.method_11(renderTexture5, 4);
						this.m_Material.SetTexture(PrismEffects.int_72, renderTexture);
						this.m_Material.SetTexture(PrismEffects.int_74, renderTexture3);
						this.m_Material.SetTexture(PrismEffects.int_75, renderTexture4);
						this.m_Material.SetTexture(PrismEffects.int_76, renderTexture5);
						if (this.renderTexture_1 && this.useBloomStability)
						{
							this.m_Material.SetTexture(PrismEffects.int_73, this.renderTexture_1);
						}
						if (this.renderTexture_1)
						{
							RenderTexture.ReleaseTemporary(this.renderTexture_1);
							this.renderTexture_1 = null;
						}
						if (this.useBloomStability)
						{
							this.renderTexture_1 = RenderTexture.GetTemporary(num2, num3, 0, renderTextureFormat);
							this.renderTexture_1.name = "PrismEffects AccumulationBuffer";
							this.renderTexture_1.filterMode = FilterMode.Bilinear;
							Graphics.Blit(renderTexture, this.renderTexture_1);
						}
						if (this.useUIBlur && this.renderTexture_2.width > 0 && this.renderTexture_2.height > 0)
						{
							Graphics.Blit(renderTexture, this.renderTexture_2);
							Shader.SetGlobalTexture(PrismEffects.int_71, this.renderTexture_2);
						}
						if (this.debugBloomTex)
						{
							this.m_Material3.EnableKeyword("PRISM_HDR_BLOOM");
							this.m_Material3.EnableKeyword("PRISM_USE_BLOOM");
							this.m_Material3.SetTexture(PrismEffects.int_72, renderTexture);
							this.m_Material3.SetTexture(PrismEffects.int_74, renderTexture3);
							this.m_Material3.SetTexture(PrismEffects.int_75, renderTexture4);
							this.m_Material3.SetTexture(PrismEffects.int_76, renderTexture5);
							this.m_Material3.SetFloat(PrismEffects.int_0, this.bloomIntensity);
							goto IL_FC9;
						}
					}
					if (this.useSharpen)
					{
						RenderTexture temporary9 = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.ARGB32);
						temporary9.name = "PrismEffects ChromDest";
						Graphics.CopyTexture(temporary9, destination);
						RenderTexture.ReleaseTemporary(temporary9);
					}
					else if (this.forceSecondChromaticPass)
					{
						if (this.useChromaticBlur)
						{
							Vector2 v = new Vector2(0f, 1f * this.chromaticBlurWidth);
							RenderTexture temporary10 = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.ARGB32);
							temporary10.name = "PrismEffects BlurChrom";
							this.m_Material2.SetVector(PrismEffects.int_66, v);
							v = new Vector2(1f * this.chromaticBlurWidth, 0f);
							RenderTexture temporary11 = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.ARGB32);
							temporary11.name = "PrismEffects BlurChrom2";
							this.m_Material2.SetVector(PrismEffects.int_66, v);
							RenderTexture temporary12 = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.ARGB32);
							temporary12.name = "PrismEffects ChromDest";
							Graphics.CopyTexture(temporary12, destination);
							RenderTexture.ReleaseTemporary(temporary10);
							RenderTexture.ReleaseTemporary(temporary11);
							RenderTexture.ReleaseTemporary(temporary12);
						}
						else
						{
							RenderTexture temporary13 = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.ARGB32);
							temporary13.name = "PrismEffects ChromDest";
							Graphics.CopyTexture(temporary13, destination);
							RenderTexture.ReleaseTemporary(temporary13);
						}
					}
					RenderTexture.ReleaseTemporary(renderTexture2);
				}
				else
				{
					if (this.useRays)
					{
						int width3 = source.width / 2;
						int height3 = source.height / 2;
						RenderTexture temporary14 = RenderTexture.GetTemporary(width3, height3, 0, renderTextureFormat);
						temporary14.name = "PrismEffects HalfRezColorDown";
						temporary14.filterMode = FilterMode.Bilinear;
						this.method_13(temporary4);
						if (this.raysShowDebug)
						{
							Graphics.Blit(temporary4, destination);
							RenderTexture.ReleaseTemporary(temporary14);
							goto IL_FC9;
						}
						RenderTexture.ReleaseTemporary(temporary14);
					}
					if (this.useSharpen)
					{
						RenderTexture temporary15 = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.ARGB32);
						temporary15.name = "PrismEffects ChromDest";
						Graphics.CopyTexture(temporary15, destination);
						RenderTexture.ReleaseTemporary(temporary15);
					}
					else if (this.forceSecondChromaticPass)
					{
						if (this.useChromaticBlur)
						{
							Vector2 v2 = new Vector2(0f, 1f * this.chromaticBlurWidth);
							RenderTexture temporary16 = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.ARGB32);
							temporary16.name = "PrismEffects BlurChrom";
							this.m_Material2.SetVector(PrismEffects.int_66, v2);
							v2 = new Vector2(1f * this.chromaticBlurWidth, 0f);
							RenderTexture temporary17 = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.ARGB32);
							temporary17.name = "PrismEffects BlurChrom2";
							this.m_Material2.SetVector(PrismEffects.int_66, v2);
							RenderTexture temporary18 = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.ARGB32);
							temporary18.name = "PrismEffects ChromDest";
							Graphics.CopyTexture(temporary18, destination);
							RenderTexture.ReleaseTemporary(temporary16);
							RenderTexture.ReleaseTemporary(temporary17);
							RenderTexture.ReleaseTemporary(temporary18);
						}
						else
						{
							RenderTexture temporary19 = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.ARGB32);
							temporary19.name = "PrismEffects ChromDest";
							Graphics.CopyTexture(temporary19, destination);
							RenderTexture.ReleaseTemporary(temporary19);
						}
					}
				}
			}
			IL_FC9:
			RenderTexture.ReleaseTemporary(temporary4);
			RenderTexture.ReleaseTemporary(temporary3);
			RenderTexture.ReleaseTemporary(temporary2);
			RenderTexture.ReleaseTemporary(temporary5);
			RenderTexture.ReleaseTemporary(temporary6);
			RenderTexture.ReleaseTemporary(temporary);
			this.bool_1 = false;
			return;
		}
		Graphics.CopyTexture(source, destination);
	}

	// Token: 0x06003266 RID: 12902 RVA: 0x000E3164 File Offset: 0x000E1364
	private void method_13(RenderTexture quarterResMain)
	{
		RenderTexture temporary = RenderTexture.GetTemporary(quarterResMain.width, quarterResMain.height, 0, RenderTextureFormat.ARGB32);
		temporary.name = "PrismEffects PreBlurTex";
		RenderTexture temporary2 = RenderTexture.GetTemporary(quarterResMain.width, quarterResMain.height, 0, RenderTextureFormat.ARGB32);
		temporary2.name = "PrismEffects QuaterResSecond";
		this.m_Material.SetTexture(PrismEffects.int_79, temporary2);
		RenderTexture.ReleaseTemporary(temporary);
		RenderTexture.ReleaseTemporary(temporary2);
	}

	// Token: 0x06003267 RID: 12903 RVA: 0x000E31E8 File Offset: 0x000E13E8
	public void SetIdentityLut(bool secondary = false)
	{
		int num = 16;
		Color[] array = new Color[4096];
		float num2 = (float)0.06666666666666667;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num; j++)
			{
				for (int k = 0; k < num; k++)
				{
					array[i + j * num + k * num * num] = new Color((float)i * 1f * num2, (float)j * 1f * num2, (float)k * 1f * num2, 1f);
				}
			}
		}
		if (!secondary)
		{
			if (this.threeDLookupTex)
			{
				UnityEngine.Object.DestroyImmediate(this.threeDLookupTex);
			}
			this.threeDLookupTex = new Texture3D(num, num, num, TextureFormat.ARGB32, false);
			this.threeDLookupTex.SetPixels(array);
			this.threeDLookupTex.Apply();
			this.basedOnTempTex = "";
			return;
		}
		if (this.secondaryThreeDLookupTex)
		{
			UnityEngine.Object.DestroyImmediate(this.secondaryThreeDLookupTex);
		}
		this.secondaryThreeDLookupTex = new Texture3D(num, num, num, TextureFormat.ARGB32, false);
		this.secondaryThreeDLookupTex.SetPixels(array);
		this.secondaryThreeDLookupTex.Apply();
		this.secondaryBasedOnTempTex = "";
	}

	// Token: 0x06003268 RID: 12904 RVA: 0x000E330E File Offset: 0x000E150E
	public bool ValidDimensions(Texture2D tex2d)
	{
		return tex2d && tex2d.height == Mathf.FloorToInt(Mathf.Sqrt((float)tex2d.width));
	}

	// Token: 0x06003269 RID: 12905 RVA: 0x000E3336 File Offset: 0x000E1536
	public void AddDependantEffectExposure(PrismEffects pe)
	{
		if (this.list_0 == null)
		{
			this.list_0 = new List<PrismEffects>();
		}
		this.list_0.Add(pe);
		pe.m_MasterEffectExposure = this;
	}

	// Token: 0x0600326A RID: 12906 RVA: 0x000E3360 File Offset: 0x000E1560
	public void Convert(Texture2D temp2DTex, bool secondaryLut = false)
	{
		if (!temp2DTex)
		{
			Debug.LogError("Couldn't color correct with 3D LUT texture. PRISM will be disabled.");
			base.enabled = false;
			return;
		}
		int num = temp2DTex.width * temp2DTex.height;
		num = temp2DTex.height;
		if (!this.ValidDimensions(temp2DTex))
		{
			Debug.LogWarning("The given 2D texture " + temp2DTex.name + " cannot be used as a 3D LUT.");
			if (!secondaryLut)
			{
				this.secondaryBasedOnTempTex = "";
				return;
			}
			this.basedOnTempTex = "";
			return;
		}
		else
		{
			Color[] pixels = temp2DTex.GetPixels();
			Color[] array = new Color[pixels.Length];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num; j++)
				{
					for (int k = 0; k < num; k++)
					{
						int num2 = num - j - 1;
						array[i + j * num + k * num * num] = pixels[k * num + i + num2 * num * num];
					}
				}
			}
			if (!secondaryLut)
			{
				if (this.threeDLookupTex)
				{
					UnityEngine.Object.DestroyImmediate(this.threeDLookupTex);
				}
				this.threeDLookupTex = new Texture3D(num, num, num, TextureFormat.ARGB32, false);
				this.threeDLookupTex.SetPixels(array);
				this.threeDLookupTex.Apply();
				this.basedOnTempTex = temp2DTex.name;
				this.twoDLookupTex = temp2DTex;
				return;
			}
			if (this.secondaryThreeDLookupTex)
			{
				UnityEngine.Object.DestroyImmediate(this.secondaryThreeDLookupTex);
			}
			this.secondaryThreeDLookupTex = new Texture3D(num, num, num, TextureFormat.ARGB32, false);
			this.secondaryThreeDLookupTex.SetPixels(array);
			this.secondaryThreeDLookupTex.Apply();
			this.secondaryBasedOnTempTex = temp2DTex.name;
			this.secondaryTwoDLookupTex = temp2DTex;
			return;
		}
	}

	// Token: 0x04002BBC RID: 11196
	public PrismPreset currentPrismPreset;

	// Token: 0x04002BBD RID: 11197
	private bool bool_0;

	// Token: 0x04002BBE RID: 11198
	public bool isParentPrism;

	// Token: 0x04002BBF RID: 11199
	public bool isChildPrism;

	// Token: 0x04002BC0 RID: 11200
	private RenderTexture renderTexture_0;

	// Token: 0x04002BC1 RID: 11201
	public Material m_Material;

	// Token: 0x04002BC2 RID: 11202
	public Shader m_Shader;

	// Token: 0x04002BC3 RID: 11203
	public Material m_Material2;

	// Token: 0x04002BC4 RID: 11204
	public Shader m_Shader2;

	// Token: 0x04002BC5 RID: 11205
	public PrismEffects m_MasterEffectExposure;

	// Token: 0x04002BC6 RID: 11206
	private List<PrismEffects> list_0;

	// Token: 0x04002BC7 RID: 11207
	public Material m_AOMaterial;

	// Token: 0x04002BC8 RID: 11208
	public Shader m_AOShader;

	// Token: 0x04002BC9 RID: 11209
	public Material m_Material3;

	// Token: 0x04002BCA RID: 11210
	public Shader m_Shader3;

	// Token: 0x04002BCB RID: 11211
	private Camera camera_0;


	// Token: 0x04002BCD RID: 11213
	public bool doBigPass = true;

	// Token: 0x04002BCE RID: 11214
	public bool useSeparableBlur = true;

	// Token: 0x04002BCF RID: 11215
	public Texture2D lensDirtTexture;

	// Token: 0x04002BD0 RID: 11216
	public bool useLensDirt = true;

	// Token: 0x04002BD1 RID: 11217
	[Space(10f)]
	public bool useBloom;

	// Token: 0x04002BD2 RID: 11218
	public bool bloomUseScreenBlend;

	// Token: 0x04002BD3 RID: 11219
	public BloomType bloomType = BloomType.HDR;

	// Token: 0x04002BD4 RID: 11220
	public bool debugBloomTex;

	// Token: 0x04002BD5 RID: 11221
	[Range(1f, 12f)]
	public int bloomDownsample = 2;

	// Token: 0x04002BD6 RID: 11222
	[Range(0f, 12f)]
	public int bloomBlurPasses = 4;

	// Token: 0x04002BD7 RID: 11223
	public float bloomIntensity = 0.15f;

	// Token: 0x04002BD8 RID: 11224
	[Range(-2f, 2f)]
	public float bloomThreshold = 0.01f;

	// Token: 0x04002BD9 RID: 11225
	public float dirtIntensity = 1f;

	// Token: 0x04002BDA RID: 11226
	public bool useBloomStability = true;

	// Token: 0x04002BDB RID: 11227
	private RenderTexture renderTexture_1;

	// Token: 0x04002BDC RID: 11228
	public bool useUIBlur;

	// Token: 0x04002BDD RID: 11229
	public int uiBlurGrabTextureFromPassNumber = 2;

	// Token: 0x04002BDE RID: 11230
	private RenderTexture renderTexture_2;

	// Token: 0x04002BDF RID: 11231
	[Space(10f)]
	public bool useVignette;

	// Token: 0x04002BE0 RID: 11232
	public float vignetteStart = 0.9f;

	// Token: 0x04002BE1 RID: 11233
	public float vignetteEnd = 0.4f;

	// Token: 0x04002BE2 RID: 11234
	public float vignetteStrength = 1f;

	// Token: 0x04002BE3 RID: 11235
	public Color vignetteColor = Color.black;

	// Token: 0x04002BE4 RID: 11236
	[Space(10f)]
	public bool useNightVision;

	// Token: 0x04002BE5 RID: 11237
	[SerializeField]
	[Tooltip("The main color of the NV effect")]
	public Color m_NVColor = new Color(0f, 1f, 0.1724138f, 0f);

	// Token: 0x04002BE6 RID: 11238
	[Tooltip("The color that the NV effect will 'bleach' towards (white = default)")]
	[SerializeField]
	public Color m_TargetBleachColor = new Color(1f, 1f, 1f, 0f);

	// Token: 0x04002BE7 RID: 11239
	[Range(0f, 0.1f)]
	[Tooltip("How much base lighting does the NV effect pick up")]
	public float m_baseLightingContribution = 0.025f;

	// Token: 0x04002BE8 RID: 11240
	[Range(0f, 128f)]
	[Tooltip("The higher this value, the more bright areas will get 'bleached out'")]
	public float m_LightSensitivityMultiplier = 100f;

	// Token: 0x04002BE9 RID: 11241
	[Space(10f)]
	public bool useNoise;

	// Token: 0x04002BEA RID: 11242
	public Texture2D noiseTexture;

	// Token: 0x04002BEB RID: 11243
	public float noiseScale = 1f;

	// Token: 0x04002BEC RID: 11244
	public float noiseIntensity = 0.2f;

	// Token: 0x04002BED RID: 11245
	public NoiseType noiseType = NoiseType.RandomTimeNoise;

	// Token: 0x04002BEE RID: 11246
	[Space(10f)]
	public bool useChromaticAberration;

	// Token: 0x04002BEF RID: 11247
	public AberrationType aberrationType = AberrationType.Vertical;

	// Token: 0x04002BF0 RID: 11248
	[Range(0f, 1f)]
	public float chromaticDistanceOne = 0.29f;

	// Token: 0x04002BF1 RID: 11249
	[Range(0f, 1f)]
	public float chromaticDistanceTwo = 0.599f;

	// Token: 0x04002BF2 RID: 11250
	public float chromaticIntensity = 0.03f;

	// Token: 0x04002BF3 RID: 11251
	public float chromaticBlurWidth = 1f;

	// Token: 0x04002BF4 RID: 11252
	public bool useChromaticBlur;

	// Token: 0x04002BF5 RID: 11253
	[Space(10f)]
	public bool useTonemap;

	// Token: 0x04002BF6 RID: 11254
	public TonemapType tonemapType = TonemapType.RomB;

	// Token: 0x04002BF7 RID: 11255
	public Vector3 toneValues = new Vector3(-1f, 2.72f, 0.15f);

	// Token: 0x04002BF8 RID: 11256
	public Vector3 secondaryToneValues = new Vector3(0.59f, 0.14f, 0.14f);

	// Token: 0x04002BF9 RID: 11257
	public bool useExposure;

	// Token: 0x04002BFA RID: 11258
	public bool debugViewExposure;

	// Token: 0x04002BFB RID: 11259
	private RenderTexture renderTexture_3;

	// Token: 0x04002BFC RID: 11260
	public float exposureMiddleGrey = 0.12f;

	// Token: 0x04002BFD RID: 11261
	public float exposureLowerLimit = -6f;

	// Token: 0x04002BFE RID: 11262
	public float exposureUpperLimit = 6f;

	// Token: 0x04002BFF RID: 11263
	public float exposureSpeed = 6f;

	// Token: 0x04002C00 RID: 11264
	public int histWidth = 1;

	// Token: 0x04002C01 RID: 11265
	public int histHeight = 1;

	// Token: 0x04002C02 RID: 11266
	private bool bool_1 = true;

	// Token: 0x04002C03 RID: 11267
	public bool useGammaCorrection;

	// Token: 0x04002C04 RID: 11268
	public float gammaValue = 1f;

	// Token: 0x04002C05 RID: 11269
	[Space(10f)]
	public bool useDof;

	// Token: 0x04002C06 RID: 11270
	public bool dofForceEnableMedian;

	// Token: 0x04002C07 RID: 11271
	public bool useNearDofBlur;

	// Token: 0x04002C08 RID: 11272
	public bool useFullScreenBlur;

	// Token: 0x04002C09 RID: 11273
	public float dofNearFocusDistance = 15f;

	// Token: 0x04002C0A RID: 11274
	public float dofFocusPoint = 5f;

	// Token: 0x04002C0B RID: 11275
	public float dofFocusDistance = 15f;

	// Token: 0x04002C0C RID: 11276
	public float dofRadius = 0.6f;

	// Token: 0x04002C0D RID: 11277
	public float dofBokehFactor = 60f;

	// Token: 0x04002C0E RID: 11278
	public DoFSamples dofSampleAmount = DoFSamples.Medium;

	// Token: 0x04002C0F RID: 11279
	public bool dofBlurSkybox = true;

	// Token: 0x04002C10 RID: 11280
	public bool debugDofPass;

	// Token: 0x04002C11 RID: 11281
	public Transform dofFocusTransform;

	// Token: 0x04002C12 RID: 11282
	[Space(10f)]
	public bool useLut;

	// Token: 0x04002C13 RID: 11283
	public Texture2D twoDLookupTex;

	// Token: 0x04002C14 RID: 11284
	public Texture3D threeDLookupTex;

	// Token: 0x04002C15 RID: 11285
	public string basedOnTempTex = "";

	// Token: 0x04002C16 RID: 11286
	public float lutLerpAmount = 0.6f;

	// Token: 0x04002C17 RID: 11287
	public bool useSecondLut;

	// Token: 0x04002C18 RID: 11288
	public Texture2D secondaryTwoDLookupTex;

	// Token: 0x04002C19 RID: 11289
	public Texture3D secondaryThreeDLookupTex;

	// Token: 0x04002C1A RID: 11290
	public string secondaryBasedOnTempTex = "";

	// Token: 0x04002C1B RID: 11291
	public float secondaryLutLerpAmount;

	// Token: 0x04002C1C RID: 11292
	[Space(10f)]
	public bool useSharpen;

	// Token: 0x04002C1D RID: 11293
	public float sharpenAmount = 1f;

	// Token: 0x04002C1E RID: 11294
	public bool useFog;

	// Token: 0x04002C1F RID: 11295
	public bool fogAffectSkybox;

	// Token: 0x04002C20 RID: 11296
	public float fogIntensity;

	// Token: 0x04002C21 RID: 11297
	public float fogStartPoint = 50f;

	// Token: 0x04002C22 RID: 11298
	public float fogDistance = 170f;

	// Token: 0x04002C23 RID: 11299
	public Color fogColor = Color.white;

	// Token: 0x04002C24 RID: 11300
	public Color fogEndColor = Color.gray;

	// Token: 0x04002C25 RID: 11301
	public float fogHeight = 2f;

	// Token: 0x04002C26 RID: 11302
	public bool useAmbientObscurance;

	// Token: 0x04002C27 RID: 11303
	public SampleCount aoSampleCount = SampleCount.Low;

	// Token: 0x04002C28 RID: 11304
	public bool useAODistanceCutoff;

	// Token: 0x04002C29 RID: 11305
	public float aoDistanceCutoffLength = 50f;

	// Token: 0x04002C2A RID: 11306
	public float aoDistanceCutoffStart = 500f;

	// Token: 0x04002C2B RID: 11307
	public float aoIntensity = 0.7f;

	// Token: 0x04002C2C RID: 11308
	public float aoMinIntensity;

	// Token: 0x04002C2D RID: 11309
	public float aoRadius = 1f;

	// Token: 0x04002C2E RID: 11310
	public bool aoDownsample;

	// Token: 0x04002C2F RID: 11311
	public AOBlurType aoBlurType = AOBlurType.Fast;

	// Token: 0x04002C30 RID: 11312
	[Range(0f, 3f)]
	public int aoBlurIterations = 1;

	// Token: 0x04002C31 RID: 11313
	public float aoBias = 0.1f;

	// Token: 0x04002C32 RID: 11314
	public float aoBlurFilterDistance = 1.25f;

	// Token: 0x04002C33 RID: 11315
	public float aoLightingContribution = 1f;

	// Token: 0x04002C34 RID: 11316
	public bool aoShowDebug;

	// Token: 0x04002C35 RID: 11317
	public bool useRays;

	// Token: 0x04002C36 RID: 11318
	public Transform rayTransform;

	// Token: 0x04002C37 RID: 11319
	public float rayWeight = 0.58767f;

	// Token: 0x04002C38 RID: 11320
	public Color rayColor = Color.white;

	// Token: 0x04002C39 RID: 11321
	public Color rayThreshold = new Color(0.87f, 0.74f, 0.65f);

	// Token: 0x04002C3A RID: 11322
	public bool raysShowDebug;

	// Token: 0x04002C3B RID: 11323
	[Space(10f)]
	public bool advancedVignette;

	// Token: 0x04002C3C RID: 11324
	public bool advancedAO;

	// Token: 0x04002C3D RID: 11325
	private static readonly int int_0 = Shader.PropertyToID("_BloomIntensity");

	// Token: 0x04002C3E RID: 11326
	private static readonly int int_1 = Shader.PropertyToID("_BloomThreshold");

	// Token: 0x04002C3F RID: 11327
	private static readonly int int_2 = Shader.PropertyToID("_DirtIntensity");

	// Token: 0x04002C40 RID: 11328
	private static readonly int int_3 = Shader.PropertyToID("_FogIntensity");

	// Token: 0x04002C41 RID: 11329
	private static readonly int int_4 = Shader.PropertyToID("_VignetteStart");

	// Token: 0x04002C42 RID: 11330
	private static readonly int int_5 = Shader.PropertyToID("_VignetteEnd");

	// Token: 0x04002C43 RID: 11331
	private static readonly int int_6 = Shader.PropertyToID("_VignetteIntensity");

	// Token: 0x04002C44 RID: 11332
	private static readonly int int_7 = Shader.PropertyToID("_VignetteColor");

	// Token: 0x04002C45 RID: 11333
	private static readonly int int_8 = Shader.PropertyToID("_NVColor");

	// Token: 0x04002C46 RID: 11334
	private static readonly int int_9 = Shader.PropertyToID("_TargetWhiteColor");

	// Token: 0x04002C47 RID: 11335
	private static readonly int int_10 = Shader.PropertyToID("_BaseLightingContribution");

	// Token: 0x04002C48 RID: 11336
	private static readonly int int_11 = Shader.PropertyToID("_LightSensitivityMultiplier");

	// Token: 0x04002C49 RID: 11337
	private static readonly int int_12 = Shader.PropertyToID("_GrainIntensity");

	// Token: 0x04002C4A RID: 11338
	private static readonly int int_13 = Shader.PropertyToID("_GrainTex");

	// Token: 0x04002C4B RID: 11339
	private static readonly int int_14 = Shader.PropertyToID("_RandomInts");

	// Token: 0x04002C4C RID: 11340
	private static readonly int int_15 = Shader.PropertyToID("_ChromaticIntensity");

	// Token: 0x04002C4D RID: 11341
	private static readonly int int_16 = Shader.PropertyToID("_ChromaticParams");

	// Token: 0x04002C4E RID: 11342
	private static readonly int int_17 = Shader.PropertyToID("_ToneParams");

	// Token: 0x04002C4F RID: 11343
	private static readonly int int_18 = Shader.PropertyToID("_SecondaryToneParams");

	// Token: 0x04002C50 RID: 11344
	private static readonly int int_19 = Shader.PropertyToID("_Gamma");

	// Token: 0x04002C51 RID: 11345
	private static readonly int int_20 = Shader.PropertyToID("_SharpenAmount");

	// Token: 0x04002C52 RID: 11346
	private static readonly int int_21 = Shader.PropertyToID("_DirtTex");

	// Token: 0x04002C53 RID: 11347
	private static readonly int int_22 = Shader.PropertyToID("_ExposureLowerLimit");

	// Token: 0x04002C54 RID: 11348
	private static readonly int int_23 = Shader.PropertyToID("_ExposureUpperLimit");

	// Token: 0x04002C55 RID: 11349
	private static readonly int int_24 = Shader.PropertyToID("_ExposureMiddleGrey");

	// Token: 0x04002C56 RID: 11350
	private static readonly int int_25 = Shader.PropertyToID("_ExposureSpeed");

	// Token: 0x04002C57 RID: 11351
	private static readonly int int_26 = Shader.PropertyToID("useNoise");

	// Token: 0x04002C58 RID: 11352
	private static readonly int int_27 = Shader.PropertyToID("useNightVision");

	// Token: 0x04002C59 RID: 11353
	private static readonly int int_28 = Shader.PropertyToID("_SunWeight");

	// Token: 0x04002C5A RID: 11354
	private static readonly int int_29 = Shader.PropertyToID("_AOIntensity");

	// Token: 0x04002C5B RID: 11355
	private static readonly int int_30 = Shader.PropertyToID("_AOLuminanceWeighting");

	// Token: 0x04002C5C RID: 11356
	private static readonly int int_31 = Shader.PropertyToID("_AOSampleCount");

	// Token: 0x04002C5D RID: 11357
	private static readonly int int_32 = Shader.PropertyToID("_AOSpiralTurns");

	// Token: 0x04002C5E RID: 11358
	private static readonly int int_33 = Shader.PropertyToID("_SunColor");

	// Token: 0x04002C5F RID: 11359
	private static readonly int int_34 = Shader.PropertyToID("_SunThreshold");

	// Token: 0x04002C60 RID: 11360
	private static readonly int int_35 = Shader.PropertyToID("_SunPosition");

	// Token: 0x04002C61 RID: 11361
	private static readonly int int_36 = Shader.PropertyToID("_FogHeight");

	// Token: 0x04002C62 RID: 11362
	private static readonly int int_37 = Shader.PropertyToID("_FogDistance");

	// Token: 0x04002C63 RID: 11363
	private static readonly int int_38 = Shader.PropertyToID("_FogStart");

	// Token: 0x04002C64 RID: 11364
	private static readonly int int_39 = Shader.PropertyToID("_FogColor");

	// Token: 0x04002C65 RID: 11365
	private static readonly int int_40 = Shader.PropertyToID("_FogEndColor");

	// Token: 0x04002C66 RID: 11366
	private static readonly int int_41 = Shader.PropertyToID("_FogBlurSkybox");

	// Token: 0x04002C67 RID: 11367
	private static readonly int int_42 = Shader.PropertyToID("_InverseView");

	// Token: 0x04002C68 RID: 11368
	private static readonly int int_43 = Shader.PropertyToID("_AORadius");

	// Token: 0x04002C69 RID: 11369
	private static readonly int int_44 = Shader.PropertyToID("_AOBias");

	// Token: 0x04002C6A RID: 11370
	private static readonly int int_45 = Shader.PropertyToID("_AOTargetScale");

	// Token: 0x04002C6B RID: 11371
	private static readonly int int_46 = Shader.PropertyToID("_AOCutoff");

	// Token: 0x04002C6C RID: 11372
	private static readonly int int_47 = Shader.PropertyToID("_AOCutoffRange");

	// Token: 0x04002C6D RID: 11373
	private static readonly int int_48 = Shader.PropertyToID("_AOCameraModelView");

	// Token: 0x04002C6E RID: 11374
	private static readonly int int_49 = Shader.PropertyToID("_AOProjInfo");

	// Token: 0x04002C6F RID: 11375
	private static readonly int int_50 = Shader.PropertyToID("_LutScale");

	// Token: 0x04002C70 RID: 11376
	private static readonly int int_51 = Shader.PropertyToID("_LutOffset");

	// Token: 0x04002C71 RID: 11377
	private static readonly int int_52 = Shader.PropertyToID("_LutTex");

	// Token: 0x04002C72 RID: 11378
	private static readonly int int_53 = Shader.PropertyToID("_LutAmount");

	// Token: 0x04002C73 RID: 11379
	private static readonly int int_54 = Shader.PropertyToID("_SecondLutScale");

	// Token: 0x04002C74 RID: 11380
	private static readonly int int_55 = Shader.PropertyToID("_SecondLutOffset");

	// Token: 0x04002C75 RID: 11381
	private static readonly int int_56 = Shader.PropertyToID("_SecondLutTex");

	// Token: 0x04002C76 RID: 11382
	private static readonly int int_57 = Shader.PropertyToID("_SecondLutAmount");

	// Token: 0x04002C77 RID: 11383
	private static readonly int int_58 = Shader.PropertyToID("_DofFocusPoint");

	// Token: 0x04002C78 RID: 11384
	private static readonly int int_59 = Shader.PropertyToID("_DofFocusDistance");

	// Token: 0x04002C79 RID: 11385
	private static readonly int int_60 = Shader.PropertyToID("_DofRadius");

	// Token: 0x04002C7A RID: 11386
	private static readonly int int_61 = Shader.PropertyToID("_DofFactor");

	// Token: 0x04002C7B RID: 11387
	private static readonly int int_62 = Shader.PropertyToID("_DofUseNearBlur");

	// Token: 0x04002C7C RID: 11388
	private static readonly int int_63 = Shader.PropertyToID("_DofNearFocusDistance");

	// Token: 0x04002C7D RID: 11389
	private static readonly int int_64 = Shader.PropertyToID("_DofBlurSkybox");

	// Token: 0x04002C7E RID: 11390
	private static readonly int int_65 = Shader.PropertyToID("_BrightnessTexture");

	// Token: 0x04002C7F RID: 11391
	private static readonly int int_66 = Shader.PropertyToID("_BlurVector");

	// Token: 0x04002C80 RID: 11392
	private static readonly int int_67 = Shader.PropertyToID("_LastCameraDepthTexture1");

	// Token: 0x04002C81 RID: 11393
	private static readonly int int_68 = Shader.PropertyToID("_DoF1");

	// Token: 0x04002C82 RID: 11394
	private static readonly int int_69 = Shader.PropertyToID("_DofUseLerp");

	// Token: 0x04002C83 RID: 11395
	private static readonly int int_70 = Shader.PropertyToID("currentIteration");

	// Token: 0x04002C84 RID: 11396
	private static readonly int int_71 = Shader.PropertyToID("_BlurredScreenTex");

	// Token: 0x04002C85 RID: 11397
	private static readonly int int_72 = Shader.PropertyToID("_Bloom1");

	// Token: 0x04002C86 RID: 11398
	private static readonly int int_73 = Shader.PropertyToID("_BloomAcc");

	// Token: 0x04002C87 RID: 11399
	private static readonly int int_74 = Shader.PropertyToID("_Bloom2");

	// Token: 0x04002C88 RID: 11400
	private static readonly int int_75 = Shader.PropertyToID("_Bloom3");

	// Token: 0x04002C89 RID: 11401
	private static readonly int int_76 = Shader.PropertyToID("_Bloom4");

	// Token: 0x04002C8A RID: 11402
	private static readonly int int_77 = Shader.PropertyToID("_AOBlurVector");

	// Token: 0x04002C8B RID: 11403
	private static readonly int int_78 = Shader.PropertyToID("_AOTex");

	// Token: 0x04002C8C RID: 11404
	private static readonly int int_79 = Shader.PropertyToID("_RaysTexture");

	// Token: 0x04002C8D RID: 11405
	private bool bool_2;

}
