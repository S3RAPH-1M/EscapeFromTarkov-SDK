using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200046E RID: 1134
public class PointWithLookSides : MonoBehaviour
{
    // Token: 0x06001F69 RID: 8041 RVA: 0x000988AB File Offset: 0x00096AAB
    public void Refresh()
    {
        if (this.Directions.Count == 0)
        {
            Debug.LogError("Point look have ZERO directions " + base.transform.parent.name);
        }
    }

    // Token: 0x06001F6A RID: 8042 RVA: 0x000988DC File Offset: 0x00096ADC
    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < this.Directions.Count; i++)
        {
            Vector3 a = this.Directions[i];
            Gizmos.color = new Color(0f, 1f, 0f, 0.9f);
            Vector3 vector = base.transform.position + a * 2f;
            Gizmos.DrawLine(base.transform.position, vector);
            GClass773.DrawCube(vector, base.transform.rotation, Vector3.one * 0.2f);
        }
    }

    // Token: 0x04001B8A RID: 7050
    public List<Vector3> Directions = new List<Vector3>();
}