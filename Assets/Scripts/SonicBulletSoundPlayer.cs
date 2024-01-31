using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SonicBulletSoundPlayer : BulletSoundPlayer
{
	public enum SonicType
	{
		Sonic9 = 0,
		Sonic545 = 1,
		Sonic762 = 2,
		SonicShotgun = 3
	}

	public class GClass718
	{
		public BulletClass Ammo;

		public Vector3 ShotPosition;

		public Vector3 ShotDirection;

		public Camera Camera;

		public float Rolloff;

		public float Delay;

		public bool IsOccluded;

		public GClass718(BulletClass ammo, Vector3 shotPosition, Vector3 shotDirection, Camera camera, float rolloff, float delay, bool isOccluded)
		{
			Ammo = ammo;
			ShotPosition = shotPosition;
			ShotDirection = shotDirection;
			Camera = camera;
			Rolloff = rolloff;
			Delay = delay;
			IsOccluded = isOccluded;
		}
	}

	[Serializable]
	public class SonicAudio
	{
		public SonicType Type;

		public AudioClip Clip;
	}

	private readonly float float_0 = 340.29f;

	[SerializeField]
	private List<SonicAudio> _sources;

	[SerializeField]
	private AnimationCurve _soundCurve;

	[SerializeField]
	private float _minDistance = 1.5f;
}
