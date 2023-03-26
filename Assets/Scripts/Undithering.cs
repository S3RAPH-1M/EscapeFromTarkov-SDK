using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

// Token: 0x02000A06 RID: 2566
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Undithering")]
public class Undithering : MonoBehaviour
{	
	// Token: 0x04003ED1 RID: 16081
	public Shader shader;

	// Token: 0x04003ED2 RID: 16082
	public bool useTriangleBlit = true;

	// Token: 0x04003ED3 RID: 16083
	[SerializeField]
	private bool _distortion;

	// Token: 0x04003ED4 RID: 16084
	private bool bool_0;

	// Token: 0x04003ED5 RID: 16085
	private Material material_0;

	// Token: 0x04003ED6 RID: 16086
	private MaterialPropertyBlock materialPropertyBlock_0;

	// Token: 0x04003ED7 RID: 16087
	private static readonly int int_0 = Shader.PropertyToID("_Distortion");

	// Token: 0x04003ED8 RID: 16088
	private static readonly int int_1 = Shader.PropertyToID("_Scatter");

	// Token: 0x04003ED9 RID: 16089
	private CommandBuffer commandBuffer_0;
}
