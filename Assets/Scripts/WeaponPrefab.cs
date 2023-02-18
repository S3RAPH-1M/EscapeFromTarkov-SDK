using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using EFT;
using EFT.AssetsManager;
using EFT.InventoryLogic;
using EFT.Visual;
using JetBrains.Annotations;
using UnityEngine;

// Token: 0x020005B6 RID: 1462
[DisallowMultipleComponent]
public class WeaponPrefab : AssetPoolObject
{
	// Token: 0x040021AE RID: 8622
	public const string BONE_ALT_GRIP = "altpose";

	// Token: 0x040021AF RID: 8623
	public const string BONE_SMOKEPORT = "smokeport";

	// Token: 0x040021B0 RID: 8624
	public const string BONE_FIREPORT = "fireport";

	// Token: 0x040021B1 RID: 8625
	public const string EXTRACTOR_GO_NAME = "extractor_smoke";

	// Token: 0x040021B2 RID: 8626
	private const string string_0 = "HIDE_SHADOW";

	// Token: 0x040021B3 RID: 8627
	[SerializeField]
	public GameObject _weaponObject;

	// Token: 0x040021B4 RID: 8628
	[SerializeField]
	public GameObject _weaponObjectSimple;

	// Token: 0x040021B5 RID: 8629
	[SerializeField]
	public RuntimeAnimatorController _originalAnimatorController;

	// Token: 0x040021B6 RID: 8630
	[SerializeField]
	public RuntimeAnimatorController _animatorSimple;

	// Token: 0x040021B7 RID: 8631
	[SerializeField]
	public RuntimeAnimatorController _animatorSpirit;

	// Token: 0x040021B8 RID: 8632
	[SerializeField]
	public TextAsset _fastAnimatorControllerBinaryData;

	// Token: 0x040021B9 RID: 8633
	[SerializeField]
	private Avatar _avatar;

	// Token: 0x04002363 RID: 9059
	[SerializeField]
	public RestSettings RestSettings;

	// Token: 0x040021BB RID: 8635
	public GameObject DefaultMuzzlePrefab;

	// Token: 0x040021BC RID: 8636
	public GameObject DefaultSmokeport;

	// Token: 0x040021BD RID: 8637
	public GameObject DefaultHeatHazeEffect;

	// Token: 0x040021BE RID: 8638
	public Vector3 RecoilCenter;

	// Token: 0x040021BF RID: 8639
	public Vector3 RotationCenter;

	// Token: 0x040021C0 RID: 8640
	public Vector3 RotationCenterNoStock;

	// Token: 0x040021C1 RID: 8641
	public Vector2 DupletAccuracyPenaltyX;

	// Token: 0x040021C2 RID: 8642
	public Vector2 DupletAccuracyPenaltyY;

	public WeaponPrefab.AimPlane FarPlane = new WeaponPrefab.AimPlane
	{
		Name = "farplane",
		Depth = 0.5f
	};

	// Token: 0x0400236D RID: 9069
	public WeaponPrefab.AimPlane DefaultAimPlane = new WeaponPrefab.AimPlane
	{
		Name = "default",
		Depth = 0f
	};

	// Token: 0x0400236E RID: 9070
	public WeaponPrefab.AimPlane[] CustomAimPlanes;

	// Token: 0x040021C6 RID: 8646
	[SerializeField]
	public GameObject _objectInstance;

	// Token: 0x040021C7 RID: 8647
	[SerializeField]
	private Transform _localWeaponRoot;

	// Token: 0x040021C8 RID: 8648
	private Player player_0;

	// Token: 0x040021C9 RID: 8649
	private Animator animator_0;

	// Token: 0x040021CC RID: 8652
	private Vector3 vector3_0;

	// Token: 0x040021D2 RID: 8658
	private Quaternion quaternion_0;

	// Token: 0x040021D3 RID: 8659
	private Vector3 vector3_1;

	// Token: 0x040021D4 RID: 8660
	private bool bool_3;

	// Token: 0x040021D5 RID: 8661
	private bool bool_4;

	// Token: 0x040021D6 RID: 8662
	private float float_0;

	// Token: 0x040021D7 RID: 8663
	private List<HotObject> list_0 = new List<HotObject>();

	// Token: 0x040021D8 RID: 8664
	private List<Material> list_1 = new List<Material>();

	// Token: 0x040021DA RID: 8666
	private float float_1 = -1f;

	// Token: 0x040021DB RID: 8667
	[Header("Extractor params")]
	public string[] RemoveChildrenOf;

	// Token: 0x040021DC RID: 8668
	public string[] AnimatedBones;

	// Token: 0x04002386 RID: 9094
	public TransformLinks Hierarchy;

	// Token: 0x040021DD RID: 8669
	public int[] LayersDefaultStates;

	// Token: 0x04002389 RID: 9097
	public WeaponPrefab.MaterialConfig[] MaterialsConfig = Array.Empty<WeaponPrefab.MaterialConfig>();

	// Token: 0x0400238A RID: 9098
	[Header("Extractor params for LODs")]
	public WeaponPrefab.LODConfig[] LodsConfig = Array.Empty<WeaponPrefab.LODConfig>();

	// Token: 0x0200061A RID: 1562
	[Serializable]
	public class AimPlane
	{
		// Token: 0x0400238B RID: 9099
		public string Name;

		// Token: 0x0400238C RID: 9100
		public float Depth;
	}

	// Token: 0x0200061B RID: 1563
	[Serializable]
	public class MaterialConfig
	{
		// Token: 0x0400238D RID: 9101
		public string renderer;

		// Token: 0x0400238E RID: 9102
		public Material material;
	}

	// Token: 0x0200061C RID: 1564
	[Serializable]
	public class LODConfig
	{
		// Token: 0x0400238F RID: 9103
		public float screenRelativeTransitionHeight;

		// Token: 0x04002390 RID: 9104
		public float fadeTransitionWidth;

		// Token: 0x04002391 RID: 9105
		public string[] renderers = Array.Empty<string>();
	}
}
