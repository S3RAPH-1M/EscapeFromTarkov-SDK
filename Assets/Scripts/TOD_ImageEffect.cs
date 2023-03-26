using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

// Token: 0x020000A8 RID: 168
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public abstract class TOD_ImageEffect : MonoBehaviour
{
	// Token: 0x04000364 RID: 868
	public TOD_Sky sky;

	// Token: 0x04000365 RID: 869
	protected Camera cam;

	// Token: 0x04000366 RID: 870
	private static readonly int int_0 = Shader.PropertyToID("_MainTex");

	// Token: 0x04000367 RID: 871
	private bool bool_0;

	// Token: 0x04000368 RID: 872
	private bool bool_1;
}
