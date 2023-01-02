using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using EFT;
using UnityEngine;

// Token: 0x02000132 RID: 306
[Serializable]
public class CustomNavigationPoint
{
	// Token: 0x0400078B RID: 1931
	public const int BASE_HIDE_VAL = 51;

	// Token: 0x0400078C RID: 1932
	public const float LIGHT_WALL_ANG = 57f;

	// Token: 0x0400078D RID: 1933
	public const float MAX_DEFENCE_LEVEL_SIDE = 8f;

	// Token: 0x0400078E RID: 1934
	public const int MAX_HIDE_VAL = 100;

	// Token: 0x0400078F RID: 1935
	[SerializeField]
	private Vector3 _cachedPosition;

	// Token: 0x04000790 RID: 1936
	public int Id;

	// Token: 0x0400079A RID: 1946
	public bool AlwaysGood;

	// Token: 0x0400079B RID: 1947
	public bool DrawSign;

	// Token: 0x0400079C RID: 1948
	public bool BordersLightHave;

	// Token: 0x0400079D RID: 1949

	// Token: 0x0400079E RID: 1950

	// Token: 0x0400079F RID: 1951
	[HideInInspector]
	public bool CanIShootToEnemy;

	// Token: 0x040007A0 RID: 1952
	[HideInInspector]
	public bool lastCanShoot;

	// Token: 0x040007A1 RID: 1953
	public bool CanLookLeft;

	// Token: 0x040007A2 RID: 1954
	public bool CanLookRight;

	// Token: 0x040007A3 RID: 1955
	public int HideLevel = 51;

	// Token: 0x040007A4 RID: 1956
	public int PlaceId = -1;

	// Token: 0x040007A7 RID: 1959
	private float _startBaseWeight = 1f;

	// Token: 0x040007A8 RID: 1960
	private bool _isSpotted;

	// Token: 0x040007A9 RID: 1961
	private bool _blocked;

	// Token: 0x040007AA RID: 1962
	private float _spottedTime;

	// Token: 0x040007AB RID: 1963
	private bool _isGoodInsideBuilding;

	// Token: 0x040007AC RID: 1964
	private float _coveringWeight;

	// Token: 0x040007AD RID: 1965
	private float _unSpottedTime;

	// Token: 0x040007AE RID: 1966
	private float _decreasedWeightCoef = 1f;

	// Token: 0x040007AF RID: 1967
	private float _nextCheckCanShootTime;
}
