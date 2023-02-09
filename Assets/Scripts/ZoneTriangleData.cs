using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;

// Token: 0x020001E7 RID: 487
[Serializable]
public class ZoneTriangleData
{
	private const bool AS_JSON = true;

	// Token: 0x04000A51 RID: 2641
	private const string resourcePath = "AIZoneData/Zone_{0}_{1}";

	// Token: 0x04000A52 RID: 2642
	private const int TRIANGLE_CACHE_SIDE_SIZE = 8;

	// Token: 0x04000A53 RID: 2643
	private static string PATH_TO_SAVE2 = "CommonAssets/Scripts/AI/Resources/AIZoneData/Zone_{0}_{1}.json";

	// Token: 0x04000A54 RID: 2644
	private static string PATH_TO_SAVE = "Assets/" + ZoneTriangleData.PATH_TO_SAVE2;

	// Token: 0x04000A55 RID: 2645
	public TriangleData[] Triangles;

	// Token: 0x04000A56 RID: 2646
	public Dictionary<int, TriangleData> TrianglesD = new Dictionary<int, TriangleData>();

	// Token: 0x04000A57 RID: 2647
	private TriangleCache[,] _triangleCache;

	// Token: 0x04000A58 RID: 2648
	private readonly List<TriangleData> emptyList = new List<TriangleData>();
}