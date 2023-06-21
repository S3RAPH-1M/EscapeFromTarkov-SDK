using System;
using UnityEngine;

// Token: 0x02000916 RID: 2326
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/CustomGlobalFog")]
[DisallowMultipleComponent]
public class CustomGlobalFog : MonoBehaviour
{
	// Token: 0x0400366C RID: 13932
	public Shader shader;

	// Token: 0x0400366D RID: 13933
	public CustomGlobalFog.BlendModes BlendMode;

	// Token: 0x0400366E RID: 13934
	public Color FogColor;

	// Token: 0x0400366F RID: 13935
	public float FogStrength;

	// Token: 0x04003670 RID: 13936
	public float FogY;

	// Token: 0x04003671 RID: 13937
	public float FogToplength;

	// Token: 0x04003672 RID: 13938
	public float FogTopIntensity;

	// Token: 0x04003673 RID: 13939
	public float FogMaxDistance;

	// Token: 0x04003674 RID: 13940
	public float FogStart;

	// Token: 0x04003675 RID: 13941
	public float DirectionDifferenceThreshold = 0.047f;

	// Token: 0x04003676 RID: 13942
	public float FuncSoftness;

	// Token: 0x04003677 RID: 13943
	public float FuncStart;

	// Token: 0x04003678 RID: 13944
	private Material material_0;

	// Token: 0x04003679 RID: 13945
	private Mesh mesh_0;

	// Token: 0x0400367A RID: 13946
	private Camera camera_0;

	// Token: 0x0400367B RID: 13947
	private static readonly int int_0 = Shader.PropertyToID("_BlendType");

	// Token: 0x0400367C RID: 13948
	private static readonly int int_1 = Shader.PropertyToID("_GFogCamToWorld");

	// Token: 0x0400367D RID: 13949
	private static readonly int int_2 = Shader.PropertyToID("_GFogMax");

	// Token: 0x0400367E RID: 13950
	private static readonly int int_3 = Shader.PropertyToID("_GFogColor");

	// Token: 0x0400367F RID: 13951
	private static readonly int int_4 = Shader.PropertyToID("_GFogStrength");

	// Token: 0x04003680 RID: 13952
	private static readonly int int_5 = Shader.PropertyToID("_GFogY");

	// Token: 0x04003681 RID: 13953
	private static readonly int int_6 = Shader.PropertyToID("_GFogFuncVals");

	// Token: 0x04003682 RID: 13954
	private static readonly int int_7 = Shader.PropertyToID("_GFogTopFuncVals");

	// Token: 0x04003683 RID: 13955
	private static readonly int int_8 = Shader.PropertyToID("_GFogStart");

	// Token: 0x04003684 RID: 13956
	private static readonly int int_9 = Shader.PropertyToID("_MainTex");

	// Token: 0x02000917 RID: 2327
	public enum BlendModes
	{
		// Token: 0x04003686 RID: 13958
		Normal,
		// Token: 0x04003687 RID: 13959
		Lighten,
		// Token: 0x04003688 RID: 13960
		Screen,
		// Token: 0x04003689 RID: 13961
		Overlay,
		// Token: 0x0400368A RID: 13962
		SoftLight
	}
}
