using System;
using UnityEngine;
using UnityEngine.Serialization;

// Token: 0x0200011C RID: 284
[Serializable]
public class CoverPointCreatorPreset
{
	// Token: 0x170001AB RID: 427
	// (get) Token: 0x060006E6 RID: 1766 RVA: 0x000213D7 File Offset: 0x0001F5D7
	public string Name
	{
		get
		{
			return this._name;
		}
	}

	// Token: 0x170001AC RID: 428
	// (get) Token: 0x060006E7 RID: 1767 RVA: 0x000213DF File Offset: 0x0001F5DF
	public DirectionCalculationType DirectionCalculation
	{
		get
		{
			return this._directionCalculation;
		}
	}

	// Token: 0x170001AD RID: 429
	// (get) Token: 0x060006E8 RID: 1768 RVA: 0x000213E7 File Offset: 0x0001F5E7
	public float ANGLE_TO_REMOVE_POINT_ON_EDGE
	{
		get
		{
			return this._angleToRemovePointOnEdge;
		}
	}

	// Token: 0x170001AE RID: 430
	// (get) Token: 0x060006E9 RID: 1769 RVA: 0x000213EF File Offset: 0x0001F5EF
	public float DISTANCE_BETWEEN_COVERS_ON_EDGE
	{
		get
		{
			return this._distanceBetweenCoversOnEdge;
		}
	}

	// Token: 0x170001AF RID: 431
	// (get) Token: 0x060006EA RID: 1770 RVA: 0x000213F7 File Offset: 0x0001F5F7
	public float SMALL_EDGE_SIZE
	{
		get
		{
			return this._smallEdgeSize;
		}
	}

	// Token: 0x170001B0 RID: 432
	// (get) Token: 0x060006EB RID: 1771 RVA: 0x000213FF File Offset: 0x0001F5FF
	public float CLUSTER_LARGE_DIST
	{
		get
		{
			return this._clusterLargeDist;
		}
	}

	// Token: 0x170001B1 RID: 433
	// (get) Token: 0x060006EC RID: 1772 RVA: 0x00021407 File Offset: 0x0001F607
	public float CLUSTER_AMBUSH_DIST
	{
		get
		{
			return this._clusterAmbushDist;
		}
	}

	// Token: 0x170001B2 RID: 434
	// (get) Token: 0x060006ED RID: 1773 RVA: 0x0002140F File Offset: 0x0001F60F
	public float CLUSTER_LARGE_ANGLE
	{
		get
		{
			return this._clusterLargeAngle;
		}
	}

	// Token: 0x170001B3 RID: 435
	// (get) Token: 0x060006EE RID: 1774 RVA: 0x00021417 File Offset: 0x0001F617
	public float CLUSTER_NEAR_DIST
	{
		get
		{
			return this._clusterNearDist;
		}
	}

	// Token: 0x170001B4 RID: 436
	// (get) Token: 0x060006EF RID: 1775 RVA: 0x0002141F File Offset: 0x0001F61F
	public float CLUSTER_FIREPOS_DIST
	{
		get
		{
			return this._clusterFirePosDist;
		}
	}

	// Token: 0x170001B5 RID: 437
	// (get) Token: 0x060006F0 RID: 1776 RVA: 0x00021427 File Offset: 0x0001F627
	public float FIRE_STEP_DIST
	{
		get
		{
			return this._fireStepDist;
		}
	}

	// Token: 0x170001B6 RID: 438
	// (get) Token: 0x060006F1 RID: 1777 RVA: 0x0002142F File Offset: 0x0001F62F
	public bool BOTH_FIREPOS_IS_BAD_COVER
	{
		get
		{
			return this._bothFireposIsBadCover;
		}
	}

	// Token: 0x170001B7 RID: 439
	// (get) Token: 0x060006F2 RID: 1778 RVA: 0x00021437 File Offset: 0x0001F637
	public float DISTANCE_RAYCAST_MULTIPLIER
	{
		get
		{
			return this._distanceRaycastMultiplier;
		}
	}

	// Token: 0x170001B8 RID: 440
	// (get) Token: 0x060006F3 RID: 1779 RVA: 0x0002143F File Offset: 0x0001F63F
	public float DISTANCE_FIREPOS_MULTIPLIER
	{
		get
		{
			return this._distanceFireposMultiplier;
		}
	}

	// Token: 0x170001B9 RID: 441
	// (get) Token: 0x060006F4 RID: 1780 RVA: 0x00021447 File Offset: 0x0001F647
	public float AmbushMinSegment
	{
		get
		{
			return this._ambushMinSegment;
		}
	}

	// Token: 0x170001BA RID: 442
	// (get) Token: 0x060006F5 RID: 1781 RVA: 0x0002144F File Offset: 0x0001F64F
	public float LEG_WALL_CHECK
	{
		get
		{
			return this._legWallCheck;
		}
	}

