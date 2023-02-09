using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000462 RID: 1122
public class NavMeshCutGroup : MonoBehaviour
{
	// Token: 0x06001F12 RID: 7954 RVA: 0x00096A94 File Offset: 0x00094C94
	public bool HaveFreeToCut(NavMeshCutElement element)
	{
		if (element.IsCut)
		{
			return true;
		}
		int num = 0;
		for (int i = 0; i < this._elements.Count; i++)
		{
			if (this._elements[i].IsCut)
			{
				num++;
			}
		}
		return num < this._elements.Count - 1;
	}

	// Token: 0x06001F13 RID: 7955 RVA: 0x00096AEA File Offset: 0x00094CEA
	private void OnDrawGizmosSelected()
	{
		this.DrawGizmo();
	}

	// Token: 0x06001F14 RID: 7956 RVA: 0x00096AF4 File Offset: 0x00094CF4
	public void DrawGizmo()
	{
		Gizmos.color = Color.yellow;
		for (int i = 0; i < this._elements.Count; i++)
		{
			NavMeshCutElement navMeshCutElement = this._elements[i];
			Gizmos.DrawWireSphere(navMeshCutElement.Position, 0.2f);
			Gizmos.DrawWireSphere(navMeshCutElement.Position, 0.3f);
		}
		for (int j = 0; j < this._elements.Count; j++)
		{
			for (int k = j; k < this._elements.Count; k++)
			{
				NavMeshCutElement navMeshCutElement2 = this._elements[j];
				NavMeshCutElement navMeshCutElement3 = this._elements[k];
				Gizmos.DrawLine(navMeshCutElement2.Position, navMeshCutElement3.Position);
			}
		}
	}

	// Token: 0x06001F15 RID: 7957 RVA: 0x00096BA4 File Offset: 0x00094DA4
	public bool UnCutOldest()
	{
		if (this.list_0.Count > 0)
		{
			NavMeshCutElement element = this.list_0[0];
			this.UnCut(element);
			return true;
		}
		return false;
	}

	// Token: 0x06001F16 RID: 7958 RVA: 0x00096BD6 File Offset: 0x00094DD6
	public void Cut(NavMeshCutElement element)
	{
		this.list_0.Add(element);
		element.Obstacle.carving = true;
		element.SetUncutTime();
	}

	// Token: 0x06001F17 RID: 7959 RVA: 0x00096BF6 File Offset: 0x00094DF6
	public void UnCut(NavMeshCutElement element)
	{
		this.list_0.Remove(element);
		element.Obstacle.carving = false;
	}

	// Token: 0x04001B52 RID: 6994
	public List<NavMeshCutElement> _elements = new List<NavMeshCutElement>();

	// Token: 0x04001B53 RID: 6995
	private List<NavMeshCutElement> list_0 = new List<NavMeshCutElement>();
}