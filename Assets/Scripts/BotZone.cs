using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using EFT.Game.Spawning;
using EFT.Interactive;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

// Token: 0x0200038F RID: 911
public class BotZone : MonoBehaviour
{
	//TODO: add ZoneDangerAreasClass
	//public ZoneDangerAreasClass ZoneDangerAreas { get; private set; }
	public int GizmosMaxDangerLevel { get; set; } = 9999;
	
	public List<BoxCollider> GetAllBounds(bool onlyActive)
	{
		List<BoxCollider> list = new List<BoxCollider>();
		foreach (Transform transform in GClass777.GetChildsName(base.transform, "Bounds", onlyActive))
		{
			BoxCollider component = transform.GetComponent<BoxCollider>();
			if (component != null)
			{
				list.Add(component);
			}
		}
		return list;
	}

	// Token: 0x06001A31 RID: 6705 RVA: 0x000810C4 File Offset: 0x0007F2C4
	public void DrawBaseWeight()
	{
		float a = 0f;
		if (this.CoverPoints.Length != 0)
		{
			a = this.CoverPoints.Max(x => x.BaseWeight);
		}
		float b = 0f;
		if (this.AmbushPoints.Length != 0)
		{
			b = this.AmbushPoints.Max(x => x.BaseWeight);
		}
		Mathf.Max(a, b);
	}

	// Token: 0x06001A32 RID: 6706 RVA: 0x00081150 File Offset: 0x0007F350
	public void OnDrawGizmos()
	{
		if (GClass728.DrawBounds)
		{
			foreach (BoxCollider boxCollider in this.GetAllBounds(false))
			{
				this.method_9(boxCollider);
			}
		}
		
		if (!Application.isPlaying)
		{
			this.method_12();
			this.method_13();
			this.method_10();
			this.method_11();
		}
	}

	// Token: 0x06001A33 RID: 6707 RVA: 0x000811D4 File Offset: 0x0007F3D4
	private void method_9(BoxCollider boxCollider)
	{
		Gizmos.color = Color.yellow;
		Vector3 size = boxCollider.size;
		Vector3 localScale = boxCollider.transform.localScale;
		Gizmos.matrix = Matrix4x4.TRS(boxCollider.transform.position, boxCollider.transform.rotation, Vector3.one);
		Vector3 size2 = new Vector3(size.x * localScale.x, size.y * localScale.y, size.z * localScale.z);
		Gizmos.DrawWireCube(Vector3.zero, size2);
		Gizmos.matrix = Matrix4x4.identity;
	}

	// Token: 0x06001A34 RID: 6708 RVA: 0x00081266 File Offset: 0x0007F466
	public void OnDrawGizmosSelected()
	{
		if (!Application.isPlaying)
		{
			this.method_12();
			this.method_13();
			this.method_10();
			this.method_11();
			DrawZoneTriangles();
			return;
		}
		//TODO: gizmos for ZoneDangerAreas
		/*if (this.ZoneDangerAreas != null)
		{
			this.ZoneDangerAreas.OnDrawGizmosSelected();
		}*/
	}

	private void DrawZoneTriangles()
	{
		var triangles = ZoneTriangleData.Triangles;
		if (triangles == null) return;
		
		Gizmos.color = Color.green;
		foreach (var triangle in triangles)
		{
			var vector = new Vector3(triangle.CenterX, triangle.CenterY, triangle.CenterZ);
			Gizmos.DrawSphere(vector, 0.3f);
			Gizmos.DrawSphere(vector + Vector3.up * 0.25f, 0.3f);
			Gizmos.DrawSphere(vector + Vector3.up * 0.5f, 0.26f);
		}
	}
	
	private void method_10()
	{
		Vector3 position = Camera.current.transform.position;
		float sDist = this.DistDrawAmbush * this.DistDrawAmbush;
		foreach (CustomNavigationPoint customNavigationPoint in this.AmbushPoints)
		{
			if ((!this.DrawOnlyInPlaces || customNavigationPoint.PlaceId <= 0) && customNavigationPoint.CovPointsPlaceSerializable.DefenceInfo.DangerCoeff <= this.GizmosMaxDangerLevel)
			{
				customNavigationPoint.OnDrawGizmosAsAmbush(new Vector3?(position), sDist, this.DrawSidesAmbush);
			}
		}
	}

	// Token: 0x06001A36 RID: 6710 RVA: 0x00081320 File Offset: 0x0007F520
	private void method_11()
	{
		Vector3 position = Camera.current.transform.position;
		float sDist = this.DistDrawBush * this.DistDrawBush;
		if (this.BushPoints == null)
		{
			return;
		}
		CustomNavigationPoint[] bushPoints = this.BushPoints;
		for (int i = 0; i < bushPoints.Length; i++)
		{
			bushPoints[i].OnDrawGizmosAsAmbush(new Vector3?(position), sDist, this.DrawSidesAmbush);
		}
	}