	// Token: 0x170001BB RID: 443
	// (get) Token: 0x060006F6 RID: 1782 RVA: 0x00021457 File Offset: 0x0001F657
	public float LegsCheckMinDist
	{
		get
		{
			return this._legsCheckMinDist;
		}
	}

	// Token: 0x170001BC RID: 444
	// (get) Token: 0x060006F7 RID: 1783 RVA: 0x0002145F File Offset: 0x0001F65F
	public bool HighQualityBorder
	{
		get
		{
			return this._highQualityBorder;
		}
	}

	// Token: 0x170001BD RID: 445
	// (get) Token: 0x060006F8 RID: 1784 RVA: 0x00021467 File Offset: 0x0001F667
	public bool IgnoreLineCast
	{
		get
		{
			return this._ignoreRayCast;
		}
	}

	// Token: 0x170001BE RID: 446
	// (get) Token: 0x060006F9 RID: 1785 RVA: 0x0002146F File Offset: 0x0001F66F
	public bool WithCheckPointStay
	{
		get
		{
			return this._withCheckPointStay;
		}
	}

	// Token: 0x170001BF RID: 447
	// (get) Token: 0x060006FA RID: 1786 RVA: 0x00021477 File Offset: 0x0001F677
	public float CheckOnNavMeshDist
	{
		get
		{
			return this._checkOnNavMeshDist;
		}
	}

	// Token: 0x170001C0 RID: 448
	// (get) Token: 0x060006FB RID: 1787 RVA: 0x0002147F File Offset: 0x0001F67F
	public float SphereCastRadius
	{
		get
		{
			return this._sphereCastRadius;
		}
	}

	// Token: 0x170001C1 RID: 449
	// (get) Token: 0x060006FC RID: 1788 RVA: 0x00021487 File Offset: 0x0001F687
	public bool RemoveCoversNearDoorAfterCalc
	{
		get
		{
			return this._removeCoversNearDoorAfterCalc;
		}
	}

	// Token: 0x04000723 RID: 1827
	[SerializeField]
	private string _name;

	// Token: 0x04000724 RID: 1828
	[SerializeField]
	private DirectionCalculationType _directionCalculation;

	// Token: 0x04000725 RID: 1829
	[SerializeField]
	private float _angleToRemovePointOnEdge = 6f;

	// Token: 0x04000726 RID: 1830
	[SerializeField]
	private float _distanceBetweenCoversOnEdge = 3f;

	// Token: 0x04000727 RID: 1831
	[SerializeField]
	private float _smallEdgeSize = 1f;

	// Token: 0x04000728 RID: 1832
	[SerializeField]
	private float _clusterLargeDist = 0.8f;

	// Token: 0x04000729 RID: 1833
	[SerializeField]
	private float _clusterAmbushDist = 1.8f;

	// Token: 0x0400072A RID: 1834
	[SerializeField]
	private float _clusterLargeAngle = 50f;

	// Token: 0x0400072B RID: 1835
	[SerializeField]
	private float _clusterNearDist = 0.4f;

	// Token: 0x0400072C RID: 1836
	[SerializeField]
	private float _clusterFirePosDist = 0.75f;

	// Token: 0x0400072D RID: 1837
	[SerializeField]
	private float _fireStepDist = 0.85f;

	// Token: 0x0400072E RID: 1838
	[SerializeField]
	private bool _bothFireposIsBadCover;

	// Token: 0x0400072F RID: 1839
	[SerializeField]
	private float _distanceRaycastMultiplier = 1f;

	// Token: 0x04000730 RID: 1840
	[SerializeField]
	private float _distanceFireposMultiplier = 1f;

	// Token: 0x04000731 RID: 1841
	[SerializeField]
	private float _ambushMinSegment = 1.5f;

	// Token: 0x04000732 RID: 1842
	[SerializeField]
	private float _legWallCheck = 0.17f;

	// Token: 0x04000733 RID: 1843
	[SerializeField]
	private float _legsCheckMinDist = 1.2f;

	// Token: 0x04000734 RID: 1844
	[SerializeField]
	private bool _highQualityBorder;

	// Token: 0x04000735 RID: 1845
	[FormerlySerializedAs("_checkLineCast")]
	[SerializeField]
	private bool _ignoreRayCast;

	// Token: 0x04000736 RID: 1846
	[SerializeField]
	private bool _withCheckPointStay = true;

	// Token: 0x04000737 RID: 1847
	[SerializeField]
	private float _checkOnNavMeshDist = 0.04f;

	// Token: 0x04000738 RID: 1848
	[SerializeField]
	private float _sphereCastRadius = 0.1f;

	// Token: 0x04000739 RID: 1849
	[SerializeField]
	private bool _removeCoversNearDoorAfterCalc = true;
}
