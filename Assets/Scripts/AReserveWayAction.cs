using System;
using EFT;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000379 RID: 889
public abstract class AReserveWayAction : MonoBehaviour
{
	// Token: 0x170003D1 RID: 977
	// (get) Token: 0x06001841 RID: 6209
	public abstract Vector3 GoTo { get; }

	// Token: 0x170003D2 RID: 978
	// (get) Token: 0x06001842 RID: 6210
	public abstract Vector3 LookShootTo { get; }

	// Token: 0x06001843 RID: 6211
	public abstract ReserveWayResult ManualUpdate();

	// Token: 0x06001844 RID: 6212
	public abstract void RefreshData();

	// Token: 0x06001845 RID: 6213
	public abstract void RefreshBot();

	// Token: 0x06001846 RID: 6214
	public abstract void DrawGizmos();

	// Token: 0x06001848 RID: 6216 RVA: 0x000134BD File Offset: 0x000116BD
	public virtual void SetFree()
	{
	}

	// Token: 0x06001849 RID: 6217
	public abstract void AutoFix();

	// Token: 0x0600184E RID: 6222 RVA: 0x00078B44 File Offset: 0x00076D44
	protected void CheckPoint(Vector3 point, string data)
	{
		NavMeshPath navMeshPath = new NavMeshPath();
		bool flag;
		if (flag = NavMesh.CalculatePath(point, base.transform.parent.position, -1, navMeshPath))
		{
			flag = (navMeshPath.status == NavMeshPathStatus.PathComplete);
		}
		if (!flag)
		{
			Debug.LogError(string.Concat(new string[]
			{
				data,
				" can't find path to point ",
				base.gameObject.name,
				"   parent:",
				base.transform.parent.name
			}));
		}
	}

	// Token: 0x0600184F RID: 6223 RVA: 0x00078BC8 File Offset: 0x00076DC8
	protected void CheckWayFromParent(string nameInfo, Vector3 from)
	{
		NavMeshPath navMeshPath = new NavMeshPath();
		if (NavMesh.CalculatePath(base.transform.parent.position, from, -1, navMeshPath) && navMeshPath.status != NavMeshPathStatus.PathComplete)
		{
			Debug.LogError(nameInfo + " can't find way from parent transform. try autofix. Check again:" + base.gameObject.name);
			this.AutoFix();
		}
	}

	// Token: 0x04001333 RID: 4915
	private float float_0;

	// Token: 0x04001334 RID: 4916
	private bool bool_0;
}