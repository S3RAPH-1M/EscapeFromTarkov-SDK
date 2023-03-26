using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

// Token: 0x02000731 RID: 1841
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class UltimateBloom : MonoBehaviour
{
	// Token: 0x04002B0C RID: 11020
	public float m_SamplingMinHeight = 400f;

	// Token: 0x04002B0D RID: 11021
	public float[] m_ResSamplingPixelCount = new float[6];

	// Token: 0x04002B0E RID: 11022
	public UltimateBloom.SamplingMode m_SamplingMode;

	// Token: 0x04002B0F RID: 11023
	public UltimateBloom.BlendMode m_BlendMode;

	// Token: 0x04002B10 RID: 11024
	public float m_ScreenMaxIntensity;

	// Token: 0x04002B11 RID: 11025
	public UltimateBloom.BloomQualityPreset m_QualityPreset;

	// Token: 0x04002B12 RID: 11026
	public UltimateBloom.HDRBloomMode m_HDR;

	// Token: 0x04002B13 RID: 11027
	public UltimateBloom.BloomScreenBlendMode m_ScreenBlendMode = UltimateBloom.BloomScreenBlendMode.Add;

	// Token: 0x04002B14 RID: 11028
	public float m_BloomIntensity = 1f;

	// Token: 0x04002B15 RID: 11029
	public float m_BloomThreshhold = 0.5f;

	// Token: 0x04002B16 RID: 11030
	public Color m_BloomThreshholdColor = Color.white;

	// Token: 0x04002B17 RID: 11031
	public int m_DownscaleCount = 5;

	// Token: 0x04002B18 RID: 11032
	public UltimateBloom.BloomIntensityManagement m_IntensityManagement;

	// Token: 0x04002B19 RID: 11033
	public float[] m_BloomIntensities;

	// Token: 0x04002B1A RID: 11034
	public Color[] m_BloomColors;

	// Token: 0x04002B1B RID: 11035
	public bool[] m_BloomUsages;

	// Token: 0x04002B1C RID: 11036
	[SerializeField]
	public DeluxeFilmicCurve m_BloomCurve = new DeluxeFilmicCurve();

	// Token: 0x04002B1D RID: 11037
	private int int_0 = 5;

	// Token: 0x04002B1E RID: 11038
	public bool useTriangleBlit = true;

	// Token: 0x04002B1F RID: 11039
	private CommandBuffer commandBuffer_0;

	// Token: 0x04002B20 RID: 11040
	private List<RenderTexture> list_0 = new List<RenderTexture>();

	// Token: 0x04002B21 RID: 11041
	private List<MaterialPropertyBlock> list_1 = new List<MaterialPropertyBlock>();

	// Token: 0x04002B22 RID: 11042
	private int int_1;

	// Token: 0x04002B23 RID: 11043
	public bool m_UseLensFlare;

	// Token: 0x04002B24 RID: 11044
	public float m_FlareTreshold = 0.8f;

	// Token: 0x04002B25 RID: 11045
	public float m_FlareIntensity = 0.25f;

	// Token: 0x04002B26 RID: 11046
	public Color m_FlareTint0 = new Color(0.5372549f, 0.32156864f, 0f);

	// Token: 0x04002B27 RID: 11047
	public Color m_FlareTint1 = new Color(0f, 0.24705882f, 0.49411765f);

	// Token: 0x04002B28 RID: 11048
	public Color m_FlareTint2 = new Color(0.28235295f, 0.5921569f, 0f);

	// Token: 0x04002B29 RID: 11049
	public Color m_FlareTint3 = new Color(0.44705883f, 0.13725491f, 0f);

	// Token: 0x04002B2A RID: 11050
	public Color m_FlareTint4 = new Color(0.47843137f, 0.34509805f, 0f);

	// Token: 0x04002B2B RID: 11051
	public Color m_FlareTint5 = new Color(0.5372549f, 0.2784314f, 0f);

	// Token: 0x04002B2C RID: 11052
	public Color m_FlareTint6 = new Color(0.38039216f, 0.54509807f, 0f);

	// Token: 0x04002B2D RID: 11053
	public Color m_FlareTint7 = new Color(0.15686275f, 0.5568628f, 0f);

	// Token: 0x04002B2E RID: 11054
	public float m_FlareGlobalScale = 1f;

	// Token: 0x04002B2F RID: 11055
	public Vector4 m_FlareScales = new Vector4(1f, 0.6f, 0.5f, 0.4f);

	// Token: 0x04002B30 RID: 11056
	public Vector4 m_FlareScalesNear = new Vector4(1f, 0.8f, 0.6f, 0.5f);

	// Token: 0x04002B31 RID: 11057
	public Texture2D m_FlareMask;

	// Token: 0x04002B32 RID: 11058
	public UltimateBloom.FlareRendering m_FlareRendering = UltimateBloom.FlareRendering.Blurred;

	// Token: 0x04002B33 RID: 11059
	public UltimateBloom.FlareType m_FlareType = UltimateBloom.FlareType.Double;

	// Token: 0x04002B34 RID: 11060
	public Texture2D m_FlareShape;

	// Token: 0x04002B35 RID: 11061
	public UltimateBloom.FlareBlurQuality m_FlareBlurQuality = UltimateBloom.FlareBlurQuality.High;

	// Token: 0x04002B37 RID: 11063
	private Mesh[] mesh_0;

	// Token: 0x04002B38 RID: 11064
	public bool m_UseBokehFlare;

	// Token: 0x04002B39 RID: 11065
	public float m_BokehScale = 0.4f;

	// Token: 0x04002B3A RID: 11066
	public UltimateBloom.BokehFlareQuality m_BokehFlareQuality = UltimateBloom.BokehFlareQuality.Medium;

	// Token: 0x04002B3B RID: 11067
	public bool m_UseAnamorphicFlare;

	// Token: 0x04002B3C RID: 11068
	public float m_AnamorphicFlareTreshold = 0.8f;

	// Token: 0x04002B3D RID: 11069
	public float m_AnamorphicFlareIntensity = 1f;

	// Token: 0x04002B3E RID: 11070
	public int m_AnamorphicDownscaleCount = 3;

	// Token: 0x04002B3F RID: 11071
	public int m_AnamorphicBlurPass = 2;

	// Token: 0x04002B40 RID: 11072
	private int int_2;

	// Token: 0x04002B41 RID: 11073
	private RenderTexture[] renderTexture_0;

	// Token: 0x04002B42 RID: 11074
	public float[] m_AnamorphicBloomIntensities;

	// Token: 0x04002B43 RID: 11075
	public Color[] m_AnamorphicBloomColors;

	// Token: 0x04002B44 RID: 11076
	public bool[] m_AnamorphicBloomUsages;

	// Token: 0x04002B45 RID: 11077
	public bool m_AnamorphicSmallVerticalBlur = true;

	// Token: 0x04002B46 RID: 11078
	public UltimateBloom.AnamorphicDirection m_AnamorphicDirection;

	// Token: 0x04002B47 RID: 11079
	public float m_AnamorphicScale = 3f;

	// Token: 0x04002B48 RID: 11080
	public bool m_UseStarFlare;

	// Token: 0x04002B49 RID: 11081
	public float m_StarFlareTreshol = 0.8f;

	// Token: 0x04002B4A RID: 11082
	public float m_StarFlareIntensity = 1f;

	// Token: 0x04002B4B RID: 11083
	public float m_StarScale = 2f;

	// Token: 0x04002B4C RID: 11084
	public int m_StarDownscaleCount = 3;

	// Token: 0x04002B4D RID: 11085
	public int m_StarBlurPass = 2;

	// Token: 0x04002B4E RID: 11086
	private int int_3;

	// Token: 0x04002B4F RID: 11087
	private RenderTexture[] renderTexture_1;

	// Token: 0x04002B50 RID: 11088
	public float[] m_StarBloomIntensities;

	// Token: 0x04002B51 RID: 11089
	public Color[] m_StarBloomColors;

	// Token: 0x04002B52 RID: 11090
	public bool[] m_StarBloomUsages;

	// Token: 0x04002B53 RID: 11091
	public bool m_UseLensDust;

	// Token: 0x04002B54 RID: 11092
	public float m_DustIntensity = 1f;

	// Token: 0x04002B55 RID: 11093
	public Texture2D m_DustTexture;

	// Token: 0x04002B56 RID: 11094
	public float m_DirtLightIntensity = 5f;

	// Token: 0x04002B57 RID: 11095
	public UltimateBloom.BloomSamplingQuality m_DownsamplingQuality;

	// Token: 0x04002B58 RID: 11096
	public UltimateBloom.BloomSamplingQuality m_UpsamplingQuality;

	// Token: 0x04002B59 RID: 11097
	public bool m_TemporalStableDownsampling = true;

	// Token: 0x04002B5A RID: 11098
	public bool m_InvertImage;

	// Token: 0x04002B5B RID: 11099
	private Material material_0;

	// Token: 0x04002B5C RID: 11100
	private Shader shader_0;

	// Token: 0x04002B5D RID: 11101
	private Material material_1;

	// Token: 0x04002B5E RID: 11102
	private Shader shader_1;

	// Token: 0x04002B5F RID: 11103
	private Material material_2;

	// Token: 0x04002B60 RID: 11104
	private Shader shader_2;

	// Token: 0x04002B61 RID: 11105
	private Material material_3;

	// Token: 0x04002B62 RID: 11106
	private Material material_4;

	// Token: 0x04002B63 RID: 11107
	private Shader shader_3;

	// Token: 0x04002B64 RID: 11108
	private Shader shader_4;

	// Token: 0x04002B65 RID: 11109
	private Material material_5;

	// Token: 0x04002B66 RID: 11110
	private Shader shader_5;

	// Token: 0x04002B67 RID: 11111
	private Material material_6;

	// Token: 0x04002B68 RID: 11112
	private Shader shader_6;

	// Token: 0x04002B69 RID: 11113
	private Material material_7;

	// Token: 0x04002B6A RID: 11114
	private Shader shader_7;

	// Token: 0x04002B6B RID: 11115
	public bool m_DirectDownSample;

	// Token: 0x04002B6C RID: 11116
	public bool m_DirectUpsample;

	// Token: 0x04002B6D RID: 11117
	public bool m_UiShowBloomScales;

	// Token: 0x04002B6E RID: 11118
	public bool m_UiShowAnamorphicBloomScales;

	// Token: 0x04002B6F RID: 11119
	public bool m_UiShowStarBloomScales;

	// Token: 0x04002B70 RID: 11120
	public bool m_UiShowHeightSampling;

	// Token: 0x04002B71 RID: 11121
	public bool m_UiShowBloomSettings;

	// Token: 0x04002B72 RID: 11122
	public bool m_UiShowSampling;

	// Token: 0x04002B73 RID: 11123
	public bool m_UiShowIntensity;

	// Token: 0x04002B74 RID: 11124
	public bool m_UiShowOptimizations;

	// Token: 0x04002B75 RID: 11125
	public bool m_UiShowLensDirt;

	// Token: 0x04002B76 RID: 11126
	public bool m_UiShowLensFlare;

	// Token: 0x04002B77 RID: 11127
	public bool m_UiShowAnamorphic;

	// Token: 0x04002B78 RID: 11128
	public bool m_UiShowStar;

	// Token: 0x04002B7A RID: 11130
	private static readonly int int_4 = Shader.PropertyToID("_MaskTex");

	// Token: 0x04002B7B RID: 11131
	private static readonly int int_5 = Shader.PropertyToID("_Intensity");

	// Token: 0x04002B7C RID: 11132
	private static readonly int int_6 = Shader.PropertyToID("_FlareIntensity");

	// Token: 0x04002B7D RID: 11133
	private static readonly int int_7 = Shader.PropertyToID("_ColorBuffer");

	// Token: 0x04002B7E RID: 11134
	private static readonly int int_8 = Shader.PropertyToID("_FlareTexture");

	// Token: 0x04002B7F RID: 11135
	private static readonly int int_9 = Shader.PropertyToID("_AdditiveTexture");

	// Token: 0x04002B80 RID: 11136
	private static readonly int int_10 = Shader.PropertyToID("_brightTexture");

	// Token: 0x04002B81 RID: 11137
	private static readonly int int_11 = Shader.PropertyToID("_DirtIntensity");

	// Token: 0x04002B82 RID: 11138
	private static readonly int int_12 = Shader.PropertyToID("_DirtLightIntensity");

	// Token: 0x04002B83 RID: 11139
	private static readonly int int_13 = Shader.PropertyToID("_ScreenMaxIntensity");

	// Token: 0x04002B84 RID: 11140
	private static readonly int int_14 = Shader.PropertyToID("_FlareScales");

	// Token: 0x04002B85 RID: 11141
	private static readonly int int_15 = Shader.PropertyToID("_FlareScalesNear");

	// Token: 0x04002B86 RID: 11142
	private static readonly int int_16 = Shader.PropertyToID("_FlareTint0");

	// Token: 0x04002B87 RID: 11143
	private static readonly int int_17 = Shader.PropertyToID("_FlareTint1");

	// Token: 0x04002B88 RID: 11144
	private static readonly int int_18 = Shader.PropertyToID("_FlareTint2");

	// Token: 0x04002B89 RID: 11145
	private static readonly int int_19 = Shader.PropertyToID("_FlareTint3");

	// Token: 0x04002B8A RID: 11146
	private static readonly int int_20 = Shader.PropertyToID("_FlareTint4");

	// Token: 0x04002B8B RID: 11147
	private static readonly int int_21 = Shader.PropertyToID("_FlareTint5");

	// Token: 0x04002B8C RID: 11148
	private static readonly int int_22 = Shader.PropertyToID("_FlareTint6");

	// Token: 0x04002B8D RID: 11149
	private static readonly int int_23 = Shader.PropertyToID("_FlareTint7");

	// Token: 0x04002B8E RID: 11150
	private static readonly int int_24 = Shader.PropertyToID("_CurveExposure");

	// Token: 0x04002B8F RID: 11151
	private static readonly int int_25 = Shader.PropertyToID("_K");

	// Token: 0x04002B90 RID: 11152
	private static readonly int int_26 = Shader.PropertyToID("_Crossover");

	// Token: 0x04002B91 RID: 11153
	private static readonly int int_27 = Shader.PropertyToID("_Toe");

	// Token: 0x04002B92 RID: 11154
	private static readonly int int_28 = Shader.PropertyToID("_Shoulder");

	// Token: 0x04002B93 RID: 11155
	private static readonly int int_29 = Shader.PropertyToID("_MaxValue");

	// Token: 0x04002B94 RID: 11156
	private static readonly int int_30 = Shader.PropertyToID("_Threshhold");

	// Token: 0x04002B95 RID: 11157
	private static readonly int int_31 = Shader.PropertyToID("_OffsetInfos");

	// Token: 0x04002B96 RID: 11158
	private static readonly int int_32 = Shader.PropertyToID("_Tint");

	// Token: 0x04002B97 RID: 11159
	private static readonly int int_33 = Shader.PropertyToID("_Intensity0");

	// Token: 0x04002B98 RID: 11160
	private static readonly int int_34 = Shader.PropertyToID("_Intensity1");

	// Token: 0x04002B99 RID: 11161
	private RenderTexture[] renderTexture_2;

	// Token: 0x04002B9A RID: 11162
	private RenderTexture[] renderTexture_3;

	// Token: 0x04002B9B RID: 11163
	private RenderTextureFormat renderTextureFormat_0;

	// Token: 0x04002B9C RID: 11164
	private bool[] bool_0;

	// Token: 0x04002B9D RID: 11165
	private RenderTexture renderTexture_4;

	// Token: 0x02000732 RID: 1842
	public enum BloomQualityPreset
	{
		// Token: 0x04002B9F RID: 11167
		Optimized,
		// Token: 0x04002BA0 RID: 11168
		Standard,
		// Token: 0x04002BA1 RID: 11169
		HighVisuals,
		// Token: 0x04002BA2 RID: 11170
		Custom
	}

	// Token: 0x02000733 RID: 1843
	public enum BloomSamplingQuality
	{
		// Token: 0x04002BA4 RID: 11172
		VerySmallKernel,
		// Token: 0x04002BA5 RID: 11173
		SmallKernel,
		// Token: 0x04002BA6 RID: 11174
		MediumKernel,
		// Token: 0x04002BA7 RID: 11175
		LargeKernel,
		// Token: 0x04002BA8 RID: 11176
		LargerKernel,
		// Token: 0x04002BA9 RID: 11177
		VeryLargeKernel
	}

	// Token: 0x02000734 RID: 1844
	public enum BloomScreenBlendMode
	{
		// Token: 0x04002BAB RID: 11179
		Screen,
		// Token: 0x04002BAC RID: 11180
		Add
	}

	// Token: 0x02000735 RID: 1845
	public enum HDRBloomMode
	{
		// Token: 0x04002BAE RID: 11182
		Auto,
		// Token: 0x04002BAF RID: 11183
		On,
		// Token: 0x04002BB0 RID: 11184
		Off
	}

	// Token: 0x02000736 RID: 1846
	public enum BlurSampleCount
	{
		// Token: 0x04002BB2 RID: 11186
		Nine,
		// Token: 0x04002BB3 RID: 11187
		Seventeen,
		// Token: 0x04002BB4 RID: 11188
		Thirteen,
		// Token: 0x04002BB5 RID: 11189
		TwentyThree,
		// Token: 0x04002BB6 RID: 11190
		TwentySeven,
		// Token: 0x04002BB7 RID: 11191
		ThrirtyOne,
		// Token: 0x04002BB8 RID: 11192
		NineCurve,
		// Token: 0x04002BB9 RID: 11193
		FourSimple
	}

	// Token: 0x02000737 RID: 1847
	public enum FlareRendering
	{
		// Token: 0x04002BBB RID: 11195
		Sharp,
		// Token: 0x04002BBC RID: 11196
		Blurred,
		// Token: 0x04002BBD RID: 11197
		MoreBlurred
	}

	// Token: 0x02000738 RID: 1848
	public enum SimpleSampleCount
	{
		// Token: 0x04002BBF RID: 11199
		Four,
		// Token: 0x04002BC0 RID: 11200
		Nine,
		// Token: 0x04002BC1 RID: 11201
		FourCurve,
		// Token: 0x04002BC2 RID: 11202
		ThirteenTemporal,
		// Token: 0x04002BC3 RID: 11203
		ThirteenTemporalCurve
	}

	// Token: 0x02000739 RID: 1849
	public enum FlareType
	{
		// Token: 0x04002BC5 RID: 11205
		Single,
		// Token: 0x04002BC6 RID: 11206
		Double
	}

	// Token: 0x0200073A RID: 1850
	public enum BloomIntensityManagement
	{
		// Token: 0x04002BC8 RID: 11208
		FilmicCurve,
		// Token: 0x04002BC9 RID: 11209
		Threshold
	}

	// Token: 0x0200073B RID: 1851
	private enum FlareStripeType
	{
		// Token: 0x04002BCB RID: 11211
		Anamorphic,
		// Token: 0x04002BCC RID: 11212
		Star,
		// Token: 0x04002BCD RID: 11213
		DiagonalUpright,
		// Token: 0x04002BCE RID: 11214
		DiagonalUpleft
	}

	// Token: 0x0200073C RID: 1852
	public enum AnamorphicDirection
	{
		// Token: 0x04002BD0 RID: 11216
		Horizontal,
		// Token: 0x04002BD1 RID: 11217
		Vertical
	}

	// Token: 0x0200073D RID: 1853
	public enum BokehFlareQuality
	{
		// Token: 0x04002BD3 RID: 11219
		Low,
		// Token: 0x04002BD4 RID: 11220
		Medium,
		// Token: 0x04002BD5 RID: 11221
		High,
		// Token: 0x04002BD6 RID: 11222
		VeryHigh
	}

	// Token: 0x0200073E RID: 1854
	public enum BlendMode
	{
		// Token: 0x04002BD8 RID: 11224
		ADD,
		// Token: 0x04002BD9 RID: 11225
		SCREEN
	}

	// Token: 0x0200073F RID: 1855
	public enum SamplingMode
	{
		// Token: 0x04002BDB RID: 11227
		Fixed,
		// Token: 0x04002BDC RID: 11228
		HeightRelative
	}

	// Token: 0x02000740 RID: 1856
	public enum FlareBlurQuality
	{
		// Token: 0x04002BDE RID: 11230
		Fast,
		// Token: 0x04002BDF RID: 11231
		Normal,
		// Token: 0x04002BE0 RID: 11232
		High
	}

	// Token: 0x02000741 RID: 1857
	public enum FlarePresets
	{
		// Token: 0x04002BE2 RID: 11234
		ChoosePreset,
		// Token: 0x04002BE3 RID: 11235
		GhostFast,
		// Token: 0x04002BE4 RID: 11236
		Ghost1,
		// Token: 0x04002BE5 RID: 11237
		Ghost2,
		// Token: 0x04002BE6 RID: 11238
		Ghost3,
		// Token: 0x04002BE7 RID: 11239
		Bokeh1,
		// Token: 0x04002BE8 RID: 11240
		Bokeh2,
		// Token: 0x04002BE9 RID: 11241
		Bokeh3
	}

	// Token: 0x02000742 RID: 1858
	// (Invoke) Token: 0x0600304C RID: 12364
	private delegate void Delegate2(RenderTexture source, RenderTexture destination, float horizontalBlur, float verticalBlur, RenderTexture additiveTexture, UltimateBloom.BlurSampleCount sampleCount, Color tint, float intensity);
}
