using System;
using System.Collections;
using System.Runtime.CompilerServices;
using EFT.Animations;
using EFT.InventoryLogic;
using UnityEngine;
using UnityEngine.Serialization;

namespace EFT.Interactive
{
	// Token: 0x0200223C RID: 8764
	public class StationaryWeapon : InteractableObject
	{
		// Token: 0x0400ADAE RID: 44462
		[SerializeField]
		private string _id;

		// Token: 0x0400ADAF RID: 44463
		[SerializeField]
		private GameObject[] _gameObjectsWithRenderers;

		// Token: 0x0400ADB0 RID: 44464
		[SerializeField]
		[FormerlySerializedAs("BeltPivotChamber")]
		private Transform _beltPivotChamber;

		// Token: 0x0400ADB1 RID: 44465
		[SerializeField]
		[FormerlySerializedAs("BetlPivotMagazine")]
		private Transform _beltPivotMagazine;

		// Token: 0x0400ADB2 RID: 44466
		[SerializeField]
		private Transform _beltEmptyPivotChamber;

		// Token: 0x0400ADB3 RID: 44467
		[SerializeField]
		private Vector2 _initialOrientation;

		// Token: 0x0400ADB4 RID: 44468
		[SerializeField]
		private Vector2 _pitchLimit;

		// Token: 0x0400ADB5 RID: 44469
		[SerializeField]
		private Vector2 _yawLimit;

		// Token: 0x0400ADB6 RID: 44470
		[SerializeField]
		private MagVisualController _magController;

		// Token: 0x0400ADB7 RID: 44471
		[SerializeField]
		private Transform _debugViews;

		// Token: 0x0400ADB8 RID: 44472
		[SerializeField]
		private Transform _collidersToCut;

		// Token: 0x0400ADB9 RID: 44473
		public string Template;

		// Token: 0x0400ADBA RID: 44474
		public StationaryWeapon.EStationaryAnimationType Animation;

		// Token: 0x0400ADBB RID: 44475
		public Transform OperatorTransform;

		// Token: 0x0400ADBC RID: 44476
		public Transform Hinge;

		// Token: 0x0400ADBD RID: 44477
		public Transform TripodView;

		// Token: 0x0400ADBE RID: 44478
		public Transform TripodAnchor;

		// Token: 0x0400ADBF RID: 44479
		public Transform WeaponTransform;

		// Token: 0x0400ADC0 RID: 44480
		public float PitchToleranceUp;

		// Token: 0x0400ADC1 RID: 44481
		public float PitchToleranceDown;

		// Token: 0x0400ADC2 RID: 44482
		public float YawTolerance;

		// Token: 0x0400ADC4 RID: 44484
		public WeaponMachinery Machinery;

		// Token: 0x0400ADC5 RID: 44485
		public MgBelt Belt;

		// Token: 0x0400ADC6 RID: 44486
		public MgBelt BeltEmpty;

		// Token: 0x0400ADC7 RID: 44487
		private Coroutine coroutine_0;

		// Token: 0x0400ADC8 RID: 44488
		private Transform transform_0;

		// Token: 0x0400ADC9 RID: 44489
		[SerializeField]
		private FollowerCullingObject _cullingObject;

		// Token: 0x0400ADCA RID: 44490
		private string string_0;

		// Token: 0x0400ADCB RID: 44491
		private Vector3 vector3_0;

		// Token: 0x0400ADCC RID: 44492
		private Quaternion quaternion_0;

		// Token: 0x0400ADCD RID: 44493
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x0200223D RID: 8765
		public enum EStationaryAnimationType
		{
			// Token: 0x0400ADCF RID: 44495
			UtesSit,
			// Token: 0x0400ADD0 RID: 44496
			UtesStand,
			// Token: 0x0400ADD1 RID: 44497
			AGS_17
		}
	}
}