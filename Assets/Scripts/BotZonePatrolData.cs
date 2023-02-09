using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x020001F5 RID: 501
public class BotZonePatrolData : MonoBehaviour
{
    public BotZone zone;
    // Token: 0x06000A79 RID: 2681 RVA: 0x00033254 File Offset: 0x00031454
    [ContextMenu("TEST")]
    private void Jopa()
    {
        foreach (var patrolWay in zone.PatrolWays)
        {
            for (int i = 0; i < patrolWay.Points.Count; i++)
            {
                if (i + 1 < patrolWay.Points.Count)
                {
                    AddWays(patrolWay.Points[i], patrolWay.Points[i + 1], new List<NavMeshObstacle>(),
                        zone.CoverPoints.ToList());
                }
                else
                {
                    AddWays(patrolWay.Points[i], patrolWay.Points[0], new List<NavMeshObstacle>(),
                        zone.CoverPoints.ToList());
                }
            }
        }
    }
    
    public async Task AddWays(PatrolPoint from, PatrolPoint to, List<NavMeshObstacle> obstacles,
        List<CustomNavigationPoint> coverPoints)
    {
        await Task.Yield();
        var wayPatrolPoints = await method_7(from.Position, to.Position, obstacles, coverPoints);
        var list = new List<WayPatrolPoints>();
        var list2 = new List<WayPatrolPoints>();
        await Task.Yield();
        if (wayPatrolPoints != null)
        {
            await Task.Yield();
            list.Add(wayPatrolPoints);
            var way = wayPatrolPoints.WayPoints.Reverse().ToArray();
            list2.Add(new WayPatrolPoints(Guid.NewGuid().GetHashCode(), way, wayPatrolPoints.CanRun));
            var wayPatrolPoints2 = await method_7(from.Position, to.Position, obstacles, coverPoints);
            if (wayPatrolPoints2 != null)
            {
                await Task.Yield();
                list.Add(wayPatrolPoints2);
                way = wayPatrolPoints2.WayPoints.Reverse().ToArray();
                list2.Add(new WayPatrolPoints(Guid.NewGuid().GetHashCode(), way, wayPatrolPoints2.CanRun));
                var wayPatrolPoints3 = await method_7(from.Position, to.Position, obstacles, coverPoints);
                if (wayPatrolPoints3 != null)
                {
                    await Task.Yield();
                    list.Add(wayPatrolPoints3);
                    way = wayPatrolPoints3.WayPoints.Reverse().ToArray();
                    list2.Add(new WayPatrolPoints(Guid.NewGuid().GetHashCode(), way, wayPatrolPoints3.CanRun));
                }

                wayPatrolPoints3 = null;
            }

            wayPatrolPoints2 = null;
        }
        else
        {
            await Task.Yield();
            var navMeshPath = new NavMeshPath();
            var flag = NavMesh.CalculatePath(from.Position, to.Position, -1, navMeshPath);
            if (!flag)
                Debug.LogError(string.Format(
                    "Can't create ways between from:{0}  to:{1}   obstacles:{2}  status:{3}  path:{4}", from, to,
                    obstacles.Count, flag, navMeshPath.status));
        }

        await Task.Yield();
        method_10(obstacles);
        var item = new WayPatrolData(from.Id, to.Id, list.ToArray());
        WaysAsList.Add(item);
        var item2 = new WayPatrolData(to.Id, from.Id, list2.ToArray());
        WaysAsList.Add(item2);
    }

    // Token: 0x06000A7B RID: 2683 RVA: 0x000332CC File Offset: 0x000314CC
    public void CheckCurZone(BotZone zone)
    {
        foreach (var wayPatrolData in WaysAsList) wayPatrolData.Check(zone);
    }

    // Token: 0x06000A7C RID: 2684 RVA: 0x000134BD File Offset: 0x000116BD
    private void method_0(WayPatrolPoints path, BotZone zone, int patrolFrom, int patrolTo)
    {
    }

    // Token: 0x06000A83 RID: 2691 RVA: 0x00033598 File Offset: 0x00031798
    private async Task<WayPatrolPoints> method_7(Vector3 from, Vector3 to, List<NavMeshObstacle> obstaclesCollect,
        List<CustomNavigationPoint> coverPoints)
    {
        await Task.Yield();
        WayPatrolPoints wayPatrolPoints = null;
        var navMeshPath = new NavMeshPath();
        if (NavMesh.CalculatePath(from, to, -1, navMeshPath) && navMeshPath.status == NavMeshPathStatus.PathComplete)
        {
            if (navMeshPath.corners.Length <= 1)
            {
                Debug.LogError(string.Format("path.corners.Length <= 1  from:{0}  to:{1}", from, to));
                return null;
            }

            var way = navMeshPath.corners.ToArray();
            var canRun = method_8(way, coverPoints);
            wayPatrolPoints = new WayPatrolPoints(Guid.NewGuid().GetHashCode(), way, canRun);
            await Task.Yield();
            for (var i = 0; i < wayPatrolPoints.WayPoints.Length - 1; i++)
                obstaclesCollect.Add(method_11(wayPatrolPoints.WayPoints[i], wayPatrolPoints.WayPoints[i + 1]));
        }

        return wayPatrolPoints;
    }

