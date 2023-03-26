using System;
using UnityEngine;

// Token: 0x020009F1 RID: 2545
[Serializable]
public class GlitchUtilities
{
	// Token: 0x04003E0E RID: 15886
	public Shader Shader;

	// Token: 0x04003E0F RID: 15887
	public Texture2D DisplacementMap;

	// Token: 0x04003E10 RID: 15888
	[Header("Digital Mistake")]
	[Range(0f, 1f)]
	public float DigitalMistakeIntensity;

	// Token: 0x04003E11 RID: 15889
	[Range(0f, 1f)]
	public float DigitalMistakeFrequency = 1f;

	// Token: 0x04003E12 RID: 15890
	[Range(0f, 1f)]
	[Header("Vertical Flip")]
	public float VerticalFlipIntensity;

	// Token: 0x04003E13 RID: 15891
	[Range(0f, 1f)]
	public float VerticalFlipFrequency = 1f;

	// Token: 0x04003E14 RID: 15892
	[Header("Color Switch")]
	[Range(0f, 1f)]
	public float ColorSwitchIntensity;

	// Token: 0x04003E15 RID: 15893
	[Range(0f, 1f)]
	public float ColorSwitchFrequency = 1f;

	// Token: 0x04003E16 RID: 15894
	[Header("Vertical Jump")]
	[Range(0f, 1f)]
	public float VerticalJumpCoef;

	// Token: 0x04003E17 RID: 15895
	[Range(0f, 1f)]
	public float VerticalJumpFrequency = 1f;

	// Token: 0x04003E18 RID: 15896
	public float VerticalJumpTimeScale = 11.3f;

	// Token: 0x04003E19 RID: 15897
	[Header("Scan Line Jitter")]
	[Range(0f, 1f)]
	public float ScanLineJitterCoef;

	// Token: 0x04003E1A RID: 15898
	[Range(0f, 1f)]
	public float ScanLineJitterFrequency = 1f;

	// Token: 0x04003E1B RID: 15899
	[Range(0f, 1f)]
	[Header("Horizontal Shake")]
	public float HorizontalShake;

	// Token: 0x04003E1C RID: 15900
	[Range(0f, 1f)]
	public float HorizontalShakeFrequency = 1f;

	// Token: 0x04003E1D RID: 15901
	[Range(0f, 1f)]
	[Header("Color Drift")]
	public float ColorDriftCoef;

	// Token: 0x04003E1E RID: 15902
	[Range(0f, 1f)]
	public float ColorDriftFrequency = 1f;

	// Token: 0x04003E1F RID: 15903
	public float MaxColorDrift = 0.06f;
}
