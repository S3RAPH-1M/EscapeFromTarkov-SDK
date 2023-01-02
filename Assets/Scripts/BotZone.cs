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
	// Token: 0x17000374 RID: 884
	// (get) Token: 0x060018C1 RID: 6337 RVA: 0x0007BFBA File Offset: 0x0007A1BA
	// (set) Token: 0x060018C2 RID: 6338 RVA: 0x0007BFC2 File Offset: 0x0007A1C2
	public int GizmosMaxDangerLevel { get; set; } = 9999;

	// Token: 0x17000375 RID: 885
	// (get) Token: 0x060018C3 RID: 6339 RVA: 0x0007BFCB File Offset: 0x0007A1CB
	// (set) Token: 0x060018C4 RID: 6340 RVA: 0x0007BFD3 File Offset: 0x0007A1D3
	public bool AlwaysDrawGizmos { get; set; }

	public string ShortName { get; private set; }

	// Token: 0x04001397 RID: 5015
	public const float MIN_BORN_CHECK_TIME = 2f;

	// Token: 0x04001398 RID: 5016
	public const float MAX_BORN_CHECK_TIME = 60f;

	// Token: 0x04001399 RID: 5017
	public float DistanceCoef = 1f;

	// Token: 0x0400139A RID: 5018
	public int PoolSize = 10;

	// Token: 0x0400139B RID: 5019
	public int Id;

	// Token: 0x0400139C RID: 5020
	[CompilerGenerated]
	private int int_0;

	// Token: 0x0400139D RID: 5021
	[CompilerGenerated]
	private bool bool_0;

	// Token: 0x0400139E RID: 5022
	[SerializeField]
	[FormerlySerializedAs("MaxPersonsOnPatrol")]
	private int _maxPersonsOnPatrol;

	// Token: 0x0400139F RID: 5023
	public bool CanSpawnBoss;

	// Token: 0x040013A0 RID: 5024
	public bool CachePathLength;

	// Token: 0x040013A1 RID: 5025
	public bool SnipeZone;

	// Token: 0x040013A2 RID: 5026
	public bool DoDownToEarthPoints;

	// Token: 0x040013A6 RID: 5030
	public bool DrawSidesAmbush;

	// Token: 0x040013B2 RID: 5042
	public bool DrawOnlyInPlaces;

	// Token: 0x040013B3 RID: 5043
	public bool DrawSidesCover;

	// Token: 0x040013B4 RID: 5044
	public float MinDefenceLevelToDraw;

	// Token: 0x040013B5 RID: 5045
	public float DistDrawCover = 50f;

	// Token: 0x040013B6 RID: 5046
	public float DistDrawAmbush = 50f;

	// Token: 0x040013B7 RID: 5047
	public float DistDrawBush = 50f;
}
