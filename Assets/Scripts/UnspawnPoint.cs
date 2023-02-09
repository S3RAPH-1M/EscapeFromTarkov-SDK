using System;
using UnityEngine;

// Token: 0x02000565 RID: 1381
public class UnspawnPoint : MonoBehaviour
{
    // Token: 0x06002402 RID: 9218 RVA: 0x000AA634 File Offset: 0x000A8834
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.7f, 0.2f, 0.2f, 0.4f);
        GClass773.DrawCube(base.transform.position + Vector3.up * 60f * 0.5f, base.transform.rotation, new Vector3(1f, 60f, 1f));
    }
}