using System;
using UnityEngine;

// Token: 0x020006C0 RID: 1728
public static class GClass773
{
    // Token: 0x06002D6C RID: 11628 RVA: 0x000CB8F9 File Offset: 0x000C9AF9
    public static void DrawCube(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        Matrix4x4 matrix = Gizmos.matrix;
        Gizmos.matrix *= Matrix4x4.TRS(position, rotation, scale);
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
        Gizmos.matrix = matrix;
    }

    // Token: 0x06002D6D RID: 11629 RVA: 0x000CB92B File Offset: 0x000C9B2B
    public static void DrawWireCube(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        Matrix4x4 matrix = Gizmos.matrix;
        Gizmos.matrix *= Matrix4x4.TRS(position, rotation, scale);
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        Gizmos.matrix = matrix;
    }

    // Token: 0x06002D6E RID: 11630 RVA: 0x000CB960 File Offset: 0x000C9B60
    public static void DrawArrow(Vector3 origin, Vector3 direction)
    {
        Vector3 vector = origin + direction;
        Vector3 vector2 = GClass773.quaternion_0 * vector * 0.1f;
        vector2 = Vector3.ClampMagnitude(vector2, 0.03f);
        Gizmos.DrawLine(origin, vector);
        Gizmos.DrawLine(vector, origin + vector2 + direction * 0.7f);
        Gizmos.DrawLine(vector, origin - vector2 + direction * 0.7f);
    }

    // Token: 0x040026FE RID: 9982
    private static readonly Quaternion quaternion_0 = Quaternion.Euler(0f, 90f, 0f);
}