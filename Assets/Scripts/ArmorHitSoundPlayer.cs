using EFT;
using EFT.CameraControl;
using UnityEngine;

public class ArmorHitSoundPlayer : BulletSoundPlayer
{
	[SerializeField]
	private AudioClip[] _fpSounds;

	[SerializeField]
	private SoundBank _closeDistandeSound;

	private PlayerCameraController playerCameraController_0;
}
