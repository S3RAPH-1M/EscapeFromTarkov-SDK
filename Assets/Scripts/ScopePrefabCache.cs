using System;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using EFT.CameraControl;

// Token: 0x020007C0 RID: 1984
public class ScopePrefabCache : MonoBehaviour
{

	[SerializeField]
	public bool CanChangeAngleByDistance;

	// Token: 0x04003149 RID: 12617
	[SerializeField]
	public Transform WeaponScopeAxis;

	// Token: 0x0400314A RID: 12618
	[SerializeField]
	public ScopePrefabCache.DistaneAngle[] AngleByRange;

	// Token: 0x0400314B RID: 12619
	private const string string_0 = "mode_";

	// Token: 0x0400314C RID: 12620
	[SerializeField]
	private ScopePrefabCache.ScopeModeInfo[] _scopeModeInfos = new ScopePrefabCache.ScopeModeInfo[0];

	// Token: 0x0400314D RID: 12621
	private int int_0;

	// Token: 0x0400314E RID: 12622
	[CompilerGenerated]
	private bool bool_0;

	// Token: 0x0400314F RID: 12623
	[CompilerGenerated]
	private bool bool_1;

	// Token: 0x02000845 RID: 2117
	[Serializable]
	public class ScopeModeInfo
	{
		// Token: 0x04003150 RID: 12624
		public GameObject ModeGameObject;

		// Token: 0x04003151 RID: 12625
		public CollimatorSight CollimatorSight;

		// Token: 0x04003152 RID: 12626
		public OpticSight OpticSight;

		// Token: 0x04003153 RID: 12627
		public bool IgnoreOpticsForCameraPlane;
	}

	// Token: 0x02000846 RID: 2118
	[Serializable]
	public struct DistaneAngle
	{
		// Token: 0x04003154 RID: 12628
		public float Distance;

		// Token: 0x04003155 RID: 12629
		public float Angle;
	}
}
