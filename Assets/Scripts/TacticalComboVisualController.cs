using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using EFT;
using EFT.InventoryLogic;
using UnityEngine;

// Token: 0x0200070D RID: 1805
public class TacticalComboVisualController : MonoBehaviour
{
	// Token: 0x04002833 RID: 10291
	public const string DISABLED_TRANSFORM_NAME = "mode_000";

	// Token: 0x04002834 RID: 10292
	public const string LIGHT_BEAM_TRANSFORM_NAME = "mode_";

	// Token: 0x04002835 RID: 10293
	private readonly List<Transform> list_0 = new List<Transform>();

	// Token: 0x04002836 RID: 10294
	public LightComponent LightMod;

	// Token: 0x04002837 RID: 10295
	private Transform transform_0;

	// Token: 0x04002838 RID: 10296
	[SerializeField]
	private float _shadowNearPlaneShift = 0.05f;

	// Token: 0x04002839 RID: 10297
	private Light[] light_0;

	// Token: 0x0400283A RID: 10298
	private LaserBeam[] laserBeam_0;

	// Token: 0x0200070E RID: 1806
	[CompilerGenerated]
	[Serializable]
	public sealed class Class376
	{
		// Token: 0x0400283B RID: 10299
		public static readonly TacticalComboVisualController.Class376 class376_0 = new TacticalComboVisualController.Class376();

		// Token: 0x0400283C RID: 10300
		public static Predicate<Transform> predicate_0;
	}
}
