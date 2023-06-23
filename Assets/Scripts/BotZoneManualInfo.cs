using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003BD RID: 957
[RequireComponent(typeof(BotZone))]
public class BotZoneManualInfo : MonoBehaviour
{
	// Token: 0x06001A50 RID: 6736 RVA: 0x0008188E File Offset: 0x0007FA8E
	public void Init()
	{
		this.SetCllidersToTrigers();
	}

	// Token: 0x06001A51 RID: 6737 RVA: 0x00081896 File Offset: 0x0007FA96
	public void Add(CustomNavigationPoint c)
	{
		c.Id = this.Points.Count;
		c.CovPointsPlaceSerializable.Id = c.Id;
		this.Points.Add(c);
	}

	// Token: 0x06001A52 RID: 6738 RVA: 0x000818C8 File Offset: 0x0007FAC8
	public void SetCllidersToTrigers()
	{
		BoxCollider[] excludableColliders = this.ExcludableColliders;
		for (int i = 0; i < excludableColliders.Length; i++)
		{
			excludableColliders[i].enabled = false;
		}
	}

	// Token: 0x06001A53 RID: 6739 RVA: 0x000818F3 File Offset: 0x0007FAF3
	public void SetAlwaysDraw(bool alwaysDraw)
	{
		this._alwaysDraw = alwaysDraw;
	}

	// Token: 0x06001A56 RID: 6742 RVA: 0x00081A16 File Offset: 0x0007FC16
	private void OnDrawGizmosSelected()
	{
		if (!this._alwaysDraw)
		{
			this.method_0();
		}
	}

	// Token: 0x06001A57 RID: 6743 RVA: 0x00081A26 File Offset: 0x0007FC26
	private void OnDrawGizmos()
	{
		if (this._alwaysDraw)
		{
			this.method_0();
		}
	}

	// Token: 0x06001A58 RID: 6744 RVA: 0x00081A38 File Offset: 0x0007FC38
	private void method_0()
	{
		foreach (CustomNavigationPoint customNavigationPoint in this.Points)
		{
			if (this.MinDefenceLevelToDraw > 0f)
			{
				Gizmos.color = new Color(0.9f, 0.2f, 0.2f, 0.5f);
				if (customNavigationPoint.CovPointsPlaceSerializable.DefenceLevel > this.MinDefenceLevelToDraw)
				{
					float num = customNavigationPoint.CovPointsPlaceSerializable.DefenceLevel / 3f;
					GClass773.DrawCube(customNavigationPoint.Position + Vector3.up * num * 0.5f, base.transform.rotation, new Vector3(1f, num, 1f));
				}
			}
			if (customNavigationPoint.StrategyType == PointWithNeighborType.ambush)
			{
				customNavigationPoint.OnDrawGizmosAsAmbush(null, 0f, this.DrawSides);
			}
			else
			{
				customNavigationPoint.OnDrawGizmosFullAsCover(null, 0f, this.DrawSides);
			}
		}
	}

	// Token: 0x06001A59 RID: 6745 RVA: 0x000134BD File Offset: 0x000116BD
	private void method_1()
	{
	}

	// Token: 0x06001A5A RID: 6746 RVA: 0x00081B60 File Offset: 0x0007FD60
	private void method_2(CustomNavigationPoint[] coreList, List<CustomNavigationPoint> mergedList)
	{
		List<CustomNavigationPoint> list = new List<CustomNavigationPoint>();
		foreach (CustomNavigationPoint customNavigationPoint in coreList)
		{
			foreach (CustomNavigationPoint customNavigationPoint2 in mergedList)
			{
				if ((customNavigationPoint.Position - customNavigationPoint2.Position).sqrMagnitude < 0.3f)
				{
					list.Add(customNavigationPoint2);
				}
			}
		}
		if (list.Count > 0)
		{
			Debug.LogError("Optimized merged" + list.Count + "  points");
			foreach (CustomNavigationPoint item in list.ToArray())
			{
				mergedList.Remove(item);
			}
			return;
		}
		Debug.Log("All fine. NOthing to optimize");
	}

	// Token: 0x06001A5B RID: 6747 RVA: 0x00081C44 File Offset: 0x0007FE44
	private void method_3()
	{
		List<CustomNavigationPoint> list = new List<CustomNavigationPoint>();
		for (int i = 0; i < this.Points.Count; i++)
		{
			CustomNavigationPoint customNavigationPoint = this.Points[i];
			for (int j = i + 1; j < this.Points.Count; j++)
			{
				CustomNavigationPoint customNavigationPoint2 = this.Points[j];
				if ((customNavigationPoint2.Position - customNavigationPoint.Position).sqrMagnitude < 0.3f)
				{
					list.Add(customNavigationPoint2);
				}
			}
		}
		if (list.Count > 0)
		{
			Debug.LogError("Optimized self " + list.Count + "  points");
			foreach (CustomNavigationPoint item in list.ToArray())
			{
				this.Points.Remove(item);
			}
			return;
		}
		Debug.Log("All fine. NOthing to optimize");
	}

	// Token: 0x0400149C RID: 5276
	public const int MANUAL_ZONE_START_ID = 100000;

	// Token: 0x0400149D RID: 5277
	public bool _alwaysDraw;

	// Token: 0x0400149E RID: 5278
	public bool DrawSides;

	// Token: 0x0400149F RID: 5279
	public float MinDefenceLevelToDraw;

	// Token: 0x040014A0 RID: 5280
	public BoxCollider[] ExcludableColliders;

	// Token: 0x040014A1 RID: 5281
	public List<CustomNavigationPoint> Points = new List<CustomNavigationPoint>(100);
}