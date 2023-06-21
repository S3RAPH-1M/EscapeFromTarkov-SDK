using System;
using UnityEngine;

// Token: 0x02000913 RID: 2323
[AddComponentMenu("Image Effects/ChromaticAberration")]
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ChromaticAberration : MonoBehaviour
{
	// Token: 0x04003653 RID: 13907
	public float Shift = 0.01f;

	// Token: 0x04003654 RID: 13908
	public int Aniso = 3;

	// Token: 0x04003655 RID: 13909
	public bool Simple;

	// Token: 0x04003656 RID: 13910
	public Shader shader;

	// Token: 0x04003657 RID: 13911
	private Material material_0;

	// Token: 0x04003658 RID: 13912
	private static readonly int int_0 = Shader.PropertyToID("_Shift");
}
