using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000461 RID: 1121
public class NavMeshCutElement : MonoBehaviour
{
	// Token: 0x170004EA RID: 1258
	// (get) Token: 0x06001F09 RID: 7945 RVA: 0x000969AD File Offset: 0x00094BAD
	public bool IsCut
	{
		get
		{
			return this.Obstacle.carving;
		}
	}

	// Token: 0x170004EB RID: 1259
	// (get) Token: 0x06001F0A RID: 7946 RVA: 0x00078C1E File Offset: 0x00076E1E
	public Vector3 Position
	{
		get
		{
			return base.transform.position;
		}
	}

	// Token: 0x06001F0B RID: 7947 RVA: 0x000969BC File Offset: 0x00094BBC
	public bool TryCut()
	{
		if (this.HaveFreeToCut())
		{
			if (this.Obstacle.carving)
			{
				return true;
			}
			this.Group.Cut(this);
			return true;
		}
		else
		{
			if (this.Group.UnCutOldest())
			{
				this.Group.Cut(this);
				return true;
			}
			return false;
		}
	}

	// Token: 0x06001F0C RID: 7948 RVA: 0x00096A0A File Offset: 0x00094C0A
	private void Update()
	{
		if (!this.Obstacle.carving)
		{
			return;
		}
		if (this.float_0 < Time.time)
		{
			this.Group.UnCut(this);
		}
	}

	// Token: 0x06001F0D RID: 7949 RVA: 0x00096A33 File Offset: 0x00094C33
	public bool HaveFreeToCut()
	{
		return this.Group.HaveFreeToCut(this);
	}

	// Token: 0x06001F0E RID: 7950 RVA: 0x00096A41 File Offset: 0x00094C41
	private void OnDrawGizmosSelected()
	{
		if (this.Group != null)
		{
			this.Group.DrawGizmo();
		}
	}

	// Token: 0x06001F10 RID: 7952 RVA: 0x00096A6A File Offset: 0x00094C6A
	public void SetUncutTime()
	{
		this.float_0 = Time.time + this.CutPeriodSec;
	}

	// Token: 0x04001B4D RID: 6989
	public NavMeshCutGroup Group;

	// Token: 0x04001B4E RID: 6990
	public NavMeshObstacle Obstacle;

	// Token: 0x04001B4F RID: 6991
	public BoxCollider Collider;

	// Token: 0x04001B50 RID: 6992
	private float float_0;

	// Token: 0x04001B51 RID: 6993
	public float CutPeriodSec = 300f;
}
