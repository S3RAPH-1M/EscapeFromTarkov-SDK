using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AnimationEventSystem;
using EFT;
using EFT.AssetsManager;
using EFT.InventoryLogic;
using EFT.Visual;
using JetBrains.Annotations;
using UnityEngine;

// Token: 0x02000664 RID: 1636
[DisallowMultipleComponent]
public class WeaponPrefab : AssetPoolObject
{

	// Token: 0x040024FA RID: 9466
	public const string BONE_ALT_GRIP = "altpose";

	// Token: 0x040024FB RID: 9467
	public const string BONE_SMOKEPORT = "smokeport";

	// Token: 0x040024FC RID: 9468
	public const string BONE_FIREPORT = "fireport";

	// Token: 0x040024FD RID: 9469
	public const string EXTRACTOR_GO_NAME = "extractor_smoke";

	// Token: 0x040024FE RID: 9470
	private const string string_0 = "HIDE_SHADOW";

	// Token: 0x040024FF RID: 9471
	[SerializeField]
	public GameObject _weaponObject;

	// Token: 0x04002500 RID: 9472
	[SerializeField]
	public GameObject _weaponObjectSimple;

	// Token: 0x04002501 RID: 9473
	[SerializeField]
	public RuntimeAnimatorController _originalAnimatorController;

	// Token: 0x04002502 RID: 9474
	[SerializeField]
	public RuntimeAnimatorController _animatorSimple;

	// Token: 0x04002503 RID: 9475
	[SerializeField]
	public RuntimeAnimatorController _animatorSpirit;

	// Token: 0x04002504 RID: 9476
	[SerializeField]
	public TextAsset _fastAnimatorControllerBinaryData;

	// Token: 0x04002505 RID: 9477
	[SerializeField]
	private Avatar _avatar;

	// Token: 0x04002506 RID: 9478
	[SerializeField]
	public RestSettings RestSettings;

	// Token: 0x04002507 RID: 9479
	public GameObject DefaultMuzzlePrefab;

	// Token: 0x04002508 RID: 9480
	public GameObject DefaultSmokeport;

	// Token: 0x04002509 RID: 9481
	public GameObject DefaultHeatHazeEffect;

	// Token: 0x0400250A RID: 9482
	public Vector3 RecoilCenter;

	// Token: 0x0400250B RID: 9483
	public Vector3 RotationCenter;

	// Token: 0x0400250C RID: 9484
	public Vector3 RotationCenterNoStock;

	// Token: 0x0400250D RID: 9485
	public Vector2 DupletAccuracyPenaltyX;

	// Token: 0x0400250E RID: 9486
	public Vector2 DupletAccuracyPenaltyY;

	// Token: 0x0400250F RID: 9487
	public WeaponPrefab.AimPlane FarPlane = new WeaponPrefab.AimPlane
	{
		Name = "farplane",
		Depth = 0.5f
	};

	// Token: 0x04002510 RID: 9488
	public WeaponPrefab.AimPlane DefaultAimPlane = new WeaponPrefab.AimPlane
	{
		Name = "default",
		Depth = 0f
	};

	// Token: 0x04002511 RID: 9489
	public WeaponPrefab.AimPlane[] CustomAimPlanes;

	// Token: 0x04002512 RID: 9490
	[SerializeField]
	public GameObject _objectInstance;

	// Token: 0x04002513 RID: 9491
	[SerializeField]
	private Transform _localWeaponRoot;

	// Token: 0x04002517 RID: 9495
	private FirearmsAnimator firearmsAnimator_0;

	// Token: 0x04002519 RID: 9497
	private AnimationEventsEmitter animationEventsEmitter_0;

	// Token: 0x0400251C RID: 9500
	private Vector3 vector3_0;

	// Token: 0x0400251D RID: 9501
	private Quaternion quaternion_0;

	// Token: 0x0400251E RID: 9502
	private Vector3 vector3_1;

	// Token: 0x0400251F RID: 9503
	private bool bool_3;

	// Token: 0x04002520 RID: 9504
	private bool bool_4;

	// Token: 0x04002521 RID: 9505
	private float float_0;

	// Token: 0x04002522 RID: 9506
	private List<HotObject> list_0 = new List<HotObject>();

	// Token: 0x04002523 RID: 9507
	private List<Material> list_1 = new List<Material>();

	// Token: 0x04002524 RID: 9508
	private GunShadowDisabler[] gunShadowDisabler_0 = Array.Empty<GunShadowDisabler>();

	// Token: 0x04002525 RID: 9509
	private float float_1 = -1f;

	// Token: 0x04002526 RID: 9510
	private Animator animator_0;

	// Token: 0x04002527 RID: 9511
	[Header("Extractor params")]
	public string[] RemoveChildrenOf;

	// Token: 0x04002528 RID: 9512
	public string[] AnimatedBones;

	// Token: 0x04002529 RID: 9513
	public TransformLinks Hierarchy;

	// Token: 0x0400252B RID: 9515
	public int[] LayersDefaultStates;

	// Token: 0x0400252C RID: 9516
	public WeaponPrefab.MaterialConfig[] MaterialsConfig = Array.Empty<WeaponPrefab.MaterialConfig>();

	// Token: 0x0400252D RID: 9517
	[Header("Extractor params for LODs")]
	public WeaponPrefab.LODConfig[] LodsConfig = Array.Empty<WeaponPrefab.LODConfig>();

	// Token: 0x0400252E RID: 9518
	private Renderer[] renderer_0;

	// Token: 0x0400252F RID: 9519
	private List<Mod> list_2 = new List<Mod>();

	// Token: 0x02000665 RID: 1637
	[Serializable]
	public class AimPlane
	{
		// Token: 0x04002530 RID: 9520
		public string Name;

		// Token: 0x04002531 RID: 9521
		public float Depth;
	}

	// Token: 0x02000666 RID: 1638
	[Serializable]
	public class MaterialConfig
	{
		// Token: 0x04002532 RID: 9522
		public string renderer;

		// Token: 0x04002533 RID: 9523
		public Material material;
	}

	// Token: 0x02000667 RID: 1639
	[Serializable]
	public class LODConfig
	{
		// Token: 0x04002534 RID: 9524
		public float screenRelativeTransitionHeight;

		// Token: 0x04002535 RID: 9525
		public float fadeTransitionWidth;

		// Token: 0x04002536 RID: 9526
		public string[] renderers = Array.Empty<string>();
	}
}
