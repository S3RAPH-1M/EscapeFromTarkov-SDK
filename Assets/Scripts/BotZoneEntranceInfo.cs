using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020001F2 RID: 498
public class BotZoneEntranceInfo : MonoBehaviour
{
    // Token: 0x06000A70 RID: 2672 RVA: 0x00032E30 File Offset: 0x00031030
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        foreach (BotZoneEntrance botZoneEntrance in this.EntraceList)
        {
            botZoneEntrance.DrawGizmosSelected();
        }
    }

    // Token: 0x04000A81 RID: 2689
    public List<BotZoneEntrance> EntraceList = new List<BotZoneEntrance>();
}