using System;
using UnityEngine;

// Token: 0x020000B1 RID: 177
[Serializable]
public class TOD_StarParameters
{
	// Token: 0x040003A3 RID: 931
	[Tooltip("Tiling of the stars texture.")]
	public float Tiling = 6f;

	// Token: 0x040003A4 RID: 932
	[Tooltip("Brightness of the stars.")]
	public float Brightness = 3f;

	// Token: 0x040003A5 RID: 933
	[Tooltip("Type of the stars position calculation.")]
	public TOD_StarsPositionType Position = TOD_StarsPositionType.Rotating;
}
