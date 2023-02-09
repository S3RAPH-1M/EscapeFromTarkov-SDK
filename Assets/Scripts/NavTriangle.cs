using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000119 RID: 281
[Serializable]
public class NavTriangle
{
	// Token: 0x060006DF RID: 1759 RVA: 0x00021194 File Offset: 0x0001F394
	public static float CalculatePathLength(Vector3[] path)
	{
		Vector3 a = path[0];
		float num = 0f;
		for (int i = 1; i < path.Length; i++)
		{
			Vector3 vector = path[i];
			Vector3 vector2 = a - vector;
			num += Mathf.Sqrt(vector2.x * vector2.x + vector2.y * vector2.y + vector2.z * vector2.z);
			a = vector;
		}
		return num;
	}

	// Token: 0x060006E0 RID: 1760 RVA: 0x00021210 File Offset: 0x0001F410
	public NavTriangle(NavPoint point1, NavPoint point2, NavPoint point3, int index)
	{
		this.Index = index;
		this.Point1 = point1;
		this.Point2 = point2;
		this.Point3 = point3;
		this.Center = (point1.Pos + point2.Pos + point3.Pos) / 3f;
	}

	// Token: 0x060006E1 RID: 1761 RVA: 0x00021284 File Offset: 0x0001F484
	public void ReworkToDictionary()
	{
		this.PathDistances = new Dictionary<int, float>();
		foreach (IntFloat intFloat in this.PathDistancesSave)
		{
			this.PathDistances.Add(intFloat.Index, intFloat.Value);
		}
		this.PathDistancesSave = null;
	}

	// Token: 0x060006E2 RID: 1762 RVA: 0x000212FC File Offset: 0x0001F4FC
	public void AddDistance(CustomNavigationPoint place)
	{
		NavTriangle.Class96 @class = new NavTriangle.Class96();
		@class.place = place;
		NavMeshPath navMeshPath = new NavMeshPath();
		if ((this.Center - @class.place.CovPointsPlaceSerializable.Origin).magnitude < 20f && NavMesh.CalculatePath(this.Center, @class.place.CovPointsPlaceSerializable.Origin, -1, navMeshPath))
		{
			float val = NavTriangle.CalculatePathLength(navMeshPath.corners);
			if (this.PathDistancesSave.FirstOrDefault(new Func<IntFloat, bool>(@class.method_0)) == null)
			{
				this.PathDistancesSave.Add(new IntFloat(@class.place.Id, val));
			}
		}
	}

	// Token: 0x04000715 RID: 1813
	public Vector3 Center;

	// Token: 0x04000716 RID: 1814
	public int Index;

	// Token: 0x04000717 RID: 1815
	public Dictionary<int, float> PathDistances = new Dictionary<int, float>();

	// Token: 0x04000718 RID: 1816
	public List<IntFloat> PathDistancesSave = new List<IntFloat>();

	// Token: 0x04000719 RID: 1817
	public NavPoint Point1;

	// Token: 0x0400071A RID: 1818
	public NavPoint Point2;

	// Token: 0x0400071B RID: 1819
	public NavPoint Point3;

	// Token: 0x0200011A RID: 282
	[CompilerGenerated]
	private sealed class Class96
	{
		// Token: 0x060006E4 RID: 1764 RVA: 0x000213A6 File Offset: 0x0001F5A6
		internal bool method_0(IntFloat x)
		{
			return x.Index == this.place.Id;
		}

		// Token: 0x0400071C RID: 1820
		public CustomNavigationPoint place;
	}
}