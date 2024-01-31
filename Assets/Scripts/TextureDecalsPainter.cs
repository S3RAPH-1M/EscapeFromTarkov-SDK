using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x02000990 RID: 2448
public class TextureDecalsPainter : MonoBehaviour
{
	// Token: 0x040039A4 RID: 14756
	[SerializeField]
	[Header("Render textures settings")]
	private PowOfTwoDimensions _renderTexDimension;

	// Token: 0x040039A5 RID: 14757
	[SerializeField]
	private DepthSize _renderTexDepthSize;

	// Token: 0x040039A6 RID: 14758
	[SerializeField]
	[Header("Shaders")]
	private Shader _drawInterceptionShader;

	// Token: 0x040039A7 RID: 14759
	[SerializeField]
	private Shader _blitShader;

	// Token: 0x040039A8 RID: 14760
	[SerializeField]
	[Header("Textures")]
	private Texture2D _bloodDecalTexture;

	// Token: 0x040039A9 RID: 14761
	[SerializeField]
	private Texture2D _vestDecalTexture;

	// Token: 0x040039AA RID: 14762
	[SerializeField]
	private Texture2D _backDecalTexture;

	// Token: 0x040039AB RID: 14763
	[Header("Decal settings")]
	[SerializeField]
	private float _projectorHeight;

	// Token: 0x040039AC RID: 14764
	[SerializeField]
	[GAttribute6(0f, 0.5f, -1f)]
	private Vector2 _decalSize;

	// Token: 0x040039AD RID: 14765
	private Material material_0;

	// Token: 0x040039AE RID: 14766
	private Material material_1;

	// Token: 0x040039AF RID: 14767
	private RenderTexture renderTexture_0;

	// Token: 0x040039B0 RID: 14768
	private RenderTexture renderTexture_1;

	// Token: 0x040039B1 RID: 14769
	private CommandBuffer commandBuffer_0;

	// Token: 0x040039B2 RID: 14770
	private Dictionary<Renderer, RenderTexture> dictionary_0;

	// Token: 0x040039B3 RID: 14771
	private List<TextureDecalsPainter.GStruct59> list_0;

	// Token: 0x040039B4 RID: 14772
	private static readonly int int_0;

	// Token: 0x040039B5 RID: 14773
	private static int int_1;

	// Token: 0x040039B6 RID: 14774
	private const int int_2 = 128;

	// Token: 0x040039B8 RID: 14776
	private static readonly int int_3;

	// Token: 0x040039B9 RID: 14777
	private static readonly int int_4;

	// Token: 0x040039BA RID: 14778
	private static readonly int int_5;

	// Token: 0x040039BB RID: 14779
	private static readonly int int_6;

	// Token: 0x040039BC RID: 14780
	private static readonly int int_7;

	// Token: 0x040039BD RID: 14781
	private static readonly int int_8;

	// Token: 0x040039BE RID: 14782
	private static readonly int int_9;

	// Token: 0x040039BF RID: 14783
	private static readonly int int_10;

	// Token: 0x02000991 RID: 2449
	public struct GStruct59
	{
		// Token: 0x040039C0 RID: 14784
		public Renderer Renderer;

		// Token: 0x040039C1 RID: 14785
		public Vector3 Point;

		// Token: 0x040039C2 RID: 14786
		public Vector3 Normal;

		// Token: 0x040039C3 RID: 14787
		public Texture2D Texture;

		// Token: 0x040039C4 RID: 14788
		public bool HasToSetShaderVars;

		// Token: 0x040039C5 RID: 14789
		public bool HasToSetTexture;
	}
}
