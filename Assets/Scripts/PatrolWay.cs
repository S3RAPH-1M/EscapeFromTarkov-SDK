using System;
using System.Collections.Generic;
using System.Text;
using EFT;
using UnityEngine;

// Token: 0x0200046B RID: 1131
[Serializable]
public class PatrolWay : MonoBehaviour
{
	public PatrolType PatrolType;

	// Token: 0x04001B81 RID: 7041
	public List<PatrolPoint> Points = new List<PatrolPoint>();

	// Token: 0x04001B82 RID: 7042
	public int MaxPersons;

	// Token: 0x04001B83 RID: 7043
	[HideInInspector]
	public WildSpawnType BlockRoles;

	// Token: 0x04001B86 RID: 7046
	public float CoefSubPoints = 1f;
}