using System;
using UnityEngine;

namespace BezierSplineTools
{
    // Token: 0x02000D33 RID: 3379
    public class BezierCurve : MonoBehaviour
    {

        // Token: 0x0600513C RID: 20796 RVA: 0x0019D6F0 File Offset: 0x0019B8F0
        public void Reset()
        {
            this.points = new Vector3[]
            {
                new Vector3(1f, 0f, 0f),
                new Vector3(2f, 0f, 0f),
                new Vector3(3f, 0f, 0f),
                new Vector3(4f, 0f, 0f)
            };
        }

        // Token: 0x040052EF RID: 21231
        public Vector3[] points;
    }
}