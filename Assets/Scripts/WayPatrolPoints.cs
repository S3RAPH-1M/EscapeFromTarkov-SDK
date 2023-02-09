using System;
using UnityEngine;

// Token: 0x020001F3 RID: 499
[Serializable]
public class WayPatrolPoints
{
    // Token: 0x06000A73 RID: 2675 RVA: 0x00032F32 File Offset: 0x00031132
    public WayPatrolPoints(int id, Vector3[] way, bool canRun)
    {
        this.WayPoints = way;
        this.Id = id;
        this.CanRun = canRun;
    }

    // Token: 0x04000A83 RID: 2691
    public int Id;

    // Token: 0x04000A84 RID: 2692
    public Vector3[] WayPoints;

    // Token: 0x04000A85 RID: 2693
    public bool IsAvailable = true;

    // Token: 0x04000A86 RID: 2694
    public bool CanRun;
}