using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using EFT.InventoryLogic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

namespace BSG.CameraEffects
{
	// Token: 0x02000AF2 RID: 2802
	[RequireComponent(typeof(Camera))]
	public class NightVision : MonoBehaviour
	{

		// Token: 0x0400463C RID: 17980
		public Shader Shader;

		// Token: 0x0400463D RID: 17981
		public float Intensity;

		// Token: 0x0400463E RID: 17982
		public Texture Noise;

		// Token: 0x0400463F RID: 17983
		public Texture Mask;

		// Token: 0x04004640 RID: 17984
		public float MaskSize = 1f;

		// Token: 0x04004641 RID: 17985
		public float NoiseIntensity;

		// Token: 0x04004642 RID: 17986
		public float NoiseScale;

		// Token: 0x04004643 RID: 17987
		[ColorUsage(false)]
		public Color Color;

		// Token: 0x04004644 RID: 17988
		public TextureMask TextureMask;

		// Token: 0x04004645 RID: 17989
		public MonoBehaviour[] SwitchComponentsOn;

		// Token: 0x04004646 RID: 17990
		public MonoBehaviour[] SwitchComponentsOff;

		// Token: 0x04004647 RID: 17991
		public AnimationCurve BlackFlashGoingToOn;

		// Token: 0x04004648 RID: 17992
		public AnimationCurve BlackFlashGoingToOff;

		// Token: 0x04004649 RID: 17993
		public AudioClip SwitchOn;

		// Token: 0x0400464A RID: 17994
		public AudioClip SwitchOff;

		// Token: 0x0400464B RID: 17995
		public Texture ThermalMaskTexture;

		// Token: 0x0400464C RID: 17996
		public Texture AnvisMaskTexture;

		// Token: 0x0400464D RID: 17997
		public Texture BinocularMaskTexture;

		// Token: 0x0400464E RID: 17998
		public Texture GasMaskTexture;

		// Token: 0x0400464F RID: 17999
		public Texture OldMonocularMaskTexture;

		// Token: 0x04004650 RID: 18000
		public float ambientFactor = 1.2f;

		// Token: 0x04004651 RID: 18001
		[SerializeField]
		private bool _on;

		// Token: 0x04004652 RID: 18002
		private static readonly int int_0 = Shader.PropertyToID("_Color");

		// Token: 0x04004653 RID: 18003
		private static readonly int int_1 = Shader.PropertyToID("_Intensity");

		// Token: 0x04004654 RID: 18004
		private static readonly int int_2 = Shader.PropertyToID("_Noise");

		// Token: 0x04004655 RID: 18005
		private static readonly int int_3 = Shader.PropertyToID("_NoiseScale");

		// Token: 0x04004656 RID: 18006
		private static readonly int int_4 = Shader.PropertyToID("_NoiseIntensity");

		// Token: 0x04004657 RID: 18007
		private static readonly int int_5 = Shader.PropertyToID("_NightVisionOn");

		// Token: 0x04004658 RID: 18008
		private static readonly int int_6 = Shader.PropertyToID("_FinalNvRT");

		// Token: 0x04004659 RID: 18009
		private static readonly string string_0 = "NIGHT_VISION_NOISE";

		// Token: 0x0400465A RID: 18010
		private Material material_0;

		// Token: 0x0400465B RID: 18011
		private Material material_1;

		// Token: 0x0400465C RID: 18012
		private int int_7;

		// Token: 0x0400465D RID: 18013
		private int int_8;

		// Token: 0x04004660 RID: 18016
		private bool? nullable_0;

		// Token: 0x04004661 RID: 18017
		private bool bool_0 = true;

		// Token: 0x04004662 RID: 18018
		private CommandBuffer commandBuffer_0;

		// Token: 0x04004663 RID: 18019
		private Camera camera_0;

		// Token: 0x04004664 RID: 18020
		private bool bool_1;

		// Token: 0x04004665 RID: 18021
		private Vector4 vector4_0;

		// Token: 0x04004666 RID: 18022
		private Color color_0;
	}
}
