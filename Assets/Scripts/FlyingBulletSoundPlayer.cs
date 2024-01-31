using System;
using System.Collections;
using System.Collections.Generic;
using EFT;
using EFT.Ballistics;
using EFT.CameraControl;
using UnityEngine;

public class FlyingBulletSoundPlayer : BulletSoundPlayer
{
	[SerializeField]
	private AudioClip[] _sources;

	[GAttribute6(0f, 10f, -1f)]
	[SerializeField]
	private Vector2 _minMaxRadius = new Vector2(0f, 10f);

	[SerializeField]
	private AnimationCurve _vignette;

	[SerializeField]
	private float _vignetteTime = 0.4f;

	[SerializeField]
	private float _vignetteDelta = 0.2f;

	private List<BallisticsCalculator> list_0;

	private Dictionary<string, int> dictionary_0;

	private string[] string_0 = new string[20];

	private int int_0;

	private PrismEffects prismEffects_0;

	private float float_0 = 0.4f;

	private IEnumerator ienumerator_0;

	private Player player_0;

	private Coroutine coroutine_0;

	private float float_1;
}