    // Token: 0x06000A84 RID: 2692 RVA: 0x00033600 File Offset: 0x00031800
    private bool method_8(Vector3[] way, List<CustomNavigationPoint> coverPoints)
    {
        if (NavTriangle.CalculatePathLength(way) > 3f)
        {
            var num = 0;
            for (var i = 0; i < way.Length - 1; i++)
            {
                var p = way[i];
                var p2 = way[i + 1];
                var num2 = method_9(p, p2, coverPoints);
                num += num2;
            }

            if (num <= 3f) return true;
        }

        return false;
    }

    // Token: 0x06000A85 RID: 2693 RVA: 0x0003365C File Offset: 0x0003185C
    private int method_9(Vector3 p1, Vector3 p2, List<CustomNavigationPoint> coverPoints)
    {
        var num = 0;
        foreach (var customNavigationPoint in coverPoints)
            if ((GetProjectionPoint(customNavigationPoint.BasePosition, p1, p2) - customNavigationPoint.BasePosition)
                .magnitude < 0.1f)
                num++;
        return num;
    }

    // Token: 0x06000A86 RID: 2694 RVA: 0x000336D4 File Offset: 0x000318D4
    private void method_10(List<NavMeshObstacle> obstacles)
    {
        foreach (var navMeshObstacle in obstacles.ToList())
        {
            navMeshObstacle.gameObject.SetActive(false);
            DestroyImmediate(navMeshObstacle.gameObject);
        }

        obstacles.Clear();
    }

    // Token: 0x06000A87 RID: 2695 RVA: 0x0003373C File Offset: 0x0003193C
    private NavMeshObstacle method_11(Vector3 from, Vector3 to)
    {
        Vector3 a;
        Vector3 b;
        if (from.z < to.z)
        {
            a = from;
            b = to;
        }
        else
        {
            a = to;
            b = from;
        }

        var gameObject = new GameObject("Obstacle");
        var navMeshObstacle = gameObject.AddComponent<NavMeshObstacle>();
        var from2 = a - b;
        var magnitude = from2.magnitude;
        gameObject.transform.position = (a + b) / 2f;
        navMeshObstacle.carving = true;
        navMeshObstacle.size = new Vector3(magnitude * 0.8f, 3f, 3f);
        from2.y = 0f;
        var y = Vector3.Angle(from2, Vector3.right);
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, y, 0f));
        return navMeshObstacle;
    }

    // Token: 0x06000A88 RID: 2696 RVA: 0x00033800 File Offset: 0x00031A00
    private void OnDrawGizmosSelected()
    {
        if (DrawGizmos && WaysAsList != null)
            foreach (var wayPatrolData in WaysAsList)
            foreach (var way in wayPatrolData.Paths)
                method_12(way);
    }

    // Token: 0x06000A89 RID: 2697 RVA: 0x0003387C File Offset: 0x00031A7C
    private void method_12(WayPatrolPoints way)
    {
        var b = Vector3.up * 0.1f;
        if (way.IsAvailable)
            Gizmos.color = way.CanRun ? Color.green : Color.blue;
        else
            Gizmos.color = Color.red;
        for (var i = 0; i < way.WayPoints.Length - 1; i++)
        {
            var a = way.WayPoints[i];
            var a2 = way.WayPoints[i + 1];
            Gizmos.DrawLine(a + b, a2 + b);
        }
    }

    public static Vector3 GetProjectionPoint(Vector3 p, Vector3 p1, Vector3 p2)
    {
        var num = p1.z - p2.z;
        if (num == 0f) return new Vector3(p.x, p1.y, p1.z);
        var num2 = p2.x - p1.x;
        if (num2 == 0f) return new Vector3(p1.x, p1.y, p.z);
        var num3 = p1.x * p2.z - p2.x * p1.z;
        var num4 = num2 * p.x - num * p.z;
        var num5 = -(num2 * num3 + num * num4) / (num2 * num2 + num * num);
        return new Vector3(-(num3 + num2 * num5) / num, p1.y, num5);
    }

    // Token: 0x04000A8A RID: 2698
    private const float float_0 = 0.1f;

    // Token: 0x04000A8B RID: 2699
    private const float float_1 = 3f;

    // Token: 0x04000A8C RID: 2700
    private const float float_2 = 3f;

    // Token: 0x04000A8D RID: 2701
    public bool DrawGizmos;

    // Token: 0x04000A8E RID: 2702
    public List<WayPatrolData> WaysAsList = new List<WayPatrolData>();
}