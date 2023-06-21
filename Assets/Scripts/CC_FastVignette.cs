using System;
using UnityEngine;

// Token: 0x0200006B RID: 107
[AddComponentMenu("Colorful/Fast Vignette")]
[ExecuteInEditMode]
public class CC_FastVignette : CC_Base
{
	
	// Token: 0x040001AE RID: 430
	public Vector2 center = new Vector2(0.5f, 0.5f);

	// Token: 0x040001AF RID: 431
	[Range(-100f, 100f)]
	public float sharpness = 10f;

	// Token: 0x040001B0 RID: 432
	[Range(0f, 100f)]
	public float darkness = 30f;

	// Token: 0x040001B1 RID: 433
	public bool desaturate;

	// Token: 0x040001B2 RID: 434
	private static readonly int int_0 = Shader.PropertyToID("_Data");
}
