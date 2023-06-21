using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

// Token: 0x02000A0C RID: 2572
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class VolumetricLightRenderer : MonoBehaviour
{
	// Token: 0x04003F58 RID: 16216
	[CompilerGenerated]
	private static Action<VolumetricLightRenderer, Matrix4x4> action_0;

	// Token: 0x04003F59 RID: 16217
	private static Mesh mesh_0;

	// Token: 0x04003F5A RID: 16218
	private static Mesh mesh_1;

	// Token: 0x04003F5B RID: 16219
	private static Material material_0;

	// Token: 0x04003F5C RID: 16220
	public bool IsOn = true;

	// Token: 0x04003F5D RID: 16221
	public bool IsOptic;

	// Token: 0x04003F5E RID: 16222
	private Camera camera_0;

	// Token: 0x04003F61 RID: 16225
	private CommandBuffer commandBuffer_0;

	// Token: 0x04003F62 RID: 16226
	private CommandBuffer commandBuffer_1;

	// Token: 0x04003F63 RID: 16227
	private Matrix4x4 matrix4x4_0;

	// Token: 0x04003F64 RID: 16228
	private Material material_1;

	// Token: 0x04003F65 RID: 16229
	private Material material_2;

	// Token: 0x04003F66 RID: 16230
	private RenderTexture renderTexture_0;

	// Token: 0x04003F67 RID: 16231
	private RenderTexture renderTexture_1;

	// Token: 0x04003F68 RID: 16232
	private RenderTexture renderTexture_2;

	// Token: 0x04003F69 RID: 16233
	private static Texture texture_0;

	// Token: 0x04003F6A RID: 16234
	private RenderTexture renderTexture_3;

	// Token: 0x04003F6B RID: 16235
	private RenderTexture renderTexture_4;

	// Token: 0x04003F6C RID: 16236
	private VolumetricLightRenderer.VolumtericResolution volumtericResolution_0 = VolumetricLightRenderer.VolumtericResolution.Half;

	// Token: 0x04003F6D RID: 16237
	private static Texture2D texture2D_0;

	// Token: 0x04003F6E RID: 16238
	private static Texture3D texture3D_0;

	// Token: 0x04003F6F RID: 16239
	private static bool bool_0;

	// Token: 0x04003F70 RID: 16240
	private static int int_0 = -1;

	// Token: 0x04003F71 RID: 16241
	private static RenderTexture renderTexture_5;

	// Token: 0x04003F72 RID: 16242
	private static RenderTexture renderTexture_6;

	// Token: 0x04003F73 RID: 16243
	private static RenderTexture renderTexture_7;

	// Token: 0x04003F74 RID: 16244
	private static RenderTexture renderTexture_8;

	// Token: 0x04003F75 RID: 16245
	private static RenderTexture renderTexture_9;

	// Token: 0x04003F76 RID: 16246
	public VolumetricLightRenderer.VolumtericResolution Resolution = VolumetricLightRenderer.VolumtericResolution.Half;

	// Token: 0x04003F77 RID: 16247
	public Texture DefaultSpotCookie;

	// Token: 0x04003F78 RID: 16248
	private Matrix4x4 matrix4x4_1;

	// Token: 0x04003F79 RID: 16249
	private static readonly int int_1 = Shader.PropertyToID("_HalfResDepthBuffer");

	// Token: 0x04003F7A RID: 16250
	private static readonly int int_2 = Shader.PropertyToID("_HalfResColor");

	// Token: 0x04003F7B RID: 16251
	private static readonly int int_3 = Shader.PropertyToID("_QuarterResDepthBuffer");

	// Token: 0x04003F7C RID: 16252
	private static readonly int int_4 = Shader.PropertyToID("_QuarterResColor");

	// Token: 0x04003F7D RID: 16253
	private static readonly int int_5 = Shader.PropertyToID("_DitherTexture");

	// Token: 0x04003F7E RID: 16254
	private static readonly int int_6 = Shader.PropertyToID("_NoiseTexture");

	// Token: 0x04003F7F RID: 16255
	private static readonly int int_7 = Shader.PropertyToID("VolumetricLightRenderer Temp");

	// Token: 0x02000A0D RID: 2573
	public enum VolumtericResolution
	{
		// Token: 0x04003F81 RID: 16257
		Full,
		// Token: 0x04003F82 RID: 16258
		Half,
		// Token: 0x04003F83 RID: 16259
		Quarter
	}
}
