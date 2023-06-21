using System;
using UnityEngine;

// Token: 0x020009F6 RID: 2550
[Serializable]
public class PixelationUtilities
{
	// Token: 0x04003E36 RID: 15926
	public Shader PixelationShader;

	// Token: 0x04003E37 RID: 15927
	[Range(2f, 2048f)]
	public float BlockCount = 256f;

	// Token: 0x04003E38 RID: 15928
	[Range(0f, 1f)]
	public float Alpha = 1f;

	// Token: 0x04003E39 RID: 15929
	public Texture PixelationMask;
}
