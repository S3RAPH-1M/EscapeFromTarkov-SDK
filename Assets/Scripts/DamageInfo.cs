using System;
using EFT;
using EFT.Ballistics;
using EFT.InventoryLogic;
using UnityEngine;

// Token: 0x02001CE4 RID: 7396
public struct DamageInfo
{
	// Token: 0x17001777 RID: 6007
	// (get) Token: 0x0600A86F RID: 43119 RVA: 0x002D2BAE File Offset: 0x002D0DAE

	// Token: 0x0600A870 RID: 43120 RVA: 0x002D2BD0 File Offset: 0x002D0DD0

	// Token: 0x04009581 RID: 38273
	public EDamageType DamageType;

	// Token: 0x04009582 RID: 38274
	public float Damage;

	// Token: 0x04009583 RID: 38275
	public float PenetrationPower;

	// Token: 0x04009584 RID: 38276
	public Collider HitCollider;

	// Token: 0x04009585 RID: 38277
	public Vector3 Direction;

	// Token: 0x04009586 RID: 38278
	public Vector3 HitPoint;

	// Token: 0x04009587 RID: 38279
	public Vector3 MasterOrigin;

	// Token: 0x04009588 RID: 38280
	public Vector3 HitNormal;

	// Token: 0x04009589 RID: 38281
	public BallisticCollider HittedBallisticCollider;

	// Token: 0x0400958A RID: 38282
	public Player Player;

	// Token: 0x0400958B RID: 38283
	public Item Weapon;

	// Token: 0x0400958C RID: 38284
	public int FireIndex;

	// Token: 0x0400958D RID: 38285
	public float ArmorDamage;

	// Token: 0x0400958E RID: 38286
	public bool IsForwardHit;

	// Token: 0x0400958F RID: 38287
	public float HeavyBleedingDelta;

	// Token: 0x04009590 RID: 38288
	public float LightBleedingDelta;

	// Token: 0x04009591 RID: 38289
	public string DeflectedBy;

	// Token: 0x04009592 RID: 38290
	public string BlockedBy;

	// Token: 0x04009593 RID: 38291
	public float StaminaBurnRate;

	// Token: 0x04009594 RID: 38292
	public float DidBodyDamage;

	// Token: 0x04009595 RID: 38293
	public float DidArmorDamage;

	// Token: 0x04009596 RID: 38294
	public string SourceId;
}
