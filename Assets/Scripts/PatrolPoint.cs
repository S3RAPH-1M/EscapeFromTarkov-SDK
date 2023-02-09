using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using EFT;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000468 RID: 1128
public class PatrolPoint : MonoBehaviour
{
	public Vector3 position
	{
		get
		{
			return base.transform.position;
		}
	}
	
	public Vector3 Position
	{
		get
		{
			return base.transform.position;
		}
	}
	
	[ContextMenu("CreateSubPoints")]
	public void CreateSubPoints()
	{
		PatrolWay way = PatrolWay;
		int num = 6;
		this.method_1();
		List<PatrolPoint> list = this.method_0();
		if (this.SubManual)
		{
			PointWithLookSides component = base.GetComponent<PointWithLookSides>();
			if (component != null)
			{
				this.PointWithLookSides = component;
				component.Refresh();
			}
			this.subPoints = new List<PatrolPoint>();
			IEnumerator enumerator = base.transform.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				NavMeshHit navMeshHit;
				if (NavMesh.SamplePosition(transform.position + Vector3.up, out navMeshHit, 1.5f, -1))
				{
					transform.position = navMeshHit.position;
				}
				else
				{
					string str = (transform.parent != null) ? transform.parent.name : "No parent";
					Debug.LogError("Can't sample to to navmesh " + transform.name + "  with SubManual == true  parent:" + str);
				}
				PatrolPoint component2 = transform.GetComponent<PatrolPoint>();
				NavMeshPath navMeshPath = new NavMeshPath();
				if (NavMesh.CalculatePath(this.Position, transform.position, -1, navMeshPath))
				{
					if (navMeshPath.status != NavMeshPathStatus.PathComplete)
					{
						Debug.LogError("Can't cal path with some of sub points " + base.gameObject.name + ". This points setted manually. SO FIX IT!!!!222");
					}
					else
					{
						float magnitude = (navMeshPath.corners[0] - this.Position).magnitude;
						float magnitude2 = (navMeshPath.corners[navMeshPath.corners.Length - 1] - transform.position).magnitude;
						if (magnitude > 0.7f)
						{
							Debug.LogError(string.Format("distToStart ERROR  {0}  {1}   {2}", magnitude, transform.gameObject.name, base.gameObject.name));
						}
						if (magnitude2 > 0.7f)
						{
							Debug.LogError(string.Format("distToEnd ERROR  {0} {1}   {2}", magnitude2, transform.gameObject.name, base.gameObject.name));
						}
					}
				}
				else
				{
					Debug.LogError("Can't cal path with some of sub points " + base.gameObject.name + ". This points setted manually. SO FIX IT!!!!111");
				}
				if (component2 != null)
				{
					this.subPoints.Add(component2);
					PointWithLookSides componentInChildren = component2.GetComponentInChildren<PointWithLookSides>();
					bool flag = false;
					bool flag2 = false;
					if (componentInChildren != null)
					{
						flag = true;
						component2.PointWithLookSides = componentInChildren;
					}
					PointWithLookSides component3 = component2.GetComponent<PointWithLookSides>();
					if (component3 != null)
					{
						flag2 = true;
						component2.PointWithLookSides = component3;
					}
					if (flag && flag2)
					{
						Debug.LogError("Patrol point " + base.gameObject.name + "  have 2 PointWithLookSides");
					}
					if (component2.PointWithLookSides != null)
					{
						component2.PointWithLookSides.Refresh();
					}
				}
			}
			goto IL_3A5;
		}
		foreach (PatrolPoint patrolPoint in list)
		{
			UnityEngine.Object.DestroyImmediate(patrolPoint.gameObject);
		}
		this.subPoints = new List<PatrolPoint>();
		this.method_2(1.7f * way.CoefSubPoints, 0f);
		this.method_2(2.5f * way.CoefSubPoints, 0f);
		this.method_2(3.4f * way.CoefSubPoints, 0f);
		if (this.subPoints.Count <= num)
		{
			Debug.LogWarning("not normal count of sub points at point. Try to fix it automaticly:" + base.gameObject.name);
			this.method_2(1.7f * way.CoefSubPoints, 1f);
			this.method_2(2.5f * way.CoefSubPoints, 1f);
		}
		IL_3A5:
		if (this.subPoints.Count <= num)
		{
			int num2 = 4;
			if (this.subPoints.Count <= 4)
			{
				Debug.LogError(string.Format("Под точек слишком мало Меньше:{0}. !!!!BLOCKER!!!!! Правь сейчас! name:{1}. ", num2, base.gameObject.name));
				return;
			}
			Debug.LogWarning(string.Format("Под точек слишком мало Меньше:{0}. name:{1}. This is not BLOCKER.Под точек нехватает. Это не полный пиздец, но ты лучше присмотрись!", num, base.gameObject.name));
		}
	}
	
	private List<PatrolPoint> method_0()
	{
		this.PointWithLookSides = null;
		this.ActionData = null;
		List<PatrolPoint> list = new List<PatrolPoint>();
		List<GameObject> list2 = new List<GameObject>();
		foreach (object obj in base.transform)
		{
			Transform transform = (Transform)obj;
			PatrolPoint component = transform.GetComponent<PatrolPoint>();
			if (component != null)
			{
				list.Add(component);
			}
			else
			{
				PointWithLookSides component2 = transform.GetComponent<PointWithLookSides>();
				if (component2 != null)
				{
					this.PointWithLookSides = component2;
					this.PointWithLookSides.Refresh();
				}
				else
				{
					AReserveWayAction component3 = transform.GetComponent<AReserveWayAction>();
					if (component3 != null)
					{
						this.ActionData = component3;
					}
					else
					{
						list2.Add(transform.gameObject);
					}
				}
			}
		}
		if (list2.Count > 0)
		{
			Debug.LogError(string.Concat(new object[]
			{
				"Patrol point have child without any good data:",
				base.gameObject.name,
				"    FIXED ",
				list2.Count
			}));
			GameObject gameObject;
			PointWithLookSides pointWithLookSides;
			if (this.PointWithLookSides == null)
			{
				gameObject = new GameObject("Looks");
				pointWithLookSides = gameObject.AddComponent<PointWithLookSides>();
				gameObject.transform.SetParent(base.transform, false);
				gameObject.transform.localPosition = Vector3.zero;
			}
			else
			{
				pointWithLookSides = this.PointWithLookSides;
				gameObject = this.PointWithLookSides.gameObject;
			}
			foreach (GameObject gameObject2 in list2)
			{
				gameObject2.transform.SetParent(gameObject.transform, true);
				Vector3 vector = gameObject2.transform.position - base.transform.position;
				if (vector.sqrMagnitude <= 1E-06f)
				{
					Debug.LogError("WRONG DIST " + gameObject2.gameObject.name);
				}
				vector.y = 0f;
				vector = GClass777.NormalizeFastSelf(vector);
				pointWithLookSides.Directions.Add(vector);
			}
			this.PointWithLookSides = pointWithLookSides;
		}
		return list;
	}

	// Token: 0x06001F46 RID: 8006 RVA: 0x00097DA0 File Offset: 0x00095FA0
	private void method_1()
	{
		foreach (LookDirections lookDirections in base.GetComponentsInChildren<LookDirections>())
		{
			float magnitude = (lookDirections.Position - base.transform.position).magnitude;
			if (magnitude > 12f)
			{
				Debug.LogError(string.Concat(new object[]
				{
					"SubManual: distToCore > 12:",
					magnitude,
					"    atpoint: ",
					base.gameObject.name,
					"   fix it MANUALLY"
				}));
			}
			NavMeshHit navMeshHit;
			if (NavMesh.SamplePosition(lookDirections.Position, out navMeshHit, 5f, -1))
			{
				if (navMeshHit.distance > 0.5f)
				{
					Debug.LogError(string.Concat(new object[]
					{
						"SubManual: hit.distance too long:",
						navMeshHit.distance,
						"    atpoint: ",
						base.gameObject.name,
						"    autofix"
					}));
				}
				NavMeshPath path = new NavMeshPath();
				if (NavMesh.CalculatePath(lookDirections.Position, navMeshHit.position, -1, path))
				{
					lookDirections.transform.position = navMeshHit.position;
					lookDirections.NormalizeLookSide();
					if (lookDirections.GetComponent<PatrolPoint>() == null)
					{
						lookDirections.gameObject.AddComponent<PatrolPoint>();
						GameObject gameObject = new GameObject("Look sides");
						PointWithLookSides pointWithLookSides = gameObject.AddComponent<PointWithLookSides>();
						gameObject.transform.SetParent(lookDirections.gameObject.transform, false);
						pointWithLookSides.Directions = new List<Vector3>();
						pointWithLookSides.Directions.Add(lookDirections.dir);
					}
				}
				else
				{
					Debug.LogError("SubManual: NO PATH AT SUB POINT:    at point: " + base.gameObject.name + "   fix it MANUALLY");
				}
			}
			else
			{
				Debug.LogError("SubManual: Can't find navmesh near:" + base.gameObject.name + "   fix it MANUALLY");
			}
		}
		LookDirections[] componentsInChildren = base.GetComponentsInChildren<LookDirections>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			UnityEngine.Object.DestroyImmediate(componentsInChildren[i]);
		}
	}
	
	private void method_2(float offset, float yOffset = 0f)
	{
		Vector3 vector = new Vector3(GClass778.Random(-1f, 1f), 0f, GClass778.Random(-1f, 1f));
		vector = GClass777.NormalizeFastSelf(vector) * offset;
		for (int i = 0; i < 4; i++)
		{
			vector = GClass777.RotateOnAngUp(vector, GClass778.Random(70f, 110f));
			NavMeshHit navMeshHit = default(NavMeshHit);
			Vector3 vector2 = this.position + vector;
			if (NavMesh.SamplePosition(vector2, out navMeshHit, 0.3f + yOffset, -1))
			{
				NavMeshPath navMeshPath = new NavMeshPath();
				if (NavMesh.CalculatePath(this.position, vector2, -1, navMeshPath) && navMeshPath.status == NavMeshPathStatus.PathComplete && navMeshPath.CalculatePathLength() < offset * 2f)
				{
					Debug.DrawRay(navMeshHit.position, Vector3.up * 2f, Color.green, 5f);
					GameObject gameObject = new GameObject("SubPoint_" + (base.transform.childCount + 1));
					PatrolPoint item = gameObject.AddComponent<PatrolPoint>();
					gameObject.transform.SetParent(base.transform);
					gameObject.transform.position = navMeshHit.position;
					this.subPoints.Add(item);
				}
			}
		}
	}
	
	private void method_3()
	{
		Gizmos.color = new Color(0f, 1f, 1f, 0.9f);
		GClass773.DrawCube(base.transform.position, base.transform.rotation, new Vector3(1f, 4f, 1f) * 0.2f);
	}

	// Token: 0x06001F49 RID: 8009 RVA: 0x0009814C File Offset: 0x0009634C
	private void method_4()
	{
		if (GClass728.NoDrawSatelites)
		{
			return;
		}
		Gizmos.color = new Color(1f, 0.9215686f, 0.01568628f, 0.9f);
		if (this.subPoints != null)
		{
			foreach (PatrolPoint patrolPoint in this.subPoints)
			{
				if (patrolPoint != null)
				{
					GClass773.DrawCube(patrolPoint.transform.position, base.transform.rotation, new Vector3(1f, 4f, 1f) * 0.14f);
				}
			}
		}
	}

	// Token: 0x06001F4A RID: 8010 RVA: 0x0009820C File Offset: 0x0009640C
	private void OnDrawGizmos()
	{
		if (GClass728.AlwaysDrawPatrolPoints)
		{
			this.method_6();
		}
	}

	// Token: 0x06001F4B RID: 8011 RVA: 0x0009821B File Offset: 0x0009641B
	private void OnDrawGizmosSelected()
	{
		if (!GClass728.AlwaysDrawPatrolPoints)
		{
			this.method_6();
		}
	}

	// Token: 0x06001F4D RID: 8013 RVA: 0x000982B4 File Offset: 0x000964B4
	private void method_6()
	{
		if (this.ActionData != null)
		{
			this.ActionData.DrawGizmos();
		}
		this.method_3();
		this.method_4();
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, Vector3.down, out raycastHit, 50f))
		{
			Gizmos.DrawLine(base.transform.position, raycastHit.point);
		}
	}
	
	public int Id;

	// Token: 0x04001B71 RID: 7025
	public bool CanUseByBoss = true;

	// Token: 0x04001B72 RID: 7026
	public PatrolWay PatrolWay;

	// Token: 0x04001B73 RID: 7027
	public bool ShallSit;

	// Token: 0x04001B74 RID: 7028
	public PatrolPointType PatrolPointType;

	// Token: 0x04001B75 RID: 7029
	public AReserveWayAction ActionData;

	// Token: 0x04001B76 RID: 7030
	public PointWithLookSides PointWithLookSides;

	// Token: 0x04001B77 RID: 7031
	public bool SubManual;

	// Token: 0x04001B78 RID: 7032
	public List<PatrolPoint> subPoints;
}