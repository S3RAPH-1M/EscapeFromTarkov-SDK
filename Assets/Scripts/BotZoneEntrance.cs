using System;
using UnityEngine;

// Token: 0x020001F1 RID: 497
[Serializable]
public class BotZoneEntrance
{
    // Token: 0x06000A6D RID: 2669 RVA: 0x00032CBA File Offset: 0x00030EBA
    public BotZoneEntrance(Vector3 center, int connectedAreaId, Vector3 pointOutSide, Vector3 pointInside)
    {
        this.PointInside = pointInside;
        this.PointOutSide = pointOutSide;
        this.CenterPoint = center;
        this.ConnectedAreaId = connectedAreaId;
    }

    // Token: 0x06000A6E RID: 2670 RVA: 0x00032CE0 File Offset: 0x00030EE0
    public void DrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.CenterPoint, 0.5f);
        Gizmos.DrawWireSphere(this.CenterPoint, 0.52f);
        Gizmos.color = new Color(1f, 0.5f, 0.1f);
        Gizmos.DrawLine(this.CenterPoint, this.PointInside);
        Gizmos.DrawSphere(this.PointInside, 0.2f);
        Gizmos.DrawWireSphere(this.PointInside, 0.22f);
        Gizmos.color = new Color(1f, 0.1f, 0.5f);
        Gizmos.DrawLine(this.CenterPoint, this.PointOutSide);
        Gizmos.DrawSphere(this.PointOutSide, 0.2f);
        Gizmos.DrawWireSphere(this.PointOutSide, 0.22f);
    }

    // Token: 0x04000A7D RID: 2685
    public Vector3 PointOutSide;

    // Token: 0x04000A7E RID: 2686
    public Vector3 PointInside;

    // Token: 0x04000A7F RID: 2687
    public Vector3 CenterPoint;

    // Token: 0x04000A80 RID: 2688
    public int ConnectedAreaId;
}