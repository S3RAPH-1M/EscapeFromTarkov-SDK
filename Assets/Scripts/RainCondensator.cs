using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000A38 RID: 2616
[RequireComponent(typeof(Renderer))]
public class RainCondensator : MonoBehaviour
{
	// Token: 0x040040A2 RID: 16546
	private const float float_0 = 8f;

	// Token: 0x040040A3 RID: 16547
	private const float float_1 = 0.25f;

	// Token: 0x040040A4 RID: 16548
	private const string string_0 = "USERAIN";

	// Token: 0x040040A5 RID: 16549
	private const string string_1 = "SMap";

	// Token: 0x040040A6 RID: 16550
	private static readonly int int_0 = Shader.PropertyToID("_RippleTexScale");

	// Token: 0x040040A7 RID: 16551
	private static readonly int int_1 = Shader.PropertyToID("_SkinnedMeshMaterial");

	// Token: 0x040040A8 RID: 16552
	private static readonly int int_2 = Shader.PropertyToID("_LocalRain");

	// Token: 0x040040A9 RID: 16553
	private static readonly int int_3 = Shader.PropertyToID("_LocalRainAverage");

	// Token: 0x040040AA RID: 16554
	private bool bool_0;

	// Token: 0x040040AB RID: 16555
	private MaterialPropertyBlock materialPropertyBlock_0;

	// Token: 0x040040AC RID: 16556
	private List<Material> list_0 = new List<Material>();

	// Token: 0x040040AD RID: 16557
	private Renderer renderer_0;

	// Token: 0x040040AE RID: 16558
	private Vector3 vector3_0;
}
