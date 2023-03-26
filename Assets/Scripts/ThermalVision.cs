using System;
using System.Runtime.CompilerServices;
using BSG.CameraEffects;
using EFT.InventoryLogic;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x020009FA RID: 2554
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ThermalVision : MonoBehaviour
{
	// Token: 0x04003E62 RID: 15970
	public bool On;

	// Token: 0x04003E63 RID: 15971
	public bool IsNoisy;

	// Token: 0x04003E64 RID: 15972
	public bool IsFpsStuck;

	// Token: 0x04003E65 RID: 15973
	public bool IsMotionBlurred;

	// Token: 0x04003E66 RID: 15974
	public bool IsGlitch;

	// Token: 0x04003E67 RID: 15975
	public bool IsPixelated;

	// Token: 0x04003E68 RID: 15976
	public bool ZeroedUnsharpRadius;

	// Token: 0x04003E69 RID: 15977
	public ThermalVisionUtilities ThermalVisionUtilities;

	// Token: 0x04003E6A RID: 15978
	public StuckFPSUtilities StuckFpsUtilities;

	// Token: 0x04003E6B RID: 15979
	public MotionBlurUtilities MotionBlurUtilities;

	// Token: 0x04003E6C RID: 15980
	public GlitchUtilities GlitchUtilities;

	// Token: 0x04003E6D RID: 15981
	public PixelationUtilities PixelationUtilities;

	// Token: 0x04003E6E RID: 15982
	public TextureMask TextureMask;

	// Token: 0x04003E6F RID: 15983
	public MonoBehaviour[] SwitchComponentsOn;

	// Token: 0x04003E70 RID: 15984
	public MonoBehaviour[] SwitchComponentsOff;

	// Token: 0x04003E71 RID: 15985
	public float ChromaticAberrationThermalShift = 0.013f;

	// Token: 0x04003E72 RID: 15986
	public AnimationCurve BlackFlashGoingToOn;

	// Token: 0x04003E73 RID: 15987
	public AnimationCurve BlackFlashGoingToOff;

	// Token: 0x04003E74 RID: 15988
	public AudioClip SwitchOn;

	// Token: 0x04003E75 RID: 15989
	public AudioClip SwitchOff;

	// Token: 0x04003E76 RID: 15990
	[Header("Unsharp Mask")]
	public float UnsharpRadiusBlur = 5f;

	// Token: 0x04003E77 RID: 15991
	public float UnsharpBias = 2f;

	// Token: 0x04003E79 RID: 15993
	private bool? nullable_0;

	// Token: 0x04003E7A RID: 15994
	private bool bool_0 = true;

	// Token: 0x04003E7B RID: 15995
	private CommandBuffer commandBuffer_0;

	// Token: 0x04003E7C RID: 15996
	private CommandBuffer commandBuffer_1;

	// Token: 0x04003E7D RID: 15997
	private Material material_0;

	// Token: 0x04003E7E RID: 15998
	private Camera camera_0;

	// Token: 0x04003E83 RID: 16003
	private VolumetricLightRenderer volumetricLightRenderer_0;

	// Token: 0x04003E86 RID: 16006
	private ChromaticAberration chromaticAberration_0;

	// Token: 0x04003E87 RID: 16007
	private float float_0;

	// Token: 0x04003E88 RID: 16008
	private float float_1;

	// Token: 0x04003E89 RID: 16009
	private static readonly int int_0 = Shader.PropertyToID("_FinalRT");

	// Token: 0x04003E8A RID: 16010
	private static readonly int int_1 = Shader.PropertyToID("_RampTex");

	// Token: 0x04003E8B RID: 16011
	private static readonly int int_2 = Shader.PropertyToID("_MainTexColorCoef");

	// Token: 0x04003E8C RID: 16012
	private static readonly int int_3 = Shader.PropertyToID("_MinimumTemperatureValue");

	// Token: 0x04003E8D RID: 16013
	private static readonly int int_4 = Shader.PropertyToID("_Noise");

	// Token: 0x04003E8E RID: 16014
	private static readonly int int_5 = Shader.PropertyToID("_NoiseIntensity");

	// Token: 0x04003E8F RID: 16015
	private static readonly int int_6 = Shader.PropertyToID("_DepthFade");

	// Token: 0x04003E90 RID: 16016
	private static readonly int int_7 = Shader.PropertyToID("_RampShift");

	// Token: 0x04003E91 RID: 16017
	private static readonly int int_8 = Shader.PropertyToID("_ThermalVisionOn");

	// Token: 0x04003E92 RID: 16018
	private static readonly int int_9 = Shader.PropertyToID("_RadiusBlur");

	// Token: 0x04003E93 RID: 16019
	private static readonly int int_10 = Shader.PropertyToID("_Bias");
}