	// Token: 0x06001A37 RID: 6711 RVA: 0x00081380 File Offset: 0x0007F580
	private void method_12()
	{
		if (this.MinDefenceLevelToDraw <= 0f)
		{
			return;
		}
		int num = 15;
		Gizmos.color = new Color(0.9f, 0.2f, 0.2f, 0.5f);
		foreach (CustomNavigationPoint customNavigationPoint in this.CoverPoints.Concat(this.AmbushPoints))
		{
			if (customNavigationPoint.CovPointsPlaceSerializable.DefenceLevel > this.MinDefenceLevelToDraw)
			{
				GClass773.DrawCube(customNavigationPoint.Position + Vector3.up * (float)num * 0.5f, base.transform.rotation, new Vector3(1f, (float)num, 1f));
			}
		}
	}

	// Token: 0x06001A38 RID: 6712 RVA: 0x00081458 File Offset: 0x0007F658
	private void method_13()
	{
		if (this.CoverPoints != null && this.CoverPoints.Length != 0)
		{
			Vector3 position = Camera.current.transform.position;
			float sDist = this.DistDrawCover * this.DistDrawCover;
			foreach (CustomNavigationPoint customNavigationPoint in this.CoverPoints)
			{
				if ((!this.DrawOnlyInPlaces || customNavigationPoint.PlaceId <= 0) && customNavigationPoint.CovPointsPlaceSerializable.DefenceInfo.DangerCoeff <= this.GizmosMaxDangerLevel)
				{
					customNavigationPoint.OnDrawGizmosFullAsCover(new Vector3?(position), sDist, this.DrawSidesCover);
				}
			}
			return;
		}
	}
	
	// Token: 0x0400145C RID: 5212
	public const float MIN_BORN_CHECK_TIME = 2f;

	// Token: 0x0400145D RID: 5213
	public const float MAX_BORN_CHECK_TIME = 60f;

	// Token: 0x0400145E RID: 5214
	public float DistanceCoef = 1f;

	// Token: 0x0400145F RID: 5215
	public int PoolSize = 10;

	// Token: 0x04001460 RID: 5216
	public int Id;

	// Token: 0x04001463 RID: 5219
	[FormerlySerializedAs("MaxPersonsOnPatrol")]
	[SerializeField]
	private int _maxPersonsOnPatrol;

	// Token: 0x04001464 RID: 5220
	public bool CanSpawnBoss;

	// Token: 0x04001465 RID: 5221
	public bool CachePathLength;

	// Token: 0x04001466 RID: 5222
	public bool SnipeZone;

	// Token: 0x04001467 RID: 5223
	public bool DoDownToEarthPoints;

	// Token: 0x04001468 RID: 5224
	public CustomNavigationPoint[] CoverPoints;

	// Token: 0x04001469 RID: 5225
	public CustomNavigationPoint[] AmbushPoints;

	// Token: 0x0400146A RID: 5226
	public CustomNavigationPoint[] BushPoints;

	// Token: 0x0400146B RID: 5227
	public AIPlaceInfo[] AllPlaces;

	// Token: 0x0400146C RID: 5228
	public ZoneTriangleData ZoneTriangleData;

	// Token: 0x0400146D RID: 5229
	public PatrolWay[] PatrolWays;

	// Token: 0x0400146E RID: 5230
	public List<SpawnPointMarker> SpawnPointMarkers;

	// Token: 0x0400146F RID: 5231
	public UnspawnPoint[] UnSpawnPoints;

	// Token: 0x04001472 RID: 5234
	public BotZone[] NeightbourZones;

	// Token: 0x04001476 RID: 5238
	public bool DrawSidesAmbush;

	// Token: 0x04001477 RID: 5239
	public bool DrawOnlyInPlaces;

	// Token: 0x04001478 RID: 5240
	public bool DrawSidesCover;

	// Token: 0x04001479 RID: 5241
	public float MinDefenceLevelToDraw;

	// Token: 0x0400147A RID: 5242
	public float DistDrawCover = 50f;

	// Token: 0x0400147B RID: 5243
	public float DistDrawAmbush = 50f;

	// Token: 0x0400147C RID: 5244
	public float DistDrawBush = 50f;

	// Token: 0x0400147D RID: 5245
	public BotLocationModifier Modifier;

	// Token: 0x0400147F RID: 5247
	public BotZoneManualInfo ZoneManualInfo;

	// Token: 0x04001480 RID: 5248
	public BotZoneStationaryWeapons StationaryWeapons;

	// Token: 0x04001481 RID: 5249
	public BotZonePatrolData ZonePatrolData;

	// Token: 0x04001482 RID: 5250
	public BotZoneNavMeshCutter ZoneNavMeshCutters;

	// Token: 0x04001483 RID: 5251
	public BotZoneEntranceInfo EntranceInfo;

	// Token: 0x04001486 RID: 5254
	public List<BotPointOfInterest> PointsOfInterest = new List<BotPointOfInterest>();

	// Token: 0x04001487 RID: 5255
	[HideInInspector]
	public string CoverPointCreatorPresetName;
}
