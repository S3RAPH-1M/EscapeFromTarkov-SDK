using System;
using System.Collections.Generic;
using EFT;
using EFT.Interactive;
using UnityEngine;

public abstract class DisablerCullingObjectBase : MonoBehaviour
{

	// Token: 0x04004363 RID: 17251
	[SerializeField]
	protected List<Collider> _colliders;

	// Token: 0x04004364 RID: 17252
	[SerializeField]
	protected List<Collider> _inverseColliders;
}