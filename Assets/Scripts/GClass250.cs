using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000111 RID: 273
public static class GClass250
{
    // Token: 0x060006C4 RID: 1732 RVA: 0x0002060C File Offset: 0x0001E80C
    public static void DrawPathGizmo(this NavMeshPath path, Color color)
    {
        Gizmos.color = color;
        Vector3[] corners = path.corners;
        for (int i = 0; i < corners.Length - 1; i++)
        {
            Gizmos.DrawLine(corners[i], corners[i + 1]);
        }
    }

    // Token: 0x060006C5 RID: 1733 RVA: 0x0002064C File Offset: 0x0001E84C
    public static void DrawPathDebug(Vector3[] path, Color color, float time, float offsetUp = 0.1f)
    {
        Vector3 b = Vector3.up * offsetUp;
        for (int i = 0; i < path.Length - 1; i++)
        {
            Debug.DrawLine(path[i] + b, path[i + 1] + b, color, time);
        }
    }

    // Token: 0x060006C6 RID: 1734 RVA: 0x00020698 File Offset: 0x0001E898
    public static float CalculatePathLength(this NavMeshPath path)
    {
        return path.corners.CalculatePathLength();
    }

    // Token: 0x060006C7 RID: 1735 RVA: 0x000206A8 File Offset: 0x0001E8A8
    public static float CalculatePathLength(this Vector3[] corners)
    {
        if (corners == null)
        {
            return float.MaxValue;
        }
        if (corners.Length < 2)
        {
            return 0f;
        }
        Vector3 a = corners[0];
        float num = 0f;
        for (int i = 1; i < corners.Length; i++)
        {
            Vector3 vector = corners[i];
            Vector3 vector2 = a - vector;
            num += Mathf.Sqrt(vector2.x * vector2.x + vector2.y * vector2.y + vector2.z * vector2.z);
            a = vector;
        }
        return num;
    }
}