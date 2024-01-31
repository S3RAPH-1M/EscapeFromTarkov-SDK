using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000A5D RID: 2653
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Tracers : MonoBehaviour
{
	// Token: 0x040040E4 RID: 16612
	public float MaxDistance;

	// Token: 0x040040E5 RID: 16613
	public float Probobility;

	// Token: 0x040040E6 RID: 16614
	public int Count;

	// Token: 0x040040E7 RID: 16615
	private Vector3[] vector3_0;

	// Token: 0x040040E8 RID: 16616
	private Vector4[] vector4_0;

	// Token: 0x040040E9 RID: 16617
	private Mesh mesh_0;

	// Token: 0x040040EA RID: 16618
	private Bounds bounds_0;

	// Token: 0x040040EB RID: 16619
	private Material material_0;

	// Token: 0x040040EC RID: 16620
	private bool bool_0;

	// Token: 0x040040ED RID: 16621
	private int int_0;

	// Token: 0x040040EE RID: 16622
	private float float_0;

	// Token: 0x040040EF RID: 16623
	private static readonly int int_1;
}
