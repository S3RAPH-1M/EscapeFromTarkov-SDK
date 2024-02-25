using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Prism.Utils
{
	// Token: 0x02000C60 RID: 3168
	[Serializable]
	public class PrismPreset : ScriptableObject
	{
		// Token: 0x04004DE5 RID: 19941
		public string PresetDescription;

		// Token: 0x04004DE6 RID: 19942
		public PrismPresetType presetType;

		// Token: 0x04004DE7 RID: 19943
		[SerializeField]
		public bool useBloom;

		// Token: 0x04004DE8 RID: 19944
		[SerializeField]
		public BloomType bloomType;

		// Token: 0x04004DE9 RID: 19945
		[SerializeField]
		public bool bloomUseScreenBlend;

		// Token: 0x04004DEA RID: 19946
		[SerializeField]
		public int bloomDownsample;

		// Token: 0x04004DEB RID: 19947
		[SerializeField]
		public int bloomBlurPasses;

		// Token: 0x04004DEC RID: 19948
		[SerializeField]
		public float bloomIntensity;

		// Token: 0x04004DED RID: 19949
		[SerializeField]
		public float bloomThreshold;

		// Token: 0x04004DEE RID: 19950
		[SerializeField]
		public bool useBloomStability;

		// Token: 0x04004DEF RID: 19951
		[SerializeField]
		public bool useBloomLensdirt;

		// Token: 0x04004DF0 RID: 19952
		[SerializeField]
		public float bloomLensdirtIntensity;

		// Token: 0x04004DF1 RID: 19953
		[SerializeField]
		public Texture2D bloomLensdirtTexture;

		// Token: 0x04004DF2 RID: 19954
		[SerializeField]
		public bool useFullScreenBlur;

		// Token: 0x04004DF3 RID: 19955
		[SerializeField]
		public bool useUIBlur;

		// Token: 0x04004DF4 RID: 19956
		[SerializeField]
		public int uiBlurGrabTextureFromPassNumber;

		// Token: 0x04004DF5 RID: 19957
		[SerializeField]
		public bool useFog;

		// Token: 0x04004DF6 RID: 19958
		[SerializeField]
		public bool fogAffectSkybox;

		// Token: 0x04004DF7 RID: 19959
		[SerializeField]
		public float fogIntensity;

		// Token: 0x04004DF8 RID: 19960
		[SerializeField]
		public float fogHeight;

		// Token: 0x04004DF9 RID: 19961
		[SerializeField]
		public float fogStartPoint;

		// Token: 0x04004DFA RID: 19962
		[SerializeField]
		public float fogDistance;

		// Token: 0x04004DFB RID: 19963
		[SerializeField]
		public Color fogColor;

		// Token: 0x04004DFC RID: 19964
		[SerializeField]
		public Color fogEndColor;

		// Token: 0x04004DFD RID: 19965
		[SerializeField]
		public bool useDoF;

		// Token: 0x04004DFE RID: 19966
		[SerializeField]
		public float dofRadius;

		// Token: 0x04004DFF RID: 19967
		[SerializeField]
		public DoFSamples dofSampleCount;

		// Token: 0x04004E00 RID: 19968
		[SerializeField]
		public float dofBokehFactor;

		// Token: 0x04004E01 RID: 19969
		[SerializeField]
		public float dofFocusPoint;

		// Token: 0x04004E02 RID: 19970
		[SerializeField]
		public float dofFocusDistance;

		// Token: 0x04004E03 RID: 19971
		[SerializeField]
		public bool useNearBlur;

		// Token: 0x04004E04 RID: 19972
		[SerializeField]
		public bool dofBlurSkybox;

		// Token: 0x04004E05 RID: 19973
		[SerializeField]
		public float dofNearFocusDistance;

		// Token: 0x04004E06 RID: 19974
		[SerializeField]
		public bool dofForceEnableMedian;

		// Token: 0x04004E07 RID: 19975
		[SerializeField]
		public bool useAmbientObscurance;

		// Token: 0x04004E08 RID: 19976
		[SerializeField]
		public float aoIntensity;

		// Token: 0x04004E09 RID: 19977
		[SerializeField]
		public float aoRadius;

		// Token: 0x04004E0A RID: 19978
		[SerializeField]
		public float aoBias;

		// Token: 0x04004E0B RID: 19979
		[SerializeField]
		public bool aoDownsample;

		// Token: 0x04004E0C RID: 19980
		[SerializeField]
		public int aoBlurIterations;

		// Token: 0x04004E0D RID: 19981
		[SerializeField]
		public float aoBlurFilterDistance;

		// Token: 0x04004E0E RID: 19982
		[SerializeField]
		public bool useAODistanceCutoff;

		// Token: 0x04004E0F RID: 19983
		[SerializeField]
		public float aoDistanceCutoffLength;

		// Token: 0x04004E10 RID: 19984
		[SerializeField]
		public float aoDistanceCutoffStart;

		// Token: 0x04004E11 RID: 19985
		[SerializeField]
		public SampleCount aoSampleCount;

		// Token: 0x04004E12 RID: 19986
		[SerializeField]
		public AOBlurType aoBlurType;

		// Token: 0x04004E13 RID: 19987
		[SerializeField]
		public float aoLightingContribution;

		// Token: 0x04004E14 RID: 19988
		[SerializeField]
		public bool useChromaticAb;

		// Token: 0x04004E15 RID: 19989
		[SerializeField]
		public AberrationType aberrationType;

		// Token: 0x04004E16 RID: 19990
		[SerializeField]
		public float chromIntensity;

		// Token: 0x04004E17 RID: 19991
		[SerializeField]
		public float chromStart;

		// Token: 0x04004E18 RID: 19992
		[SerializeField]
		public float chromEnd;

		// Token: 0x04004E19 RID: 19993
		[SerializeField]
		public bool useChromaticBlur;

		// Token: 0x04004E1A RID: 19994
		[SerializeField]
		public float chromaticBlurWidth;

		// Token: 0x04004E1B RID: 19995
		[SerializeField]
		public bool useVignette;

		// Token: 0x04004E1C RID: 19996
		[SerializeField]
		public float vignetteStart;

		// Token: 0x04004E1D RID: 19997
		[SerializeField]
		public float vignetteEnd;

		// Token: 0x04004E1E RID: 19998
		[SerializeField]
		public float vignetteIntensity;

		// Token: 0x04004E1F RID: 19999
		[SerializeField]
		public Color vignetteColor;

		// Token: 0x04004E20 RID: 20000
		[SerializeField]
		public bool useNoise;

		// Token: 0x04004E21 RID: 20001
		[SerializeField]
		public float noiseIntensity;

		// Token: 0x04004E22 RID: 20002
		[SerializeField]
		public bool useTonemap;

		// Token: 0x04004E23 RID: 20003
		[SerializeField]
		public TonemapType toneType;

		// Token: 0x04004E24 RID: 20004
		[SerializeField]
		public Vector3 toneValues;

		// Token: 0x04004E25 RID: 20005
		[SerializeField]
		public Vector3 secondaryToneValues;

		// Token: 0x04004E26 RID: 20006
		[SerializeField]
		public bool useGammaCorrection;

		// Token: 0x04004E27 RID: 20007
		[SerializeField]
		public float gammaValue;

		// Token: 0x04004E28 RID: 20008
		[SerializeField]
		public bool useExposure;

		// Token: 0x04004E29 RID: 20009
		[SerializeField]
		public float exposureSpeed;

		// Token: 0x04004E2A RID: 20010
		[SerializeField]
		public float exposureMiddleGrey;

		// Token: 0x04004E2B RID: 20011
		[SerializeField]
		public float exposureLowerLimit;

		// Token: 0x04004E2C RID: 20012
		[SerializeField]
		public float exposureUpperLimit;

		// Token: 0x04004E2D RID: 20013
		[SerializeField]
		public bool useLUT;

		// Token: 0x04004E2E RID: 20014
		[SerializeField]
		public string lutPath;

		// Token: 0x04004E2F RID: 20015
		[SerializeField]
		public float lutIntensity;

		// Token: 0x04004E30 RID: 20016
		[SerializeField]
		public Texture2D twoDLookupTex;

		// Token: 0x04004E31 RID: 20017
		[SerializeField]
		public bool useSecondLut;

		// Token: 0x04004E32 RID: 20018
		[SerializeField]
		public string secondaryLutPath;

		// Token: 0x04004E33 RID: 20019
		[SerializeField]
		public Texture2D secondaryTwoDLookupTex;

		// Token: 0x04004E34 RID: 20020
		[SerializeField]
		public float secondaryLutLerpAmount;

		// Token: 0x04004E35 RID: 20021
		[SerializeField]
		public bool useNV;

		// Token: 0x04004E36 RID: 20022
		[SerializeField]
		public Color nvColor;

		// Token: 0x04004E37 RID: 20023
		[SerializeField]
		public Color nvBleachColor;

		// Token: 0x04004E38 RID: 20024
		[SerializeField]
		public float nvLightingContrib;

		// Token: 0x04004E39 RID: 20025
		[SerializeField]
		public float nvLightSensitivity;

		// Token: 0x04004E3A RID: 20026
		[SerializeField]
		public bool useRays;

		// Token: 0x04004E3B RID: 20027
		[SerializeField]
		public float rayWeight;

		// Token: 0x04004E3C RID: 20028
		[SerializeField]
		public Color rayColor;

		// Token: 0x04004E3D RID: 20029
		[SerializeField]
		public Color rayThreshold;
	}
}
