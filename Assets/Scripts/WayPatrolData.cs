using System;
using UnityEngine;

// Token: 0x020001F4 RID: 500
[Serializable]
public class WayPatrolData
{
	// Token: 0x06000A74 RID: 2676 RVA: 0x00032F58 File Offset: 0x00031158
	public static PatrolPoint FindPoint(BotZone zone, int patrolFromId)
	{
		PatrolWay[] patrolWays = zone.PatrolWays;
		for (int i = 0; i < patrolWays.Length; i++)
		{
			foreach (PatrolPoint patrolPoint in patrolWays[i].Points)
			{
				if (patrolPoint.Id == patrolFromId)
				{
					return patrolPoint;
				}
			}
		}
		return null;
	}

	// Token: 0x06000A75 RID: 2677 RVA: 0x00032FD0 File Offset: 0x000311D0
	public WayPatrolData(int from, int to, WayPatrolPoints[] paths)
	{
		this.Paths = paths;
		this.PatrolFrom = from;
		this.PatrolTo = to;
	}

	// Token: 0x06000A76 RID: 2678 RVA: 0x00032FF0 File Offset: 0x000311F0
	public void SetAllAvailable()
	{
		for (int i = 0; i < this.Paths.Length; i++)
		{
			this.Paths[i].IsAvailable = true;
		}
	}

	// Token: 0x06000A77 RID: 2679 RVA: 0x00033020 File Offset: 0x00031220
	public void Check(BotZone zone)
	{
		foreach (WayPatrolPoints wayPatrolPoints in this.Paths)
		{
			PatrolPoint patrolPoint = WayPatrolData.FindPoint(zone, this.PatrolFrom);
			if (patrolPoint == null)
			{
				Debug.LogError(string.Format("Cached bot way PatrolFrom :{0}  {1} is too far from first path point ", patrolPoint, this.PatrolFrom));
			}
			else if (wayPatrolPoints != null)
			{
				if (wayPatrolPoints.WayPoints == null)
				{
					Debug.LogError(string.Format("wayPatrolPointse.WayPoints == null.  zone:{0} DO CACHE WAYS", zone));
				}
				else
				{
					float magnitude = (patrolPoint.position - wayPatrolPoints.WayPoints[0]).magnitude;
					if (magnitude > 0.5f)
					{
						Debug.LogError(string.Format("Cached bot way PatrolFrom :{0}  name:{1} is too far from first path point  distFrom:{2}   DO CACHE WAYS", this.PatrolFrom, patrolPoint, magnitude));
					}
					PatrolPoint patrolPoint2 = WayPatrolData.FindPoint(zone, this.PatrolTo);
					if (patrolPoint2 != null)
					{
						float magnitude2 = (patrolPoint2.position - wayPatrolPoints.WayPoints[wayPatrolPoints.WayPoints.Length - 1]).magnitude;
						if (magnitude2 > 0.5f)
						{
							Debug.LogError(string.Format("Cached bot way PatrolTo :{0}  name:{1} is too far from first path point  distTo:{2}   DO CACHE WAYS", this.PatrolTo, patrolPoint2, magnitude2));
						}
					}
					else
					{
						Debug.LogError("Can't find patrol point for cache ways.  DO CACHE WAYS");
					}
				}
			}
			else
			{
				Debug.LogError(string.Format("wayPatrolPointse == null.  zone:{0}  DO CACHE WAYS", zone));
			}
		}
	}

	// Token: 0x04000A87 RID: 2695
	public int PatrolFrom;

	// Token: 0x04000A88 RID: 2696
	public int PatrolTo;

	// Token: 0x04000A89 RID: 2697
	public WayPatrolPoints[] Paths;
}