using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x020009DC RID: 2524
[ExecuteInEditMode]
public class ScopeMaskRenderer : MonoBehaviour
{

	// Token: 0x04003D43 RID: 15683
	private Shader shader_0;

	// Token: 0x04003D45 RID: 15685
	private Material material_0;

	// Token: 0x04003D46 RID: 15686
	private Material material_1;

	// Token: 0x04003D47 RID: 15687
	private Shader shader_1;

	// Token: 0x04003D48 RID: 15688
	private Material material_2;

	// Token: 0x04003D49 RID: 15689
	private RenderTexture renderTexture_0;


	// Token: 0x04003D4C RID: 15692
	private static readonly Color color_0 = Color.red;

	// Token: 0x04003D4D RID: 15693
	private static readonly Color color_1 = Color.blue;

	// Token: 0x04003D4E RID: 15694
	private static readonly Color color_2 = Color.green;

	// Token: 0x04003D4F RID: 15695
	private static readonly float float_0 = 9f;

	// Token: 0x04003D50 RID: 15696
	private static readonly int int_0 = Shader.PropertyToID("_ScopeMask");

	// Token: 0x04003D51 RID: 15697
	private static readonly int int_1 = Shader.PropertyToID("_Color");
}
