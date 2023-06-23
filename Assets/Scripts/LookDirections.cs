using System;
using EFT;
using UnityEngine;

// Token: 0x0200045E RID: 1118
public class LookDirections : MonoBehaviour
{
    // Token: 0x170004E7 RID: 1255
    // (get) Token: 0x06001EFC RID: 7932 RVA: 0x00078C1E File Offset: 0x00076E1E
    public Vector3 Position
    {
        get
        {
            return base.transform.position;
        }
    }

    // Token: 0x170004E8 RID: 1256
    // (get) Token: 0x06001EFD RID: 7933 RVA: 0x0009679A File Offset: 0x0009499A
    public bool HaveLookSide
    {
        get
        {
            return this.UseLookSide;
        }
    }

    // Token: 0x170004E9 RID: 1257
    // (get) Token: 0x06001EFE RID: 7934 RVA: 0x000967A2 File Offset: 0x000949A2
    public int LookIndexes
    {
        get
        {
            if (!this.UseLookSide)
            {
                return 0;
            }
            return 1;
        }
    }

    // Token: 0x06001EFF RID: 7935 RVA: 0x000967AF File Offset: 0x000949AF
    public void OnDrawGizmosSelected()
    {
        if (this.UseLookSide)
        {
            Gizmos.DrawRay(base.transform.position, this.dir);
        }
    }

    // Token: 0x06001F00 RID: 7936 RVA: 0x000967CF File Offset: 0x000949CF
    public int GetOwnerId()
    {
        return -1;
    }

    // Token: 0x06001F02 RID: 7938 RVA: 0x000967D2 File Offset: 0x000949D2
    public void NormalizeLookSide()
    {
        this.dir = GClass777.NormalizeFastSelf(this.dir);
    }

    // Token: 0x04001B47 RID: 6983
    public bool UseLookSide;

    // Token: 0x04001B48 RID: 6984
    public Vector3 dir = Vector3.zero;
}